using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using CafedralReportingWPF.Reports.Datasets;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace CafedralReportingWPF.Views
{
    public partial class WorkloadReportPage : Page
    {
        public ObservableCollection<YearViewModel> Years { get; set; }

        public WorkloadReportPage()
        {
            InitializeComponent();            
        }        
        private void LoadReport(YearViewModel yearModel)
        {
            _reportViewer.Reset();

            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            WorkloadDataset dataset = new WorkloadDataset();
            dataset.BeginInit();
            reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
            reportDataSource1.Value = dataset.DataTable2;
            _reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            _reportViewer.LocalReport.ReportPath = @"./Reports/Controls/Workload.rdlc";
            dataset.EndInit();
            
            var context = DbContextSingleton.GetContext();

            var year = context.AcademicYears.FirstOrDefault(y => y.Id == yearModel.Id);
            var workflows = WorkflowStaticWorker.GetAllWorkflowByYear(context,yearModel.Id);
            var statics = context.StaticWorkflows.Include(s=>s.Employee).Include(s=>s.Employee2).Include(s => s.Employee3).Include(s => s.Employee4).Include(s => s.Employee5)
                .Include(s => s.Agreement).Include(s => s.Semester)
                .Where(s => s.IsEnabled).ToList();
            //var ext = statics.Select(s=>new ExtendedStaticWorkflow(s,year)).ToList();

            DatatableDataImporter.FillWorkloadDataset(dataset.DataTable2, workflows, statics.Select(s => new ExtendedStaticWorkflow(s, year)).ToList());

            _reportViewer.RefreshReport();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            var year = yearCombobox.SelectedItem as YearViewModel;            
            LoadReport(year);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var context = DbContextSingleton.GetContext();
            Years = new ObservableCollection<YearViewModel>(context.AcademicYears.ToList().Select(s => new YearViewModel { Id = s.Id, Name = s.FullYearName }));
            yearCombobox.ItemsSource = Years;
        }
    }
}
