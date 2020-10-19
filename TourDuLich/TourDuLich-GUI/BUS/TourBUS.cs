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

namespace TourDuLich_GUI.BUS {
    public class TourBUS {
        TourContext _ctx = new TourContext();

        public async Task<List<Tour>> GetAll() {
            List<Tour> result = await _ctx.Set<Tour>().ToListAsync();
            return result;
        }
        public async Task<Tour> GetOne(int id) {
            Tour result = await _ctx.Set<Tour>()
                .Include(o => o.TourType)
                .Include(o => o.TourPrices)
                .Include(o => o.TourDetails)
                .FirstOrDefaultAsync(o => o.ID == id);

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

        public void CreateOne(Tour item) {
            ValidateOne(item);

            // This "item" is unattached => ATTACH!
            _ctx.Entry(item).State = EntityState.Added;

            _ctx.SaveChanges();

            return;
        }

        public void UpdateOne(Tour item) {
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

        public void DeleteOne(Tour item) {
            Tour tour = _ctx.Set<Tour>().Include(o => o.TourPrices).First(o => o.ID == item.ID);
            _ctx.Tours.Remove(tour);
            /*_ctx.Entry(tour).State = EntityState.Deleted;
*/
            _ctx.SaveChanges();

        }

        public bool ValidateOne(Tour item) {
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

        public void SanitizeTimeOfTourPrices(ICollection<TourPrice> tourPrices) {
            foreach (TourPrice tourPrice in tourPrices) {
                tourPrice.TimeStart = new DateTime(tourPrice.TimeStart.Year, tourPrice.TimeStart.Month, tourPrice.TimeStart.Day, 0, 0, 0);
                tourPrice.TimeEnd = new DateTime(tourPrice.TimeEnd.Year, tourPrice.TimeEnd.Month, tourPrice.TimeEnd.Day, 23, 59, 59);
            }
        }

        public void CreateTourPriceForTour(Tour item) {
            TourPrice tourPrice = new TourPrice(item);
            item.TourPrices.Add(tourPrice);
        }

        public void DeleteTourPriceFromTour(TourPrice tourPrice) {
            Tour tour = tourPrice.Tour;
            tour.TourPrices.Remove(tourPrice);
        }

        public void AddTourDetailToTour(Tour tour, Destination destination) {
            // Destination is fetched from ANOTHER Context instance => Make a copy
            Destination newDestination = _ctx.Destinations.First(o => o.ID == destination.ID);

            int lastOrderValue = 0;
            if (tour.TourDetails != null && tour.TourDetails.Count > 0) {
                lastOrderValue = tour.TourDetails.Last().Order; // Get value order of LastTourDetail
            }

            TourDetail tourDetail = new TourDetail() {
                Tour = tour,
                Order = lastOrderValue + 1,
                Destination = newDestination
            };
            Console.WriteLine("AddTourDetailToTour : Updated length  =  " + tour.TourDetails.Count);
            tour.TourDetails.Add(tourDetail);
        }

        public void DeleteTourDetailFromTour(TourDetail tourDetail) {
            Tour tour = tourDetail.Tour;
            tour.TourDetails.Remove(tourDetail);
            SortTourDetails(tour); // Sort TourDetail
        }

        public void SortTourDetails(Tour tour) {
            int tdIndex = 1;
            foreach (TourDetail t in tour.TourDetails) {
                t.Order = tdIndex;
                tdIndex++;
            }
        }

        public void MoveUpTourDetailOfTour(TourDetail tourDetail) {
            //Skip first element
            if (tourDetail.Order > 1) {
                //Get previous value order of TourDetail
                int previousOrderTourDetail = tourDetail.Order - 1;
                //Because Row Table begin from 0 but Order begin from 1

                //Get tourDetail above current tourDetail
                TourDetail previousTourDetail = tourDetail.Tour.TourDetails.First(o => o.Order == previousOrderTourDetail);

                SwapTourDetail(tourDetail, previousTourDetail);

            }

        }

        public void MoveDownTourDetailOfTour(TourDetail tourDetail)// Current TourDetail
        {
            int lengthTourDetails = tourDetail.Tour.TourDetails.Count;
            //Skip last element
            if (tourDetail.Order < lengthTourDetails) {
                //Get next value order of TourDetail
                int nextOrderOfTourDetail = tourDetail.Order + 1;

                //Get tourDetail below current tourDetail
                TourDetail nextTourDetail = tourDetail.Tour.TourDetails.First(o => o.Order == nextOrderOfTourDetail);
                Console.WriteLine("next value order= " + nextTourDetail.Order + "current value order= " + tourDetail.Order);
                SwapTourDetail(tourDetail, nextTourDetail);

            }
        }

        private void SwapTourDetail(TourDetail tourDetail_1, TourDetail tourDetail_2) {
            int temp_OrderOfTourDetail_1 = tourDetail_1.Order;

            tourDetail_1.Order = tourDetail_2.Order;
            tourDetail_2.Order = temp_OrderOfTourDetail_1;
        }

        /// <summary>
        /// Get tour price on specific date
        /// </summary>
        /// <param name="id">TourID</param>
        /// <param name="startDate">Tour group start date</param>
        /// <returns>Tour price on specific date</returns>
        public long GetPriceOnDate(int id, DateTime startDate) {
            long price = 0;

            var tourPrice = _ctx.TourPrices.Where(tp => tp.TourID == id
                && DbFunctions.TruncateTime(tp.TimeStart) <= startDate.Date
                && startDate.Date <= DbFunctions.TruncateTime(tp.TimeEnd))
                .First();

            if (tourPrice != null) {
                price = tourPrice.Value;
            } else {
                var tour = _ctx.Tours.Find(id);
                price = tour.PriceRef;
            }

            return price;
        }
    }
}
