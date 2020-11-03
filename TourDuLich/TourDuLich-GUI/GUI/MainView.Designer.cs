namespace TourDuLich_GUI.GUI
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.manageViewDocument = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.reportViewDocument = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl_Main = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement_ManageView = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement_ReportView = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.documentManager_MainView = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageViewDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportViewDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager_MainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.manageViewDocument,
            this.reportViewDocument});
            // 
            // manageViewDocument
            // 
            this.manageViewDocument.Caption = "Quản lý";
            this.manageViewDocument.ControlName = "ManageView";
            this.manageViewDocument.ControlTypeName = "TourDuLich_GUI.GUI.ManageView";
            this.manageViewDocument.FloatLocation = new System.Drawing.Point(145, 139);
            this.manageViewDocument.FloatSize = new System.Drawing.Size(590, 413);
            // 
            // reportViewDocument
            // 
            this.reportViewDocument.Caption = "Thống kê";
            this.reportViewDocument.ControlName = "ReportView";
            this.reportViewDocument.ControlTypeName = "TourDuLich_GUI.GUI.ReportView";
            this.reportViewDocument.FloatLocation = new System.Drawing.Point(250, 139);
            this.reportViewDocument.FloatSize = new System.Drawing.Size(590, 413);
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(95, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(703, 568);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl_Main
            // 
            this.accordionControl_Main.AllowItemSelection = true;
            this.accordionControl_Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl_Main.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement_ManageView,
            this.accordionControlElement_ReportView});
            this.accordionControl_Main.Location = new System.Drawing.Point(0, 31);
            this.accordionControl_Main.Name = "accordionControl_Main";
            this.accordionControl_Main.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            this.accordionControl_Main.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl_Main.Size = new System.Drawing.Size(95, 568);
            this.accordionControl_Main.TabIndex = 1;
            this.accordionControl_Main.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl_Main.SelectedElementChanged += new DevExpress.XtraBars.Navigation.SelectedElementChangedEventHandler(this.accordionControl_Main_SelectedElementChanged);
            // 
            // accordionControlElement_ManageView
            // 
            this.accordionControlElement_ManageView.Name = "accordionControlElement_ManageView";
            this.accordionControlElement_ManageView.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement_ManageView.Text = "Quản lý";
            // 
            // accordionControlElement_ReportView
            // 
            this.accordionControlElement_ReportView.Name = "accordionControlElement_ReportView";
            this.accordionControlElement_ReportView.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement_ReportView.Text = "Thống kê";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(798, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // documentManager_MainView
            // 
            this.documentManager_MainView.ContainerControl = this;
            this.documentManager_MainView.View = this.tabbedView1;
            this.documentManager_MainView.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroupProperties.ShowTabHeader = false;
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.DocumentProperties.AllowClose = false;
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.reportViewDocument,
            this.manageViewDocument});
            dockingContainer2.Element = this.documentGroup1;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer2});
            this.tabbedView1.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl_Main);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "MainView";
            this.NavigationControl = this.accordionControl_Main;
            this.Text = "Tour Du Lịch";
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manageViewDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportViewDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager_MainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl_Main;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_ManageView;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement_ReportView;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager_MainView;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document manageViewDocument;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document reportViewDocument;
    }
}