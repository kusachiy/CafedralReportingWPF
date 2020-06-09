using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using CafedralReportingWPF.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CafedralReportingWPF.Views
{
    /// <summary>
    /// Interaction logic for WorkflowControl.xaml
    /// </summary>
    public partial class WorkflowPage : Page
    {
        private Context _context;
        private List<Workflow> _allWorkflows;
        private Workflow _selectedWorkflow;
        public WorkflowPage()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
        }
        private void FiltersChanged(object sender, TextChangedEventArgs e)
        {
            var lowerDispFilter = dispFilter.Text.ToLower();
            ICollectionView cv = CollectionViewSource.GetDefaultView(myDataGrid.ItemsSource);
            cv.Filter = f =>
            {
                Workflow w = f as Workflow;
                return w.WorkflowYear.FullYearName.StartsWith(yearFilter.Text) &&
                w.Discipline.DisciplineName.ToLower().StartsWith(lowerDispFilter) &&
                w.Semester.SemesterNumber.ToString().StartsWith(semFilter.Text);             
            };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            yearFilter.Clear();
            dispFilter.Clear();
            semFilter.Clear();
            if (_allWorkflows is null)
                _allWorkflows = WorkflowStaticWorker.GetAllWorkflows(_context);
            myDataGrid.ItemsSource = _allWorkflows;
        }
        private void Add_WF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_WF_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedWorkflow is null)
                return;
            var window = new WokrflowDialog(_selectedWorkflow);
            window.ShowDialog();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedWorkflow = myDataGrid.SelectedItem as Workflow;
            Edit_Button.IsEnabled = !(_selectedWorkflow is null);
        }
    }
}
