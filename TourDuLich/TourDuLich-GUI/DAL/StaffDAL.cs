using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.DAL
{
    class StaffDAL
    {
        static TourContext _ctx = new TourContext();

        public StaffDAL()
        {
            _ctx = new TourContext();
        }

        public static List<Staff> GetAll()
        {
            var staffs = _ctx.Staffs.ToList();

            return staffs;
        }
        public static Staff GetOne(int id)
        {
            // if found => return staff, else return null
            return _ctx.Staffs.Find(id);
        }

        public static void CreateOne(Staff staff)
        {
            _ctx.Staffs.Add(staff);
            _ctx.SaveChanges();
        }

        public static Staff UpdateOne(Staff staff)
        {
            // get by id
            var staffToUpdate = _ctx.Staffs.Find(staff.ID);

            // update entity
            staffToUpdate.Name = staff.Name;

            // save change to db
            _ctx.SaveChanges();

            return staffToUpdate;
        }

        public static void DeleteOne(int id)
        {
            var staff = _ctx.Staffs.Find(id);
            _ctx.Staffs.Remove(staff);
            _ctx.SaveChanges();
        }
    }
}
