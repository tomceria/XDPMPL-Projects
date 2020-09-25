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
        public MainView()
        {
            InitializeComponent();
            gridControl.DataSource = GetDataSource();
            BindingList<Tour> dataSource = GetDataSource();
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
            return result;
        }
        public class Customer
        {
            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Required]
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            public string Phone { get; set; }
        }
    }
}