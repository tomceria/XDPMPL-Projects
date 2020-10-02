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

namespace TourDuLich_GUI
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainView()
        {
            InitializeComponent();
            InitializeDataSources();
        }

        private async void InitializeDataSources()
        {
            // Prefetch UI changes
            gridView.ShowLoadingPanel();

            // Data fetch
            BindingList<Tour> list = new BindingList<Tour>(
                await TourBUS.GetAll()
            );

            // UI changes
            gridView.HideLoadingPanel();
            gridControl.DataSource = list;
            bsiListCount.Caption = $"{list.Count} items";
        }
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditTourView editTourView = new EditTourView();
            editTourView.ShowDialog(this);

            Console.WriteLine("Completed.");
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            {
                Tour selectedTour = (Tour)gridView.GetFocusedRow();
                Console.WriteLine("Data: " + (selectedTour.Name));
                EditTourView editTourView = new EditTourView(selectedTour);
                editTourView.ShowDialog(this);

                Console.WriteLine("Completed.");
            }
        }
    }
}