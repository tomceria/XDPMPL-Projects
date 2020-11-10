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

            List<TourType> tourTypes = new List<TourType>
            {
                new TourType {Name = "Du lịch di động"},
                new TourType {Name = "Du lịch kết hợp nghề nghiệp"},
                new TourType {Name = "Du lịch xã hội và gia đình"}
            };
            context.TourTypes.AddRange(tourTypes);
            context.SaveChanges();
            
            List<CostType> costTypes = new List<CostType>
            {
                new CostType {Name = "Chi phí Khách sạn"},
                new CostType {Name = "Chi phí Trung chuyển"},
                new CostType {Name = "Chi phí Ăn uống"},
                new CostType {Name = "Chi phí Khác"},
            };
            context.CostTypes.AddRange(costTypes);
            context.SaveChanges();
            
            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Lưu Minh Hoàng 2",
                    CMND = "079099001462",
                    Address = "100-102 Somewhere, Q. 10",
                    Gender = "Nam",
                    PhoneNumber = "0908228566"
                },
                new Customer
                {
                    Name = "Hoang Lưu Mình",
                    CMND = "099099001463",
                    Address = "123 Đường Bờ Biển, Q. 100",
                    Gender = "Nữ",
                    PhoneNumber = "0909000999"
                },
                new Customer
                {
                    Name = "Loang Mưu Hình",
                    CMND = "089099001464",
                    Address = "456 Thiên Đường, Q. 0",
                    Gender = "Nam",
                    PhoneNumber = "0908009000"
                },
                new Customer
                {
                    Name = "Trần Thị Yeah",
                    CMND = "00901910999",
                    Address = "300 De, Q. Yass",
                    Gender = "Nữ",
                    PhoneNumber = "09123000123"
                },
                new Customer
                {
                    Name = "Phanh Vị Thõ",
                    CMND = "011011001101",
                    Address = "9000 Đường EVO, Q. Tân Bình 2",
                    Gender = "Nữ",
                    PhoneNumber = "01289994562"
                },
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
            
            List<Staff> staffs = new List<Staff>
            {
                new Staff {Name = "Lưu Minh Hoàng"},
                new Staff {Name = "Võ Hoàng Huy"},
                new Staff {Name = "Trần Mình Hiếu"},
                new Staff {Name = "Hứa Thị Ánh Ngân"},
                new Staff {Name = "Trần Thị Thuý An"},
                new Staff {Name = "Ôn Tuấn Huy"},
            };
            context.Staffs.AddRange(staffs);
            context.SaveChanges();

            List<Destination> destinations = new List<Destination>
            {
                new Destination {Name = "Sân bay Tân Sơn Nhất"},
                new Destination {Name = "Sân bay Đà Nẵng"},
                new Destination {Name = "Bán đảo Sơn Trà"},
                new Destination {Name = "Bán đảo Sơn Trà"},
                new Destination {Name = "Chùa Linh Ứng"},
                new Destination {Name = "Biển Mỹ Khê"},
                new Destination {Name = "Ngũ Hành Sơn"},
                new Destination {Name = "Bà Nà"},
                new Destination {Name = "Đại Nội - Hoàng Thành"},
                new Destination {Name = "Chùa Thiên Mụ"},
                new Destination {Name = "Lăng Khải Định"},
                new Destination {Name = "Sân bay Phù Bái"},
            };
            context.Destinations.AddRange(destinations);
            context.SaveChanges();

            List<Tour> tours = new List<Tour>
            {
                new Tour
                {
                    Name = "Du lịch Đà Nẵng - Bà Nà - Hội An - Huế - Động Phong Nha từ Sài Gòn",
                    Description =
                        "Đà Nẵng - Cao Nguyên Bà Nà - Phố Cổ Hội An - Cố Đô Huế - Thánh Địa La Vang - Động Phong Nha",
                    PriceRef = 6499000,
                    TourType = tourTypes[2],
                    TourDetails = new List<TourDetail>
                    {
                        new TourDetail {Order = 1, Destination = destinations[0]},
                        new TourDetail {Order = 2, Destination = destinations[1]},
                        new TourDetail {Order = 3, Destination = destinations[2]},
                        new TourDetail {Order = 4, Destination = destinations[3]},
                        new TourDetail {Order = 5, Destination = destinations[4]},
                        new TourDetail {Order = 6, Destination = destinations[5]},
                        new TourDetail {Order = 7, Destination = destinations[6]},
                        new TourDetail {Order = 8, Destination = destinations[7]},
                        new TourDetail {Order = 9, Destination = destinations[8]},
                        new TourDetail {Order = 10, Destination = destinations[9]},
                        new TourDetail {Order = 11, Destination = destinations[10]},
                        new TourDetail {Order = 12, Destination = destinations[11]}
                    },
                    TourPrices = new List<TourPrice>
                    {
                        new TourPrice
                        {
                            Value = 5449000,
                            TimeStart = DateTime.Now,
                            TimeEnd = DateTime.Now.AddMonths(1)
                        },
                        new TourPrice
                        {
                            Value = 7499000,
                            TimeStart = DateTime.Now.AddMonths(1).AddDays(1),
                            TimeEnd = DateTime.Now.AddMonths(2),
                        },
                    },
                    TourGroups = new List<TourGroup>
                    {
                        new TourGroup
                        {
                            Name = "Du lịch Đà Nẵng 1",
                            DateStart = DateTime.Now,
                            DateEnd = DateTime.Now.AddDays(4),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[0],
                                    Value = 1456000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 550000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 850000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 100000,
                                    Note = "Phí vui chơi Bà Nà"
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                        new TourGroup
                        {
                            Name = "Du lịch Đà Nẵng 2",
                            DateStart = DateTime.Now.AddDays(5),
                            DateEnd = DateTime.Now.AddDays(8),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[0],
                                    Value = 1456000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 550000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 850000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 100000,
                                    Note = "Phí vui chơi Bà Nà"
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                        new TourGroup
                        {
                            Name = "Du lịch Đà Nẵng 3",
                            DateStart = DateTime.Now.AddDays(9),
                            DateEnd = DateTime.Now.AddDays(12),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[0],
                                    Value = 1456000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 550000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 850000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 100000,
                                    Note = "Phí vui chơi Bà Nà"
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                    }
                },
                new Tour
                {
                    Name = "Du lịch Sài Gòn từ Huế",
                    Description =
                        "Tham quan các sân bay???",
                    PriceRef = 3999000,
                    TourType = tourTypes[1],
                    TourDetails = new List<TourDetail>
                    {
                        new TourDetail {Order = 1, Destination = destinations[11]},
                        new TourDetail {Order = 2, Destination = destinations[1]},
                        new TourDetail {Order = 3, Destination = destinations[0]}
                    },
                    TourPrices = new List<TourPrice>
                    {
                        new TourPrice
                        {
                            Value = 5449000,
                            TimeStart = DateTime.Now,
                            TimeEnd = DateTime.Now.AddMonths(2)
                        },
                        new TourPrice
                        {
                            Value = 7499000,
                            TimeStart = DateTime.Now.AddMonths(2).AddDays(1),
                            TimeEnd = DateTime.Now.AddMonths(3),
                        },
                    },
                    TourGroups = new List<TourGroup>
                    {
                        new TourGroup
                        {
                            Name = "Du lịch Sài Gòn 1",
                            DateStart = DateTime.Now,
                            DateEnd = DateTime.Now.AddDays(1),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 1200000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 400000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                        new TourGroup
                        {
                            Name = "Du lịch Sài Gòn 2",
                            DateStart = DateTime.Now.AddDays(2),
                            DateEnd = DateTime.Now.AddDays(3),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 1200000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 400000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                        new TourGroup
                        {
                            Name = "Du lịch Sài Gòn 3",
                            DateStart = DateTime.Now.AddDays(4),
                            DateEnd = DateTime.Now.AddDays(5),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 1200000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 400000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                        new TourGroup
                        {
                            Name = "Du lịch Sài Gòn 4",
                            DateStart = DateTime.Now.AddDays(6),
                            DateEnd = DateTime.Now.AddDays(7),
                            TourGroupCosts = new List<TourGroupCost>
                            {
                                new TourGroupCost
                                {
                                    CostType = costTypes[1],
                                    Value = 1200000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[2],
                                    Value = 400000
                                },
                                new TourGroupCost
                                {
                                    CostType = costTypes[3],
                                    Value = 50000,
                                    Note = "Phí tài xế xe buýt"
                                }
                            }
                        },
                    }
                },
            };
            context.Tours.AddRange(tours);
            context.SaveChanges();
        }
    }
}
