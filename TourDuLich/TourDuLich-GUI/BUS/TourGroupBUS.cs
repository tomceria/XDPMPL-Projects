using System;
using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{

    class TourGroupBUS
    {
        TourContext _ctx;

        public TourGroupBUS()
        {
            _ctx = new TourContext();
        }

        public List<TourGroup> GetAll()
        {
            var tourGroups = _ctx.TourGroups.ToList();

            return tourGroups;
        }
        public TourGroup GetOne(int id)
        {
            // if found => return tourGroup, else return null
            return _ctx.TourGroups.Find(id);
        }

        public void CreateOne(TourGroup tourGroup)
        {
            _ctx.TourGroups.Add(tourGroup);
            _ctx.SaveChanges();
        }

        public TourGroup UpdateOne(TourGroup tourGroup)
        {
            // get by id
            var tourGroupToUpdate = _ctx.TourGroups.Find(tourGroup.ID);

            // update entity
            tourGroupToUpdate.TourID = tourGroup.TourID;
            tourGroupToUpdate.Name = tourGroup.Name;
            tourGroupToUpdate.DateStart = tourGroup.DateStart;
            tourGroupToUpdate.DateEnd = tourGroup.DateEnd;
            tourGroupToUpdate.PriceGroup = tourGroup.PriceGroup;

            // save change to db
            _ctx.SaveChanges();

            return tourGroupToUpdate;
        }
    }
}
