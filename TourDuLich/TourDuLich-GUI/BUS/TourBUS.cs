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

            if (result == null)
            {
                return null;
            }

            if (result.TourPrices != null & result.TourPrices.Count > 0)
            {
                result.TourPrices = result.TourPrices.OrderBy(o => o.TimeStart).ToList();
            }
            if (result.TourPrices != null & result.TourPrices.Count > 0)
            {
                result.TourDetails = result.TourDetails.OrderBy(o => o.Order).ToList();
            }

            return result;
        }

        public void CreateOne(Tour item)
        {
            ValidateOne(item);

            // This "item" is unattached => ATTACH!
            _ctx.Entry(item).State = EntityState.Added;

            _ctx.SaveChanges();

            return;
        }

        public void UpdateOne(Tour item)
        {
            ValidateOne(item);

            // as "item" is loaded from a DataSource/BindingList, it is ALREADY ATTACHED => Must detach TourPrices before deleting/adding

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

        public bool ValidateOne(Tour item)
        {
            List<TourPrice> tourPrices = item.TourPrices.ToList();

            for (int i = 0; i < tourPrices.Count; i++)
            {
                // Check Valid TimeStart < TimeEnd
                if (!(tourPrices[i].TimeStart < tourPrices[i].TimeEnd))
                {
                    throw new Exception("Khoảng thời gian không hợp lệ (Ngày bắt đầu phải trước Ngày kết thúc)");
                }

                for (int j = i+1; j < tourPrices.Count - 1; j++)
                {
                    // Check non-intersect: (A1>B2) || (B1>A2); assumes A1<A2,B1<B2
                    if (!(tourPrices[i].TimeStart >= tourPrices[j].TimeEnd || tourPrices[j].TimeStart >= tourPrices[i].TimeEnd)) {
                        Console.WriteLine("i: " + tourPrices[i].ID + "j: " + tourPrices[j].ID);
                        throw new Exception("Tồn tại khoảng thời gian trùng trong bảng giá");
                    }
                }
            }

            return true;
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

            int i = 1;
            foreach( TourDetail t in tour.TourDetails)
            {
                t.Order = i;
                i++;
                Console.WriteLine("Order value : " + t.Order);
            }
            // TODO: Update Order
        }

        public void SortTourDetails()
        {

        }
    }
}
