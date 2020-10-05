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
        public static async Task<List<Tour>> GetAll()
        {
            using var _ctx = new TourContext();

            List<Tour> result = await _ctx.Set<Tour>().ToListAsync();
                /*List<Tour> = */

            Console.WriteLine("Count: " + result.Count);

            return result;
        }
        public static async Task<Tour> GetOne(int id)
        {
            using var _ctx = new TourContext();

            Tour result = await _ctx.Set<Tour>()
                .Include(o => o.TourType)
                .Include(o => o.TourPrices)
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }

        public static void CreateOne(Tour item)
        {
            using var _ctx = new TourContext();

            _ctx.Tours.Add(item);

            _ctx.SaveChanges();

            return;
        }

        public static void UpdateOne(Tour item)
        {
            using var _ctx = new TourContext();

            _ctx.Entry(item).State = EntityState.Modified;
            foreach (TourPrice tP in item.TourPrices)
            {
                _ctx.Entry(tP).State = EntityState.Modified;
            }

            _ctx.SaveChanges();

            return;
        }

      public static  void DeleteOne(Tour item)
        {
            using var _ctx = new TourContext();

            _ctx.Entry(item).State = EntityState.Deleted;

            /*Tour tour = await _ctx.Set<Tour>().Include(o => o.TourPrices).FirstAsync(o => o.ID == item.ID);
            _ctx.Entry(tour).State = EntityState.Deleted;
            */
            _ctx.SaveChanges();

        }
    }
}
