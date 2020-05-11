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
    public partial class WorkflowPage : Page
    {
        private Context _context; 
        public WorkflowPage()
        {
            InitializeComponent();

            _context = DbContextSingleton.GetContext();
            /*
            FileLoader loader = new FileLoader();
            WorkflowWorker.ImportWorkflow(_context,loader.ImportWorkflow());
            */

            _context.Workflows.Load();
            this.DataContext = _context.Workflows.Local.ToBindingList();
        }
              
        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
