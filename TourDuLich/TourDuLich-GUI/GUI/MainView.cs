using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TourDuLich_GUI.GUI
{
    public partial class MainView : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        ManageView manageView;
        ReportView reportView;

        public MainView()
        {
            InitializeComponent();
            ConfigureControls();
        }

        private void ConfigureControls()
        {
            manageView = new ManageView();
            reportView = new ReportView();

            this.accordionControl_Main.SelectElement(accordionControlElement_ManageView);

            // Handling the QueryControl event that will populate all automatically generated Documents
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

        /**
         * LISTENERS
         */
        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (e.Document == manageViewDocument)
            {
                e.Control = manageView;
            }
            if (e.Document == reportViewDocument)
            {
                e.Control = reportView;
            }
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }

        private void accordionControl_Main_SelectedElementChanged(object sender, DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs e)
        {
            try
            {
                var selected = accordionControl_Main.SelectedElement;
                if (selected == accordionControlElement_ManageView)
                {
                    this.documentManager_MainView.View.Controller.Activate(manageViewDocument);


                }
                else if (selected == accordionControlElement_ReportView)
                {
                    this.documentManager_MainView.View.Controller.Activate(reportViewDocument);
                }
            }
            catch (DevExpress.XtraBars.Docking2010.Views.DeferredLoadingException)
            {
                Console.WriteLine("Ignore this.");
            }
        }
    }
}
