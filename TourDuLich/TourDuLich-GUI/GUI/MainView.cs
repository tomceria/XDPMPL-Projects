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
using TourDuLich_GUI.Models;
using System.Data.Entity;
using TourDuLich_GUI.BUS;
using System.Collections.ObjectModel;
using TourDuLich_GUI.DAL;

namespace TourDuLich_GUI
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TourBUS TourBUS = new TourBUS();
        TourGroupBUS TourGroupBUS = new TourGroupBUS();

        enum Page
        {
            Tours,
            TourGroups
        }
        
        public MainView()
        {
            InitializeComponent();
            InitializeDataSources();
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

        private async void InitializeDataSources_Tours()
        {
            // TODO: Remove ASYNC

            // Prefetch UI changes
            gridView_Tours.ShowLoadingPanel();

            // Data fetch
            BindingList<Tour> list = new BindingList<Tour>(
                await TourBUS.GetAll()
            );

            // UI changes
            gridView_Tours.HideLoadingPanel();
            gridControl.DataSource = list;
            bsiListCount.Caption = $"{list.Count} items";
        }

        private void InitializeDataSources_TourGroups()
        {
            // Data fetch
            BindingList<TourGroup> list = new BindingList<TourGroup>(
                TourGroupBUS.GetAll()
            );

            // UI changes
            gridControl.DataSource = list;
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

            TourBUS.DeleteOne(selectedTour);
        }

        // Events

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            handleNewTour();

            // Post-Disposal of Dialog
            InitializeDataSources();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            handleEditTour();

            // Post-Disposal of Dialog
            InitializeDataSources();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            handleDeleteTour();

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
                        selectedItem = gridView_Tours.GetFocusedRow();
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