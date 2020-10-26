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
            ValidateOne(item);

            // This "item" is unattached => ATTACH!
            _ctx.Entry(item).State = EntityState.Added;

            _ctx.SaveChanges();

            return item;
        }

        public static void UpdateOne(Tour item) {
            ValidateOne(item);

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

        public static void DeleteOne(Tour item) {
            Tour tour = _ctx.Set<Tour>().Include(o => o.TourPrices).First(o => o.ID == item.ID);
            _ctx.Tours.Remove(tour);
            /*_ctx.Entry(tour).State = EntityState.Deleted;
*/
            _ctx.SaveChanges();

        }

        public static bool ValidateOne(Tour item) {
            // Sanitize => update item
            SanitizeTimeOfTourPrices(item.TourPrices);
            // End Sanitize

            List<TourPrice> tourPrices = item.TourPrices.ToList();

            for (int i = 0; i < tourPrices.Count - 1; i++) {
                // Check Valid TimeStart < TimeEnd
                if (!(tourPrices[i].TimeStart < tourPrices[i].TimeEnd)) {
                    throw new Exception("Khoảng thời gian không hợp lệ (Ngày bắt đầu phải trước Ngày kết thúc)");
                }

                for (int j = i + 1; j < tourPrices.Count; j++) {
                    // Check non-intersect: (A1>B2) || (B1>A2); assumes A1<A2,B1<B2
                    if (!(tourPrices[i].TimeStart >= tourPrices[j].TimeEnd || tourPrices[j].TimeStart >= tourPrices[i].TimeEnd)) {
                        throw new Exception("Tồn tại khoảng thời gian trùng trong bảng giá");
                    }
                }
            }

            return true;
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

        public static void SanitizeTimeOfTourPrices(ICollection<TourPrice> tourPrices) {
            foreach (TourPrice tourPrice in tourPrices) {
                tourPrice.TimeStart = new DateTime(tourPrice.TimeStart.Year, tourPrice.TimeStart.Month, tourPrice.TimeStart.Day, 0, 0, 0);
                tourPrice.TimeEnd = new DateTime(tourPrice.TimeEnd.Year, tourPrice.TimeEnd.Month, tourPrice.TimeEnd.Day, 23, 59, 59);
            }
        }

        public static TourPrice GetTourPriceOnDate(int tourId, DateTime startDate)
        {
            var tourPrice = _ctx.TourPrices.Where(tp => tp.TourID == tourId
                && DbFunctions.TruncateTime(tp.TimeStart) <= startDate.Date
                && startDate.Date <= DbFunctions.TruncateTime(tp.TimeEnd))
                .FirstOrDefault();

            return tourPrice;
        }
    }
}
