using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TourDuLich_GUI.GUI
{
    public partial class ReportView : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportView()
        {
            InitializeComponent();
            ConfigureControls();
        }

        private void ConfigureControls()
        {
            DateTime defaultStartDate = DateTime.Today.AddMonths(-1);
            DateTime defaultEndDate = DateTime.Today;
            dateEdit_TBR_StartDate.EditValue = defaultStartDate;
            dateEdit_TBR_EndDate.EditValue = defaultEndDate;
        }
    }
}
