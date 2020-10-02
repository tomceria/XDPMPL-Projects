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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using TourDuLich_GUI.Models;
using DevExpress.XtraGrid;
using System.Data.Entity;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI
{
    public partial class EditTourView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Tour tour;

        public EditTourView()
        {

            InitializeComponent();
            tour = new Tour();
            InitializeDataSources();
        }

        public EditTourView(Tour _tour)
        {
            InitializeComponent();
            tour = _tour;
            InitializeDataSources();
        }

        private async void InitializeDataSources()
        {
            // Prefetch UI changes

            // Data fetch
            BindingList<Tour> item = new BindingList<Tour>(
                new List<Tour>() { await TourBUS.GetOne(tour.ID) }
            );
            BindingList<TourType> tourTypes = new BindingList<TourType>(await TourTypeBUS.GetAll());

            // UI changes
            dataLayoutControl_Tour.DataSource = item;
            LookUpEdit_TourTypeID.Properties.DataSource = tourTypes;
            LookUpEdit_TourTypeID.EditValue = item[0].TourTypeID;
            LookUpEdit_TourTypeID.Properties.DisplayMember = "Name";
            LookUpEdit_TourTypeID.Properties.ValueMember = "ID";
        }

        // Event Handlers

        private void handleSaveTour ()
        {
            // TODO: Perform save tour
        }

        private void handleResetTour()
        {
            tour = new Tour();

/*            InitializeDataSources();
*/
        }

        private void handleDeleteTour()
        {
            // TODO: Perform delete tour
            Console.WriteLine("Deeeeeelete!");
        }

        private void handleCloseEdit()
        {
            this.Dispose();
        }

        private void handleAddTourPrice()
        {
            ((BindingList<Tour>)dataLayoutControl_Tour.DataSource) .ElementAt(0)
                .TourPrices
                .Add(new TourPrice(tour));

            gridView_TourPrice.GridControl.RefreshDataSource();
        }

        private void handleDeleteTourPrice()
        {
/*            gridView_TourPrice.DeleteRow(gridView_TourPrice.FocusedRowHandle);
*/            
            if (gridView_TourPrice.FocusedRowHandle < 0)
            {
                return;
            }
            ICollection<TourPrice> tourPrices = 
                ((BindingList<Tour>)dataLayoutControl_Tour.DataSource)
                    .ElementAt(0)
                    .TourPrices;
            tourPrices.Remove(tourPrices.ElementAt(gridView_TourPrice.FocusedRowHandle));

            gridView_TourPrice.GridControl.RefreshDataSource();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveTour();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveTour();
            handleCloseEdit();
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleSaveTour();
            handleResetTour();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleResetTour();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            handleDeleteTour();
        }

        private void button_AddTourPrice_Click(object sender, EventArgs e)
        {
            handleAddTourPrice();
        }

        private void button_DeleteTourPrice_Click(object sender, EventArgs e)
        {
            handleDeleteTourPrice();
        }
    }
}
