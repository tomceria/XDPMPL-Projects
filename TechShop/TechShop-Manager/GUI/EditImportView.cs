using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;
using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    public partial class EditImportView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Import _item;
        private bool isUpdate = false;

        public EditImportView() // New Import
        {
            InitializeComponent();
            _item = new Import();
            ConfigureControls();
            InitializeDataSources();
        }

        public EditImportView(Import tour) // Edit Import
        {
            InitializeComponent();
            _item = tour;
            isUpdate = true;
            ConfigureControls();
            InitializeDataSources();
        }

        private void ConfigureControls()
        {
            bbiDelete.Enabled = isUpdate;
        }

        private void InitializeDataSources()
        {
            // Data fetch
            Import item = Import.GetOne(_item.Id);

            if (item == null)
            {
                item = _item; // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditImportView(Import tour)
            }
            else
            {
                _item = item;
            }

            // Data binding
            BindingList<Import> itemBL = new BindingList<Import>(new List<Import>() {item});

            BindingList<Product> productsBL = new BindingList<Product>(
                // Product.GetAll()
            );

            BindingList<ImportDetail> importDetailsBL = new BindingList<ImportDetail>(
                (item.ImportDetails != null) ? item.ImportDetails.ToList() : new List<ImportDetail>()
            );

            dataLayoutControl_Import.DataSource = itemBL;

            gridView_ImportDetails.GridControl.DataSource = importDetailsBL;
            gridView_ImportDetails.PopulateColumns();
            gridView_ImportDetails.Columns["ProductId"].Visible = false;
            gridView_ImportDetails.Columns["ImportId"].Visible = false;
            gridView_ImportDetails.Columns["Product"].Visible = false;
            gridView_ImportDetails.Columns["Import"].Visible = false;
            
            gridView_Products.GridControl.DataSource = productsBL;
            gridView_Products.OptionsView.ColumnAutoWidth = false;
            gridView_Products.PopulateColumns();
            gridView_Products.Columns["Id"].Visible = false;
            gridView_Products.Columns["Sku"].Visible = false;
            gridView_Products.Columns["Slug"].Visible = false;
            gridView_Products.Columns["Description"].Visible = false;
            gridView_Products.Columns["IsHidden"].Visible = false;
            gridView_Products.Columns["ProductType"].Visible = false;
            gridView_Products.Columns["OrderDetails"].Visible = false;
            gridView_Products.Columns["ComboDetails"].Visible = false;
        }

        private Import getItemState()
        {
            return _item;

            /*            return ((BindingList<Import>) dataLayoutControl_Import.DataSource).ElementAt(0);
            */
        }

        private bool ValidateForm()
        {
            Import item = _item;

            try
            {
            }
            catch (ArgumentException e)
            {
                string message = e.Message.Split(Environment.NewLine.ToCharArray())[0];
                MessageBox.Show(message, "Lỗi dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // TODO: Focus on controls

                return false;
            }

            return true;
        }

        // Event Handlers

        private void handleSaveImport()
        {
            // Validations
            if (ValidateForm() == false)
            {
                return;
            }

            if (isUpdate)
            {
                // _item.Update();
            }
            else
            {
                // var temp = _item.Create();

                // if (temp.Id != 0)   // tourGroup added to Database => ID changed from 0
                // {
                //     isUpdate = true;
                // }
            }

            MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ConfigureControls();
            InitializeDataSources();
        }

        private void handleDeleteImport()
        {
            // Import.DeleteOne(_item.Id);

            // close window
            Dispose();
        }

        private void handleCloseEdit()
        {
            //Revert changes when click close button
            // Import.RevertChanges();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveImport();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult res =
                MessageBox.Show("Bạn chắc chắn muốn xóa tour du lịch này?\nMọi dữ liệu liên quan sẽ bị xoá.",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                handleDeleteImport();
            }
        }

        private void tabbedDetails_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            InitializeDataSources(); // TODO: This works for some reasons?????
        }

        private void EditViewTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            handleCloseEdit();
        }
    }
}