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

namespace CafedralReportingWPF.Views
{
    public struct YearViewModel
    {
        public int Id { get; set; }
        public string Name { get; set;}
    }


    public partial class SemesterReportPage : Page
    {
        public ObservableCollection<string> Years { get; set; }

        public SemesterReportPage()
        {
            InitializeComponent();            
        }

        private void LoadReport(bool isAutumn, YearViewModel year)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isautumn = semesterCombobox.SelectedItem.ToString() == "Осенний";
            var year = yearCombobox.SelectedItem;
            LoadReport(isautumn,(YearViewModel)year);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var context = DbContextSingleton.GetContext();
            Years = new ObservableCollection<string>(context.AcademicYears.ToList().Select(s => s.FullYearName));
            yearCombobox.Items.Clear();
            yearCombobox.ItemsSource = Years;
        }
    }
}
