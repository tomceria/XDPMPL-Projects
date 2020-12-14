using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    partial class InventoryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryView));
            this.gridControl_Imports = new DevExpress.XtraGrid.GridControl();
            this.gridView_Imports = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bsiListCount = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabControl_Imports = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_Imports = new DevExpress.XtraTab.XtraTabPage();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl_ImportDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView_ImportDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xtraTabPage_Orders = new DevExpress.XtraTab.XtraTabPage();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl_OrderDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView_OrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl_Orders = new DevExpress.XtraGrid.GridControl();
            this.gridView_Orders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Imports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Imports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Imports)).BeginInit();
            this.xtraTabControl_Imports.SuspendLayout();
            this.xtraTabPage_Imports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ImportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ImportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.xtraTabPage_Orders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Orders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Orders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Imports
            // 
            this.gridControl_Imports.Location = new System.Drawing.Point(12, 12);
            this.gridControl_Imports.MainView = this.gridView_Imports;
            this.gridControl_Imports.MenuManager = this.ribbonControl;
            this.gridControl_Imports.Name = "gridControl_Imports";
            this.gridControl_Imports.Size = new System.Drawing.Size(294, 423);
            this.gridControl_Imports.TabIndex = 2;
            this.gridControl_Imports.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Imports});
            // 
            // gridView_Imports
            // 
            this.gridView_Imports.GridControl = this.gridControl_Imports;
            this.gridView_Imports.Name = "gridView_Imports";
            this.gridView_Imports.OptionsBehavior.Editable = false;
            this.gridView_Imports.OptionsBehavior.ReadOnly = true;
            this.gridView_Imports.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView_Imports.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
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
            // xtraTabControl_Imports
            // 
            this.xtraTabControl_Imports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Imports.Location = new System.Drawing.Point(0, 100);
            this.xtraTabControl_Imports.Name = "xtraTabControl_Imports";
            this.xtraTabControl_Imports.SelectedTabPage = this.xtraTabPage_Imports;
            this.xtraTabControl_Imports.Size = new System.Drawing.Size(790, 472);
            this.xtraTabControl_Imports.TabIndex = 5;
            this.xtraTabControl_Imports.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_Imports,
            this.xtraTabPage_Orders});
            this.xtraTabControl_Imports.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl_Imports_SelectedPageChanged);
            // 
            // xtraTabPage_Imports
            // 
            this.xtraTabPage_Imports.Controls.Add(this.dataLayoutControl1);
            this.xtraTabPage_Imports.Name = "xtraTabPage_Imports";
            this.xtraTabPage_Imports.Size = new System.Drawing.Size(788, 447);
            this.xtraTabPage_Imports.Text = "Phiếu nhập";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl_ImportDetails);
            this.dataLayoutControl1.Controls.Add(this.gridControl_Imports);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(788, 447);
            this.dataLayoutControl1.TabIndex = 3;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl_ImportDetails
            // 
            this.gridControl_ImportDetails.Location = new System.Drawing.Point(310, 12);
            this.gridControl_ImportDetails.MainView = this.gridView_ImportDetails;
            this.gridControl_ImportDetails.MenuManager = this.ribbonControl;
            this.gridControl_ImportDetails.Name = "gridControl_ImportDetails";
            this.gridControl_ImportDetails.Size = new System.Drawing.Size(466, 423);
            this.gridControl_ImportDetails.TabIndex = 4;
            this.gridControl_ImportDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ImportDetails});
            // 
            // gridView_ImportDetails
            // 
            this.gridView_ImportDetails.GridControl = this.gridControl_ImportDetails;
            this.gridView_ImportDetails.Name = "gridView_ImportDetails";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(788, 447);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl_Imports;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(298, 427);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl_ImportDetails;
            this.layoutControlItem3.Location = new System.Drawing.Point(298, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(470, 427);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // xtraTabPage_Orders
            // 
            this.xtraTabPage_Orders.Controls.Add(this.dataLayoutControl2);
            this.xtraTabPage_Orders.Name = "xtraTabPage_Orders";
            this.xtraTabPage_Orders.Size = new System.Drawing.Size(788, 447);
            this.xtraTabPage_Orders.Text = "Hoá đơn mua hàng";
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.gridControl_OrderDetails);
            this.dataLayoutControl2.Controls.Add(this.gridControl_Orders);
            this.dataLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.Root = this.layoutControlGroup1;
            this.dataLayoutControl2.Size = new System.Drawing.Size(788, 447);
            this.dataLayoutControl2.TabIndex = 1;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // gridControl_OrderDetails
            // 
            this.gridControl_OrderDetails.Location = new System.Drawing.Point(345, 12);
            this.gridControl_OrderDetails.MainView = this.gridView_OrderDetails;
            this.gridControl_OrderDetails.MenuManager = this.ribbonControl;
            this.gridControl_OrderDetails.Name = "gridControl_OrderDetails";
            this.gridControl_OrderDetails.Size = new System.Drawing.Size(431, 423);
            this.gridControl_OrderDetails.TabIndex = 4;
            this.gridControl_OrderDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_OrderDetails});
            // 
            // gridView_OrderDetails
            // 
            this.gridView_OrderDetails.GridControl = this.gridControl_OrderDetails;
            this.gridView_OrderDetails.Name = "gridView_OrderDetails";
            // 
            // gridControl_Orders
            // 
            this.gridControl_Orders.Location = new System.Drawing.Point(12, 12);
            this.gridControl_Orders.MainView = this.gridView_Orders;
            this.gridControl_Orders.MenuManager = this.ribbonControl;
            this.gridControl_Orders.Name = "gridControl_Orders";
            this.gridControl_Orders.Size = new System.Drawing.Size(329, 423);
            this.gridControl_Orders.TabIndex = 0;
            this.gridControl_Orders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Orders});
            // 
            // gridView_Orders
            // 
            this.gridView_Orders.GridControl = this.gridControl_Orders;
            this.gridView_Orders.Name = "gridView_Orders";
            this.gridView_Orders.OptionsBehavior.ReadOnly = true;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(788, 447);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl_Orders;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(333, 427);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl_OrderDetails;
            this.layoutControlItem4.Location = new System.Drawing.Point(333, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(435, 427);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // InventoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl_Imports);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "InventoryView";
            this.Size = new System.Drawing.Size(790, 599);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Imports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Imports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Imports)).EndInit();
            this.xtraTabControl_Imports.ResumeLayout(false);
            this.xtraTabPage_Imports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ImportDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ImportDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.xtraTabPage_Orders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Orders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Orders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl_Imports;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Imports;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarStaticItem bsiListCount;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_Imports;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Orders;
        private DevExpress.XtraGrid.GridControl gridControl_Orders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Orders;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_Imports;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl_ImportDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ImportDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gridControl_OrderDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_OrderDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}