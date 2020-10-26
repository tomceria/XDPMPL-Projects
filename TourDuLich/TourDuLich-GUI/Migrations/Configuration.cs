namespace TourDuLich_GUI.Migrations {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TourDuLich_GUI.BUS;

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
            IList<Destination> destinations = new List<Destination>();
            IList<CostType> costTypes = new List<CostType>();
            IList<Customer> customers = new List<Customer>();
            IList<Staff> staffs = new List<Staff>();

            if (!context.TourTypes.Any()) {
                tourTypes.Add(new TourType() { Name = "Du lịch di động" });
                tourTypes.Add(new TourType() { Name = "Du lịch kết hợp nghề nghiệp" });
                tourTypes.Add(new TourType() { Name = "Du lịch xã hội và gia đình" });

                context.TourTypes.AddRange(tourTypes);
            } else {
                tourTypes = context.TourTypes.ToList();
            }

            if (!context.TourPrices.Any()) {
                tourPrices.Add(new TourPrice() {
                    Value = 200000,
                    TimeStart = DateTime.Now,
                    TimeEnd = DateTime.Now.AddDays(10)
                });

                context.TourPrices.AddRange(tourPrices);
            } else {
                tourPrices = context.TourPrices.ToList();
            }

            if (!context.Tours.Any()) {
                tours.Add(new Tour() {
                    Name = "HCM - Hanoi",
                    PriceRef = 100000,
                    Description = "Hello world",
                    TourType = tourTypes[0],
                    TourPrices = tourPrices
                });
                tours.Add(new Tour() {
                    Name = "HCM - Da Nang",
                    PriceRef = 200000,
                    Description = "Hello world 2",
                    TourType = tourTypes[1]
                });

                context.Tours.AddRange(tours);
            }

            if (!context.Destinations.Any()) {
                destinations.Add(new Destination() { Name = "Hạ Long Bay" });
                destinations.Add(new Destination() { Name = "Phố cổ Hội An" });
                destinations.Add(new Destination() { Name = "Tiệm bánh Cối Xay Gió" });

                context.Destinations.AddRange(destinations);
            }

            if (!context.CostTypes.Any()) {
                costTypes.Add(new CostType() { Name = "Chi phí khách sạn" });
                costTypes.Add(new CostType() { Name = "Chi phí Vận chuyển" });
                costTypes.Add(new CostType() { Name = "Chi phí ăn uống" });
                costTypes.Add(new CostType() { Name = "Chi phí khác" });

                context.CostTypes.AddRange(costTypes);
            }

            if (!context.Customers.Any()) {
                customers.Add(new Customer() {
                    Name = "Lưu Minh Hoàng",
                    CMND = "079099001462",
                    Address = "100 Everywhere",
                    Gender = "Nam",
                    PhoneNumber = "0908228566"
                });
                customers.Add(new Customer() {
                    Name = "Lưu Minh H",
                    CMND = "099999999",
                    Address = "102 Everywhere",
                    Gender = "Nam",
                    PhoneNumber = "0909000999"
                });

                context.Customers.AddRange(customers);
            }

            if (!context.Staffs.Any()) {
                staffs.Add(new Staff() { Name = "Nguyễn Văn A" });
                staffs.Add(new Staff() { Name = "Trần Thị B" });

                context.Staffs.AddRange(staffs);
            }

            context.SaveChanges();
        }
    }
}
