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
            var ctx = new TourContext();

            List<Tour> result = await ctx.Set<Tour>().ToListAsync();

            return result;
        }
        public static async Task<Tour> GetOne(int id)
        {
            var ctx = new TourContext();

            Tour result = await ctx.Set<Tour>()
                .Include(o => o.TourType)
                .FirstOrDefaultAsync(o => o.ID == id);

            return result;
        }

        public static void SaveOne(Tour item)
        {
            var ctx = new TourContext();

            bool doesExist = false;
            if (ctx.Tours.Any(o => o.ID == item.ID))
            {
                doesExist = true;
            }

            switch (doesExist)
            {
                case true:
                    {
                        // Update

                        /*                        var existing = ctx.Set<Tour>().Include(o => o.TourPrices).First(o => o.ID == item.ID);
                                                foreach(TourPrice tP in existing.TourPrices.ToList())
                                                {
                                                    existing.TourPrices.Remove(tP);
                                                }
                                                foreach(TourPrice tP in item.TourPrices.ToList())
                                                {
                                                    tP.TourID = item.ID;
                                                    existing.TourPrices.Add(tP);
                                                    tP.Tour = existing;
                                                    Console.WriteLine("id: " + existing.TourPrices.ElementAt(existing.TourPrices.Count - 1).ID);
                                                    Console.WriteLine("tourid: " + existing.TourPrices.ElementAt(existing.TourPrices.Count - 1).TourID);
                                                }
                        */

                        ctx.Entry(item).State = EntityState.Modified;
                        foreach (TourPrice tP in item.TourPrices)
                        {
                            ctx.Entry(tP).State = EntityState.Modified;
                        }
                        break;
                    }
                case false:
                    {
                        // Add
                        ctx.Tours.Add(item);
                        break;
                    }
            }


            ctx.SaveChanges();

            return;
        }
    }
}
