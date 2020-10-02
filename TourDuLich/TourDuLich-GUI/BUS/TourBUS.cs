using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{
    public class TourBUS
    {
        public static async Task<BindingList<Tour>> GetAll()
        {
            var ctx = new TourContext();

            BindingList<Tour> result = new BindingList<Tour>();
            DbSet<Tour> query = ctx.Tours;
            await query.LoadAsync().ContinueWith(loadTask =>
                {
                    result = ctx.Tours.Local.ToBindingList();
                }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            return result;
        }
    }
}
