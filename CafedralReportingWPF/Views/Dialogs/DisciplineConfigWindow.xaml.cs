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
    public partial class DisciplineConfigWindow : Window
    {
        private Context _context;

        public DisciplineConfigWindow()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
            _context.Disciplines.Include(d=>d.ReadInSemester).OrderBy(d => d.ReadInSemester.SemesterNumber).ThenBy(d => d.DisciplineName).Load();
            this.DataContext = _context.Disciplines.Local;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            this.DialogResult = true;  
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SemCombobox.ItemsSource = _context.Semesters.Local;
        }
    }
}
