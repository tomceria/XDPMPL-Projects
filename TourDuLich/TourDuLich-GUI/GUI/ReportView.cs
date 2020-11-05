﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TourDuLich_GUI.BUS;
using TourDuLich_GUI.BUS.Report;

namespace TourDuLich_GUI.GUI
{
    public partial class ReportView : DevExpress.XtraEditors.XtraUserControl
    {
        private List<TourBusinessReport> _tourBusinessReports;

        public ReportView()
        {
            InitializeComponent();
            ConfigureControls();
            
            PLACEHOLDER_getDumpReport();
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
                    Sales = 10000,
                    CustomerCount = 30,
                    TourGroupCount = 2,
                    TotalCost = 500000,
                    TourCostPerCostType = new Dictionary<CostType, long>
                    {
                        {costTypes[0], 250000},
                        {costTypes[1], 360000},
                        {costTypes[2], 470000},
                        {costTypes[3], 580000},
                    }
                },
                new TourBusinessReport()
                {
                    Tour = tours[1],
                    Sales = 10000,
                    CustomerCount = 30,
                    TourGroupCount = 2,
                    TotalCost = 500000,
                    TourCostPerCostType = new Dictionary<CostType, long>
                    {
                        {costTypes[0], 250000},
                        {costTypes[1], 360000},
                        {costTypes[2], 470000},
                        {costTypes[3], 580000},
                    }
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