﻿using System;
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
/*            
            var context = new TourContext();
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

            public List<Destination> destinations = new List<Destination>()
                {
                    new Destination() {
                        Name = "Ha Long Bay"
                    },
                    new Destination() {
                        Name = "Pho co Hoi An"
                    },
                    new Destination() {
                        Name = "Tiem banh Coi Xay Gio"
                    },
                };

            tours.ForEach(s => context.Tours.Add(s));
            destinations.ForEach(s => context.Destinations.Add(s));
            context.SaveChanges();
*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}