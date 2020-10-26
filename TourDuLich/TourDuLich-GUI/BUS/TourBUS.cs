using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.Models {
    public partial class Tour
    {
        public static List<Tour> GetAll() {
            return TourDAL.GetAll();
        }

        public static Tour GetOne(int id) {
            return TourDAL.GetOne(id);
        }

        public static void DeleteOne(Tour item) {
            TourDAL.DeleteOne(item);
        }

        public Tour Create()
        {
            return TourDAL.CreateOne(this);
        }

        public void Update()
        {
            TourDAL.UpdateOne(this);
        }

        public void CreateTourPriceForTour() {
            TourPrice tourPrice = new TourPrice(this);
            this.TourPrices.Add(tourPrice);
        }

        public void DeleteTourPriceFromTour(TourPrice tourPrice) {
            Tour tour = tourPrice.Tour;
            tour.TourPrices.Remove(tourPrice);
        }

        public void AddTourDetailToTour(Destination destination) {
            int lastOrderValue = 0;
            if (this.TourDetails != null && this.TourDetails.Count > 0) {
                lastOrderValue = this.TourDetails.Last().Order; // Get value order of LastTourDetail
            }

            TourDetail tourDetail = TourDAL.CreateTourDetail(this, lastOrderValue + 1, destination.ID);
            this.TourDetails.Add(tourDetail);
        }

        public void DeleteTourDetailFromTour(TourDetail tourDetail) {
            Tour tour = tourDetail.Tour;
            tour.TourDetails.Remove(tourDetail);
            SortTourDetails(tour); // Sort TourDetail
        }

        public void MoveUpTourDetailOfTour(TourDetail tourDetail) {
            //Skip first element
            if (tourDetail.Order > 1) {
                //Get previous value order of TourDetail
                int previousOrderTourDetail = tourDetail.Order - 1;
                //Because Row Table begin from 0 but Order begin from 1

                //Get tourDetail above current tourDetail
                TourDetail previousTourDetail = tourDetail.Tour.TourDetails.First(o => o.Order == previousOrderTourDetail);

                Tour.SwapTourDetail(tourDetail, previousTourDetail);

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

        private static void SortTourDetails(Tour tour)
        {
            int tdIndex = 1;
            foreach (TourDetail t in tour.TourDetails)
            {
                t.Order = tdIndex;
                tdIndex++;
            }

        }
        private static void SwapTourDetail(TourDetail tourDetail_1, TourDetail tourDetail_2) {
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
        public static long GetTourPriceOrPriceRef(int tourId, DateTime startDate) {
            long price;

            var tourPrice = TourDAL.GetTourPriceOnDate(tourId, startDate);

            if (tourPrice != null) {
                price = tourPrice.Value;
            } else {
                price = GetOne(tourId).PriceRef;
            }

            return price;
        }
    }
}
