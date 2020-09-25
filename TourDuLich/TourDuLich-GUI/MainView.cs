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
            result.Add(new Tour()
                {
                    ID = 1,
                    Name = "Saigon - Hanoi",
                    Description = "Wow",
                    PriceRef = 300000
                }
            );
            result.Add(new Tour()
                {
                    ID = 2,
                    Name = "Saigon - Da Nang",
                    Description = "wowwww",
                    PriceRef = 400000
                }
            );
            result.Add(new Tour()
                {
                    ID = 3,
                    Name = "Saigon - Da Lat",
                    Description = "cold place",
                    PriceRef = 200000
                }
            );
            return result;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (int i in gridView.GetSelectedRows())
            {
                Console.WriteLine("Data: " + ((Tour)gridView.GetRow(i)).Name);
            }
        }
    }
}