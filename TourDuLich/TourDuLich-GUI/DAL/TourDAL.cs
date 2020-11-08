using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL {
    public class TourDAL {
        static TourContext _ctx = new TourContext();

        public static List<Tour> GetAll() {
            List<Tour> result = _ctx.Set<Tour>().ToList();
            return result;
        }

        public static Tour GetOne(int id) {
            Tour result = _ctx.Set<Tour>()
                .Include(o => o.TourType)
                .Include(o => o.TourPrices)
                .Include(o => o.TourDetails)
                .FirstOrDefault(o => o.ID == id);

            if (result == null) {
                return null;
            }

            if (result.TourPrices != null & result.TourPrices.Count > 0) {
                result.TourPrices = result.TourPrices.OrderBy(o => o.TimeStart).ToList();
            }
            if (result.TourDetails != null & result.TourDetails.Count > 0) {
                result.TourDetails = result.TourDetails.OrderBy(o => o.Order).ToList();
            }

            return result;
        }

        public static Tour CreateOne(Tour item) {
            // This "item" is unattached => ATTACH!
            _ctx.Entry(item).State = EntityState.Added;

            _ctx.SaveChanges();

            return item;
        }

        public static void UpdateOne(Tour item) {
            // as "item" is loaded from a DataSource/BindingList, it is ALREADY ATTACHED => Must detach TourPrices before deleting/adding
            _ctx.Entry(item).State = EntityState.Modified;    
            Console.WriteLine("Original item : " + _ctx.TourDetails.Where(o => o.TourID == item.ID).ToList().Count);// Context
            Console.WriteLine("Updated item : " + item.TourDetails.Count);// Instance

            // TourPrices
            List<TourPrice> tourPrices = item.TourPrices.ToList();
            List<TourPrice> ogTourPrices = _ctx.TourPrices.Where(o => o.TourID == item.ID).ToList();

            foreach (TourPrice ogTourPrice in ogTourPrices)
            {
                if (tourPrices.FirstOrDefault(o => o.ID == ogTourPrice.ID) == null )
                {
                    _ctx.Entry(ogTourPrice).State = EntityState.Deleted;
                }
            }

            foreach (TourPrice tourPrice in tourPrices)
            {
                if( ogTourPrices.FirstOrDefault(o => o.ID == tourPrice.ID) == null)
                {
                    _ctx.Entry(tourPrice).State = EntityState.Added;
                }
                else
                {
                    _ctx.Entry(tourPrice).State = EntityState.Modified;
                }
            }

            // TourDetails
            List<TourDetail> tourDetails = item.TourDetails.ToList();
            List<TourDetail> ogTourDetails = _ctx.TourDetails.Where(o => o.TourID == item.ID).ToList();

            foreach (TourDetail ogTourDetail in ogTourDetails)
            {
                if (tourDetails.FirstOrDefault(o => o.ID == ogTourDetail.ID) == null)
                {
                    _ctx.Entry(ogTourDetail).State = EntityState.Deleted;
                }
            }

            foreach (TourDetail tourDetail in tourDetails)
            {
                if (ogTourDetails.FirstOrDefault(o => o.ID == tourDetail.ID) == null)
                {
                    _ctx.Entry(tourDetail).State = EntityState.Added;
                }
                else
                {
                    _ctx.Entry(tourDetail).State = EntityState.Modified;
                }
            }

            _ctx.SaveChanges();
            return;
        }

        public static void DeleteOne(int id) {

            Tour tour = _ctx.Set<Tour>().Include(o => o.TourPrices).First(o => o.ID == id);
            //Delete all tour detail of tour
            _ctx.TourDetails.RemoveRange(tour.TourDetails);
            //Delete all tour group of tour
            List<TourGroup> tourGroups = tour.TourGroups.ToList();
            foreach (TourGroup tourGroup in tourGroups)
            {
                //Delete reference
                _ctx.TourGroupCosts.RemoveRange(tourGroup.TourGroupCosts);
                _ctx.TourGroupDetails.RemoveRange(tourGroup.TourGroupDetails);
                _ctx.TourGroupStaffs.RemoveRange(tourGroup.TourGroupStaffs);
                _ctx.TourGroups.Remove(tourGroup);

            }

            _ctx.Tours.Remove(tour);
            /*_ctx.Entry(tour).State = EntityState.Deleted;
*/
            _ctx.SaveChanges();
        }

        public static TourDetail CreateTourDetail(Tour tour, int order, int destinationId)
        {
            // Destination is fetched from ANOTHER Context instance => Make a copy
            Destination newDestination = _ctx.Destinations.First(o => o.ID == destinationId);

            return new TourDetail()
            {
                Tour = tour,
                Order = order,
                Destination = newDestination,
                DestinationID = destinationId
            };
        }

        public static TourPrice GetTourPriceOnDate(int tourId, DateTime startDate)
        {
            var tourPrice = _ctx.TourPrices
                .FirstOrDefault(tp => tp.TourID == tourId
                              && DbFunctions.TruncateTime(tp.TimeStart) <= startDate.Date
                              && startDate.Date <= DbFunctions.TruncateTime(tp.TimeEnd));

            return tourPrice;
        }

        public static void RevertChanges(Tour tour)
        {
            _ctx.Entry(tour).State = EntityState.Unchanged;
        }
    }
}
