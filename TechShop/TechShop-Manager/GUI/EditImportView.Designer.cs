using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    partial class EditImportView
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
            this.dataLayoutControl_Import = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.labelControl_ImportDetails = new DevExpress.XtraEditors.LabelControl();
            this.btn_AddImportDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btn_RemoveImportDetail = new DevExpress.XtraEditors.SimpleButton();
            this.GridControl_Products = new DevExpress.XtraGrid.GridControl();
            this.gridView_Products = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GridControl_ImportDetails = new DevExpress.XtraGrid.GridControl();
            this.importBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_ImportDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LookUpEdit_ImportType = new DevExpress.XtraEditors.LookUpEdit();
            this.IdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.SupplierTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForId = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSupplier = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Import)).BeginInit();
            this.dataLayoutControl_Import.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_ImportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ImportDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ImportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl_Import
            // 
            this.dataLayoutControl_Import.AllowCustomization = false;
            this.dataLayoutControl_Import.Controls.Add(this.labelControl_ImportDetails);
            this.dataLayoutControl_Import.Controls.Add(this.btn_AddImportDetail);
            this.dataLayoutControl_Import.Controls.Add(this.btn_RemoveImportDetail);
            this.dataLayoutControl_Import.Controls.Add(this.GridControl_Products);
            this.dataLayoutControl_Import.Controls.Add(this.GridControl_ImportDetails);
            this.dataLayoutControl_Import.Controls.Add(this.LookUpEdit_ImportType);
            this.dataLayoutControl_Import.Controls.Add(this.IdTextEdit);
            this.dataLayoutControl_Import.Controls.Add(this.DateDateEdit);
            this.dataLayoutControl_Import.Controls.Add(this.SupplierTextEdit);
            this.dataLayoutControl_Import.DataSource = this.importBindingSource;
            this.dataLayoutControl_Import.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_Import.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.ItemForId});
            this.dataLayoutControl_Import.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl_Import.Name = "dataLayoutControl_Import";
            this.dataLayoutControl_Import.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(830, 324, 650, 400);
            this.dataLayoutControl_Import.Root = this.layoutControlGroup1;
            this.dataLayoutControl_Import.Size = new System.Drawing.Size(798, 441);
            this.dataLayoutControl_Import.TabIndex = 0;
            // 
            // labelControl_ImportDetails
            // 
            this.labelControl_ImportDetails.Location = new System.Drawing.Point(12, 60);
            this.labelControl_ImportDetails.Name = "labelControl_ImportDetails";
            this.labelControl_ImportDetails.Size = new System.Drawing.Size(90, 13);
            this.labelControl_ImportDetails.StyleController = this.dataLayoutControl_Import;
            this.labelControl_ImportDetails.TabIndex = 24;
            this.labelControl_ImportDetails.Text = "Chi tiết Phiếu nhập";
            // 
            // btn_AddImportDetail
            // 
            this.btn_AddImportDetail.Location = new System.Drawing.Point(515, 77);
            this.btn_AddImportDetail.Name = "btn_AddImportDetail";
            this.btn_AddImportDetail.Size = new System.Drawing.Size(35, 22);
            this.btn_AddImportDetail.StyleController = this.dataLayoutControl_Import;
            this.btn_AddImportDetail.TabIndex = 23;
            this.btn_AddImportDetail.Text = "<";
            this.btn_AddImportDetail.Click += new System.EventHandler(this.btnAddImportDetail_ItemClick);
            // 
            // btn_RemoveImportDetail
            // 
            this.btn_RemoveImportDetail.Location = new System.Drawing.Point(515, 103);
            this.btn_RemoveImportDetail.Name = "btn_RemoveImportDetail";
            this.btn_RemoveImportDetail.Size = new System.Drawing.Size(35, 22);
            this.btn_RemoveImportDetail.StyleController = this.dataLayoutControl_Import;
            this.btn_RemoveImportDetail.TabIndex = 22;
            this.btn_RemoveImportDetail.Text = ">";
            this.btn_RemoveImportDetail.Click += new System.EventHandler(this.btnRemoveImportDetail_ItemClick);
            // 
            // GridControl_Products
            // 
            this.GridControl_Products.Location = new System.Drawing.Point(554, 77);
            this.GridControl_Products.MainView = this.gridView_Products;
            this.GridControl_Products.MenuManager = this.mainRibbonControl;
            this.GridControl_Products.Name = "GridControl_Products";
            this.GridControl_Products.Size = new System.Drawing.Size(232, 352);
            this.GridControl_Products.TabIndex = 20;
            this.GridControl_Products.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Products});
            // 
            // gridView_Products
            // 
            this.gridView_Products.GridControl = this.GridControl_Products;
            this.gridView_Products.Name = "gridView_Products";
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiDelete});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 10;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(798, 158);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Lưu";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xoá";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Phiếu nhập";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiDelete);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Hành động";
            // 
            // GridControl_ImportDetails
            // 
            this.GridControl_ImportDetails.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.importBindingSource, "ImportDetails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GridControl_ImportDetails.Location = new System.Drawing.Point(12, 77);
            this.GridControl_ImportDetails.MainView = this.gridView_ImportDetails;
            this.GridControl_ImportDetails.MenuManager = this.mainRibbonControl;
            this.GridControl_ImportDetails.Name = "GridControl_ImportDetails";
            this.GridControl_ImportDetails.Size = new System.Drawing.Size(499, 352);
            this.GridControl_ImportDetails.TabIndex = 18;
            this.GridControl_ImportDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ImportDetails});
            // 
            // importBindingSource
            // 
            this.importBindingSource.DataSource = typeof(TechShop_Manager.BUS.Import);
            // 
            // gridView_ImportDetails
            // 
            this.gridView_ImportDetails.GridControl = this.GridControl_ImportDetails;
            this.gridView_ImportDetails.Name = "gridView_ImportDetails";
            // 
            // LookUpEdit_ImportType
            // 
            this.LookUpEdit_ImportType.Location = new System.Drawing.Point(472, 12);
            this.LookUpEdit_ImportType.MenuManager = this.mainRibbonControl;
            this.LookUpEdit_ImportType.Name = "LookUpEdit_ImportType";
            this.LookUpEdit_ImportType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.LookUpEdit_ImportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit_ImportType.Properties.NullText = "";
            this.LookUpEdit_ImportType.Properties.PopupSizeable = false;
            this.LookUpEdit_ImportType.Size = new System.Drawing.Size(314, 20);
            this.LookUpEdit_ImportType.StyleController = this.dataLayoutControl_Import;
            this.LookUpEdit_ImportType.TabIndex = 14;
            // 
            // IdTextEdit
            // 
            this.IdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.importBindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IdTextEdit.Location = new System.Drawing.Point(80, 12);
            this.IdTextEdit.MenuManager = this.mainRibbonControl;
            this.IdTextEdit.Name = "IdTextEdit";
            this.IdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.IdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.IdTextEdit.Properties.Mask.EditMask = "N0";
            this.IdTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.IdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.IdTextEdit.Size = new System.Drawing.Size(706, 20);
            this.IdTextEdit.StyleController = this.dataLayoutControl_Import;
            this.IdTextEdit.TabIndex = 15;
            // 
            // DateDateEdit
            // 
            this.DateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.importBindingSource, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DateDateEdit.EditValue = null;
            this.DateDateEdit.Location = new System.Drawing.Point(80, 12);
            this.DateDateEdit.MenuManager = this.mainRibbonControl;
            this.DateDateEdit.Name = "DateDateEdit";
            this.DateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Size = new System.Drawing.Size(706, 20);
            this.DateDateEdit.StyleController = this.dataLayoutControl_Import;
            this.DateDateEdit.TabIndex = 16;
            // 
            // SupplierTextEdit
            // 
            this.SupplierTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.importBindingSource, "Supplier", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SupplierTextEdit.Location = new System.Drawing.Point(80, 36);
            this.SupplierTextEdit.MenuManager = this.mainRibbonControl;
            this.SupplierTextEdit.Name = "SupplierTextEdit";
            this.SupplierTextEdit.Size = new System.Drawing.Size(706, 20);
            this.SupplierTextEdit.StyleController = this.dataLayoutControl_Import;
            this.SupplierTextEdit.TabIndex = 17;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.LookUpEdit_ImportType;
            this.layoutControlItem4.Location = new System.Drawing.Point(389, 0);
            this.layoutControlItem4.Name = "Loại tour";
            this.layoutControlItem4.Size = new System.Drawing.Size(389, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // ItemForId
            // 
            this.ItemForId.Control = this.IdTextEdit;
            this.ItemForId.Location = new System.Drawing.Point(0, 0);
            this.ItemForId.Name = "ItemForId";
            this.ItemForId.Size = new System.Drawing.Size(778, 24);
            this.ItemForId.Text = "Id";
            this.ItemForId.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(798, 441);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDate,
            this.ItemForSupplier,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(778, 421);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateDateEdit;
            this.ItemForDate.Location = new System.Drawing.Point(0, 0);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(778, 24);
            this.ItemForDate.Text = "Ngày giờ";
            this.ItemForDate.TextSize = new System.Drawing.Size(65, 13);
            // 
            // ItemForSupplier
            // 
            this.ItemForSupplier.Control = this.SupplierTextEdit;
            this.ItemForSupplier.Location = new System.Drawing.Point(0, 24);
            this.ItemForSupplier.Name = "ItemForSupplier";
            this.ItemForSupplier.Size = new System.Drawing.Size(778, 24);
            this.ItemForSupplier.Text = "Nhà cung cấp";
            this.ItemForSupplier.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelControl_ImportDetails;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(778, 17);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_AddImportDetail;
            this.layoutControlItem3.Location = new System.Drawing.Point(503, 65);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(39, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GridControl_ImportDetails;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 65);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(503, 356);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.GridControl_Products;
            this.layoutControlItem2.Location = new System.Drawing.Point(542, 65);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(236, 356);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_RemoveImportDetail;
            this.layoutControlItem6.Location = new System.Drawing.Point(503, 91);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(39, 330);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(770, 303);
            this.Root.TextVisible = false;
            // 
            // EditImportView
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.dataLayoutControl_Import);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditImportView";
            this.Ribbon = this.mainRibbonControl;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditViewTemplate_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Import)).EndInit();
            this.dataLayoutControl_Import.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_ImportDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ImportDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ImportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_Import;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_ImportType;
        private DevExpress.XtraEditors.TextEdit IdTextEdit;
        private System.Windows.Forms.BindingSource importBindingSource;
        private DevExpress.XtraEditors.DateEdit DateDateEdit;
        private DevExpress.XtraEditors.TextEdit SupplierTextEdit;
        private DevExpress.XtraGrid.GridControl GridControl_ImportDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ImportDetails;
        private DevExpress.XtraLayout.LayoutControlItem ItemForId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSupplier;
        private DevExpress.XtraGrid.GridControl GridControl_Products;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Products;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_RemoveImportDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btn_AddImportDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl labelControl_ImportDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}