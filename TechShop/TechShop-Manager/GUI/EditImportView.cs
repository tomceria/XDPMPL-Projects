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
        private List<Product> _products = Product.GetAll();

        public EditImportView() // New Import
        {
            InitializeComponent();
            _item = new Import()
            {
                ImportDetails = new List<ImportDetail>()
            };
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
                _products
            );

            BindingList<ImportDetail> importDetailsBL = new BindingList<ImportDetail>(
                (item.ImportDetails != null) ? item.ImportDetails.ToList() : new List<ImportDetail>()
            );

            dataLayoutControl_Import.DataSource = itemBL;

            gridView_ImportDetails.GridControl.DataSource = importDetailsBL;
            gridView_ImportDetails.PopulateColumns();
            gridView_ImportDetails.Columns["ImportId"].Visible = false;
            gridView_ImportDetails.Columns["Import"].Visible = false;
            gridView_ImportDetails.Columns["ProductId"].VisibleIndex = 0;
            gridView_ImportDetails.Columns["Product"].VisibleIndex = 1;
            gridView_ImportDetails.Columns["Price"].VisibleIndex = 2;
            gridView_ImportDetails.Columns["Quantity"].VisibleIndex = 3;
            gridView_ImportDetails.Columns["ProductId"].OptionsColumn.AllowEdit = false;
            gridView_ImportDetails.Columns["Product"].OptionsColumn.AllowEdit = false;
            gridView_ImportDetails.Columns["Price"].OptionsColumn.AllowEdit = false;
            gridView_ImportDetails.Columns["Quantity"].OptionsColumn.AllowEdit = true;

            gridView_Products.GridControl.DataSource = productsBL;
            gridView_Products.OptionsView.ColumnAutoWidth = false;
            gridView_Products.PopulateColumns();
            gridView_Products.Columns["Sku"].Visible = false;
            gridView_Products.Columns["Slug"].Visible = false;
            gridView_Products.Columns["Description"].Visible = false;
            gridView_Products.Columns["IsHidden"].Visible = false;
            gridView_Products.Columns["ProductTypeId"].Visible = false;
            gridView_Products.Columns["OrderDetails"].Visible = false;
            gridView_Products.Columns["ComboDetails"].Visible = false;
            gridView_Products.Columns["QuantityLogs"].Visible = false;
            gridView_Products.OptionsBehavior.Editable = false;
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
                _item.Update();
            }
            else
            {
                var temp = _item.Add();

                if (temp.Id != 0) // tourGroup added to Database => ID changed from 0
                {
                    isUpdate = true;
                }
            }

            MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ConfigureControls();
            InitializeDataSources();
        }

        private void handleDeleteImport()
        {
            Import.DeleteOne(_item.Id);

            // close window
            Dispose();
        }

        private void handleAddImportDetail()
        {
            Product selectedProduct = _products.ElementAt(gridView_Products.FocusedRowHandle);

            if (
                _item.ImportDetails != null && selectedProduct != null &&
                _item.ImportDetails.FirstOrDefault(o => o.ProductId == selectedProduct.Id) != null
            )
            {
                return;
            }

            ImportDetail selectedImportDetail = new ImportDetail
            {
                ProductId = selectedProduct.Id,
                ImportId = getItemState().Id,
                Price = selectedProduct.Price,
                Quantity = 1
            };

            getItemState().ImportDetails.Add(selectedImportDetail);
            InitializeDataSources();
            gridView_ImportDetails.RefreshData();
        }

        private void handleDeleteImportDetail()
        {
            ImportDetail selectedImportDetail =
                getItemState().ImportDetails.ElementAt(gridView_ImportDetails.FocusedRowHandle);
            getItemState().ImportDetails.Remove(selectedImportDetail);
            InitializeDataSources();
            gridView_ImportDetails.RefreshData();
        }

        private void handleCloseEdit()
        {
            //Revert changes when click close button
            Import.RevertChanges();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveImport();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult res =
                MessageBox.Show("Bạn chắc chắn muốn xóa Phiếu nhập này?",
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

        private void btnAddImportDetail_ItemClick(object sender, EventArgs e)
        {
            handleAddImportDetail();
        }

        private void btnRemoveImportDetail_ItemClick(object sender, EventArgs e)
        {
            handleDeleteImportDetail();
        }
    }
}