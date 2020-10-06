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

    /*    private int GetLastValueOfOrder()
        {

        }*/
        public void CreateOne(TourDetail item)
        {
            _ctx.TourDetails.Add(item);

            _ctx.SaveChanges();

            return;
        }
    }
}
