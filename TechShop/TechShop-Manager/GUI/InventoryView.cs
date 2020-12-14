using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    public partial class InventoryView : DevExpress.XtraEditors.XtraUserControl
    {
        enum Page
        {
            Imports,
            Orders,
        }

        public InventoryView()
        {
            InitializeComponent();
            ConfigureControls();
            InitializeDataSources();
        }

        private void ConfigureControls()
        {
            gridView_Imports.OptionsBehavior.Editable = false;
            gridView_Orders.OptionsBehavior.Editable = false;
        }

        private Page getCurrentPage()
        {
            Page curPage = Page.Imports;
            int tabIndex = xtraTabControl_Imports.SelectedTabPageIndex;
            switch (tabIndex)
            {
                case 0:
                    {
                        curPage = Page.Imports; break;
                    }
                case 1:
                    {
                        curPage = Page.Orders; break;
                    }
            }

            return curPage;
        }

        private void InitializeDataSources()
        {   
            switch (getCurrentPage())
            {
                case Page.Imports:
                    {
                        InitializeDataSources_Imports();
                        break;
                    }
                case Page.Orders:
                    {
                        InitializeDataSources_Orders();
                        break;
                    }
            }
        }

        private void InitializeDataSources_Imports()
        {
            // Data fetch
            BindingList<Import> list = new BindingList<Import>(
                // Import.GetAll()
            );

            // UI changes
            gridControl_Imports.DataSource = list;
            gridControl_Imports.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }

        private void InitializeDataSources_Orders()
        {
            // Data fetch
            BindingList<Order> list = new BindingList<Order>(
                // Order.GetAll()
            );

            // UI changes
            gridControl_Orders.DataSource = list;
            gridControl_Orders.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }
        
        // Event Handlers

        private void handleNewImport()
        {
            EditImportView editImportView = new EditImportView();
            editImportView.ShowDialog(this);
        }

        private void handleEditImport()
        {
            Import selectedImport = (Import)gridView_Imports.GetFocusedRow();

            if (selectedImport == null)
            {
                return;
            }

            // EditImportView editImportView = new EditImportView(selectedImport);
            // editImportView.ShowDialog(this);
        }

        private void handleDeleteImport()
        {
            Import selectedImport = (Import)gridView_Imports.GetFocusedRow();

            if (selectedImport == null)
            {
                return;
            }

            // Import.DeleteOne(selectedImport.ID);
        }

        private void handleNewOrder()
        {
            // EditOrderView editOrderView = new EditOrderView();
            // editOrderView.ShowDialog(this);
        }

        private void handleEditOrder()
        {
            Order selectedOrder = (Order)gridView_Orders.GetFocusedRow();

            if (selectedOrder == null)
            {
                return;
            }

            // EditOrderView editOrderView = new EditOrderView(selectedOrder);
            // editOrderView.ShowDialog(this);
        }

        private void handleDeleteOrder() { 
            Order selectedOrder = (Order)gridView_Orders.GetFocusedRow();

            if (selectedOrder == null) {
                return;
            }

            // Order.DeleteOne(selectedOrder.ID);
        }

        private void handleUpdateSelected()
        {
            object selectedItem = null;
            switch (getCurrentPage())
            {
                case Page.Imports:
                    {
                        selectedItem = gridView_Imports.GetFocusedRow();
                        bbiNew.Enabled = true;
                        bbiEdit.Enabled = selectedItem != null;
                        bbiDelete.Enabled = selectedItem != null;
                        break;
                    }
                case Page.Orders:
                    {
                        selectedItem = gridView_Orders.GetFocusedRow();
                        bbiNew.Enabled = true;
                        bbiEdit.Enabled = selectedItem != null;
                        bbiDelete.Enabled = selectedItem != null;
                        break;
                    }
            }
        }
        
        // Events

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (getCurrentPage())
            {
                case Page.Imports:
                    {
                        handleNewImport();
                        break;
                    }
                case Page.Orders:
                    {
                        handleNewOrder();
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
                case Page.Imports:
                    {
                        handleEditImport();
                        break;
                    }
                case Page.Orders:
                    {
                        handleEditOrder();
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
                case Page.Imports: {
                        DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa tour du lịch này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            handleDeleteImport();
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case Page.Orders: {
                        DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa đoàn tour du lịch này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            handleDeleteOrder();
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

        private void xtraTabControl_Imports_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeDataSources();
            handleUpdateSelected();
        }
    }
}