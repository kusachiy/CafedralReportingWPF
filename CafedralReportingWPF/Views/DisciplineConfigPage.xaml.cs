using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
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

namespace CafedralReportingWPF.Views
{
    /// <summary>
    /// Interaction logic for WorkflowControl.xaml
    /// </summary>
    public partial class DisciplineConfigPage : Page
    {
        private Context _context; 
        public DisciplineConfigPage()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
           _context.DisciplineConfig.Include(d=>d.Discipline).Include(d=>d.Employee).Load();
            this.DataContext = _context.DisciplineConfig.Local.ToBindingList();
        }
              
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
