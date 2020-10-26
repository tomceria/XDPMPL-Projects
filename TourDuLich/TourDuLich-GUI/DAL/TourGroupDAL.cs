using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS {

    class TourGroupBUS {
        private TourContext _ctx;
        private TourBUS tourBUS;

        public TourGroupBUS() {
            _ctx = new TourContext();
            tourBUS = new TourBUS();
        }

        public List<TourGroup> GetAll() {
            var tourGroups = _ctx.TourGroups.ToList();

            return tourGroups;
        }
        public TourGroup GetOne(int id) {
            // if found => return tourGroup, else return null
            return _ctx.TourGroups.Find(id);
        }

        public TourGroup CreateOne(TourGroup tourGroup) {
            tourGroup.PriceGroup = this.CalculateTourGroupPrice(tourGroup);

            _ctx.Entry(tourGroup).State = EntityState.Added;
            _ctx.SaveChanges();

            return tourGroup;
        }

        public TourGroup UpdateOne(TourGroup tourGroup) {
            var tourGroupToUpdate = _ctx.TourGroups.Find(tourGroup.ID);

            if (tourGroupToUpdate == null) {
                return null;
            }

            tourGroup.PriceGroup = this.CalculateTourGroupPrice(tourGroup);

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

        public void DeleteOne(int id) {
            var tourGroup = _ctx.TourGroups.Find(id);

            _ctx.TourGroupCosts.RemoveRange(tourGroup.TourGroupCosts);
            _ctx.TourGroupDetails.RemoveRange(tourGroup.TourGroupDetails);
            _ctx.TourGroupStaffs.RemoveRange(tourGroup.TourGroupStaffs);
            _ctx.TourGroups.Remove(tourGroup);

            _ctx.SaveChanges();
        }

        /// <param name="tourGroup">A tour group to add detail</param>
        /// <param name="customer">Customer to be added to tour group details</param>

        public bool isExistTourGroupDetail(TourGroup tourGroup, int idCustomer) {

            foreach (TourGroupDetail tourGroupDetail in tourGroup.TourGroupDetails) {
                //If exist return true
                if (tourGroupDetail.CustomerID == idCustomer) return true;
            }
            //If not exist return false
            return false;
        }

        public bool isExistTourGroupStaff(TourGroup tourGroup, int idStaff) {

            foreach (TourGroupStaff tourGroupStaff in tourGroup.TourGroupStaffs) {
                //If exist return true
                if (tourGroupStaff.StaffID == idStaff) return true;
            }
            //If not exist return false
            return false;
        }

        public void AddTourGroupDetailToTourGroup(TourGroup tourGroup, Customer customer) {
            if (isExistTourGroupDetail(tourGroup, customer.ID)) {
                Console.WriteLine("Customer exist");
                return;
            }

            // Customer is fetched from ANOTHER Context instance => Make a copy
            Customer newCustomer = _ctx.Customers.First(o => o.ID == customer.ID);

            TourGroupDetail tourGroupDetail = new TourGroupDetail() {

                TourGroup = tourGroup,
                Customer = newCustomer,
                CustomerID = newCustomer.ID
            };
            tourGroup.TourGroupDetails.Add(tourGroupDetail);
        }

        /// <param name="tourGroupDetail">A detail to be deleted</param>
        public void DeleteTourGroupDetailFromTourGroup(TourGroup tourGroup, TourGroupDetail tourGroupDetail) {
            tourGroup.TourGroupDetails.Remove(tourGroupDetail);
        }

        /// <param name="tourGroup">A tour group to add staff</param>
        /// <param name="staff">Staff to be added to tour group staffs</param>
        public void AddTourGroupStaffToTourGroup(TourGroup tourGroup, Staff staff) {
            if (isExistTourGroupStaff(tourGroup, staff.ID)) {
                Console.WriteLine("Staff exist");
                return;
            }
            // Staff is fetched from ANOTHER Context instance => Make a copy
            Staff newStaff = _ctx.Staffs.First(o => o.ID == staff.ID);

            TourGroupStaff tourGroupStaff = new TourGroupStaff() {
                TourGroup = tourGroup,
                Staff = newStaff,
                StaffID = newStaff.ID,
                StaffTask = TourGroupStaff.Tasks.First()
            };

            tourGroup.TourGroupStaffs.Add(tourGroupStaff);
        }

        /// <param name="tourGroupStaff">A tour group staff to be deleted</param>
        public void DeleteTourGroupStaffFromTourGroup(TourGroup tourGroup, TourGroupStaff tourGroupStaff) {
            tourGroup.TourGroupStaffs.Remove(tourGroupStaff);
        }

        /// <param name="tourGroup">A tour group to create new cost</param>
        public void CreateTourGroupCostForTour(TourGroup tourGroup) {
            var costType = _ctx.CostTypes.First();
            TourGroupCost tourGroupCost = new TourGroupCost {
                TourGroupID = tourGroup.ID,
                TourGroup = tourGroup,
                CostTypeID = costType.ID,
                CostType = costType
            };

            tourGroup.TourGroupCosts.Add(tourGroupCost);
        }

        /// <param name="tourGroupCost">A tour group cost to be deleted</param>
        public void DeleteTourGroupCostFromTour(TourGroupCost tourGroupCost) {
            TourGroup tourGroup = tourGroupCost.TourGroup;
            tourGroup.TourGroupCosts.Remove(tourGroupCost);
        }

        /// <summary>
        /// Calculate TourGroupPrice = TourPrice + TourGroupCosts
        /// </summary>
        /// <returns>TourGroupPrice</returns>
        public long CalculateTourGroupPrice(TourGroup tourGroup) {
            var tourPrice = tourBUS.GetPriceOnDate(tourGroup.TourID, tourGroup.DateStart);

            long costs = 0;
            foreach (TourGroupCost cost in tourGroup.TourGroupCosts) {
                costs += cost.Value;
            }

            return tourPrice + costs;
        }
    }
}