using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{
    public class TourBUS
    {
        TourContext _ctx = new TourContext();
        
        public async Task<List<Tour>> GetAll()
        {
            List<Tour> result = await _ctx.Set<Tour>().ToListAsync();
            return result;
        }
        public async Task<Tour> GetOne(int id)
        {
            Tour result = await _ctx.Set<Tour>()
                .Include(o => o.TourType)
                .Include(o => o.TourPrices)
                .Include(o => o.TourDetails)
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }

        public void CreateOne(Tour item)
        {

            _ctx.Tours.Add(item);

            _ctx.SaveChanges();

            return;
        }

        public void UpdateOne(Tour item)
        {
            // as "item" is loaded from a DataSource/BindingList, it is ALREADY DETACHED => Must detach TourPrices before deleting/adding

            _ctx.Entry(item).State = EntityState.Modified;

            // TourPrices
            List<TourPrice> tourPrices = item.TourPrices.ToList();

            foreach (TourPrice tP in tourPrices)
            {
                _ctx.Entry(tP).State = EntityState.Detached;
            }
            item.TourPrices.Clear();
            _ctx.TourPrices.RemoveRange(_ctx.TourPrices.Where(o => o.TourID == item.ID));
            foreach (TourPrice tP in tourPrices)
            {
                _ctx.Entry(tP).State = EntityState.Added;
            }

            // TourDetails
            List<TourDetail> tourDetails = item.TourDetails.ToList();
            foreach (TourDetail tP in tourDetails)
            {
                _ctx.Entry(tP).State = EntityState.Detached;
            }
            item.TourDetails.Clear();
            _ctx.TourDetails.RemoveRange(_ctx.TourDetails.Where(o => o.TourID == item.ID));
            foreach (TourDetail tP in tourDetails)
            {
                _ctx.Entry(tP).State = EntityState.Added;
            }

            _ctx.SaveChanges();
            return;
        }

        public void DeleteOne(Tour item)
        {
            Tour tour = _ctx.Set<Tour>().Include(o => o.TourPrices).First(o => o.ID == item.ID);
            _ctx.Tours.Remove(tour);
            /*_ctx.Entry(tour).State = EntityState.Deleted;
*/
            _ctx.SaveChanges();

        }

        public void CreateTourPriceForTour(Tour item)
        {
            TourPrice tourPrice = new TourPrice(item);
            item.TourPrices.Add(tourPrice);
        }

        public void DeleteTourPriceFromTour(TourPrice tourPrice)
        {
            Tour tour = tourPrice.Tour;
            tour.TourPrices.Remove(tourPrice);
        }

        public void AddTourDetailToTour(Tour tour, Destination destination)
        {
            // Destination is fetched from ANOTHER Context instance => Make a copy
            Destination newDestination = _ctx.Destinations.First(o => o.ID == destination.ID);

            int lastOrderValue = 0;
            if (tour.TourDetails != null && tour.TourDetails.Count > 0)
            {
                lastOrderValue = tour.TourDetails.Last().Order; // Get value order of LastTourDetail
            }

            Console.WriteLine("Value Order : " + lastOrderValue + "COunt tourDetail : " + lastOrderValue);
            TourDetail tourDetail = new TourDetail() 
            {
                Tour = tour,
                Order = lastOrderValue + 1,
                Destination = newDestination
            };

            tour.TourDetails.Add(tourDetail);
        }

        public void DeleteTourDetailFromTour(TourDetail tourDetail)
        {
            Tour tour = tourDetail.Tour;
            tour.TourDetails.Remove(tourDetail);

            // TODO: Update Order
        }
    }
}
