namespace TourDuLich_GUI.Migrations {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TourDuLich_GUI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.TourContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.TourContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            IList<TourType> tourTypes = new List<TourType>();
            IList<TourPrice> tourPrices = new List<TourPrice>();
            IList<Tour> tours = new List<Tour>();

            if (!context.TourTypes.Any()) {
                tourTypes.Add(new TourType() { Name = "Du lịch di động" });
                tourTypes.Add(new TourType() { Name = "Du lịch kết hợp nghề nghiệp" });
                tourTypes.Add(new TourType() { Name = "Du lịch xã hội và gia đình" });

                context.TourTypes.AddRange(tourTypes);
            }

            if (!context.TourPrices.Any()) {
                tourPrices.Add(new TourPrice() {
                    Value = 200000,
                    TimeStart = DateTime.Now,
                    TimeEnd = DateTime.Now.AddDays(10)
                });

                context.TourPrices.AddRange(tourPrices);
            }

            if (!context.Tours.Any()) {
                tours.Add(new Tour() {
                    Name = "HCM - Hanoi",
                    PriceRef = 100000,
                    Description = "Hello world",
                    TourType = tourTypes[0],
                });
            }

            context.SaveChanges();
        }
    }
}
