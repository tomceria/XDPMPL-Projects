using System;
using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL {
    class StaffDAL {
        static TourContext _ctx = new TourContext();

        public StaffDAL() {
            _ctx = new TourContext();
        }

        public static List<Staff> GetAll() {
            var staffs = _ctx.Staffs.ToList();

            return staffs;
        }

        public static List<Staff> GetAll(DateTime startDate, DateTime endDate) {
            // lọc ra những tour group có ngày khởi hành trong khoảng thời gian tìm kiếm
            var result = _ctx.Staffs.ToList().ConvertAll(staff => {
                Staff newStaff = new Staff(staff);
                newStaff.TourGroupStaffs = staff.TourGroupStaffs.Where(tg => tg.TourGroup.DateStart >= startDate && tg.TourGroup.DateStart <= endDate).ToList();
                return newStaff;
            });

            return result;
        }

        public static Staff GetOne(int id) {
            // if found => return staff, else return null
            return _ctx.Staffs.Find(id);
        }

        public static void CreateOne(Staff staff) {
            _ctx.Staffs.Add(staff);
            _ctx.SaveChanges();
        }

        public static Staff UpdateOne(Staff staff) {
            // get by id
            var staffToUpdate = _ctx.Staffs.Find(staff.ID);

            // update entity
            staffToUpdate.Name = staff.Name;

            // save change to db
            _ctx.SaveChanges();

            return staffToUpdate;
        }

        public static void DeleteOne(int id) {
            var staff = _ctx.Staffs.Find(id);
            _ctx.Staffs.Remove(staff);
            _ctx.SaveChanges();
        }
        
        public static void Reload()
        {
            _ctx = new TourContext();
        }
    }
}
