using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CafedralReportingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context _context; 
        public MainWindow()
        {
            InitializeComponent();

            _context = DbContextSingleton.GetContext();
            _context.Workflows.Load();
            this.DataContext = _context.Workflows.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(new Employee());
            if (employeeWindow.ShowDialog() == true)
            {
                Employee newEmployee = employeeWindow.Employee;
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
            }
        }
        /*
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedItem == null) return;
            // получаем выделенный объект
            Employee employee = employeesList.SelectedItem as Employee;

            EmployeeWindow employeeWindow = new EmployeeWindow(new Employee
            {
                Id = employee.Id,
                FullName = employee.FullName
            });

            if (employeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = context.Employees.Find(employeeWindow.Employee.Id);
                if (employee != null)
                {                    
                    employee.FullName = employeeWindow.Employee.FullName;
                    context.Entry(employee).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedItem == null) return;

            Employee employee = employeesList.SelectedItem as Employee;
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
        */
        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            FileLoader fileLoader = new FileLoader();
            var entities = fileLoader.ImportWorkflow();*/
            _context.EmployeeToDiscipline.Load();
            var c = _context.EmployeeToDiscipline.Local.ToList();
            _context.EmployeeToDiscipline.Include(etd => etd.Discipline).Include(etd => etd.Employee).Load();
            var etds = _context.EmployeeToDiscipline.ToList();
        }
    }
}
