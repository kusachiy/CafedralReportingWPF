using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
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

        private void MyDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selecteditem = myDataGrid.SelectedItem as Workflow;
            MessageBox.Show($"{selecteditem.Discipline}");
        }
    }
}
