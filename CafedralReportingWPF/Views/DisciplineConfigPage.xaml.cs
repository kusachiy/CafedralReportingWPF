using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    public partial class DisciplineConfigPage : Page
    {
        private Context _context; 
        public DisciplineConfigPage()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
           _context.DisciplineConfig.Include(d=>d.Discipline).Include(d=>d.Employee).Include(d=>d.Agreement).Load();
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
            AgreementCombobox.ItemsSource = _context.Agreements.Local;
        }
    }
}
