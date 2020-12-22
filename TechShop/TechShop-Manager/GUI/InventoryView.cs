using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    public partial class InventoryView : DevExpress.XtraEditors.XtraUserControl
    {
        enum Page
        {
            Imports,
            Orders
        }

        private Import selectedImport = new Import();
        private Order selectedOrder = new Order();

        public InventoryView()
        {
            InitializeComponent();
            ConfigureControls();
            InitializeDataSources();
            handleUpdateSelected();
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
                    curPage = Page.Imports;
                    break;
                }
                case 1:
                {
                    curPage = Page.Orders;
                    break;
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
                Import.GetAll()
            );

            // UI changes
            gridControl_Imports.DataSource = list;
            gridControl_Imports.RefreshDataSource();
            gridView_Imports.Columns["ImportDetails"].Visible = false;
            gridView_Imports.Columns["Date"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            gridView_Imports.OptionsBehavior.Editable = false;

            bsiListCount.Caption = $"{list.Count} items";
        }

        private void InitializeDataSources_Orders()
        {
            // Data fetch
            BindingList<Order> list = new BindingList<Order>(
                Order.GetAll()
            );

            // UI changes
            gridControl_Orders.DataSource = list;
            gridControl_Orders.RefreshDataSource();
            gridView_Orders.Columns["CustomerId"].Visible = false;
            gridView_Orders.Columns["OrderDetails"].Visible = false;
            gridView_Orders.Columns["Date"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            gridView_Orders.Columns["PaidPrice"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView_Orders.Columns["PaidPrice"].DisplayFormat.FormatString = "N0";
            gridView_Orders.OptionsView.ColumnAutoWidth = false;
            gridView_Orders.OptionsBehavior.Editable = false;

            bsiListCount.Caption = $"{list.Count} items";
        }

        private void InitializeDataSources_ImportDetails()
        {
            BindingList<ImportDetail> importDetailsBL = new BindingList<ImportDetail>(
                (selectedImport != null && selectedImport.ImportDetails != null)
                    ? selectedImport.ImportDetails.ToList()
                    : new List<ImportDetail>()
            );

            gridView_ImportDetails.GridControl.DataSource = importDetailsBL;
            gridView_ImportDetails.Columns["ImportId"].Visible = false;
            gridView_ImportDetails.Columns["Import"].Visible = false;
            gridView_ImportDetails.Columns["ProductId"].VisibleIndex = 0;
            gridView_ImportDetails.Columns["Product"].VisibleIndex = 1;
            gridView_ImportDetails.Columns["Price"].VisibleIndex = 2;
            gridView_ImportDetails.Columns["Quantity"].VisibleIndex = 3;
            gridView_ImportDetails.OptionsBehavior.Editable = false;
        }

        private void InitializeDataSources_OrderDetails()
        {
            BindingList<OrderDetail> orderDetailsBL = new BindingList<OrderDetail>(
                (selectedOrder != null && selectedOrder.OrderDetails != null) ? selectedOrder.OrderDetails.ToList() : new List<OrderDetail>()
            );

            gridView_OrderDetails.GridControl.DataSource = orderDetailsBL;
            gridView_OrderDetails.Columns["OrderId"].Visible = false;
            gridView_OrderDetails.Columns["Order"].Visible = false;
            gridView_OrderDetails.Columns["Price"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView_OrderDetails.Columns["Price"].DisplayFormat.FormatString = "N0";
            gridView_OrderDetails.Columns["ProductId"].VisibleIndex = 0;
            gridView_OrderDetails.Columns["Product"].VisibleIndex = 1;
            gridView_OrderDetails.Columns["Price"].VisibleIndex = 2;
            gridView_OrderDetails.Columns["Quantity"].VisibleIndex = 3;
            gridView_OrderDetails.OptionsBehavior.Editable = false;
        }

        // Event Handlers

        private void handleNewImport()
        {
            EditImportView editImportView = new EditImportView();
            editImportView.ShowDialog(this);
        }

        private void handleEditImport()
        {
            Import selectedImport = (Import) gridView_Imports.GetFocusedRow();

            if (selectedImport == null)
            {
                return;
            }

            EditImportView editImportView = new EditImportView(selectedImport);
            editImportView.ShowDialog(this);
        }

        private void handleDeleteImport()
        {
            Import selectedImport = (Import) gridView_Imports.GetFocusedRow();

            if (selectedImport == null)
            {
                return;
            }

            Import.DeleteOne(selectedImport.Id);
        }

        private void handleNewOrder()
        {
            // EditOrderView editOrderView = new EditOrderView();
            // editOrderView.ShowDialog(this);
        }

        private void handleEditOrder()
        {
            Order selectedOrder = (Order) gridView_Orders.GetFocusedRow();

            if (selectedOrder == null)
            {
                return;
            }

            // EditOrderView editOrderView = new EditOrderView(selectedOrder);
            // editOrderView.ShowDialog(this);
        }

        private void handleDeleteOrder()
        {
            Order selectedOrder = (Order) gridView_Orders.GetFocusedRow();

            if (selectedOrder == null)
            {
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

                    selectedImport = (Import) selectedItem;
                    InitializeDataSources_ImportDetails();
                    break;
                }
                case Page.Orders:
                {
                    selectedItem = gridView_Orders.GetFocusedRow();
                    bbiNew.Enabled = false;
                    bbiEdit.Enabled = false;
                    bbiDelete.Enabled = false;

                    selectedOrder = (Order) selectedItem;
                    InitializeDataSources_OrderDetails();
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
            switch (getCurrentPage())
            {
                case Page.Imports:
                {
                    DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa tour du lịch này?", "Xác nhận",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        handleDeleteImport();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    break;
                }
                case Page.Orders:
                {
                    DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa đoàn tour du lịch này?", "Xác nhận",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        handleDeleteOrder();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    break;
                }
            }

            // Refresh
            InitializeDataSources();
            handleUpdateSelected();
        }

        private void gridView_Imports_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            handleUpdateSelected();
        }

        private void gridView_Orders_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            handleUpdateSelected();
        }

        private void xtraTabControl_Imports_SelectedPageChanged(object sender,
            DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeDataSources();
            handleUpdateSelected();
        }
    }
}