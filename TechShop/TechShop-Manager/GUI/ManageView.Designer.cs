using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    partial class ManageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageView));
            this.gridControl_Products = new DevExpress.XtraGrid.GridControl();
            this.gridView_Products = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bsiListCount = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabControl_Products = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_Products = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage_Combos = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_Combos = new DevExpress.XtraGrid.GridControl();
            this.gridView_Combos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage_Customers = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_Customers = new DevExpress.XtraGrid.GridControl();
            this.gridView_Customers = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Products)).BeginInit();
            this.xtraTabControl_Products.SuspendLayout();
            this.xtraTabPage_Products.SuspendLayout();
            this.xtraTabPage_Combos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Combos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Combos)).BeginInit();
            this.xtraTabPage_Customers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Customers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Customers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Products
            // 
            this.gridControl_Products.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Products.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Products.MainView = this.gridView_Products;
            this.gridControl_Products.MenuManager = this.ribbonControl;
            this.gridControl_Products.Name = "gridControl_Products";
            this.gridControl_Products.Size = new System.Drawing.Size(788, 447);
            this.gridControl_Products.TabIndex = 2;
            this.gridControl_Products.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Products});
            // 
            // gridView_Products
            // 
            this.gridView_Products.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Products.GridControl = this.gridControl_Products;
            this.gridView_Products.Name = "gridView_Products";
            this.gridView_Products.OptionsBehavior.Editable = false;
            this.gridView_Products.OptionsBehavior.ReadOnly = true;
            this.gridView_Products.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView_Products.OptionsView.ShowFooter = true;
            this.gridView_Products.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bsiListCount});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 25;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(790, 100);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "Thêm";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Sửa";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xoá";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bsiListCount
            // 
            this.bsiListCount.Caption = "??? items";
            this.bsiListCount.Id = 20;
            this.bsiListCount.Name = "bsiListCount";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Trang chủ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Hành động";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiListCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 572);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(790, 27);
            // 
            // xtraTabControl_Products
            // 
            this.xtraTabControl_Products.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Products.Location = new System.Drawing.Point(0, 100);
            this.xtraTabControl_Products.Name = "xtraTabControl_Products";
            this.xtraTabControl_Products.SelectedTabPage = this.xtraTabPage_Products;
            this.xtraTabControl_Products.Size = new System.Drawing.Size(790, 472);
            this.xtraTabControl_Products.TabIndex = 5;
            this.xtraTabControl_Products.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_Products,
            this.xtraTabPage_Combos,
            this.xtraTabPage_Customers});
            this.xtraTabControl_Products.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl_Products_SelectedPageChanged);
            // 
            // xtraTabPage_Products
            // 
            this.xtraTabPage_Products.Controls.Add(this.gridControl_Products);
            this.xtraTabPage_Products.Name = "xtraTabPage_Products";
            this.xtraTabPage_Products.Size = new System.Drawing.Size(788, 447);
            this.xtraTabPage_Products.Text = "Sản Phẩm";
            // 
            // xtraTabPage_Combos
            // 
            this.xtraTabPage_Combos.Controls.Add(this.gridControl_Combos);
            this.xtraTabPage_Combos.Name = "xtraTabPage_Combos";
            this.xtraTabPage_Combos.Size = new System.Drawing.Size(788, 447);
            this.xtraTabPage_Combos.Text = "Combo";
            // 
            // gridControl_Combos
            // 
            this.gridControl_Combos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Combos.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Combos.MainView = this.gridView_Combos;
            this.gridControl_Combos.MenuManager = this.ribbonControl;
            this.gridControl_Combos.Name = "gridControl_Combos";
            this.gridControl_Combos.Size = new System.Drawing.Size(788, 447);
            this.gridControl_Combos.TabIndex = 0;
            this.gridControl_Combos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Combos});
            // 
            // gridView_Combos
            // 
            this.gridView_Combos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Combos.GridControl = this.gridControl_Combos;
            this.gridView_Combos.Name = "gridView_Combos";
            // 
            // xtraTabPage_Customers
            // 
            this.xtraTabPage_Customers.Controls.Add(this.gridControl_Customers);
            this.xtraTabPage_Customers.Name = "xtraTabPage_Customers";
            this.xtraTabPage_Customers.Size = new System.Drawing.Size(788, 447);
            this.xtraTabPage_Customers.Text = "Khách hàng";
            // 
            // gridControl_Customers
            // 
            this.gridControl_Customers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Customers.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Customers.MainView = this.gridView_Customers;
            this.gridControl_Customers.MenuManager = this.ribbonControl;
            this.gridControl_Customers.Name = "gridControl_Customers";
            this.gridControl_Customers.Size = new System.Drawing.Size(788, 447);
            this.gridControl_Customers.TabIndex = 0;
            this.gridControl_Customers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Customers});
            // 
            // gridView_Customers
            // 
            this.gridView_Customers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView_Customers.GridControl = this.gridControl_Customers;
            this.gridView_Customers.Name = "gridView_Customers";
            // 
            // ManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl_Products);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "ManageView";
            this.Size = new System.Drawing.Size(790, 599);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Products)).EndInit();
            this.xtraTabControl_Products.ResumeLayout(false);
            this.xtraTabPage_Products.ResumeLayout(false);
            this.xtraTabPage_Combos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Combos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Combos)).EndInit();
            this.xtraTabPage_Customers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Customers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Customers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl_Products;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Products;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarStaticItem bsiListCount;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_Products;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Products;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Combos;
        private DevExpress.XtraGrid.GridControl gridControl_Combos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Combos;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Customers;
        private DevExpress.XtraGrid.GridControl gridControl_Customers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Customers;
    }
}
