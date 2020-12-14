using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    public partial class ManageView : DevExpress.XtraEditors.XtraUserControl
    {
        enum Page
        {
            Products,
            Combos,
            Customers
        }

        public ManageView()
        {
            InitializeComponent();
            ConfigureControls();
            InitializeDataSources();
        }

        private void ConfigureControls()
        {
            gridView_Products.OptionsBehavior.Editable = false;
            gridView_Combos.OptionsBehavior.Editable = false;
            gridView_Customers.OptionsBehavior.Editable = false;
            gridView_Customers.PopulateColumns();
        }

        private Page getCurrentPage()
        {
            Page curPage = Page.Products;
            int tabIndex = xtraTabControl_Products.SelectedTabPageIndex;
            switch (tabIndex)
            {
                case 0:
                    {
                        curPage = Page.Products; break;
                    }
                case 1:
                    {
                        curPage = Page.Combos; break;
                    }
                case 2:
                    {
                        curPage = Page.Customers; break;
                    }
            }

            return curPage;
        }

        private void InitializeDataSources()
        {   
            switch (getCurrentPage())
            {
                case Page.Products:
                    {
                        InitializeDataSources_Products();
                        break;
                    }
                case Page.Combos:
                    {
                        InitializeDataSources_Combos();
                        break;
                    }
                case Page.Customers:
                    {
                        InitializeDataSources_Customers();
                        break;
                    }
            }
        }

        private void InitializeDataSources_Products()
        {
            // Data fetch
            BindingList<Product> list = new BindingList<Product>(
                // Product.GetAll()
            );

            // UI changes
            gridControl_Products.DataSource = list;
            gridControl_Products.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }

        private void InitializeDataSources_Combos()
        {
            // Data fetch
            BindingList<Combo> list = new BindingList<Combo>(
                // Combo.GetAll()
            );

            // UI changes
            gridControl_Combos.DataSource = list;
            gridControl_Combos.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }
        
        private void InitializeDataSources_Customers()
        {
            // Data fetch
            BindingList<Customer> list = new BindingList<Customer>(
                // Customer.GetAll()
            );

            // UI changes
            gridControl_Customers.DataSource = list;
            gridControl_Customers.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }

        // Event Handlers

        private void handleNewProduct()
        {
            // EditProductView editProductView = new EditProductView();
            // editProductView.ShowDialog(this);
        }

        private void handleEditProduct()
        {
            Product selectedProduct = (Product)gridView_Products.GetFocusedRow();

            if (selectedProduct == null)
            {
                return;
            }

            // EditProductView editProductView = new EditProductView(selectedProduct);
            // editProductView.ShowDialog(this);
        }

        private void handleDeleteProduct()
        {
            Product selectedProduct = (Product)gridView_Products.GetFocusedRow();

            if (selectedProduct == null)
            {
                return;
            }

            // Product.DeleteOne(selectedProduct.ID);
        }

        private void handleNewCombo()
        {
            // EditComboView editComboView = new EditComboView();
            // editComboView.ShowDialog(this);
        }

        private void handleEditCombo()
        {
            Combo selectedCombo = (Combo)gridView_Combos.GetFocusedRow();

            if (selectedCombo == null)
            {
                return;
            }

            // EditComboView editComboView = new EditComboView(selectedCombo);
            // editComboView.ShowDialog(this);
        }

        private void handleDeleteCombo() { 
            Combo selectedCombo = (Combo)gridView_Combos.GetFocusedRow();

            if (selectedCombo == null) {
                return;
            }

            // Combo.DeleteOne(selectedCombo.ID);
        }

        private void handleUpdateSelected()
        {
            object selectedItem = null;
            switch (getCurrentPage())
            {
                case Page.Products:
                    {
                        selectedItem = gridView_Products.GetFocusedRow();
                        bbiNew.Enabled = true;
                        bbiEdit.Enabled = selectedItem != null;
                        bbiDelete.Enabled = selectedItem != null;
                        break;
                    }
                case Page.Combos:
                    {
                        selectedItem = gridView_Combos.GetFocusedRow();
                        bbiNew.Enabled = true;
                        bbiEdit.Enabled = selectedItem != null;
                        bbiDelete.Enabled = selectedItem != null;
                        break;
                    }
                case Page.Customers:
                    {
                        selectedItem = null;    // Customers are uneditable
                        bbiNew.Enabled = false;
                        bbiEdit.Enabled = false;
                        bbiDelete.Enabled = false;
                        break;
                    }
            }
        }
        
        // Events

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (getCurrentPage())
            {
                case Page.Products:
                    {
                        handleNewProduct();
                        break;
                    }
                case Page.Combos:
                    {
                        handleNewCombo();
                        break;
                    }
            }

            // Post-Disposal of Dialog
            InitializeDataSources();
            handleUpdateSelected();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (getCurrentPage())
            {
                case Page.Products:
                    {
                        handleEditProduct();
                        break;
                    }
                case Page.Combos:
                    {
                        handleEditCombo();
                        break;
                    }
            }

            // Post-Disposal of Dialog
            InitializeDataSources();
            handleUpdateSelected();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (getCurrentPage()) {
                case Page.Products: {
                        DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa tour du lịch này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            handleDeleteProduct();
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case Page.Combos: {
                        DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa đoàn tour du lịch này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            handleDeleteCombo();
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }

            // Refresh
            InitializeDataSources();
            handleUpdateSelected();
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            handleUpdateSelected();
        }

        private void xtraTabControl_Products_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeDataSources();
            handleUpdateSelected();
        }
    }
}
