using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{
    class TourGroupStaffBUS
    {
        private TourContext _ctx;

        public TourGroupStaffBUS()
        {
            _ctx = new TourContext();
        }

        public List<TourGroupStaff> GetAll()
        {
            var tourGroupStaffs = _ctx.TourGroupStaffs.ToList();

            return tourGroupStaffs;
        }
        public TourGroupStaff GetOne(int id)
        {
            // if found => return tourGroupStaff, else return null
            return _ctx.TourGroupStaffs.Find(id);
        }

        public void CreateOne(TourGroupStaff tourGroupStaff)
        {
            _ctx.TourGroupStaffs.Add(tourGroupStaff);
            _ctx.SaveChanges();
        }

        public TourGroupStaff UpdateOne(TourGroupStaff tourGroupStaff)
        {
            // get by id
            var tourGroupStaffToUpdate = _ctx.TourGroupStaffs.Find(tourGroupStaff.ID);

            // update entity
            tourGroupStaffToUpdate.TourGroupID = tourGroupStaff.TourGroupID;
            tourGroupStaffToUpdate.StaffID = tourGroupStaff.StaffID;
            tourGroupStaffToUpdate.StaffTask = tourGroupStaff.StaffTask;

            // save change to db
            _ctx.SaveChanges();

            return tourGroupStaffToUpdate;
        }

        public void DeleteOne(int id)
        {
            var tourGroupStaff = _ctx.TourGroupStaffs.Find(id);
            _ctx.TourGroupStaffs.Remove(tourGroupStaff);
            _ctx.SaveChanges();
        }
    }
}
