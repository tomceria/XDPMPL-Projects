using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    partial class EditComboView
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
            this.dataLayoutControl_Combo = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btn_RemoveComboDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddComboDetail = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Products = new DevExpress.XtraGrid.GridControl();
            this.gridView_Products = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.labelControl_ComboDetails = new DevExpress.XtraEditors.LabelControl();
            this.LookUpEdit_ComboType = new DevExpress.XtraEditors.LookUpEdit();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.comboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.GridControl_ComboDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView_ComboDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForComboDetails = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Combo)).BeginInit();
            this.dataLayoutControl_Combo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ComboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_ComboDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ComboDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComboDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl_Combo
            // 
            this.dataLayoutControl_Combo.AllowCustomization = false;
            this.dataLayoutControl_Combo.Controls.Add(this.btn_RemoveComboDetail);
            this.dataLayoutControl_Combo.Controls.Add(this.btn_AddComboDetail);
            this.dataLayoutControl_Combo.Controls.Add(this.gridControl_Products);
            this.dataLayoutControl_Combo.Controls.Add(this.labelControl_ComboDetails);
            this.dataLayoutControl_Combo.Controls.Add(this.LookUpEdit_ComboType);
            this.dataLayoutControl_Combo.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl_Combo.Controls.Add(this.PriceTextEdit);
            this.dataLayoutControl_Combo.Controls.Add(this.GridControl_ComboDetails);
            this.dataLayoutControl_Combo.DataSource = this.comboBindingSource;
            this.dataLayoutControl_Combo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_Combo.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.dataLayoutControl_Combo.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl_Combo.Name = "dataLayoutControl_Combo";
            this.dataLayoutControl_Combo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(830, 324, 650, 400);
            this.dataLayoutControl_Combo.Root = this.layoutControlGroup1;
            this.dataLayoutControl_Combo.Size = new System.Drawing.Size(798, 441);
            this.dataLayoutControl_Combo.TabIndex = 0;
            // 
            // btn_RemoveComboDetail
            // 
            this.btn_RemoveComboDetail.Location = new System.Drawing.Point(503, 103);
            this.btn_RemoveComboDetail.Name = "btn_RemoveComboDetail";
            this.btn_RemoveComboDetail.Size = new System.Drawing.Size(27, 22);
            this.btn_RemoveComboDetail.StyleController = this.dataLayoutControl_Combo;
            this.btn_RemoveComboDetail.TabIndex = 21;
            this.btn_RemoveComboDetail.Text = ">";
            this.btn_RemoveComboDetail.Click += new System.EventHandler(this.btnDeleteComboDetail_ItemClick);
            // 
            // btn_AddComboDetail
            // 
            this.btn_AddComboDetail.Location = new System.Drawing.Point(503, 77);
            this.btn_AddComboDetail.Name = "btn_AddComboDetail";
            this.btn_AddComboDetail.Size = new System.Drawing.Size(27, 22);
            this.btn_AddComboDetail.StyleController = this.dataLayoutControl_Combo;
            this.btn_AddComboDetail.TabIndex = 20;
            this.btn_AddComboDetail.Text = "<";
            this.btn_AddComboDetail.Click += new System.EventHandler(this.btnAddComboDetail_ItemClick);
            // 
            // gridControl_Products
            // 
            this.gridControl_Products.Location = new System.Drawing.Point(534, 77);
            this.gridControl_Products.MainView = this.gridView_Products;
            this.gridControl_Products.MenuManager = this.mainRibbonControl;
            this.gridControl_Products.Name = "gridControl_Products";
            this.gridControl_Products.Size = new System.Drawing.Size(252, 352);
            this.gridControl_Products.TabIndex = 19;
            this.gridControl_Products.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Products});
            // 
            // gridView_Products
            // 
            this.gridView_Products.GridControl = this.gridControl_Products;
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
            this.mainRibbonPage.Text = "Combo";
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
            // labelControl_ComboDetails
            // 
            this.labelControl_ComboDetails.Location = new System.Drawing.Point(12, 60);
            this.labelControl_ComboDetails.Name = "labelControl_ComboDetails";
            this.labelControl_ComboDetails.Size = new System.Drawing.Size(100, 13);
            this.labelControl_ComboDetails.StyleController = this.dataLayoutControl_Combo;
            this.labelControl_ComboDetails.TabIndex = 18;
            this.labelControl_ComboDetails.Text = "Danh sách Sản phẩm";
            // 
            // LookUpEdit_ComboType
            // 
            this.LookUpEdit_ComboType.Location = new System.Drawing.Point(472, 12);
            this.LookUpEdit_ComboType.MenuManager = this.mainRibbonControl;
            this.LookUpEdit_ComboType.Name = "LookUpEdit_ComboType";
            this.LookUpEdit_ComboType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.LookUpEdit_ComboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit_ComboType.Properties.NullText = "";
            this.LookUpEdit_ComboType.Properties.PopupSizeable = false;
            this.LookUpEdit_ComboType.Size = new System.Drawing.Size(314, 20);
            this.LookUpEdit_ComboType.StyleController = this.dataLayoutControl_Combo;
            this.LookUpEdit_ComboType.TabIndex = 14;
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comboBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NameTextEdit.Location = new System.Drawing.Point(69, 12);
            this.NameTextEdit.MenuManager = this.mainRibbonControl;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(717, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl_Combo;
            this.NameTextEdit.TabIndex = 15;
            // 
            // comboBindingSource
            // 
            this.comboBindingSource.DataSource = typeof(TechShop_Manager.BUS.Combo);
            // 
            // PriceTextEdit
            // 
            this.PriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.comboBindingSource, "Price", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PriceTextEdit.Location = new System.Drawing.Point(69, 36);
            this.PriceTextEdit.MenuManager = this.mainRibbonControl;
            this.PriceTextEdit.Name = "PriceTextEdit";
            this.PriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PriceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PriceTextEdit.Properties.Mask.EditMask = "N0";
            this.PriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PriceTextEdit.Size = new System.Drawing.Size(717, 20);
            this.PriceTextEdit.StyleController = this.dataLayoutControl_Combo;
            this.PriceTextEdit.TabIndex = 16;
            // 
            // GridControl_ComboDetails
            // 
            this.GridControl_ComboDetails.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.comboBindingSource, "ComboDetails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GridControl_ComboDetails.Location = new System.Drawing.Point(12, 77);
            this.GridControl_ComboDetails.MainView = this.gridView_ComboDetails;
            this.GridControl_ComboDetails.MenuManager = this.mainRibbonControl;
            this.GridControl_ComboDetails.Name = "GridControl_ComboDetails";
            this.GridControl_ComboDetails.Size = new System.Drawing.Size(487, 352);
            this.GridControl_ComboDetails.TabIndex = 17;
            this.GridControl_ComboDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ComboDetails});
            // 
            // gridView_ComboDetails
            // 
            this.gridView_ComboDetails.GridControl = this.GridControl_ComboDetails;
            this.gridView_ComboDetails.Name = "gridView_ComboDetails";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.LookUpEdit_ComboType;
            this.layoutControlItem4.Location = new System.Drawing.Point(389, 0);
            this.layoutControlItem4.Name = "Loại tour";
            this.layoutControlItem4.Size = new System.Drawing.Size(389, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
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
            this.ItemForName,
            this.ItemForPrice,
            this.ItemForComboDetails,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(778, 421);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(778, 24);
            this.ItemForName.Text = "Tên Combo";
            this.ItemForName.TextSize = new System.Drawing.Size(54, 13);
            // 
            // ItemForPrice
            // 
            this.ItemForPrice.Control = this.PriceTextEdit;
            this.ItemForPrice.Location = new System.Drawing.Point(0, 24);
            this.ItemForPrice.Name = "ItemForPrice";
            this.ItemForPrice.Size = new System.Drawing.Size(778, 24);
            this.ItemForPrice.Text = "Giá";
            this.ItemForPrice.TextSize = new System.Drawing.Size(54, 13);
            // 
            // ItemForComboDetails
            // 
            this.ItemForComboDetails.Control = this.GridControl_ComboDetails;
            this.ItemForComboDetails.Location = new System.Drawing.Point(0, 65);
            this.ItemForComboDetails.Name = "ItemForComboDetails";
            this.ItemForComboDetails.Size = new System.Drawing.Size(491, 356);
            this.ItemForComboDetails.StartNewLine = true;
            this.ItemForComboDetails.Text = "Combo Details";
            this.ItemForComboDetails.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForComboDetails.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelControl_ComboDetails;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(778, 17);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl_Products;
            this.layoutControlItem2.Location = new System.Drawing.Point(522, 65);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(256, 356);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_AddComboDetail;
            this.layoutControlItem3.Location = new System.Drawing.Point(491, 65);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(31, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_RemoveComboDetail;
            this.layoutControlItem5.Location = new System.Drawing.Point(491, 91);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(31, 330);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // EditComboView
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.dataLayoutControl_Combo);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditComboView";
            this.Ribbon = this.mainRibbonControl;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditViewTemplate_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Combo)).EndInit();
            this.dataLayoutControl_Combo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ComboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl_ComboDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ComboDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComboDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_Combo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_ComboType;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private System.Windows.Forms.BindingSource comboBindingSource;
        private DevExpress.XtraEditors.TextEdit PriceTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrice;
        private DevExpress.XtraGrid.GridControl GridControl_ComboDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ComboDetails;
        private DevExpress.XtraLayout.LayoutControlItem ItemForComboDetails;
        private DevExpress.XtraEditors.LabelControl labelControl_ComboDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_RemoveComboDetail;
        private DevExpress.XtraEditors.SimpleButton btn_AddComboDetail;
        private DevExpress.XtraGrid.GridControl gridControl_Products;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Products;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}