using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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

            PLACEHOLDER_getDumpReport();

            InitializeDataSources();
        }

        private void ConfigureControls()
        {
            DateTime defaultStartDate = DateTime.Today.AddMonths(-1).Date;
            DateTime defaultEndDate = DateTime.Today.Date;
            dateEdit_TBR_StartDate.EditValue = defaultStartDate;
            dateEdit_TBR_EndDate.EditValue = defaultEndDate;
            dateEdit_SAR_StartDate.EditValue = defaultStartDate;
            dateEdit_SAR_EndDate.EditValue = defaultEndDate;
        }

        private void InitializeDataSources()
        {
            var tourCostPerCostTypeArr =
                _tourBusinessReportSum.TourCostPerCostType.Select(row => new
                    {
                        CostType = row.Key,
                        Value = row.Value / 1000
                    }
                );

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
            seriesTbrSales.DataSource = _tourBusinessReports;

            // TourCost
            ChartControl chartTourCost = chartControl_TBR_TourCost;
            Series seriesTbrTourCost = chartTourCost.GetSeriesByName("Series_TBR_TourCost");
            seriesTbrTourCost.ArgumentDataMember = "CostType.Name";
            seriesTbrTourCost.ValueDataMembers.Clear();
            seriesTbrTourCost.ValueDataMembers.AddRange("Value");
            seriesTbrTourCost.Label.TextPattern = "{V:#,#}k ({VP:0.00%})";
            seriesTbrTourCost.LegendTextPattern = "{A}";
            seriesTbrTourCost.DataSource = tourCostPerCostTypeArr.ToArray();

            // Complete Table
            gridView_TBR.GridControl.DataSource = _tourBusinessReports;
            gridView_TBR.OptionsBehavior.Editable = false;
            gridView_TBR.Columns["Sales"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView_TBR.Columns["Sales"].DisplayFormat.FormatString = "#,# VND";
            gridView_TBR.Columns["TotalCost"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView_TBR.Columns["TotalCost"].DisplayFormat.FormatString = "#,# VND";
            gridView_TBR.Columns["TourCostPerCostType"].Visible = false;
            foreach (var row in tourCostPerCostTypeArr)
            {
                var fieldName = $"costType_{row.CostType.ID}";
                
                gridView_TBR.Columns.Add(new GridColumn()
                {
                    Caption = row.CostType.Name,
                    FieldName = fieldName,
                    UnboundType = UnboundColumnType.Integer,
                    Visible = true
                });

                gridView_TBR.Columns[fieldName].DisplayFormat.FormatType = FormatType.Numeric;
                gridView_TBR.Columns[fieldName].DisplayFormat.FormatString = "#,# VND";
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
                                    CostType = row.Key,
                                    Value = row.Value
                                }
                            )
                            .First(o =>
                                o.CostType.ID == Int32.Parse(
                                    e.Column.FieldName.Split('_')[1])
                            ).Value;
                    }

                    if (e.IsSetData && e.Value != null)
                    {
                        // Does nothing as Reports are uneditable
                    }
                }
            };
        }

        // Functions

        private void PLACEHOLDER_getDumpReport()
        {
            List<CostType> costTypes = CostType.GetAll();
            List<Tour> tours = Tour.GetAll();
            _tourBusinessReports = new List<TourBusinessReport>
            {
                new TourBusinessReport()
                {
                    Tour = tours[0],
                    Sales = 5340000,
                    CustomerCount = 30,
                    TourGroupCount = 2,
                    TotalCost = 500000,
                    TourCostPerCostType = new Dictionary<CostType, long>
                    {
                        {costTypes[0], 150000},
                        {costTypes[1], 260000},
                        {costTypes[2], 470000},
                        {costTypes[3], 580000},
                    }
                },
                new TourBusinessReport()
                {
                    Tour = tours[1],
                    Sales = 3680000,
                    CustomerCount = 30,
                    TourGroupCount = 2,
                    TotalCost = 500000,
                    TourCostPerCostType = new Dictionary<CostType, long>
                    {
                        {costTypes[0], 250000},
                        {costTypes[1], 360000},
                        {costTypes[2], 370000},
                        {costTypes[3], 680000},
                    }
                }
            };
            _tourBusinessReportSum = new TourBusinessReport()
            {
                Sales = 5340000 + 3680000,
                CustomerCount = 30 * 2,
                TourGroupCount = 2 * 2,
                TotalCost = 500000 * 2,
                TourCostPerCostType = new Dictionary<CostType, long>
                {
                    {costTypes[0], 250000 * 2},
                    {costTypes[1], 360000 * 2},
                    {costTypes[2], 470000 * 2},
                    {costTypes[3], 580000 * 2},
                }
            };
        }

        // Event Handlers

        private void handleGenerateReport_TBR()
        {
            // TODO: Implement Huy's report business function
            Console.WriteLine("TBR!!!");
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