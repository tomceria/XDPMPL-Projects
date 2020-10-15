using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraLayout;
using TourDuLich_GUI.Models;
using TourDuLich_GUI.BUS;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace TourDuLich_GUI.GUI
{
    public partial class EditTourGroupView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TourGroupBUS TourGroupBUS = new TourGroupBUS();
        TourBUS TourBUS = new TourBUS();
        CustomerBUS CustomerBUS = new CustomerBUS();
        StaffBUS StaffBUS = new StaffBUS();
        CostTypeBUS CostTypeBUS = new CostTypeBUS();

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

        private async void InitializeDataSources()
        {
            // Data fetch
            TourGroup item = TourGroupBUS.GetOne(_item.ID);
            List<Tour> tours = await TourBUS.GetAll();
            List<Customer> customers = CustomerBUS.GetAll();
            List<Staff> staffs = StaffBUS.GetAll();
            List<CostType> costTypes = CostTypeBUS.GetAll();

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
            if (item.TourGroupCosts != null)
            {
                _tourGroupCosts = item.TourGroupCosts.ToList();
            } else
            {
                _tourGroupCosts = new List<TourGroupCost>();
            }
            tourGroupCostsBL = new BindingList<TourGroupCost>(_tourGroupCosts);
            // TourGroup.TourGroupDetails
            if (item.TourGroupDetails != null)
            {
                _tourGroupDetails = item.TourGroupDetails.ToList();
            } else
            {
                _tourGroupDetails = new List<TourGroupDetail>();
                item.TourGroupDetails = _tourGroupDetails;
            }
            tourGroupDetailsBL = new BindingList<TourGroupDetail>(_tourGroupDetails);
            // TourGroup.TourGroupStaffs
            if (item.TourGroupStaffs != null)
            {
                _tourGroupStaffs = item.TourGroupStaffs.ToList();
            } else
            {
                _tourGroupStaffs = new List<TourGroupStaff>();
                item.TourGroupStaffs = _tourGroupStaffs;
            }
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
            LookUpEdit_TourID.Properties.Columns["Name"].Visible = true;

            // Customers
            gridView_Customers.GridControl.DataSource = customersBL;
            gridView_Customers.PopulateColumns();
            gridView_Customers.OptionsBehavior.Editable = false;
            gridView_Customers.Columns["TourGroupDetails"].Visible = false;

            // Staffs
            gridView_Staffs.GridControl.DataSource = staffsBL;
            gridView_Staffs.PopulateColumns();
            gridView_Staffs.OptionsBehavior.Editable = false;
            gridView_Staffs.Columns["TourGroupStaffs"].Visible = false;

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

        // Event Handlers

        private void handleSaveTourGroup()
        {
            if (isUpdate)
            {
                TourGroupBUS.UpdateOne(_item);
            } else
            {
                var temp = TourGroupBUS.CreateOne(_item);
                if (temp.ID != 0)
                {
                    isUpdate = true;
                }
            }
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

            TourGroupBUS.AddTourGroupDetailToTourGroup(_item, customer);
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

            TourGroupBUS.DeleteTourGroupDetailFromTourGroup(_item, tourGroupDetail);

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
            TourGroupBUS.AddTourGroupStaffToTourGroup(_item, staff);
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
            TourGroupBUS.DeleteTourGroupStaffFromTourGroup(_item, tourGroupStaff);
            gridView_TourGroupStaffs.GridControl.RefreshDataSource();
            Console.WriteLine(_item.TourGroupStaffs.Count);

            // ((BindingList<Staff>)gridView_Staffs.GridControl.DataSource).Add(staff);

        }

        private void handleAddTourGroupCostToTourGroup()
        {
            TourGroupBUS.CreateTourGroupCostForTour(_item);
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

            TourGroupBUS.DeleteTourGroupCostFromTour(tourGroupCost);
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
