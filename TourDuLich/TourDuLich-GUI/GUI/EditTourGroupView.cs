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

            // Data binding
            BindingList<TourGroup> itemBL = new BindingList<TourGroup>( new List<TourGroup>() { item } );
            BindingList<Tour> toursBL = new BindingList<Tour>(tours);
            dataLayoutControl_TourGroup.DataSource = itemBL;

            LookUpEdit_TourID.Properties.DataSource = toursBL;
            LookUpEdit_TourID.Properties.DisplayMember = "Name";
            LookUpEdit_TourID.Properties.ValueMember = "ID";
            LookUpEdit_TourID.Properties.PopulateColumns();
            foreach (LookUpColumnInfo column in LookUpEdit_TourID.Properties.Columns)
            {
                column.Visible = false;
            }
            LookUpEdit_TourID.Properties.Columns["Name"].Visible = true;

        }
    }
}
