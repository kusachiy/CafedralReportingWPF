using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Reports.Datasets;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CafedralReportingWPF.Views
{
    /// <summary>
    /// Interaction logic for SemesterReportPage.xaml
    /// </summary>
    public partial class SemesterReportPage : Page
    {
        public SemesterReportPage()
        {
            InitializeComponent();
            _reportViewer.Load += LoadReport;
        } 
        private void LoadReport(object sender, EventArgs e)
        {            
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            SemesterDataset dataset = new SemesterDataset();
            dataset.BeginInit();
            reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
            reportDataSource1.Value = dataset.DataTable1;
            _reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            _reportViewer.LocalReport.ReportPath = @"./Reports/Controls/Semester.rdlc";
            dataset.EndInit();
            
            //fill data into adventureWorksDataSet
            var context = DbContextSingleton.GetContext();
            var workflows = WorkflowStaticWorker.GetAllWorkflows(context);

            DatatableDataImporter.FillSemesterDataset(dataset.DataTable1, workflows);

            _reportViewer.RefreshReport();       
        }        
    }
}
