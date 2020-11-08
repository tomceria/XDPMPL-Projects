using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.GUI
{
    public partial class ManageView : DevExpress.XtraEditors.XtraUserControl
    {
        enum Page
        {
            Tours,
            TourGroups,
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
            gridView_Tours.OptionsBehavior.Editable = false;
            gridView_TourGroups.OptionsBehavior.Editable = false;
            gridView_Customers.OptionsBehavior.Editable = false;
            gridView_Customers.PopulateColumns();
            gridView_Customers.Columns["TourGroupDetails"].Visible = false;
        }

        private Page getCurrentPage()
        {
            Page curPage = Page.Tours;
            int tabIndex = xtraTabControl_Tours.SelectedTabPageIndex;
            switch (tabIndex)
            {
                case 0:
                    {
                        curPage = Page.Tours; break;
                    }
                case 1:
                    {
                        curPage = Page.TourGroups; break;
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
                case Page.Tours:
                    {
                        InitializeDataSources_Tours();
                        break;
                    }
                case Page.TourGroups:
                    {
                        InitializeDataSources_TourGroups();
                        break;
                    }
                case Page.Customers:
                    {
                        InitializeDataSources_Customers();
                        break;
                    }
            }
        }

        private void InitializeDataSources_Tours()
        {
            // Data fetch
            BindingList<Tour> list = new BindingList<Tour>(
                Tour.GetAll()
            );
            //Mapping tour price
            foreach( Tour tour in list)
            {
                tour.CurrentPrice = Tour.GetTourPriceOrPriceRef(tour.ID, DateTime.Now);
            }

            // UI changes
            gridControl_Tours.DataSource = list;
            gridControl_Tours.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }

        private void InitializeDataSources_TourGroups()
        {
            // Data fetch
            BindingList<TourGroup> list = new BindingList<TourGroup>(
                TourGroup.GetAll()
            );

            // UI changes
            gridControl_TourGroups.DataSource = list;
            gridControl_TourGroups.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }
        
        private void InitializeDataSources_Customers()
        {
            // Data fetch
            BindingList<Customer> list = new BindingList<Customer>(
                Customer.GetAll()
            );

            // UI changes
            gridControl_Customers.DataSource = list;
            gridControl_Customers.RefreshDataSource();
            bsiListCount.Caption = $"{list.Count} items";
        }

        // Event Handlers

        private void handleNewTour()
        {
            EditTourView editTourView = new EditTourView();
            editTourView.ShowDialog(this);
        }

        private void handleEditTour()
        {
            Tour selectedTour = (Tour)gridView_Tours.GetFocusedRow();

            if (selectedTour == null)
            {
                return;
            }

            EditTourView editTourView = new EditTourView(selectedTour);
            editTourView.ShowDialog(this);
        }

        private void handleDeleteTour()
        {
            Tour selectedTour = (Tour)gridView_Tours.GetFocusedRow();

            if (selectedTour == null)
            {
                return;
            }

            Tour.DeleteOne(selectedTour.ID);
        }

        private void handleNewTourGroup()
        {
            EditTourGroupView editTourGroupView = new EditTourGroupView();
            editTourGroupView.ShowDialog(this);
        }

        private void handleEditTourGroup()
        {
            TourGroup selectedTourGroup = (TourGroup)gridView_TourGroups.GetFocusedRow();

            if (selectedTourGroup == null)
            {
                return;
            }

            EditTourGroupView editTourGroupView = new EditTourGroupView(selectedTourGroup);
            editTourGroupView.ShowDialog(this);
        }

        private void handleDeleteTourGroup() { 
            TourGroup selectedTourGroup = (TourGroup)gridView_TourGroups.GetFocusedRow();

            if (selectedTourGroup == null) {
                return;
            }

            TourGroup.DeleteOne(selectedTourGroup.ID);
        }

        private void handleUpdateSelected()
        {
            object selectedItem = null;
            switch (getCurrentPage())
            {
                case Page.Tours:
                    {
                        selectedItem = gridView_Tours.GetFocusedRow();
                        bbiNew.Enabled = true;
                        bbiEdit.Enabled = selectedItem != null;
                        bbiDelete.Enabled = selectedItem != null;
                        break;
                    }
                case Page.TourGroups:
                    {
                        selectedItem = gridView_TourGroups.GetFocusedRow();
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
                case Page.Tours:
                    {
                        handleNewTour();
                        break;
                    }
                case Page.TourGroups:
                    {
                        handleNewTourGroup();
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
                case Page.Tours:
                    {
                        handleEditTour();
                        break;
                    }
                case Page.TourGroups:
                    {
                        handleEditTourGroup();
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
                case Page.Tours: {
                        DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa tour du lịch này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            handleDeleteTour();
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case Page.TourGroups: {
                        DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa đoàn tour du lịch này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            handleDeleteTourGroup();
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

        private void xtraTabControl_Tours_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeDataSources();
            handleUpdateSelected();
        }
    }
}