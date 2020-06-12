using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.Helpers;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace CafedralReportingWPF.Views
{

    public partial class StaticWorkflowConfigWindow : Window
    {
        private Context _context; 
        public StaticWorkflowConfigWindow()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
           _context.StaticWorkflows.Include(s=>s.Agreement).Include(s => s.Employee).Include(s => s.Employee2).Include(s => s.Employee3).Include(s => s.Employee4).Include(s => s.Employee5)
                .Include(s => s.Semester).Load();
            this.DataContext = _context.StaticWorkflows.Local.ToBindingList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Employees.Load();
            _context.Agreements.Load();
            _context.Semesters.Load();
            SemestersCombobox.ItemsSource = _context.Semesters.Local;
            EmployeesCombobox.ItemsSource = _context.Employees.Local;
            EmployeesCombobox2.ItemsSource = _context.Employees.Local;
            EmployeesCombobox3.ItemsSource = _context.Employees.Local;
            EmployeesCombobox4.ItemsSource = _context.Employees.Local;
            EmployeesCombobox5.ItemsSource = _context.Employees.Local;
            AgreementCombobox.ItemsSource = _context.Agreements.Local;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            this.DialogResult = true;
        }
    }
}