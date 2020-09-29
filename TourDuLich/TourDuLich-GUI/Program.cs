using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
/*            var context = new TourContext();
            List<TourType> tourTypes = new List<TourType>() {
                new TourType() {
                ID = 1,
                Name = "Du lịch di động"
                },
                new TourType() {
                ID = 2,
                Name = "Du lịch kết hợp nghề nghiệp"
                },
                new TourType() {
                ID = 3,
                Name = "Du lịch xã hội và gia đình"
                },
            };

            var tours = new List<Tour> {
                new Tour { ID = 1, Name = "HCM - Hanoi", PriceRef = 1050, Description = "Hello world", TourType = tourTypes[0] }
            };
            tours.ForEach(s => context.Tours.Add(s));
            context.SaveChanges();
*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}