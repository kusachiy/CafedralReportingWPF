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
    public partial class GroupConfigWindow : Window
    {
        private Context _context;

        public GroupConfigWindow()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
            _context.StudyGroups.Load();
            this.DataContext = _context.StudyGroups.Local;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            this.DialogResult = true;  
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
