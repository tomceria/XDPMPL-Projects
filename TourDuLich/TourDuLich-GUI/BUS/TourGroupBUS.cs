using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.BUS
{

    class TourGroupBUS
    {
        private TourContext _ctx;

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

        public TourGroup CreateOne(TourGroup tourGroup)
        {
            if (validate(tourGroup))
            {
                tourGroup = _ctx.TourGroups.Add(tourGroup);
                _ctx.SaveChanges();
            }

            return tourGroup;
        }

        public TourGroup UpdateOne(TourGroup tourGroup)
        {
            // get by id
            var tourGroupToUpdate = _ctx.TourGroups.Find(tourGroup.ID);

            if (tourGroupToUpdate != null)
            {
                // update entity
                if (validate(tourGroup))
                {
                    tourGroupToUpdate.TourID = tourGroup.TourID;
                    tourGroupToUpdate.Name = tourGroup.Name;
                    tourGroupToUpdate.DateStart = tourGroup.DateStart;
                    tourGroupToUpdate.DateEnd = tourGroup.DateEnd;
                    tourGroupToUpdate.PriceGroup = tourGroup.PriceGroup;

                    // save change to db
                    _ctx.SaveChanges();
                }
            }

            return tourGroupToUpdate;
        }

        public void DeleteOne(int id)
        {
            var tourGroup = _ctx.TourGroups.Find(id);
            _ctx.TourGroups.Remove(tourGroup);
            _ctx.SaveChanges();
        }

        /// <param name="tourGroup">A tour group to validate</param>
        /// <returns>Returns true if validated</returns>
        public bool validate(TourGroup tourGroup)
        {
            string errorMsg;

            // validate tour group name
            if (string.IsNullOrEmpty(tourGroup.Name))
            {
                errorMsg = "Name is empty";
                Console.WriteLine(errorMsg);
                return false;
            }

            // validate tour 
            if (tourGroup.TourID == 0)
            {
                errorMsg = "Tour is empty";
                Console.WriteLine(errorMsg);
                return false;
            }

            // valitdate datetime
            if (DateTime.Compare(tourGroup.DateStart.Date, DateTime.Now.Date) < 0)
            {
                errorMsg = "Start date is not valid";
                Console.WriteLine(errorMsg);
                return false;
            }

            // valitdate datetime
            if (DateTime.Compare(tourGroup.DateStart.Date, tourGroup.DateEnd.Date) > 0)
            {
                errorMsg = "Date is not valid";
                Console.WriteLine(errorMsg);
                return false;
            }

            return true;
        }

        /// <param name="tourGroup">A tour group to add detail</param>
        /// <param name="customer">Customer to be added to tour group details</param>
        public void AddTourGroupDetailToTourGroup(TourGroup tourGroup, Customer customer)
        {
            TourGroupDetail tourGroupDetail = new TourGroupDetail
            {
                TourGroupID = tourGroup.ID,
                CustomerID = customer.ID
            };

            if (tourGroupDetail.TourGroupID != 0)
            {
                tourGroup.TourGroupDetails.Add(tourGroupDetail);
            }
            else
            {
                Console.WriteLine("Lỗi rồi");
            }
        }

        /// <param name="tourGroupDetail">A detail to be deleted</param>
        public void DeleteTourGroupDetailFromTourGroup(TourGroupDetail tourGroupDetail)
        {
            var detail = _ctx.TourGroupDetails.Find(tourGroupDetail.ID);

            if (detail != null)
            {
                _ctx.TourGroupDetails.Remove(detail);
            }
        }

        /// <param name="tourGroup">A tour group to add staff</param>
        /// <param name="staff">Staff to be added to tour group staffs</param>
        public void AddTourGroupStaffToTourGroup(TourGroup tourGroup, Staff staff)
        {
            TourGroupStaff tourGroupStaff = new TourGroupStaff
            {
                TourGroupID = tourGroup.ID,
                StaffID = staff.ID
            };

            if (tourGroupStaff.TourGroupID != 0)
            {
                tourGroup.TourGroupStaffs.Add(tourGroupStaff);
            }
            else
            {
                Console.WriteLine("Lỗi rồi");
            }
        }

        /// <param name="tourGroupStaff">A tour group staff to be deleted</param>
        public void DeleteTourGroupStaffFromTourGroup(TourGroupStaff tourGroupStaff)
        {
            var staff = _ctx.TourGroupDetails.Find(tourGroupStaff.ID);

            if (staff != null)
            {
                _ctx.TourGroupDetails.Remove(staff);
            }
        }

        /// <param name="tourGroup">A tour group to create new cost</param>
        public void CreateTourGroupCostForTour(TourGroup tourGroup)
        {
            var costType = _ctx.CostTypes.First();
            TourGroupCost tourGroupCost = new TourGroupCost
            {
                TourGroupID = tourGroup.ID,
                CostTypeID = costType.ID
            };

            if (tourGroupCost.TourGroupID != 0)
            {
                _ctx.TourGroupCosts.Add(tourGroupCost);
            } else
            {
                Console.WriteLine("Lỗi rồi");
            }
        }

        /// <param name="tourGroupCost">A tour group cost to be deleted</param>
        public void DeleteTourGroupCostFromTour(TourGroupCost tourGroupCost)
        {
            var cost = _ctx.TourGroupCosts.Find(tourGroupCost.ID);

            if (cost != null)
            {
                _ctx.TourGroupCosts.Remove(cost);
            }
        }
    }
}
