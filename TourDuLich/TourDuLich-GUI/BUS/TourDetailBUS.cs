using DevExpress.Office;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;
using Destination = TourDuLich_GUI.Models.Destination;

namespace TourDuLich_GUI.BUS
{
    public class TourDetailBUS
    {

        TourContext _ctx = new TourContext();

        public async Task<List<TourDetail>> GetAll()
        {

            List<TourDetail> result = await _ctx.Set<TourDetail>().ToListAsync();

            return result;
        }
        public async Task<TourDetail> GetOne(int id)
        {

            TourDetail result = await _ctx.Set<TourDetail>()
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }
        public void AddDestinationToTourDetail(Tour tour, Destination destination)
        {
            int lastOrderValue = 0;
            if (tour.TourDetails != null && tour.TourDetails.Count > 0)
            {
                lastOrderValue = tour.TourDetails.Last().Order; // Get value order of LastTourDetail
            }

            Console.WriteLine("Value Order : " + lastOrderValue + "COunt tourDetail : " + lastOrderValue);
            TourDetail tourDetail = new TourDetail() 
            {
                TourID = tour.ID,
                Order = lastOrderValue + 1,
                DestinationID = destination.ID
            };

            CreateOne(tourDetail);

        }
    /*    private int GetLastValueOfOrder()
        {

        }*/
        public void CreateOne(TourDetail item)
        {
            _ctx.TourDetail.Add(item);

            _ctx.SaveChanges();

            return;
        }
    }
}
