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
    public class YearViewModel
    {
        public int Id { get; set; }
        public string Name { get; set;}

        public override string ToString()
        {
            return Name;
        }
    }


    public partial class SemesterReportPage : Page
    {
        public ObservableCollection<YearViewModel> Years { get; set; }

        public SemesterReportPage()
        {
            InitializeComponent();            
        }

        private void LoadReport(bool isAutumn, YearViewModel yearModel)
        {
            _reportViewer.Reset();

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
            //var workflows = WorkflowStaticWorker.GetAllWorkflows(context);
            var year = context.AcademicYears.FirstOrDefault(y => y.Id == yearModel.Id);
            var workflows = WorkflowStaticWorker.GetAllWorkflowBySemesterAndYear(context,isAutumn,year.Id);
            var statics = context.StaticWorkflows.Where(s => s.IsEnabled).Select(s => new ExtendedStaticWorkflow(s, year)).ToList();

            DatatableDataImporter.FillSemesterDataset(dataset.DataTable1, workflows,statics);

            _reportViewer.RefreshReport();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var isautumn = (semesterCombobox.SelectedItem as ComboBoxItem).Content.ToString();
            var year = yearCombobox.SelectedItem as YearViewModel;
            
            LoadReport(isautumn == "Осенний",year);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var context = DbContextSingleton.GetContext();
            Years = new ObservableCollection<YearViewModel>(context.AcademicYears.ToList().Select(s => new YearViewModel { Id = s.Id, Name = s.FullYearName }));
            yearCombobox.ItemsSource = Years;
        }
    }
}
