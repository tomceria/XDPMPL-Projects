using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI.BUS
{
    public partial class TourGroup
    {
        public static List<TourGroup> GetAll() {
            return TourGroupDAL.GetAll();
        }

        public static TourGroup GetOne(int id)
        {
            return TourGroupDAL.GetOne(id);
        }

        public static void DeleteOne(int id) {
            TourGroupDAL.DeleteOne(id);
        }

        public TourGroup Create()
        {
            this.PriceGroup = CalculateTourGroupPrice(this);
            return TourGroupDAL.CreateOne(this);
        }

        public void Update()
        {
            this.PriceGroup = CalculateTourGroupPrice(this);
            TourGroupDAL.UpdateOne(this);
        }

        /// <param name="customer">Customer to be added to tour group details</param>
        public void AddTourGroupDetailToTourGroup(Customer customer) {
            if (this.doesExistTourGroupDetail(customer.ID)) {
                Console.WriteLine("Customer exist");
                return;
            }

            TourGroupDetail tourGroupDetail = TourGroupDAL.CreateTourGroupDetail(this, customer);
            this.TourGroupDetails.Add(tourGroupDetail);
        }

        /// <param name="tourGroupDetail">A detail to be deleted</param>
        public void DeleteTourGroupDetailFromTourGroup(TourGroupDetail tourGroupDetail) {
            this.TourGroupDetails.Remove(tourGroupDetail);
        }

        /// <param name="tourGroup">A tour group to add staff</param>
        /// <param name="staff">Staff to be added to tour group staffs</param>
        public void AddTourGroupStaffToTourGroup(Staff staff) {
            if (this.doesExistTourGroupStaff(staff.ID)) {
                Console.WriteLine("Staff exist");
                return;
            }

            TourGroupStaff tourGroupStaff = TourGroupDAL.CreateTourGroupStaff(this, staff);

            this.TourGroupStaffs.Add(tourGroupStaff);
        }

        /// <param name="tourGroupStaff">A tour group staff to be deleted</param>
        public void DeleteTourGroupStaffFromTourGroup(TourGroupStaff tourGroupStaff) {
            this.TourGroupStaffs.Remove(tourGroupStaff);
        }

        /// <param name="tourGroup">A tour group to create new cost</param>
        public void CreateTourGroupCostForTour() {
            TourGroupCost tourGroupCost = TourGroupDAL.CreateTourGroupCost(this);

            this.TourGroupCosts.Add(tourGroupCost);
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
        public static long CalculateTourGroupPrice(TourGroup tourGroup) {
            var tourPrice = Tour.GetTourPriceOrPriceRef(tourGroup.TourID, tourGroup.DateStart);

            long costs = 0;
            foreach (TourGroupCost cost in tourGroup.TourGroupCosts) {
                costs += cost.Value;
            }

            return tourPrice + costs;
        }


        private bool doesExistTourGroupDetail(int idCustomer) {

            foreach (TourGroupDetail tourGroupDetail in this.TourGroupDetails) {
                //If exist return true
                if (tourGroupDetail.CustomerID == idCustomer) return true;
            }
            //If not exist return false
            return false;
        }

        private bool doesExistTourGroupStaff(int idStaff) {

            foreach (TourGroupStaff tourGroupStaff in this.TourGroupStaffs) {
                //If exist return true
                if (tourGroupStaff.StaffID == idStaff) return true;
            }
            //If not exist return false
            return false;
        }
        public void RevertChanges()
        {
            TourGroupDAL.RevertChanges(this);
        }

    }
}
