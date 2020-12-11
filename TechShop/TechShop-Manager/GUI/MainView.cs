using System;

namespace TechShop_Manager.GUI
{
    public partial class MainView : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private ManageView _manageView;
        private ReportView _reportView;

        public MainView()
        {
            InitializeComponent();
            ConfigureControls();
        }

        /**
         * Functions
         */
        
        private void ConfigureControls()
        {
            // Default document is ManageView. This will trigger handleSelectMenuItem()
            this.accordionControl_Main.SelectElement(accordionControlElement_ManageView);

            // Handling the QueryControl event that will populate all automatically generated Documents
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

        /**
         * Event Handlers
         */

        private void handleSelectMenuItem()
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
                // This method will be called upon startup (which it shouldn't be).
                // At the time, documents have not been loaded yet.
                Console.WriteLine("Ignore this.");
            }
        }

        private void handleOnActivateDocument(DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Document == manageViewDocument)
            {
                if (_manageView == null)
                {
                    _manageView = new ManageView();
                }
                e.Control = _manageView;
            }
            if (e.Document == reportViewDocument)
            {
                if (_reportView == null)
                {
                    _reportView = new ReportView();
                }
                e.Control = _reportView;
            }
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }
        
        /**
         * Events
         */

        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            handleOnActivateDocument(e);
        }

        private void accordionControl_Main_SelectedElementChanged(object sender, DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs e)
        {
            handleSelectMenuItem();
        }
    }
}
