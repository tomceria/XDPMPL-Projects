using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                _ctx.Entry(tourGroup).State = EntityState.Added;

/*                tourGroup = _ctx.TourGroups.Add(tourGroup);
*/
                _ctx.SaveChanges();
            }

            return tourGroup;
        }

        public TourGroup UpdateOne(TourGroup tourGroup)
        {
            Console.WriteLine("instance: " + tourGroup.TourGroupDetails.Count);
            Console.WriteLine("context: " + _ctx.TourGroupDetails.Where(o => o.TourGroupID == tourGroup.ID).ToList().Count);

            var tourGroupToUpdate = _ctx.TourGroups.Find(tourGroup.ID);

/*            if (tourGroupToUpdate != null && validate(tourGroup))
*/
            if (tourGroupToUpdate != null)
            {
                _ctx.Entry(tourGroup).State = EntityState.Modified;

                List<TourGroupDetail> tourGroupDetails = tourGroup.TourGroupDetails.ToList();
                List<TourGroupDetail> ogTourGroupDetails = _ctx.TourGroupDetails.Where(o => o.TourGroupID == tourGroup.ID).ToList();
                foreach (TourGroupDetail tourGroupDetail in ogTourGroupDetails)
                {
                    if (tourGroupDetails.FirstOrDefault(o => o.ID == tourGroupDetail.ID) == null)
                    {
                        _ctx.Entry(tourGroupDetail).State = EntityState.Deleted;
                    }
                }
                foreach (TourGroupDetail tourGroupDetail in tourGroupDetails)
                {
                    if (ogTourGroupDetails.FirstOrDefault(o => o.ID == tourGroupDetail.ID) == null)
                    {
                        _ctx.Entry(tourGroupDetail).State = EntityState.Added;
                    } else
                    {
                        _ctx.Entry(tourGroupDetail).State = EntityState.Modified;
                    }
                }

                _ctx.SaveChanges();
            }

            return tourGroup;
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
            // Customer is fetched from ANOTHER Context instance => Make a copy
            Customer newCustomer = _ctx.Customers.First(o => o.ID == customer.ID);

            TourGroupDetail tourGroupDetail = new TourGroupDetail() 
            {
                TourGroup = tourGroup,
                Customer = newCustomer
            };

            tourGroup.TourGroupDetails.Add(tourGroupDetail);
        }

        /// <param name="tourGroupDetail">A detail to be deleted</param>
        public void DeleteTourGroupDetailFromTourGroup(TourGroup tourGroup, TourGroupDetail tourGroupDetail)
        {
            tourGroup.TourGroupDetails.Remove(tourGroupDetail);
        }

        /// <param name="tourGroup">A tour group to add staff</param>
        /// <param name="staff">Staff to be added to tour group staffs</param>
        public void AddTourGroupStaffToTourGroup(TourGroup tourGroup, Staff staff)
        {
            // Staff is fetched from ANOTHER Context instance => Make a copy
            Staff newStaff = _ctx.Staffs.First(o => o.ID == staff.ID);

            TourGroupStaff tourGroupStaff = new TourGroupStaff() 
            {
                TourGroup = tourGroup,
                Staff = newStaff
            };

            tourGroup.TourGroupStaffs.Add(tourGroupStaff);
        }

        /// <param name="tourGroupStaff">A tour group staff to be deleted</param>
        public void DeleteTourGroupStaffFromTourGroup(TourGroup tourGroup, TourGroupStaff tourGroupStaff)
        {
            tourGroup.TourGroupStaffs.Remove(tourGroupStaff);
        }

        /// <param name="tourGroup">A tour group to create new cost</param>
        public void CreateTourGroupCostForTour(TourGroup tourGroup)
        {
            var costType = _ctx.CostTypes.First();
            TourGroupCost tourGroupCost = new TourGroupCost
            {
                TourGroupID = tourGroup.ID,
                TourGroup = tourGroup,
                CostTypeID = costType.ID,
                CostType = costType
            };

            tourGroup.TourGroupCosts.Add(tourGroupCost);
        }

        /// <param name="tourGroupCost">A tour group cost to be deleted</param>
        public void DeleteTourGroupCostFromTour(TourGroupCost tourGroupCost)
        {
            TourGroup tourGroup = tourGroupCost.TourGroup;
            tourGroup.TourGroupCosts.Remove(tourGroupCost);
        }
    }
}
