using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    partial class EditViewTemplate
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
            this.dataLayoutControl_Customer = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.LookUpEdit_CustomerType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Customer)).BeginInit();
            this.dataLayoutControl_Customer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_CustomerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl_Customer
            // 
            this.dataLayoutControl_Customer.AllowCustomization = false;
            this.dataLayoutControl_Customer.Controls.Add(this.LookUpEdit_CustomerType);
            this.dataLayoutControl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_Customer.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.dataLayoutControl_Customer.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl_Customer.Name = "dataLayoutControl_Customer";
            this.dataLayoutControl_Customer.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(830, 324, 650, 400);
            this.dataLayoutControl_Customer.Root = this.layoutControlGroup1;
            this.dataLayoutControl_Customer.Size = new System.Drawing.Size(798, 441);
            this.dataLayoutControl_Customer.TabIndex = 0;
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
            this.mainRibbonPage.Text = "Customer";
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
            // LookUpEdit_CustomerType
            // 
            this.LookUpEdit_CustomerType.Location = new System.Drawing.Point(472, 12);
            this.LookUpEdit_CustomerType.MenuManager = this.mainRibbonControl;
            this.LookUpEdit_CustomerType.Name = "LookUpEdit_CustomerType";
            this.LookUpEdit_CustomerType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.LookUpEdit_CustomerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit_CustomerType.Properties.NullText = "";
            this.LookUpEdit_CustomerType.Properties.PopupSizeable = false;
            this.LookUpEdit_CustomerType.Size = new System.Drawing.Size(314, 20);
            this.LookUpEdit_CustomerType.StyleController = this.dataLayoutControl_Customer;
            this.LookUpEdit_CustomerType.TabIndex = 14;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.LookUpEdit_CustomerType;
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
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(778, 421);
            // 
            // EditViewTemplate
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.dataLayoutControl_Customer);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "EditViewTemplate";
            this.Ribbon = this.mainRibbonControl;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditViewTemplate_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_Customer)).EndInit();
            this.dataLayoutControl_Customer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_CustomerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_Customer;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_CustomerType;
    }
}