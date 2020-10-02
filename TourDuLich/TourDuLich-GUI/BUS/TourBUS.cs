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
        public static async Task<ObservableCollection<Tour>> GetAll()
        {
            var ctx = new TourContext();

            ObservableCollection<Tour> result = new ObservableCollection<Tour>();
            DbSet<Tour> query = ctx.Tours;
            await query.LoadAsync().ContinueWith(loadTask =>
                {
                    result = ctx.Tours.Local;
                }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            return result;
        }
    }
}
