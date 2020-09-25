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

namespace TourDuLich_GUI
{
    public partial class EditTourView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Tour tour;

        public EditTourView(Tour _tour)
        {
/*            dataLayoutControl1.DataSource = GetDataSource();
*/            /*            dataLayoutControl1.RetrieveFields();
                        List<BaseLayoutItem> flatList = new FlatItemsList().GetItemsList(dataLayoutControl1.Root);
                        BaseLayoutItem aboutItem = flatList.First(e => e.Text == "About");
                        aboutItem.TextLocation = DevExpress.Utils.Locations.Top;
            */
            InitializeComponent();
            tour = _tour;

            dataLayoutControl1.DataSource = GetDataSource();
        }

        public BindingList<Tour> GetDataSource()
        {
            BindingList<Tour> result = new BindingList<Tour>();
            result.Add(tour);
            return result;
        }
    }
}
