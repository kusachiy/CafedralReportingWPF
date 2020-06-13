using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CafedralReportingWPF.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class WokrflowDialog : Window
    {
        public Workflow Workflow { get; private set; }

        private Context _context;
        public WokrflowDialog(Workflow workflow)
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
            Workflow = workflow;
            this.DataContext = Workflow;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            this.DialogResult = true;  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Employees.Load();
            _context.Agreements.Load();
            _context.Disciplines.Load();
            _context.Semesters.Load();
            _context.StudyGroups.Load();
            _context.AcademicYears.Load();

            DisciplineCombobox.ItemsSource = _context.Disciplines.Local;
            SemesterCombobox.ItemsSource = _context.Semesters.Local;
            GroupCombobox.ItemsSource = _context.StudyGroups.Local;
            YearCombobox.ItemsSource = _context.AcademicYears.Local;
            EmployeeCombobox.ItemsSource = _context.Employees.Local;            
            AgreementCombobox.ItemsSource = _context.Agreements.Local;
        }
    }
}
