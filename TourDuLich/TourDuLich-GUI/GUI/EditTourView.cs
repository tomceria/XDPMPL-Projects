using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.GUI
{
    public partial class EditTourView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Tour _item;
        private bool isUpdate = false;

        public EditTourView() // New Tour
        {
            InitializeComponent();
            _item = new Tour();
            InitializeDataSources();
        }

        public EditTourView(Tour tour) // Edit Tour
        {
            InitializeComponent();
            _item = tour;
            isUpdate = true;
            InitializeDataSources();
        }

        private void InitializeDataSources() {
            // Data fetch
            Tour item = Tour.GetOne(_item.ID);
            List<TourType> tourTypes = TourType.GetAll();
            List<Destination> destinations = Destination.GetAll();

            if (item == null) {
                item = _item; // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditTourView(Tour tour)
            } else {
                _item = item;
            }

            // Data binding
            BindingList<Tour> itemBL = new BindingList<Tour>(new List<Tour>() { item });
            BindingList<TourType> tourTypesBL = new BindingList<TourType>(tourTypes);
            BindingList<Destination> destinationsBL = new BindingList<Destination>(destinations);

            BindingList<TourPrice> tourPricesBL = new BindingList<TourPrice>(
                (item.TourPrices != null) ?
                item.TourPrices.ToList() :
                new List<TourPrice>()
            );
            BindingList<TourDetail> tourDetailsBL = new BindingList<TourDetail>(
                (item.TourDetails != null) ?
                item.TourDetails.ToList() :
                new List<TourDetail>()
            );

            dataLayoutControl_Tour.DataSource = itemBL;

            LookUpEdit_TourTypeID.Properties.DataSource = tourTypesBL;
            LookUpEdit_TourTypeID.Properties.DisplayMember = "Name";
            LookUpEdit_TourTypeID.Properties.ValueMember = "ID";
            LookUpEdit_TourTypeID.Properties.PopulateColumns();

            // TODO: Fix this!!!
/*            LookUpEdit_TourTypeID.Properties.Columns["Tours"].Visible = false;
*/
            LookUpEdit_TourTypeID.EditValue = itemBL[0].TourTypeID;

            gridView_TourPrice.GridControl.DataSource = tourPricesBL;
            gridView_TourPrice.GridControl.RefreshDataSource();

            listBoxControl_Destination.DataSource = destinationsBL;
            listBoxControl_TourDetail.DataSource = tourDetailsBL;
            Console.WriteLine("Count: " + tourPricesBL.Count);
        }

        private Tour getItemState() {
            return _item;

            /*            return ((BindingList<Tour>) dataLayoutControl_Tour.DataSource).ElementAt(0);
            */
        }

        private Destination getSelectedDestination() {
            return (Destination) listBoxControl_Destination.SelectedItem;
        }

        // Event Handlers

        private void handleSaveTour() {
            try {
                if (isUpdate) {
                    _item.Update();
                } else {
                    var temp = _item.Create();

                    if (temp.ID != 0)   // tourGroup added to Database => ID changed from 0
                    {
                        isUpdate = true;
                    }
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Lỗi dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void handleResetTour() {
            _item = new Tour();

            /*            InitializeDataSources();
             */
        }

        private void handleDeleteTour() {
            Tour.DeleteOne(_item);
            // close window
            Dispose();
        }

        private void handleCloseEdit() {
            Dispose();
        }

        private void handleAddTourPrice() {
            _item.CreateTourPriceForTour();
            gridView_TourPrice.GridControl.RefreshDataSource();
        }

        private void handleDeleteTourPrice() {
            if (gridView_TourPrice.FocusedRowHandle < 0) {
                return;
            }
            ICollection<TourPrice> tourPrices =
                ((BindingList<Tour>) dataLayoutControl_Tour.DataSource)
                .ElementAt(0)
                .TourPrices;
            TourPrice tourPrice = tourPrices.ElementAt(gridView_TourPrice.FocusedRowHandle);

            _item.DeleteTourPriceFromTour(tourPrice);
            gridView_TourPrice.GridControl.RefreshDataSource();
        }

        // Begin Destination of TourDetail
        private void handleAddTourDetailToTour() {
            Destination destination = getSelectedDestination();

            _item.AddTourDetailToTour(destination);
            listBoxControl_TourDetail.Refresh();
        }

        private void handleDeleteDestinationFromTour() {
            TourDetail tourDetail = (TourDetail) listBoxControl_TourDetail.SelectedItem;
            if (tourDetail != null) {
                _item.DeleteTourDetailFromTour(tourDetail);
                listBoxControl_TourDetail.Refresh();
            }
        }

        //End Destination of TourDetail

        //Begin TourDetail event
        private void handleMoveTourDetail(int direction) {

            TourDetail tourDetail = (TourDetail) listBoxControl_TourDetail.SelectedItem;
            ICollection<TourDetail> tourDetails = getItemState().TourDetails;
            int selectedI = listBoxControl_TourDetail.SelectedIndex;
            if (tourDetail == null) {
                return;
            }

            if (direction < 0) // Move up
            {
                if (selectedI == 0) { return; }
                _item.MoveUpTourDetailOfTour(tourDetail);
            } else // Move down
            {
                if (selectedI == tourDetails.Count - 1) { return; }
                _item.MoveDownTourDetailOfTour(tourDetail);
            }

            listBoxControl_TourDetail.DataSource = getItemState().TourDetails.OrderBy(o => o.Order).ToList();
            listBoxControl_TourDetail.SelectedIndex = direction < 0 ? selectedI - 1 : selectedI + 1;
            listBoxControl_TourDetail.Refresh();

        }

        // ** HIẾU'S APPROACH **
        // private void UpdateListBoxControl_TourDetail(TourDetail tourDetail, int nextSelectedKey) {
        //     BindingList<TourDetail> tourDetailsBL1 = new BindingList<TourDetail>(tourDetail.Tour.TourDetails.OrderBy(o => o.Order).ToList());
        //     listBoxControl_TourDetail.DataSource = tourDetailsBL1;
        //     listBoxControl_TourDetail.SetSelected(nextSelectedKey, true);
        // }
        // private void handleMoveUpTourDetail() { // Hiếu's approach 
        //     TourDetail tourDetail = (TourDetail) listBoxControl_TourDetail.SelectedItem;
        //     if (tourDetail != null) {
        //         int selectedKeyOfListBox = tourDetail.Order;
        //         TourBUS.MoveUpTourDetailOfTour(tourDetail);
        //         //Next key of row table = selectedKeyOfListBox - 1, Order Begin from 1 and Row Table begin from 0   => next key of row table = -1 +(-1) = -2 
        //         if (selectedKeyOfListBox > 1) {
        //             UpdateListBoxControl_TourDetail(tourDetail, selectedKeyOfListBox - 2);
        //         }
        //     }
        // }
        // private void handleMoveDownTourDetail() { // Hiếu's approach 
        //     TourDetail tourDetail = (TourDetail) listBoxControl_TourDetail.SelectedItem;
        //     if (tourDetail != null)
        //     {
        //                 // Next key = current key + 1; But key Order Begin from 1 and Row Table begin from 0 => original number 
        //                 int selectedKeyOfListBox = tourDetail.Order;
        //                 TourBUS.MoveDownTourDetailOfTour(tourDetail);
        //                 if (selectedKeyOfListBox < tourDetail.Tour.TourDetails.Count) 
        //                 {
        //                     UpdateListBoxControl_TourDetail(tourDetail, selectedKeyOfListBox);
        //                 }
        //     }
        // }

        //End TourDetail event
        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleSaveTour();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleSaveTour();
            handleCloseEdit();
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleSaveTour();
            handleResetTour();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleResetTour();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleDeleteTour();
        }

        private void button_AddTourPrice_Click(object sender, EventArgs e) {
            handleAddTourPrice();
        }

        private void button_DeleteTourPrice_Click(object sender, EventArgs e) {
            handleDeleteTourPrice();
        }

        private void listBoxControl_Destination_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void btnAddTourDetail_Click(object sender, EventArgs e) {
            handleAddTourDetailToTour();
        }

        private void btnRemoveDestination_Click(object sender, EventArgs e) {
            handleDeleteDestinationFromTour();
        }

        private void listBoxControl_TourDetail_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void tabbedDetails_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e) {
            InitializeDataSources(); // TODO: This works for some reasons?????
        }

        private void mainRibbonControl_Click(object sender, EventArgs e) {

        }

        private void simpleButton2_Click(object sender, EventArgs e) {

        }

        private void btn_MoveUpTourDetail_Click(object sender, EventArgs e) {
            handleMoveTourDetail(-1);
        }

        private void btn_MoveDownTourDetail_Click(object sender, EventArgs e) {
            handleMoveTourDetail(1);
        }
    }
}