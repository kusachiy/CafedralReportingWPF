﻿using CafedralReportingWPF.DataSource;
using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
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
    public partial class SemesterConfigWindow : Window
    {
        private Context _context;

        public SemesterConfigWindow()
        {
            InitializeComponent();
            _context = DbContextSingleton.GetContext();
            this.DataContext = _context.Semesters.Local;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            this.DialogResult = true;  
        }
    }
}
