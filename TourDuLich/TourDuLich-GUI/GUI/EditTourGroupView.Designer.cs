namespace TourDuLich_GUI.GUI
{
    partial class EditTourGroupView
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
            this.dataLayoutControl_TourGroup = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.LookUpEdit_TourID = new DevExpress.XtraEditors.LookUpEdit();
            this.ItemForTourID = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.DateStartDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForDateStart = new DevExpress.XtraLayout.LayoutControlItem();
            this.DateEndDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForDateEnd = new DevExpress.XtraLayout.LayoutControlItem();
            this.PriceGroupTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForPriceGroup = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_TourGroup)).BeginInit();
            this.dataLayoutControl_TourGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_TourID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTourID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStartDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStartDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEndDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEndDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceGroupTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriceGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl_TourGroup
            // 
            this.dataLayoutControl_TourGroup.AllowCustomization = false;
            this.dataLayoutControl_TourGroup.Controls.Add(this.LookUpEdit_TourID);
            this.dataLayoutControl_TourGroup.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl_TourGroup.Controls.Add(this.DateStartDateEdit);
            this.dataLayoutControl_TourGroup.Controls.Add(this.DateEndDateEdit);
            this.dataLayoutControl_TourGroup.Controls.Add(this.PriceGroupTextEdit);
            this.dataLayoutControl_TourGroup.DataSource = typeof(TourDuLich_GUI.Models.TourGroup);
            this.dataLayoutControl_TourGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_TourGroup.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl_TourGroup.Name = "dataLayoutControl_TourGroup";
            this.dataLayoutControl_TourGroup.Root = this.layoutControlGroup1;
            this.dataLayoutControl_TourGroup.Size = new System.Drawing.Size(798, 441);
            this.dataLayoutControl_TourGroup.TabIndex = 0;
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
            this.ItemForTourID,
            this.ItemForName,
            this.ItemForDateStart,
            this.ItemForDateEnd,
            this.ItemForPriceGroup});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(778, 421);
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
            this.mainRibbonPage.Text = "Đoàn Tour";
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
            // LookUpEdit_TourID
            // 
            this.LookUpEdit_TourID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", typeof(TourDuLich_GUI.Models.TourGroup), "TourID", true));
            this.LookUpEdit_TourID.Location = new System.Drawing.Point(100, 12);
            this.LookUpEdit_TourID.MenuManager = this.mainRibbonControl;
            this.LookUpEdit_TourID.Name = "LookUpEdit_TourID";
            this.LookUpEdit_TourID.Properties.Appearance.Options.UseTextOptions = true;
            this.LookUpEdit_TourID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.LookUpEdit_TourID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit_TourID.Properties.NullText = "";
            this.LookUpEdit_TourID.Size = new System.Drawing.Size(686, 20);
            this.LookUpEdit_TourID.StyleController = this.dataLayoutControl_TourGroup;
            this.LookUpEdit_TourID.TabIndex = 4;
            // 
            // ItemForTourID
            // 
            this.ItemForTourID.Control = this.LookUpEdit_TourID;
            this.ItemForTourID.Location = new System.Drawing.Point(0, 0);
            this.ItemForTourID.Name = "ItemForTourID";
            this.ItemForTourID.Size = new System.Drawing.Size(778, 24);
            this.ItemForTourID.TextSize = new System.Drawing.Size(85, 13);
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", typeof(TourDuLich_GUI.Models.TourGroup), "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(100, 36);
            this.NameTextEdit.MenuManager = this.mainRibbonControl;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NameTextEdit.Size = new System.Drawing.Size(686, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl_TourGroup;
            this.NameTextEdit.TabIndex = 5;
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 24);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(778, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(85, 13);
            // 
            // DateStartDateEdit
            // 
            this.DateStartDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", typeof(TourDuLich_GUI.Models.TourGroup), "DateStart", true));
            this.DateStartDateEdit.EditValue = null;
            this.DateStartDateEdit.Location = new System.Drawing.Point(100, 60);
            this.DateStartDateEdit.MenuManager = this.mainRibbonControl;
            this.DateStartDateEdit.Name = "DateStartDateEdit";
            this.DateStartDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DateStartDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateStartDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateStartDateEdit.Size = new System.Drawing.Size(686, 20);
            this.DateStartDateEdit.StyleController = this.dataLayoutControl_TourGroup;
            this.DateStartDateEdit.TabIndex = 6;
            // 
            // ItemForDateStart
            // 
            this.ItemForDateStart.Control = this.DateStartDateEdit;
            this.ItemForDateStart.Location = new System.Drawing.Point(0, 48);
            this.ItemForDateStart.Name = "ItemForDateStart";
            this.ItemForDateStart.Size = new System.Drawing.Size(778, 24);
            this.ItemForDateStart.TextSize = new System.Drawing.Size(85, 13);
            // 
            // DateEndDateEdit
            // 
            this.DateEndDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", typeof(TourDuLich_GUI.Models.TourGroup), "DateEnd", true));
            this.DateEndDateEdit.EditValue = null;
            this.DateEndDateEdit.Location = new System.Drawing.Point(100, 84);
            this.DateEndDateEdit.MenuManager = this.mainRibbonControl;
            this.DateEndDateEdit.Name = "DateEndDateEdit";
            this.DateEndDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DateEndDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEndDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEndDateEdit.Size = new System.Drawing.Size(686, 20);
            this.DateEndDateEdit.StyleController = this.dataLayoutControl_TourGroup;
            this.DateEndDateEdit.TabIndex = 7;
            // 
            // ItemForDateEnd
            // 
            this.ItemForDateEnd.Control = this.DateEndDateEdit;
            this.ItemForDateEnd.Location = new System.Drawing.Point(0, 72);
            this.ItemForDateEnd.Name = "ItemForDateEnd";
            this.ItemForDateEnd.Size = new System.Drawing.Size(778, 24);
            this.ItemForDateEnd.TextSize = new System.Drawing.Size(85, 13);
            // 
            // PriceGroupTextEdit
            // 
            this.PriceGroupTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", typeof(TourDuLich_GUI.Models.TourGroup), "PriceGroup", true));
            this.PriceGroupTextEdit.Location = new System.Drawing.Point(100, 108);
            this.PriceGroupTextEdit.MenuManager = this.mainRibbonControl;
            this.PriceGroupTextEdit.Name = "PriceGroupTextEdit";
            this.PriceGroupTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.PriceGroupTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PriceGroupTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PriceGroupTextEdit.Properties.Mask.EditMask = "N0";
            this.PriceGroupTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PriceGroupTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PriceGroupTextEdit.Size = new System.Drawing.Size(686, 20);
            this.PriceGroupTextEdit.StyleController = this.dataLayoutControl_TourGroup;
            this.PriceGroupTextEdit.TabIndex = 8;
            // 
            // ItemForPriceGroup
            // 
            this.ItemForPriceGroup.Control = this.PriceGroupTextEdit;
            this.ItemForPriceGroup.Location = new System.Drawing.Point(0, 96);
            this.ItemForPriceGroup.Name = "ItemForPriceGroup";
            this.ItemForPriceGroup.Size = new System.Drawing.Size(778, 325);
            this.ItemForPriceGroup.TextSize = new System.Drawing.Size(85, 13);
            // 
            // EditTourGroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.dataLayoutControl_TourGroup);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditTourGroupView";
            this.Ribbon = this.mainRibbonControl;
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_TourGroup)).EndInit();
            this.dataLayoutControl_TourGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_TourID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTourID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStartDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStartDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEndDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEndDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceGroupTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPriceGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_TourGroup;
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
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_TourID;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.DateEdit DateStartDateEdit;
        private DevExpress.XtraEditors.DateEdit DateEndDateEdit;
        private DevExpress.XtraEditors.TextEdit PriceGroupTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTourID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDateStart;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDateEnd;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriceGroup;
    }
}