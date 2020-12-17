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
    public partial class EditComboView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Combo _item;
        private List<ComboDetail> _comboDetails;
        private List<Product> _products;
        private bool isUpdate = false;

        public EditComboView() // New Combo
        {
            InitializeComponent();
            _item = new Combo();
            ConfigureControls();
            InitializeDataSources();
        }

        public EditComboView(Combo combo) // Edit Combo
        {
            InitializeComponent();
            _item = combo;
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
            Combo item = Combo.GetOne(_item.Id);

            if (item == null)
            {
                item = _item; // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditViewTemplate(Combo combo)
            }
            else
            {
                _item = item;
            }

            // Data binding
            _products = Product.GetAll();
            BindingList<Combo> itemBL = new BindingList<Combo>(new List<Combo>() {item});
            BindingList<ComboDetail> comboDetailsBL = new BindingList<ComboDetail>(
                item.ComboDetails != null ? item.ComboDetails.ToList() : new List<ComboDetail>()
            );
            BindingList<Product> productsBL = new BindingList<Product>(
                _products
            );

            dataLayoutControl_Combo.DataSource = itemBL;

            gridView_ComboDetails.GridControl.DataSource = comboDetailsBL;
            gridView_ComboDetails.PopulateColumns();
            gridView_ComboDetails.Columns["Combo"].Visible = false;
            gridView_ComboDetails.Columns["ProductId"].Visible = false;
            gridView_ComboDetails.Columns["ComboId"].Visible = false;
            gridView_ComboDetails.Columns["Product"].VisibleIndex = 0;
            gridView_ComboDetails.Columns["Quantity"].VisibleIndex = 1;

            gridView_Products.GridControl.DataSource = productsBL;
            gridView_Products.PopulateColumns();
            gridView_Products.Columns["Id"].Visible = false;
            gridView_Products.Columns["Slug"].Visible = false;
            gridView_Products.Columns["Description"].Visible = false;
            gridView_Products.Columns["ProductTypeId"].Visible = false;
            gridView_Products.Columns["IsHidden"].Visible = false;
            gridView_Products.Columns["OrderDetails"].Visible = false;
            gridView_Products.Columns["ComboDetails"].Visible = false;
            gridView_Products.OptionsView.ColumnAutoWidth = false;
        }

        private Combo getItemState()
        {
            return _item;

            /*            return ((BindingList<Combo>) dataLayoutControl_Combo.DataSource).ElementAt(0);
            */
        }

        private bool ValidateForm()
        {
            Combo item = _item;

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
        //Refresh
        private void RefreshData()
        {

        }

        // Event Handlers

        private void handleSaveCombo()
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

                if (temp.Id != 0) // comboGroup added to Database => ID changed from 0
                {
                    isUpdate = true;
                }
            }

            MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ConfigureControls();
            InitializeDataSources();
        }

        private void handleDeleteCombo()
        {
            Combo.DeleteOne(_item.Id);

            // close window
            Dispose();
        }

        private void handleAddComboDetail()
        {

            Product selectedProduct = _products.ElementAt(gridView_Products.FocusedRowHandle);
            if(getItemState().ComboDetails.First(o => o.ProductId == selectedProduct.Id) != null)
            {
                return;
            }
            ComboDetail selectedComboDetail = new ComboDetail
            {
                ProductId = selectedProduct.Id,
                ComboId = _item.Id,
                Quantity = 1

            };
            getItemState().AddComboDetail(selectedComboDetail);
            InitializeDataSources();
            gridView_ComboDetails.RefreshData();
        }        
        
        private void handleDeleteComboDetail()
        {
            ComboDetail selectedComboDetail = getItemState().ComboDetails.ElementAt(gridView_ComboDetails.FocusedRowHandle);
            getItemState().DeleteComboDetail(selectedComboDetail);
            InitializeDataSources();
            gridView_ComboDetails.RefreshData();
        }

        private void handleCloseEdit()
        {
            //Revert changes when click close button
            Combo.RevertChanges();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveCombo();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa combo này?\nMọi dữ liệu liên quan sẽ bị xoá.",
                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                handleDeleteCombo();
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

        private void btnAddComboDetail_ItemClick(object sender, EventArgs e)
        {
            handleAddComboDetail();

        }

        private void btnDeleteComboDetail_ItemClick(object sender, EventArgs e)
        {
            handleDeleteComboDetail();
        }
    }
}