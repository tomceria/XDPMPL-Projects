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
                /*List<Tour> = */

            Console.WriteLine("Count: " + result.Count);

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
            using var dbContextTransaction = _ctx.Database.BeginTransaction();


            List<TourPrice> tourPrices = item.TourPrices.ToList();

            _ctx.Entry(item).State = EntityState.Modified;
            foreach (TourPrice tP in tourPrices)
            {
                _ctx.Entry(tP).State = EntityState.Detached;
            }
            item.TourPrices.Clear();
            _ctx.TourPrices.RemoveRange(_ctx.TourPrices.Where(o => o.TourID == item.ID));
            _ctx.SaveChanges();
            foreach (TourPrice tP in tourPrices)
            {
                _ctx.Entry(tP).State = EntityState.Added;
                _ctx.SaveChanges();
            }
            _ctx.SaveChanges();

            dbContextTransaction.Commit();
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
    }
}
