using System;
using System.Collections.Generic;
using TourDuLich_GUI.BUS;
using System.Data.Entity;

namespace TourDuLich_GUI.DAL {
    class TourInitializer : DropCreateDatabaseIfModelChanges<TourContext> {
        protected override void Seed(TourContext context) {
            IList<TourType> tourTypes = new List<TourType>();
            tourTypes.Add(new TourType() { Name = "Du lịch di động" });
            tourTypes.Add(new TourType() { Name = "Du lịch kết hợp nghề nghiệp" });
            tourTypes.Add(new TourType() { Name = "Du lịch xã hội và gia đình" });

            context.TourTypes.AddRange(tourTypes);
            context.SaveChanges();
        }
    }
}