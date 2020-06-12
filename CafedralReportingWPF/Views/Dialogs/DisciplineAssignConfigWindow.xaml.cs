using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.Helpers;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace CafedralReportingWPF.Views
{

    public partial class DisciplineAssignConfigWindow : Page
    {
        private Context _context; 
        public DisciplineAssignConfigWindow()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
           _context.DisciplineConfig.Include(d=>d.Discipline).Include(d=>d.Discipline.ReadInSemester)
                .Include(d=>d.Employee).Include(d => d.Employee2).Include(d => d.Employee3).Include(d => d.Employee4).Include(d => d.Employee5)
                .Include(d=>d.Agreement).Load();
            this.DataContext = _context.DisciplineConfig.Local.ToBindingList();
        }              
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Employees.Load();
            _context.Agreements.Load();
            EmployeesCombobox.ItemsSource = _context.Employees.Local;
            EmployeesCombobox2.ItemsSource = _context.Employees.Local;
            EmployeesCombobox3.ItemsSource = _context.Employees.Local;
            EmployeesCombobox4.ItemsSource = _context.Employees.Local;
            EmployeesCombobox5.ItemsSource = _context.Employees.Local;

            AgreementCombobox.ItemsSource = _context.Agreements.Local;
        }
    }
}