using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.DAL {
    class TourInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TourContext> {
        protected override void Seed(TourContext context) {

/*            var tours = new List<Tour> {
                new Tour { ID = 1, Name = "HCM - Hanoi", PriceRef = 1050, Description = "Hello world" }
            };
            tours.ForEach(s => context.Tours.Add(s));
            context.SaveChanges();
*/
        }
    }
}