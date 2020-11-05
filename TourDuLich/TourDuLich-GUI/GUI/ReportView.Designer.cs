namespace TourDuLich_GUI.GUI
{
    partial class ReportView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl_Report = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_TourBusinessReport = new DevExpress.XtraTab.XtraTabPage();
            this.dataLayoutControl_TBR = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btn_TBR_Generate = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit_TBR_EndDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_TBR_StartDate = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem_LBR_StartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem_TBR_StartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xtraTabPage_StaffActivityReport = new DevExpress.XtraTab.XtraTabPage();
            this.dataLayoutControl_SAR = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.dateEdit_SAR_EndDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_SAR_StartDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem_SAR_StartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem_SAR_EndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_SAR_Generate = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Report)).BeginInit();
            this.xtraTabControl_Report.SuspendLayout();
            this.xtraTabPage_TourBusinessReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_TBR)).BeginInit();
            this.dataLayoutControl_TBR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_EndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_EndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_StartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_StartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_LBR_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_TBR_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.xtraTabPage_StaffActivityReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_SAR)).BeginInit();
            this.dataLayoutControl_SAR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_EndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_EndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_StartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_StartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_SAR_StartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_SAR_EndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_Report
            // 
            this.xtraTabControl_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_Report.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_Report.Name = "xtraTabControl_Report";
            this.xtraTabControl_Report.SelectedTabPage = this.xtraTabPage_TourBusinessReport;
            this.xtraTabControl_Report.Size = new System.Drawing.Size(714, 528);
            this.xtraTabControl_Report.TabIndex = 0;
            this.xtraTabControl_Report.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_TourBusinessReport,
            this.xtraTabPage_StaffActivityReport});
            // 
            // xtraTabPage_TourBusinessReport
            // 
            this.xtraTabPage_TourBusinessReport.Controls.Add(this.dataLayoutControl_TBR);
            this.xtraTabPage_TourBusinessReport.Name = "xtraTabPage_TourBusinessReport";
            this.xtraTabPage_TourBusinessReport.Size = new System.Drawing.Size(712, 503);
            this.xtraTabPage_TourBusinessReport.Text = "Tình hình hoạt động theo Tour";
            // 
            // dataLayoutControl_TBR
            // 
            this.dataLayoutControl_TBR.Controls.Add(this.btn_TBR_Generate);
            this.dataLayoutControl_TBR.Controls.Add(this.dateEdit_TBR_EndDate);
            this.dataLayoutControl_TBR.Controls.Add(this.dateEdit_TBR_StartDate);
            this.dataLayoutControl_TBR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_TBR.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl_TBR.Name = "dataLayoutControl_TBR";
            this.dataLayoutControl_TBR.Root = this.Root;
            this.dataLayoutControl_TBR.Size = new System.Drawing.Size(712, 503);
            this.dataLayoutControl_TBR.TabIndex = 0;
            this.dataLayoutControl_TBR.Text = "dataLayoutControl1";
            // 
            // btn_TBR_Generate
            // 
            this.btn_TBR_Generate.Location = new System.Drawing.Point(12, 36);
            this.btn_TBR_Generate.Name = "btn_TBR_Generate";
            this.btn_TBR_Generate.Size = new System.Drawing.Size(688, 22);
            this.btn_TBR_Generate.StyleController = this.dataLayoutControl_TBR;
            this.btn_TBR_Generate.TabIndex = 6;
            this.btn_TBR_Generate.Text = "Lập báo cáo";
            // 
            // dateEdit_TBR_EndDate
            // 
            this.dateEdit_TBR_EndDate.EditValue = null;
            this.dateEdit_TBR_EndDate.Location = new System.Drawing.Point(408, 12);
            this.dateEdit_TBR_EndDate.Name = "dateEdit_TBR_EndDate";
            this.dateEdit_TBR_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TBR_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TBR_EndDate.Size = new System.Drawing.Size(292, 20);
            this.dateEdit_TBR_EndDate.StyleController = this.dataLayoutControl_TBR;
            this.dateEdit_TBR_EndDate.TabIndex = 5;
            // 
            // dateEdit_TBR_StartDate
            // 
            this.dateEdit_TBR_StartDate.EditValue = null;
            this.dateEdit_TBR_StartDate.Location = new System.Drawing.Point(62, 12);
            this.dateEdit_TBR_StartDate.Name = "dateEdit_TBR_StartDate";
            this.dateEdit_TBR_StartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TBR_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_TBR_StartDate.Size = new System.Drawing.Size(292, 20);
            this.dateEdit_TBR_StartDate.StyleController = this.dataLayoutControl_TBR;
            this.dateEdit_TBR_StartDate.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem_LBR_StartDate,
            this.emptySpaceItem1,
            this.layoutControlItem_TBR_StartDate,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(712, 503);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem_LBR_StartDate
            // 
            this.layoutControlItem_LBR_StartDate.Control = this.dateEdit_TBR_StartDate;
            this.layoutControlItem_LBR_StartDate.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem_LBR_StartDate.Name = "layoutControlItem_LBR_StartDate";
            this.layoutControlItem_LBR_StartDate.Size = new System.Drawing.Size(346, 24);
            this.layoutControlItem_LBR_StartDate.Text = "Từ ngày";
            this.layoutControlItem_LBR_StartDate.TextSize = new System.Drawing.Size(47, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(692, 433);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem_TBR_StartDate
            // 
            this.layoutControlItem_TBR_StartDate.Control = this.dateEdit_TBR_EndDate;
            this.layoutControlItem_TBR_StartDate.Location = new System.Drawing.Point(346, 0);
            this.layoutControlItem_TBR_StartDate.Name = "layoutControlItem_TBR_StartDate";
            this.layoutControlItem_TBR_StartDate.Size = new System.Drawing.Size(346, 24);
            this.layoutControlItem_TBR_StartDate.Text = "Đến ngày";
            this.layoutControlItem_TBR_StartDate.TextSize = new System.Drawing.Size(47, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_TBR_Generate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(692, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // xtraTabPage_StaffActivityReport
            // 
            this.xtraTabPage_StaffActivityReport.Controls.Add(this.dataLayoutControl_SAR);
            this.xtraTabPage_StaffActivityReport.Name = "xtraTabPage_StaffActivityReport";
            this.xtraTabPage_StaffActivityReport.Size = new System.Drawing.Size(712, 503);
            this.xtraTabPage_StaffActivityReport.Text = "Hoạt động của Nhân viên";
            // 
            // dataLayoutControl_SAR
            // 
            this.dataLayoutControl_SAR.Controls.Add(this.btn_SAR_Generate);
            this.dataLayoutControl_SAR.Controls.Add(this.dateEdit_SAR_EndDate);
            this.dataLayoutControl_SAR.Controls.Add(this.dateEdit_SAR_StartDate);
            this.dataLayoutControl_SAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl_SAR.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl_SAR.Name = "dataLayoutControl_SAR";
            this.dataLayoutControl_SAR.Root = this.layoutControlGroup1;
            this.dataLayoutControl_SAR.Size = new System.Drawing.Size(712, 503);
            this.dataLayoutControl_SAR.TabIndex = 0;
            this.dataLayoutControl_SAR.Text = "dataLayoutControl_SAR";
            // 
            // dateEdit_SAR_EndDate
            // 
            this.dateEdit_SAR_EndDate.EditValue = null;
            this.dateEdit_SAR_EndDate.Location = new System.Drawing.Point(408, 12);
            this.dateEdit_SAR_EndDate.Name = "dateEdit_SAR_EndDate";
            this.dateEdit_SAR_EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SAR_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SAR_EndDate.Size = new System.Drawing.Size(292, 20);
            this.dateEdit_SAR_EndDate.StyleController = this.dataLayoutControl_SAR;
            this.dateEdit_SAR_EndDate.TabIndex = 5;
            // 
            // dateEdit_SAR_StartDate
            // 
            this.dateEdit_SAR_StartDate.EditValue = null;
            this.dateEdit_SAR_StartDate.Location = new System.Drawing.Point(62, 12);
            this.dateEdit_SAR_StartDate.Name = "dateEdit_SAR_StartDate";
            this.dateEdit_SAR_StartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SAR_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_SAR_StartDate.Size = new System.Drawing.Size(292, 20);
            this.dateEdit_SAR_StartDate.StyleController = this.dataLayoutControl_SAR;
            this.dateEdit_SAR_StartDate.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem_SAR_StartDate,
            this.emptySpaceItem2,
            this.layoutControlItem_SAR_EndDate,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(712, 503);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem_SAR_StartDate
            // 
            this.layoutControlItem_SAR_StartDate.Control = this.dateEdit_SAR_StartDate;
            this.layoutControlItem_SAR_StartDate.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem_SAR_StartDate.Name = "layoutControlItem_SAR_StartDate";
            this.layoutControlItem_SAR_StartDate.Size = new System.Drawing.Size(346, 24);
            this.layoutControlItem_SAR_StartDate.Text = "Từ ngày";
            this.layoutControlItem_SAR_StartDate.TextSize = new System.Drawing.Size(47, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(692, 433);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem_SAR_EndDate
            // 
            this.layoutControlItem_SAR_EndDate.Control = this.dateEdit_SAR_EndDate;
            this.layoutControlItem_SAR_EndDate.Location = new System.Drawing.Point(346, 0);
            this.layoutControlItem_SAR_EndDate.Name = "layoutControlItem_SAR_EndDate";
            this.layoutControlItem_SAR_EndDate.Size = new System.Drawing.Size(346, 24);
            this.layoutControlItem_SAR_EndDate.Text = "Đến ngày";
            this.layoutControlItem_SAR_EndDate.TextSize = new System.Drawing.Size(47, 13);
            // 
            // btn_SAR_Generate
            // 
            this.btn_SAR_Generate.Location = new System.Drawing.Point(12, 36);
            this.btn_SAR_Generate.Name = "btn_SAR_Generate";
            this.btn_SAR_Generate.Size = new System.Drawing.Size(688, 22);
            this.btn_SAR_Generate.StyleController = this.dataLayoutControl_SAR;
            this.btn_SAR_Generate.TabIndex = 6;
            this.btn_SAR_Generate.Text = "Lập báo cáo";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_SAR_Generate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(692, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl_Report);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(714, 528);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Report)).EndInit();
            this.xtraTabControl_Report.ResumeLayout(false);
            this.xtraTabPage_TourBusinessReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_TBR)).EndInit();
            this.dataLayoutControl_TBR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_EndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_EndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_StartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_TBR_StartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_LBR_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_TBR_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.xtraTabPage_StaffActivityReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl_SAR)).EndInit();
            this.dataLayoutControl_SAR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_EndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_EndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_StartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_SAR_StartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_SAR_StartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_SAR_EndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl_Report;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_TourBusinessReport;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_StaffActivityReport;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_TBR;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dateEdit_TBR_EndDate;
        private DevExpress.XtraEditors.DateEdit dateEdit_TBR_StartDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btn_TBR_Generate;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl_SAR;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dateEdit_SAR_EndDate;
        private DevExpress.XtraEditors.DateEdit dateEdit_SAR_StartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_SAR_StartDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_SAR_EndDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_LBR_StartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_TBR_StartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_SAR_Generate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
