using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.GUI;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

/*            var context = new TourContext();
*/            /*
             List<TourType> tourTypes = new List<TourType>() {
                 new TourType() {
                     Name = "Du lịch di động"
                 },
                 new TourType() {
                     Name = "Du lịch kết hợp nghề nghiệp"
                 },
                 new TourType() {
                     Name = "Du lịch xã hội và gia đình"
                 },
             };

             var tours = new List<Tour> {
                             new Tour {
                                 ID = 0,
                                 Name = "HCM - Hanoi",
                                 PriceRef = 100000,
                                 Description = "Hello world",
                                 TourType = tourTypes[0],
                                 TourPrices = new List<TourPrice>() {
                                     new TourPrice() { Value = 200000, TimeStart = DateTime.Now, TimeEnd = DateTime.Now.AddDays(10) }
                                 }
                             },
                             new Tour { Name = "HCM - Da Nang", PriceRef = 200000, Description = "Hello world 2", TourType = tourTypes[1] }
                         };

             List<Destination> destinations = new List<Destination>()
                                 {
                                     new Destination() {
                                         Name = "Ha Long Bay"
                                     },
                                     new Destination() {
                                         Name = "Pho co Hoi An"
                                     },
                                     new Destination() {
                                         Name = "Tiem banh Coi Xay Gio"
                                     }
                                 };

                         tours.ForEach(s => context.Tours.Add(s));
                         destinations.ForEach(s => context.Destinations.Add(s));
             */

            /*            List<CostType> costTypes = new List<CostType>()
                        {
                            new CostType() { Name = "Chi phí Khách sạn" },
                            new CostType() { Name = "Chi phí Vận chuyển" },
                            new CostType() { Name = "Chi phí Ăn uống" },
                            new CostType() { Name = "Chi phí khác" }
                        };
                        costTypes.ForEach(s => context.CostTypes.Add(s));
            */
/*            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Lưu Minh Hoàng", CMND = "079099001462", Address = "100 Everywhere", Gender = "Nam", PhoneNumber = "0908228566" },
                new Customer() { Name = "Lưu Minh H", CMND = "099999999", Address = "102 Everywhere", Gender = "Nam", PhoneNumber = "0909000999" }
            };
            customers.ForEach(s => context.Customers.Add(s));

            List<Staff> staffs = new List<Staff>()
            {
                new Staff() { Name = "Nguyễn Văn A" },
                new Staff() { Name = "Nguyễn Văn B" }
            };
            staffs.ForEach(s => context.Staffs.Add(s));

            context.SaveChanges();
*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}