using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraLayout;
using TourDuLich_GUI.BUS;
using TourDuLich_GUI.DAL;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace TourDuLich_GUI.GUI
{
    public partial class EditTourGroupView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private TourGroup _item;
        private List<TourGroupDetail> _tourGroupDetails;
        private List<TourGroupStaff> _tourGroupStaffs;
        private List<TourGroupCost> _tourGroupCosts;

        private bool isUpdate = false;

        // Data Sources
        BindingList<TourGroup> itemBL;
        BindingList<Tour> toursBL;
        BindingList<Customer> customersBL;
        BindingList<Staff> staffsBL;
        BindingList<CostType> costTypesBL;
        BindingList<TourGroupCost> tourGroupCostsBL;
        BindingList<TourGroupDetail> tourGroupDetailsBL;
        BindingList<TourGroupStaff> tourGroupStaffsBL;

        public EditTourGroupView()
        {
            InitializeComponent();
            _item = new TourGroup();
            InitializeDataSources();
        }

        public EditTourGroupView(TourGroup tourGroup)
        {
            InitializeComponent();
            _item = tourGroup;
            isUpdate = true;
            InitializeDataSources();
        }

        private void InitializeDataSources()
        {
            // Data fetch
            TourGroup item = TourGroup.GetOne(_item.ID);
            List<Tour> tours = Tour.GetAll();
            List<Customer> customers = Customer.GetAll();
            List<Staff> staffs = Staff.GetAll();
            List<CostType> costTypes = CostType.GetAll();

            if (item == null)
            {
                item = _item;       // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditTourView(Tour tour)
            } else
            {
                _item = item;
            }

            // Data binding
            itemBL = new BindingList<TourGroup>( new List<TourGroup>() { item } );
            toursBL = new BindingList<Tour>(tours);
            customersBL = new BindingList<Customer>(customers);
            staffsBL = new BindingList<Staff>(staffs);
            costTypesBL = new BindingList<CostType>(costTypes);

            // TourGroup.TourGroupCosts
            _tourGroupCosts = item.TourGroupCosts != null
                ? item.TourGroupCosts.ToList()
                : new List<TourGroupCost>();
            item.TourGroupCosts = _tourGroupCosts;
            tourGroupCostsBL = new BindingList<TourGroupCost>(_tourGroupCosts);
            // TourGroup.TourGroupDetails
            _tourGroupDetails = item.TourGroupDetails != null
                ? item.TourGroupDetails.ToList()
                : new List<TourGroupDetail>();
            item.TourGroupDetails = _tourGroupDetails;
            tourGroupDetailsBL = new BindingList<TourGroupDetail>(_tourGroupDetails);
            // TourGroup.TourGroupStaffs
            _tourGroupStaffs = item.TourGroupStaffs != null
                ? item.TourGroupStaffs.ToList()
                : new List<TourGroupStaff>();
            item.TourGroupStaffs = _tourGroupStaffs;
            tourGroupStaffsBL = new BindingList<TourGroupStaff>(_tourGroupStaffs);

            dataLayoutControl_TourGroup.DataSource = itemBL;

            TextEdit_PriceGroup.Enabled = false;


            // Tours
            LookUpEdit_TourID.Properties.DataSource = toursBL;
            LookUpEdit_TourID.Properties.DisplayMember = "Name";
            LookUpEdit_TourID.Properties.ValueMember = "ID";
            LookUpEdit_TourID.Properties.PopulateColumns();
            foreach (LookUpColumnInfo column in LookUpEdit_TourID.Properties.Columns)
            {
                column.Visible = false;
            }

            // TODO: Fix this
/*            LookUpEdit_TourID.Properties.Columns["Name"].Visible = true;
*/
            // Customers
            gridView_Customers.GridControl.DataSource = customersBL;
            gridView_Customers.PopulateColumns();
            gridView_Customers.OptionsBehavior.Editable = false;

            // TODO: Fix this
/*            gridView_Customers.Columns["TourGroupDetails"].Visible = false;
*/
            // Staffs
            gridView_Staffs.GridControl.DataSource = staffsBL;
            gridView_Staffs.PopulateColumns();
            gridView_Staffs.OptionsBehavior.Editable = false;

            // TODO: Fix this
/*            gridView_Staffs.Columns["TourGroupStaffs"].Visible = false;
*/
            // TourGroupDetails
            ListBoxControl_TourGroupDetails.DataSource = tourGroupDetailsBL;

            // TourGroupStaffs
            gridView_TourGroupStaffs.GridControl.DataSource = tourGroupStaffsBL;
            gridView_TourGroupStaffs.PopulateColumns();
            foreach (GridColumn column in gridView_TourGroupStaffs.Columns)
            {
                column.Visible = false;
            }
            gridView_TourGroupStaffs.Columns["Staff"].VisibleIndex = 0;
            gridView_TourGroupStaffs.Columns["StaffTask"].VisibleIndex = 1;
            gridView_TourGroupStaffs.Columns["Staff"].Visible = true;
            gridView_TourGroupStaffs.Columns["StaffTask"].Visible = true;
            RepositoryItemLookUpEdit lookUpEdit_TourGroupStaff_StaffTask = new RepositoryItemLookUpEdit();
            lookUpEdit_TourGroupStaff_StaffTask.DataSource = TourGroupStaff.Tasks;
            GridControl_TourGroupStaffs.RepositoryItems.Add(lookUpEdit_TourGroupStaff_StaffTask);
            gridView_TourGroupStaffs.Columns["StaffTask"].ColumnEdit = lookUpEdit_TourGroupStaff_StaffTask;

            // TourGroupCosts
            gridView_TourGroupCosts.GridControl.DataSource = tourGroupCostsBL;
            gridView_TourGroupCosts.PopulateColumns();
            gridView_TourGroupCosts.Columns["TourGroup"].Visible = false;
            gridView_TourGroupCosts.Columns["TourGroupID"].Visible = false;
            gridView_TourGroupCosts.Columns["CostType"].Visible = false;

            // CostTypes
            RepositoryItemLookUpEdit lookUpEdit_TourGroupCost_CostType = new RepositoryItemLookUpEdit();
            lookUpEdit_TourGroupCost_CostType.DataSource = costTypesBL;
            lookUpEdit_TourGroupCost_CostType.ValueMember = "ID";
            lookUpEdit_TourGroupCost_CostType.DisplayMember = "Name";
            lookUpEdit_TourGroupCost_CostType.PopulateColumns();
            lookUpEdit_TourGroupCost_CostType.Columns["TourGroupCosts"].Visible = false;
            GridControl_TourGroupCosts.RepositoryItems.Add(lookUpEdit_TourGroupCost_CostType);
            gridView_TourGroupCosts.Columns["CostTypeID"].ColumnEdit = lookUpEdit_TourGroupCost_CostType;

        }

        private void RefreshDataSources()
        {
            // Tours
            LookUpEdit_TourID.Properties.DataSource = toursBL;

            // Customers
            gridView_Customers.GridControl.DataSource = customersBL;

            // Staffs
            gridView_Staffs.GridControl.DataSource = staffsBL;

            // TourGroupDetails
            ListBoxControl_TourGroupDetails.DataSource = tourGroupDetailsBL;

            // TourGroupStaffs
            gridView_TourGroupStaffs.GridControl.DataSource = tourGroupStaffsBL;

            // TourGroupCosts
            gridView_TourGroupCosts.GridControl.DataSource = tourGroupCostsBL;
        }

        // States
        private Customer getSelectedCustomer()
        {
            return (Customer)gridView_Customers.GetFocusedRow();
        }

        private Staff getSelectedStaff()
        {
            return (Staff)gridView_Staffs.GetFocusedRow();
        }

        // Functions

        /// <param name="tourGroup">A tour group to validate</param>
        /// <returns>Returns true if validated</returns>
        public bool ValidateForm()
        {
            TourGroup tourGroup = _item;

            try
            {
                // validate tour group name
                if (string.IsNullOrEmpty(tourGroup.Name))
                {
                    throw new ArgumentException("Tên Đoàn rỗng.", "TourGroup.Name");
                }

                // validate tour 
                if (tourGroup.TourID == 0)
                {
                    throw new ArgumentException("Tour của Đoàn rỗng.", "TourGroup.Tour");
                }

                // valitdate datetime
    /*            if (DateTime.Compare(tourGroup.DateStart.Date, DateTime.Now.Date) < 0)
                {
                    errorMsg = "Start date is not valid";
                    Console.WriteLine(errorMsg);
                    return false;
                }
    */
                // valitdate datetime
                if (DateTime.Compare(tourGroup.DateStart.Date, tourGroup.DateEnd.Date) > 0)
                {
                    throw new ArgumentException("Ngày bắt đầu và ngày kết thúc không hợp lệ.", "TourGroup.Date");
                }
            } catch (ArgumentException e)
            {
                string message = e.Message.Split(Environment.NewLine.ToCharArray())[0];
                MessageBox.Show(message, "Lỗi dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // TODO: Focus on controls

                return false;
            }

            return true;
        }

        // Event Handlers

        private void handleSaveTourGroup()
        {
            if (ValidateForm() == false)
            {
                return;
            }

            if (isUpdate)
            {
                _item.Update();
            } else
            {
                var temp = _item.Create();

/*                var temp = TourGroupBUS.CreateOne(_item);
*/
                if (temp.ID != 0)   // tourGroup added to Database => ID changed from 0
                {
                    isUpdate = true;
                }
            }

            InitializeDataSources();    // Reload data with updated data
        }

        private void handleCloseEdit()
        {
            Dispose();
        }

        private void handleAddTourGroupDetailToTourGroup()
        {
            Customer customer = getSelectedCustomer();

            if (customer == null)
            {
                return;
            }

            _item.AddTourGroupDetailToTourGroup(customer);
            //((BindingList<Customer>)gridView_Customers.GridControl.DataSource).Remove(customer);
        }

        private void handleDeleteTourGroupDetailFromTourGroup()
        {
            TourGroupDetail tourGroupDetail = (TourGroupDetail)ListBoxControl_TourGroupDetails.SelectedItem;
            if (tourGroupDetail == null)
            {
                return;
            }
            //Customer customer = tourGroupDetail.Customer;

            _item.DeleteTourGroupDetailFromTourGroup(tourGroupDetail);

            // ((BindingList<Customer>)gridView_Customers.GridControl.DataSource).Add(customer);
        }

        private void handleAddTourGroupStaffToTourGroup()
        {
            Staff staff = getSelectedStaff();
            if (staff == null)
            {
                return;
            }

            Console.WriteLine(_item.TourGroupStaffs.Count);
            _item.AddTourGroupStaffToTourGroup(staff);
            gridView_TourGroupStaffs.GridControl.RefreshDataSource();
            Console.WriteLine(_item.TourGroupStaffs.Count);

            //((BindingList<Staff>)gridView_Staffs.GridControl.DataSource).Remove(staff);
        }

        private void handleDeleteTourGroupStaffFromTourGroup()
        {
            if (gridView_TourGroupStaffs.FocusedRowHandle < 0)
            {
                return;
            }
            ICollection<TourGroupStaff> tourGroupStaffs = _item.TourGroupStaffs;
            TourGroupStaff tourGroupStaff = tourGroupStaffs.ElementAt(gridView_TourGroupStaffs.FocusedRowHandle);
            if (tourGroupStaff == null)
            {
                return;
            }
            //Staff staff = tourGroupDetail.Staff;

            Console.WriteLine(_item.TourGroupStaffs.Count);
            _item.DeleteTourGroupStaffFromTourGroup(tourGroupStaff);
            gridView_TourGroupStaffs.GridControl.RefreshDataSource();
            Console.WriteLine(_item.TourGroupStaffs.Count);

            // ((BindingList<Staff>)gridView_Staffs.GridControl.DataSource).Add(staff);

        }

        private void handleAddTourGroupCostToTourGroup()
        {
            _item.CreateTourGroupCostForTour();
            gridView_TourGroupCosts.GridControl.RefreshDataSource();
        }

        private void handleDeleteTourGroupCostFromTourGroup()
        {
            if (gridView_TourGroupCosts.FocusedRowHandle < 0)
            {
                return;
            }
            ICollection<TourGroupCost> tourGroupCosts = _item.TourGroupCosts;
            TourGroupCost tourGroupCost = tourGroupCosts.ElementAt(gridView_TourGroupCosts.FocusedRowHandle);

            _item.DeleteTourGroupCostFromTour(tourGroupCost);
            gridView_TourGroupCosts.GridControl.RefreshDataSource();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveTourGroup();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveTourGroup();
            handleCloseEdit();
        }

        private void button_AddTourDetail_Click(object sender, EventArgs e)
        {
            handleAddTourGroupDetailToTourGroup();
        }

        private void button_DeleteTourGroupDetail_Click(object sender, EventArgs e)
        {
            handleDeleteTourGroupDetailFromTourGroup();
        }

        private void Button_AddTourGroupStaff_Click(object sender, EventArgs e)
        {
            handleAddTourGroupStaffToTourGroup();
        }

        private void Button_DeleteTourStaff_Click(object sender, EventArgs e)
        {
            handleDeleteTourGroupStaffFromTourGroup();
        }

        private void Button_AddTourGroupCost_Click(object sender, EventArgs e)
        {
            handleAddTourGroupCostToTourGroup();
        }

        private void Button_DeleteTourGroupCost_Click(object sender, EventArgs e)
        {
            handleDeleteTourGroupCostFromTourGroup();
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            RefreshDataSources();
        }
    }
}
