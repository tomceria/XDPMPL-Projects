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

namespace TourDuLich_GUI
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BindingList<Tour> dataSource;
        public List<Tour> tours = new List<Tour>()
            {
                new Tour() {
                    ID = 1,
                    Name = "Saigon - Hanoi",
                    Description = "Wow",
                    PriceRef = 300000
                },
                new Tour() {
                    ID = 2,
                    Name = "Saigon - Da Nang",
                    Description = "wowwww",
                    PriceRef = 400000
                },
                new Tour() {
                    ID = 3,
                    Name = "Saigon - Da Lat",
                    Description = "cold place",
                    PriceRef = 200000
                },
            };
        public List<Destination> destinations = new List<Destination>()
            {
                new Destination() {
                    ID = 1,
                    Name = "Ha Long Bay"
                },
                new Destination() {
                    ID = 2,
                    Name = "Pho co Hoi An"
                },
                new Destination() {
                    ID = 3,
                    Name = "Tiem banh Coi Xay Gio"
                },
            };

        public MainView()
        {
            InitializeComponent();
            dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            bsiListCount.Caption = $"{dataSource.Count} items";
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        public BindingList<Tour> GetDataSource()
        {
            BindingList<Tour> result = new BindingList<Tour>();

            for (int i = 0; i < tours.Count; i++)
            {
                Tour t = tours[i];
                Destination d = destinations[i];
                t.TourDetails = new List<TourDetail>() {
                    new TourDetail() {
                        ID = i,
                        Order = i + 1,
                        Tour = t,
                        Destination = d
                    }
                };
                result.Add(t);
            }
            return result;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (int i in gridView.GetSelectedRows())
            {
                Tour selectedTour = (Tour)gridView.GetRow(i);
                Console.WriteLine("Data: " + (selectedTour.Name));
                EditTourView editTourView = new EditTourView(this, selectedTour);
                editTourView.ShowDialog(this);
            }
        }
    }
}