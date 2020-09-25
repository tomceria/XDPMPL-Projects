namespace TourDuLich_GUI
{
    partial class EditTourView
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PriceRefTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPriceRef = new DevExpress.XtraLayout.LayoutControlItem();
            this.tourBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TourDetailsListBoxControl = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAddDestination = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveDestination = new DevExpress.XtraEditors.SimpleButton();
            this.tabbedDetails = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTourDetails = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceRefTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriceRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TourDetailsListBoxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTourDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.btnRemoveDestination);
            this.dataLayoutControl1.Controls.Add(this.btnAddDestination);
            this.dataLayoutControl1.Controls.Add(this.listBoxControl1);
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PriceRefTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TourDetailsListBoxControl);
            this.dataLayoutControl1.DataSource = this.tourBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(517, 308, 650, 400);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(798, 441);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tourBindingSource, "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(83, 12);
            this.NameTextEdit.MenuManager = this.mainRibbonControl;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NameTextEdit.Size = new System.Drawing.Size(703, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            this.NameTextEdit.TabIndex = 4;
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
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
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Lưu và Đóng";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Lưu và Thêm mới";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset";
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xoá";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Tour";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndNew);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiReset);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiDelete);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Hành động";
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tourBindingSource, "Description", true));
            this.DescriptionTextEdit.Location = new System.Drawing.Point(83, 36);
            this.DescriptionTextEdit.MenuManager = this.mainRibbonControl;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DescriptionTextEdit.Size = new System.Drawing.Size(703, 20);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionTextEdit.TabIndex = 5;
            // 
            // PriceRefTextEdit
            // 
            this.PriceRefTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tourBindingSource, "PriceRef", true));
            this.PriceRefTextEdit.Location = new System.Drawing.Point(83, 60);
            this.PriceRefTextEdit.MenuManager = this.mainRibbonControl;
            this.PriceRefTextEdit.Name = "PriceRefTextEdit";
            this.PriceRefTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.PriceRefTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PriceRefTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PriceRefTextEdit.Properties.Mask.EditMask = "N0";
            this.PriceRefTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PriceRefTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PriceRefTextEdit.Size = new System.Drawing.Size(703, 20);
            this.PriceRefTextEdit.StyleController = this.dataLayoutControl1;
            this.PriceRefTextEdit.TabIndex = 6;
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
            this.ItemForDescription,
            this.ItemForPriceRef,
            this.tabbedDetails});
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
            this.ItemForName.TextSize = new System.Drawing.Size(68, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(778, 24);
            this.ItemForDescription.TextSize = new System.Drawing.Size(68, 13);
            // 
            // ItemForPriceRef
            // 
            this.ItemForPriceRef.Control = this.PriceRefTextEdit;
            this.ItemForPriceRef.Location = new System.Drawing.Point(0, 48);
            this.ItemForPriceRef.Name = "ItemForPriceRef";
            this.ItemForPriceRef.Size = new System.Drawing.Size(778, 24);
            this.ItemForPriceRef.TextSize = new System.Drawing.Size(68, 13);
            // 
            // tourBindingSource
            // 
            this.tourBindingSource.DataSource = typeof(TourDuLich_GUI.Models.Tour);
            // 
            // TourDetailsListBoxControl
            // 
            this.TourDetailsListBoxControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.tourBindingSource, "TourDetails", true));
            this.TourDetailsListBoxControl.Location = new System.Drawing.Point(421, 119);
            this.TourDetailsListBoxControl.Name = "TourDetailsListBoxControl";
            this.TourDetailsListBoxControl.Size = new System.Drawing.Size(353, 298);
            this.TourDetailsListBoxControl.StyleController = this.dataLayoutControl1;
            this.TourDetailsListBoxControl.TabIndex = 8;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Location = new System.Drawing.Point(24, 119);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(355, 298);
            this.listBoxControl1.StyleController = this.dataLayoutControl1;
            this.listBoxControl1.TabIndex = 9;
            // 
            // btnAddDestination
            // 
            this.btnAddDestination.Location = new System.Drawing.Point(383, 119);
            this.btnAddDestination.Name = "btnAddDestination";
            this.btnAddDestination.Size = new System.Drawing.Size(34, 22);
            this.btnAddDestination.StyleController = this.dataLayoutControl1;
            this.btnAddDestination.TabIndex = 10;
            this.btnAddDestination.Text = ">";
            // 
            // btnRemoveDestination
            // 
            this.btnRemoveDestination.Location = new System.Drawing.Point(383, 145);
            this.btnRemoveDestination.Name = "btnRemoveDestination";
            this.btnRemoveDestination.Size = new System.Drawing.Size(34, 22);
            this.btnRemoveDestination.StyleController = this.dataLayoutControl1;
            this.btnRemoveDestination.TabIndex = 11;
            this.btnRemoveDestination.Text = "<";
            // 
            // tabbedDetails
            // 
            this.tabbedDetails.Location = new System.Drawing.Point(0, 72);
            this.tabbedDetails.Name = "tabbedDetails";
            this.tabbedDetails.SelectedTabPage = this.layoutControlGroup3;
            this.tabbedDetails.Size = new System.Drawing.Size(778, 349);
            this.tabbedDetails.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.tabbedDetails.Text = "Địa điểm";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.ItemForTourDetails,
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(754, 302);
            this.layoutControlGroup3.Text = "Địa điểm";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.listBoxControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(359, 302);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAddDestination;
            this.layoutControlItem2.Location = new System.Drawing.Point(359, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(38, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ItemForTourDetails
            // 
            this.ItemForTourDetails.Control = this.TourDetailsListBoxControl;
            this.ItemForTourDetails.Location = new System.Drawing.Point(397, 0);
            this.ItemForTourDetails.Name = "ItemForTourDetails";
            this.ItemForTourDetails.Size = new System.Drawing.Size(357, 302);
            this.ItemForTourDetails.StartNewLine = true;
            this.ItemForTourDetails.Text = "Tour Details";
            this.ItemForTourDetails.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForTourDetails.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRemoveDestination;
            this.layoutControlItem3.Location = new System.Drawing.Point(359, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(38, 276);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // EditTourView
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditTourView";
            this.Ribbon = this.mainRibbonControl;
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceRefTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriceRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TourDetailsListBoxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTourDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.TextEdit PriceRefTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriceRef;
        private System.Windows.Forms.BindingSource tourBindingSource;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.ListBoxControl TourDetailsListBoxControl;
        private DevExpress.XtraEditors.SimpleButton btnRemoveDestination;
        private DevExpress.XtraEditors.SimpleButton btnAddDestination;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedDetails;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTourDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}