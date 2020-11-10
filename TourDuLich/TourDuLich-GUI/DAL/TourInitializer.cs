using System;
using System.Collections.Generic;
using System.Data.Entity;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL
{
    class TourInitializer : DropCreateDatabaseIfModelChanges<TourContext>
    {
        protected override void Seed(TourContext context)
        {
        }
    }
}