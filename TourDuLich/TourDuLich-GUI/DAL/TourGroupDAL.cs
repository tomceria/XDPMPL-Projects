using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL {

    class TourGroupDAL {
        private static TourContext _ctx = new TourContext();

        public TourGroupDAL() {
            _ctx = new TourContext();
        }

        public static List<TourGroup> GetAll() {
            var tourGroups = _ctx.TourGroups.ToList();

            return tourGroups;
        }
        public static TourGroup GetOne(int id) {
            // if found => return tourGroup, else return null
            return _ctx.TourGroups.Find(id);
        }

        public static TourGroup CreateOne(TourGroup tourGroup) {
            _ctx.Entry(tourGroup).State = EntityState.Added;
            _ctx.SaveChanges();

            return tourGroup;
        }

        public static TourGroup UpdateOne(TourGroup tourGroup) {
            var tourGroupToUpdate = _ctx.TourGroups.Find(tourGroup.ID);

            if (tourGroupToUpdate == null) {
                return null;
            }

            _ctx.Entry(tourGroup).State = EntityState.Modified;

            List<TourGroupDetail> tourGroupDetails = tourGroup.TourGroupDetails.ToList();
            List<TourGroupDetail> ogTourGroupDetails = _ctx.TourGroupDetails.Where(o => o.TourGroupID == tourGroup.ID).ToList();
            foreach (TourGroupDetail tourGroupDetail in ogTourGroupDetails) {
                if (tourGroupDetails.FirstOrDefault(o => o.ID == tourGroupDetail.ID) == null) {
                    _ctx.Entry(tourGroupDetail).State = EntityState.Deleted;
                }
            }
            foreach (TourGroupDetail tourGroupDetail in tourGroupDetails) {
                if (ogTourGroupDetails.FirstOrDefault(o => o.ID == tourGroupDetail.ID) == null) {
                    _ctx.Entry(tourGroupDetail).State = EntityState.Added;
                } else {
                    _ctx.Entry(tourGroupDetail).State = EntityState.Modified;
                }
            }

            List<TourGroupStaff> tourGroupStaffs = tourGroup.TourGroupStaffs.ToList();
            List<TourGroupStaff> ogTourGroupStaffs = _ctx.TourGroupStaffs.Where(o => o.TourGroupID == tourGroup.ID).ToList();
            foreach (TourGroupStaff tourGroupStaff in ogTourGroupStaffs) {
                if (tourGroupStaffs.FirstOrDefault(o => o.ID == tourGroupStaff.ID) == null) {
                    _ctx.Entry(tourGroupStaff).State = EntityState.Deleted;
                }
            }
            foreach (TourGroupStaff tourGroupStaff in tourGroupStaffs) {
                if (ogTourGroupStaffs.FirstOrDefault(o => o.ID == tourGroupStaff.ID) == null) {
                    _ctx.Entry(tourGroupStaff).State = EntityState.Added;
                } else {
                    _ctx.Entry(tourGroupStaff).State = EntityState.Modified;
                }
            }

            List<TourGroupCost> tourGroupCosts = tourGroup.TourGroupCosts.ToList();
            List<TourGroupCost> ogTourGroupCosts = _ctx.TourGroupCosts.Where(o => o.TourGroupID == tourGroup.ID).ToList();
            foreach (TourGroupCost tourGroupCost in ogTourGroupCosts) {
                if (tourGroupCosts.FirstOrDefault(o => o.ID == tourGroupCost.ID) == null) {
                    _ctx.Entry(tourGroupCost).State = EntityState.Deleted;
                }
            }
            foreach (TourGroupCost tourGroupCost in tourGroupCosts) {
                if (ogTourGroupCosts.FirstOrDefault(o => o.ID == tourGroupCost.ID) == null) {
                    _ctx.Entry(tourGroupCost).State = EntityState.Added;
                } else {
                    _ctx.Entry(tourGroupCost).State = EntityState.Modified;
                }
            }

            _ctx.SaveChanges();
            return tourGroup;
        }

        public static void DeleteOne(int id) {
            var tourGroup = _ctx.TourGroups.Find(id);

            _ctx.TourGroupCosts.RemoveRange(tourGroup.TourGroupCosts);
            _ctx.TourGroupDetails.RemoveRange(tourGroup.TourGroupDetails);
            _ctx.TourGroupStaffs.RemoveRange(tourGroup.TourGroupStaffs);
            _ctx.TourGroups.Remove(tourGroup);

            _ctx.SaveChanges();
        }


        public static TourGroupDetail CreateTourGroupDetail(TourGroup tourGroup, Customer customer)
        {
            Customer newCustomer = _ctx.Customers.First(o => o.ID == customer.ID);

            TourGroupDetail tourGroupDetail = new TourGroupDetail() {
                TourGroup = tourGroup,
                Customer = newCustomer,
                CustomerID = newCustomer.ID
            };

            return tourGroupDetail;
        }

        public static TourGroupStaff CreateTourGroupStaff(TourGroup tourGroup, Staff staff)
        {
            Staff newStaff = _ctx.Staffs.First(o => o.ID == staff.ID);

            TourGroupStaff tourGroupStaff = new TourGroupStaff() {
                TourGroup = tourGroup,
                Staff = newStaff,
                StaffID = newStaff.ID,
                StaffTask = TourGroupStaff.Tasks.First()
            };

            return tourGroupStaff;
        }

        public static TourGroupCost CreateTourGroupCost(TourGroup tourGroup)
        {
            var costType = _ctx.CostTypes.First();

            TourGroupCost tourGroupCost = new TourGroupCost() {
                TourGroup = tourGroup,
                CostType = costType,
                CostTypeID = costType.ID
            };

            return tourGroupCost;
        }
    }
}