using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using TourDuLich_GUI.Models;
using TourDuLich_GUI.BUS;
using System.Data.Entity;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

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
        private bool isUpdate = false;

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

            // TODO: REMOVE PLACEHOLDER
            item.TourGroupCosts = new List<TourGroupCost>()
            {
                new TourGroupCost() { CostType = costTypes.ElementAt(0) }
            };

            // Data binding
            BindingList<TourGroup> itemBL = new BindingList<TourGroup>( new List<TourGroup>() { item } );
            BindingList<Tour> toursBL = new BindingList<Tour>(tours);
            BindingList<Customer> customersBL = new BindingList<Customer>(customers);
            BindingList<Staff> staffsBL = new BindingList<Staff>(staffs);
            BindingList<CostType> costTypesBL = new BindingList<CostType>(costTypes);

            BindingList<TourGroupCost> tourGroupCostsBL = new BindingList<TourGroupCost>(
                (item.TourGroupCosts != null)
                    ? item.TourGroupCosts.ToList()
                    : new List<TourGroupCost>()
                );

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
            gridView_Customers.OptionsBehavior.ReadOnly = true;
            gridView_Customers.Columns["TourGroupDetails"].Visible = false;

            // Staffs
            gridView_Staffs.GridControl.DataSource = staffsBL;
            gridView_Customers.OptionsBehavior.ReadOnly = true;
            gridView_Staffs.Columns["TourGroupStaffs"].Visible = false;

            // TourGroupCosts
            gridView_TourGroupCosts.GridControl.DataSource = tourGroupCostsBL;

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

        private TourGroup getItemState()
        {
            return ((BindingList<TourGroup>)dataLayoutControl_TourGroup.DataSource).ElementAt(0);
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(getItemState().TourGroupCosts.ElementAt(0).Note);
            Console.WriteLine(getItemState().TourGroupCosts.ElementAt(0).CostType.Name);
        }
    }
}
