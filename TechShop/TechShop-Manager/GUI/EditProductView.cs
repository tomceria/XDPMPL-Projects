using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;
using TechShop_Manager.BUS;
using TechShop_Manager.DAL;

namespace TechShop_Manager.GUI
{
    public partial class EditProductView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Product _item;
        private bool isUpdate = false;

        public EditProductView() // New Product
        {
            InitializeComponent();
            _item = new Product();
            ConfigureControls();
            InitializeDataSources();
        }

        public EditProductView(Product tour) // Edit Product
        {
            InitializeComponent();
            _item = tour;
            isUpdate = true;
            ConfigureControls();
            InitializeDataSources();
        }

        private void ConfigureControls() {
            bbiDelete.Enabled = isUpdate;
        }

        private void InitializeDataSources() {
            // Data fetch
            Product item = Product.GetOne(_item.Id);

            if (item == null) {
                item = _item; // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditViewTemplate(Product tour)
            } else {
                _item = item;
            }

            // Data binding
            BindingList<Product> itemBL = new BindingList<Product>(new List<Product>() { item });
            BindingList<ProductType> productTypesBL = new BindingList<ProductType>(
                ProductDAL.GetProductTypes()
            );

            dataLayoutControl_Product.DataSource = itemBL;
            
            LookUpEdit_ProductTypeId.Properties.DataSource = productTypesBL;
            LookUpEdit_ProductTypeId.Properties.DisplayMember = nameof(Product.Name);
            LookUpEdit_ProductTypeId.Properties.ValueMember = nameof(Product.Id);
            var valueNameColumnOfProductType =
                LookUpEdit_ProductTypeId.GetColumnValue(new LookUpColumnInfo(nameof(Product.Name)));
            if (valueNameColumnOfProductType == null)
            {
                LookUpEdit_ProductTypeId.Properties.Columns.Add(new LookUpColumnInfo(nameof(Product.Name)));
            }
        }

        private Product getItemState() {
            return _item;

            /*            return ((BindingList<Product>) dataLayoutControl_Product.DataSource).ElementAt(0);
            */
        }

        private bool ValidateForm()
        {
            Product item = _item;

            try
            {
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

        private void handleSaveProduct() {
            // Validations
            if (ValidateForm() == false)
            {
                return;
            }
            
            if (isUpdate) {
                _item.Update();
            } else {
                var temp = _item.Add();

                if (temp.Id != 0)   // tourGroup added to Database => ID changed from 0
                {
                    isUpdate = true;
                }
            }
            
            MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ConfigureControls();
            InitializeDataSources();
        }

        private void handleDeleteProduct() {
            Product.DeleteOne(_item.Id);
            
            // close window
            Dispose();
        }

        private void handleCloseEdit() {
            //Revert changes when click close button
            Product.RevertChanges();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleSaveProduct();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                handleDeleteProduct();
            }
        }

        private void tabbedDetails_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e) {
            InitializeDataSources(); // TODO: This works for some reasons?????
        }

        private void EditViewTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            handleCloseEdit();
        }
    }
}