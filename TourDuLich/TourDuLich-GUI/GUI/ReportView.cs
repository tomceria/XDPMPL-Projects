using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using TourDuLich_GUI.BUS;
using TourDuLich_GUI.BUS.Report;

namespace TourDuLich_GUI.GUI
{
    public partial class ReportView : DevExpress.XtraEditors.XtraUserControl
    {
        private List<TourBusinessReport> _tourBusinessReports;
        private TourBusinessReport _tourBusinessReportSum;

        public ReportView()
        {
            InitializeComponent();
            ConfigureControls();

            _tourBusinessReports = new List<TourBusinessReport>();
            _tourBusinessReportSum = new TourBusinessReport();

            PopulateDataSources();
        }

        // Private Functions

        private void ConfigureControls()
        {
            DateTime defaultStartDate = DateTime.Today.AddMonths(-1).Date;
            DateTime defaultEndDate = DateTime.Today.Date;
            dateEdit_TBR_StartDate.EditValue = defaultStartDate;
            dateEdit_TBR_EndDate.EditValue = defaultEndDate;
            dateEdit_SAR_StartDate.EditValue = defaultStartDate;
            dateEdit_SAR_EndDate.EditValue = defaultEndDate;
        }

        private void PopulateDataSources()
        {
            var tourCostPerCostTypeArr =
                _tourBusinessReportSum.TourCostPerCostType.Select(row => new
                    {
                        CostType = row.Key,
                        Value = row.Value / 1000
                    }
                ).ToList();

            // Sales
            ChartControl chartSales = chartControl_TBR_Sales;
            Series seriesTbrSales = chartSales.GetSeriesByName("Series_TBR_Sales");
            seriesTbrSales.ArgumentDataMember = "Tour.Name";
            seriesTbrSales.ValueDataMembers.Clear();
            seriesTbrSales.ValueDataMembers.AddRange("Sales");
            seriesTbrSales.CrosshairLabelPattern = "{A}: {V:#,#}";
            seriesTbrSales.Label.TextPattern = "{V:#,#}";
            ((XYDiagram) chartSales.Diagram).AxisX.Label.TextPattern = "{A}";
            ((XYDiagram) chartSales.Diagram).AxisY.Label.TextPattern = "{V:#,#}";
            seriesTbrSales.DataSource = null;
            seriesTbrSales.DataSource = _tourBusinessReports;

            // TourCost
            ChartControl chartTourCost = chartControl_TBR_TourCost;
            Series seriesTbrTourCost = chartTourCost.GetSeriesByName("Series_TBR_TourCost");
            seriesTbrTourCost.ArgumentDataMember = "CostType.Name";
            seriesTbrTourCost.ValueDataMembers.Clear();
            seriesTbrTourCost.ValueDataMembers.AddRange("Value");
            seriesTbrTourCost.Label.TextPattern = "{V:#,#}k ({VP:0.00%})";
            seriesTbrTourCost.LegendTextPattern = "{A}";
            seriesTbrTourCost.DataSource = null;
            seriesTbrTourCost.DataSource = tourCostPerCostTypeArr;

            // Complete Table
            gridView_TBR.GridControl.DataSource = null;
            gridView_TBR.GridControl.DataSource = _tourBusinessReports;
            gridView_TBR.GridControl.RefreshDataSource();
            gridView_TBR.OptionsBehavior.Editable = false;
            gridView_TBR.Columns["Sales"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView_TBR.Columns["Sales"].DisplayFormat.FormatString = "0,0 VND";
            gridView_TBR.Columns["TotalCost"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView_TBR.Columns["TotalCost"].DisplayFormat.FormatString = "0,0 VND";
            gridView_TBR.Columns["TourCostPerCostType"].Visible = false;
            foreach (var costType in CostType.GetAll())
            {
                var fieldName = $"costType_{costType.ID}";

                var existingColumn = gridView_TBR.Columns.FirstOrDefault(o => o.FieldName == fieldName);
                if (existingColumn != null)
                {
                    gridView_TBR.Columns.Remove(existingColumn);
                }
                
                gridView_TBR.Columns.Add(new GridColumn()
                {
                    Caption = costType.Name,
                    FieldName = fieldName,
                    UnboundType = UnboundColumnType.Integer,
                    Visible = true
                });

                gridView_TBR.Columns[fieldName].DisplayFormat.FormatType = FormatType.Numeric;
                gridView_TBR.Columns[fieldName].DisplayFormat.FormatString = "0,0 VND";
            }

            gridView_TBR.CustomUnboundColumnData += (sender, e) =>
            {
                if (new Regex(@"^costType_\d+").IsMatch(e.Column.FieldName))
                {
                    if (e.IsGetData)
                    {
                        e.Value = _tourBusinessReports[e.ListSourceRowIndex]
                            .TourCostPerCostType
                            .Select(row => new
                                {
                                    CostType = row.Key, row.Value
                                }
                            )
                            .FirstOrDefault(o =>
                                o.CostType.ID == int.Parse(
                                    e.Column.FieldName.Split('_')[1])
                            )?.Value ?? 0;
                    }

                    if (e.IsSetData && e.Value != null)
                    {
                        // Does nothing as Reports are readonly
                    }
                }
            };
            gridView_TBR.OptionsView.ColumnAutoWidth = false;
            gridView_TBR.BestFitColumns();
        }

        // Event Handlers

        private void handleGenerateReport_TBR()
        {
            TourBusinessReport.GetReports(
                (DateTime) dateEdit_TBR_StartDate.EditValue,
                (DateTime) dateEdit_TBR_EndDate.EditValue,
                out _tourBusinessReports,
                out _tourBusinessReportSum
            );
            PopulateDataSources();
        }

        private void handleGenerateReport_SAR()
        {
            // TODO: Implement Huy's report business function
            Console.WriteLine("SAR!!!");
        }

        // Event

        private void btn_TBR_Generate_Click(object sender, EventArgs e)
        {
            handleGenerateReport_TBR();
        }

        private void btn_SAR_Generate_Click(object sender, EventArgs e)
        {
            handleGenerateReport_SAR();
        }
    }
}