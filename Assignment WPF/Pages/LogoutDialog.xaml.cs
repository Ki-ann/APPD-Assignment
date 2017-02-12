﻿using Assignment_WPF;
using Assignment_WPF.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Assignment_WPF.Data.EFModels;

namespace MaterialDesignColors.WpfExample.Domain
{
    /// <summary>
    /// Interaction logic for LogoutDialog.xaml
    /// </summary>
    public partial class LogoutDialog : UserControl
    {
        public LogoutDialog()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Application.Current.MainWindow = new LoginWindow();
            Application.Current.MainWindow.Show();
            mainWindow.Close();
        }
    }
}
