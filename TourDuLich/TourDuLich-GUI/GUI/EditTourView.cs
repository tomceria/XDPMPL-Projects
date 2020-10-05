﻿using System;
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
        TourBUS TourBUS = new TourBUS();
        TourTypeBUS TourTypeBUS = new TourTypeBUS();
        DestinationBUS DestinationBUS = new DestinationBUS();
        TourDetailBUS TourDetailBUS = new TourDetailBUS();
        private Tour _item;
        private bool isUpdate = false;

        public EditTourView()   // New Tour
        {
            InitializeComponent();
            _item = new Tour();
            InitializeDataSources();
        }

        public EditTourView(Tour tour)     // Edit Tour
        {
            InitializeComponent();
            _item = tour;
            isUpdate = true;
            InitializeDataSources();
        }

        private async void InitializeDataSources()
        {
            // Data fetch
            Tour item = await TourBUS.GetOne(_item.ID);
            List<TourType> tourTypes = await TourTypeBUS.GetAll();
            List<Destination> destinations = await DestinationBUS.GetAll();
            
            if (item == null)
            {
                item = _item;       // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditTourView(Tour tour)
            }

            // Data binding
            BindingList<Tour> itemBL = new BindingList<Tour>( new List<Tour>() { item } );
            BindingList<TourType> tourTypesBL = new BindingList<TourType>(tourTypes);
            BindingList<Destination> destinationsBL = new BindingList<Destination>(destinations);

            BindingList<TourPrice> tourPricesBL = new BindingList<TourPrice>(
                (item.TourPrices != null)
                    ? new List<TourPrice>(item.TourPrices)
                    : new List<TourPrice>()
                );
            dataLayoutControl_Tour.DataSource = itemBL;
            LookUpEdit_TourTypeID.Properties.DataSource = tourTypesBL;
            LookUpEdit_TourTypeID.Properties.DisplayMember = "Name";
            LookUpEdit_TourTypeID.Properties.ValueMember = "ID";
            LookUpEdit_TourTypeID.Properties.PopulateColumns();
            LookUpEdit_TourTypeID.Properties.Columns["Tours"].Visible = false;
            LookUpEdit_TourTypeID.EditValue = itemBL[0].TourTypeID;
            gridView_TourPrice.GridControl.DataSource = tourPricesBL;
            gridView_TourPrice.GridControl.RefreshDataSource();
            listBoxControl_Destination.DataSource = destinationsBL;

            Console.WriteLine("Count: " + tourPricesBL.Count);
        }

        private Tour getItemState()
        {
            return ((BindingList<Tour>)dataLayoutControl_Tour.DataSource).ElementAt(0);
        }

        private Destination getSelectedDestination()
        {
            return (Destination)listBoxControl_Destination.SelectedItem;
        }

        // Event Handlers

        private void handleSaveTour()
        {
            if (isUpdate)
            {
                TourBUS.UpdateOne(getItemState());
            } else
            {
                TourBUS.CreateOne(getItemState());
                isUpdate = true;
            }
;
        }

        private void handleResetTour()
        {
            _item = new Tour();

/*            InitializeDataSources();
*/
        }

        private void handleDeleteTour()
        {
            Tour selectedTour = getItemState();
            TourBUS.DeleteOne(selectedTour);
            // close window
            Dispose();
        }

        private void handleCloseEdit()
        {
            Dispose();
        }

        private void handleAddTourPrice()
        {

            TourPrice tourPrice = new TourPrice(getItemState());
            Console.WriteLine("ID: " + tourPrice.ID);
            ((BindingList<Tour>)dataLayoutControl_Tour.DataSource).ElementAt(0)
                .TourPrices
                .Add(tourPrice);

            Console.WriteLine(((BindingList<Tour>)dataLayoutControl_Tour.DataSource).ElementAt(0).TourPrices.ElementAt(
                ((BindingList<Tour>)dataLayoutControl_Tour.DataSource).ElementAt(0).TourPrices.Count - 1
                ).ID);
            Console.WriteLine("CCCCount: " + ((BindingList<Tour>)dataLayoutControl_Tour.DataSource).ElementAt(0).TourPrices.Count);

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

        // Begin Destination of TourDetail

        private void handleAddDestinationToTourDetail()
        {

           
           

            Destination destination = getSelectedDestination();
            TourDetailBUS.AddDestinationToTourDetail(_item, destination);

            //TODO: call func AddDestinationToTourDetail(Tour tour, Destination destination )(TourDetailBUS) 
            
        }
        //End Destination of TourDetail

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

        private void listBoxControl_Destination_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddDestination_Click(object sender, EventArgs e)
        {
            handleAddDestinationToTourDetail();
        }

        private void listBoxControl_TourDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
