using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    partial class EditProductView
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
            this.dataLayoutControl_Product = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.LookUpEdit_ProductType = new DevExpress.XtraEditors.LookUpEdit();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SlugTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SkuTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ManufacturerTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LookUpEdit_ProductTypeId = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSlug = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForManufacturer = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSku = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Product)).BeginInit();
            this.dataLayoutControl_Product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ProductType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlugTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkuTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManufacturerTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ProductTypeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSlug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManufacturer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductTypeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSku)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl_Product
            // 
            this.dataLayoutControl_Product.AllowCustomization = false;
            this.dataLayoutControl_Product.Controls.Add(this.LookUpEdit_ProductType);
            this.dataLayoutControl_Product.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl_Product.Controls.Add(this.SlugTextEdit);
            this.dataLayoutControl_Product.Controls.Add(this.SkuTextEdit);
            this.dataLayoutControl_Product.Controls.Add(this.PriceTextEdit);
            this.dataLayoutControl_Product.Controls.Add(this.ManufacturerTextEdit);
            this.dataLayoutControl_Product.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl_Product.Controls.Add(this.LookUpEdit_ProductTypeId);
            this.dataLayoutControl_Product.DataSource = this.productBindingSource;
            this.dataLayoutControl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_Product.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.ItemForSlug});
            this.dataLayoutControl_Product.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl_Product.Name = "dataLayoutControl_Product";
            this.dataLayoutControl_Product.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(830, 324, 650, 400);
            this.dataLayoutControl_Product.Root = this.layoutControlGroup1;
            this.dataLayoutControl_Product.Size = new System.Drawing.Size(798, 441);
            this.dataLayoutControl_Product.TabIndex = 0;
            // 
            // LookUpEdit_ProductType
            // 
            this.LookUpEdit_ProductType.Location = new System.Drawing.Point(472, 12);
            this.LookUpEdit_ProductType.MenuManager = this.mainRibbonControl;
            this.LookUpEdit_ProductType.Name = "LookUpEdit_ProductType";
            this.LookUpEdit_ProductType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.LookUpEdit_ProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit_ProductType.Properties.NullText = "";
            this.LookUpEdit_ProductType.Properties.PopupSizeable = false;
            this.LookUpEdit_ProductType.Size = new System.Drawing.Size(314, 20);
            this.LookUpEdit_ProductType.StyleController = this.dataLayoutControl_Product;
            this.LookUpEdit_ProductType.TabIndex = 14;
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
            this.mainRibbonPage.Text = "Sản phẩm";
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
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NameTextEdit.Location = new System.Drawing.Point(84, 12);
            this.NameTextEdit.MenuManager = this.mainRibbonControl;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(313, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl_Product;
            this.NameTextEdit.TabIndex = 15;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(TechShop_Manager.BUS.Product);
            // 
            // SlugTextEdit
            // 
            this.SlugTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "Slug", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SlugTextEdit.Location = new System.Drawing.Point(84, 36);
            this.SlugTextEdit.MenuManager = this.mainRibbonControl;
            this.SlugTextEdit.Name = "SlugTextEdit";
            this.SlugTextEdit.Size = new System.Drawing.Size(702, 20);
            this.SlugTextEdit.StyleController = this.dataLayoutControl_Product;
            this.SlugTextEdit.TabIndex = 16;
            // 
            // SkuTextEdit
            // 
            this.SkuTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "Sku", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SkuTextEdit.Location = new System.Drawing.Point(84, 36);
            this.SkuTextEdit.MenuManager = this.mainRibbonControl;
            this.SkuTextEdit.Name = "SkuTextEdit";
            this.SkuTextEdit.Size = new System.Drawing.Size(702, 20);
            this.SkuTextEdit.StyleController = this.dataLayoutControl_Product;
            this.SkuTextEdit.TabIndex = 17;
            // 
            // PriceTextEdit
            // 
            this.PriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "Price", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PriceTextEdit.Location = new System.Drawing.Point(84, 84);
            this.PriceTextEdit.MenuManager = this.mainRibbonControl;
            this.PriceTextEdit.Name = "PriceTextEdit";
            this.PriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PriceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PriceTextEdit.Properties.Mask.EditMask = "N0";
            this.PriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PriceTextEdit.Size = new System.Drawing.Size(702, 20);
            this.PriceTextEdit.StyleController = this.dataLayoutControl_Product;
            this.PriceTextEdit.TabIndex = 18;
            // 
            // ManufacturerTextEdit
            // 
            this.ManufacturerTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "Manufacturer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ManufacturerTextEdit.Location = new System.Drawing.Point(84, 60);
            this.ManufacturerTextEdit.MenuManager = this.mainRibbonControl;
            this.ManufacturerTextEdit.Name = "ManufacturerTextEdit";
            this.ManufacturerTextEdit.Size = new System.Drawing.Size(702, 20);
            this.ManufacturerTextEdit.StyleController = this.dataLayoutControl_Product;
            this.ManufacturerTextEdit.TabIndex = 19;
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DescriptionTextEdit.Location = new System.Drawing.Point(84, 108);
            this.DescriptionTextEdit.MenuManager = this.mainRibbonControl;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Size = new System.Drawing.Size(702, 20);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl_Product;
            this.DescriptionTextEdit.TabIndex = 20;
            // 
            // LookUpEdit_ProductTypeId
            // 
            this.LookUpEdit_ProductTypeId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.productBindingSource, "ProductTypeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LookUpEdit_ProductTypeId.Location = new System.Drawing.Point(473, 12);
            this.LookUpEdit_ProductTypeId.MenuManager = this.mainRibbonControl;
            this.LookUpEdit_ProductTypeId.Name = "LookUpEdit_ProductTypeId";
            this.LookUpEdit_ProductTypeId.Properties.Appearance.Options.UseTextOptions = true;
            this.LookUpEdit_ProductTypeId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.LookUpEdit_ProductTypeId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit_ProductTypeId.Properties.NullText = "";
            this.LookUpEdit_ProductTypeId.Size = new System.Drawing.Size(313, 20);
            this.LookUpEdit_ProductTypeId.StyleController = this.dataLayoutControl_Product;
            this.LookUpEdit_ProductTypeId.TabIndex = 22;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.LookUpEdit_ProductType;
            this.layoutControlItem4.Location = new System.Drawing.Point(389, 0);
            this.layoutControlItem4.Name = "Loại tour";
            this.layoutControlItem4.Size = new System.Drawing.Size(389, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // ItemForSlug
            // 
            this.ItemForSlug.Control = this.SlugTextEdit;
            this.ItemForSlug.Location = new System.Drawing.Point(0, 24);
            this.ItemForSlug.Name = "ItemForSlug";
            this.ItemForSlug.Size = new System.Drawing.Size(778, 24);
            this.ItemForSlug.Text = "Mã hiển thị";
            this.ItemForSlug.TextSize = new System.Drawing.Size(69, 13);
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
            this.ItemForManufacturer,
            this.ItemForDescription,
            this.ItemForProductTypeId,
            this.ItemForPrice,
            this.ItemForSku});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(778, 421);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(389, 24);
            this.ItemForName.Text = "Tên Sản phẩm";
            this.ItemForName.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForManufacturer
            // 
            this.ItemForManufacturer.Control = this.ManufacturerTextEdit;
            this.ItemForManufacturer.Location = new System.Drawing.Point(0, 48);
            this.ItemForManufacturer.Name = "ItemForManufacturer";
            this.ItemForManufacturer.Size = new System.Drawing.Size(778, 24);
            this.ItemForManufacturer.Text = "Nhà sản xuất";
            this.ItemForManufacturer.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 96);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(778, 325);
            this.ItemForDescription.Text = "Mô tả";
            this.ItemForDescription.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForProductTypeId
            // 
            this.ItemForProductTypeId.Control = this.LookUpEdit_ProductTypeId;
            this.ItemForProductTypeId.Location = new System.Drawing.Point(389, 0);
            this.ItemForProductTypeId.Name = "ItemForProductTypeId";
            this.ItemForProductTypeId.Size = new System.Drawing.Size(389, 24);
            this.ItemForProductTypeId.Text = "Loại Sản phẩm";
            this.ItemForProductTypeId.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForPrice
            // 
            this.ItemForPrice.Control = this.PriceTextEdit;
            this.ItemForPrice.Location = new System.Drawing.Point(0, 72);
            this.ItemForPrice.Name = "ItemForPrice";
            this.ItemForPrice.Size = new System.Drawing.Size(778, 24);
            this.ItemForPrice.Text = "Giá";
            this.ItemForPrice.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForSku
            // 
            this.ItemForSku.Control = this.SkuTextEdit;
            this.ItemForSku.Location = new System.Drawing.Point(0, 24);
            this.ItemForSku.Name = "ItemForSku";
            this.ItemForSku.Size = new System.Drawing.Size(778, 24);
            this.ItemForSku.Text = "SKU";
            this.ItemForSku.TextSize = new System.Drawing.Size(69, 13);
            // 
            // EditProductView
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.dataLayoutControl_Product);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditProductView";
            this.Ribbon = this.mainRibbonControl;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditViewTemplate_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Product)).EndInit();
            this.dataLayoutControl_Product.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ProductType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlugTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkuTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManufacturerTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_ProductTypeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSlug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForManufacturer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductTypeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSku)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_Product;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_ProductType;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private System.Windows.Forms.BindingSource productBindingSource;
        private DevExpress.XtraEditors.TextEdit SlugTextEdit;
        private DevExpress.XtraEditors.TextEdit SkuTextEdit;
        private DevExpress.XtraEditors.TextEdit PriceTextEdit;
        private DevExpress.XtraEditors.TextEdit ManufacturerTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_ProductTypeId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSlug;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSku;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForManufacturer;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductTypeId;
    }
}