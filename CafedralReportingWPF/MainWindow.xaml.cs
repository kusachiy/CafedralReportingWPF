using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.DataSource.DbWorkers;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Views;
using System.Windows;
using System.Windows.Controls;

namespace CafedralReportingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page _currentPage;
        WorkflowPage _workflowControl;
        SuccessPage _successPage;
        SemesterReportPage _semReportPage;

        public MainWindow()
        {
            InitializeComponent();
            _successPage = new SuccessPage();
            _workflowControl = new WorkflowPage();
            _semReportPage = new SemesterReportPage();
            _currentPage = _workflowControl;
        }   

        private void Click_Workload_Control(object sender, RoutedEventArgs e)
        {
            SetFrameContent(_workflowControl);
        }
        private void Click_Workload_Report(object sender, RoutedEventArgs e)
        {
            SetFrameContent(_semReportPage);
        }
        private void Click_Import(object sender, RoutedEventArgs e)
        {
            SetFrameContent(null);
            var context = DbContextSingleton.GetContext();            
            FileLoader loader = new FileLoader();
            WorkflowStaticWorker.ImportWorkflow(context,loader.ImportWorkflow());
            SetFrameContent(_successPage);

        }

        private void SetFrameContent(Page page)
        {
            _currentPage = page;
            myFrame.Content = page;
        }

    }
}
