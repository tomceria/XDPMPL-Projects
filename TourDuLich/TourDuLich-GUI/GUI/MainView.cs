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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using TourDuLich_GUI.BUS;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace TourDuLich_GUI.GUI
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        enum Page
        {
            Tours,
            TourGroups,
            Customers
        }

        public MainView()
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
            }
        }

        private void InitializeDataSources_Tours()
        {
            // TODO: Remove ASYNC

            // Prefetch UI changes
            gridView_Tours.ShowLoadingPanel();

            // Data fetch
            BindingList<Tour> list = new BindingList<Tour>(
                Tour.GetAll()
            );

            // UI changes
            gridView_Tours.HideLoadingPanel();
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

            Tour.DeleteOne(selectedTour);
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

        private void handleDeleteTourGroup( ) { 
            TourGroup selectedTourGroup = (TourGroup)gridView_TourGroups.GetFocusedRow();

            if (selectedTourGroup == null) {
                return;
            }

            TourGroup.DeleteOne(selectedTourGroup.ID);
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
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (getCurrentPage()) {
                case Page.Tours: {
                        handleDeleteTour();
                        break;
                    }
                case Page.TourGroups: {
                        handleDeleteTourGroup();
                        break;
                    }
            }

            // Refresh
            InitializeDataSources();
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object selectedItem = null;
            switch (getCurrentPage())
            {
                case Page.Tours:
                    {
                        selectedItem = gridView_Tours.GetFocusedRow();
                        break;
                    }
                case Page.TourGroups:
                    {
                        selectedItem = gridView_TourGroups.GetFocusedRow();
                        break;
                    }
                case Page.Customers:
                    {
                        selectedItem = gridView_TourGroups.GetFocusedRow();
                        break;
                    }
            }
            bool selectedExists = selectedItem != null;

            bbiEdit.Enabled = selectedExists;
            bbiDelete.Enabled = selectedExists;
        }

        private void xtraTabControl_Tours_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitializeDataSources();
        }
    }
}