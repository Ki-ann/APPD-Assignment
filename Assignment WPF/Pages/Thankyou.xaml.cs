﻿using Assignment_WPF.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Assignment_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Thankyou.xaml
    /// </summary>
    public partial class Thankyou : Page
    {
        public static decimal _totalPrice = 0;
        public static string _description;
        public StackPanel _Panel;
        public Thankyou(decimal price, StackPanel stackpanel)
        {
            InitializeComponent();
            _totalPrice = price;
            _Panel = stackpanel;
            foreach(Border child in _Panel.Children)
            {
                foreach (object tb in ((StackPanel)(child.Child)).Children)
                {
                    if (tb.GetType() == typeof(TextBlock))
                    {
                        _description += ((TextBlock)tb).Text + "\n";
                    }
                }
            }
        }

       
        private void btn_receipt_Click(object sender, RoutedEventArgs e)
        {
            Receipt win2 = new Receipt(_totalPrice, _description);
            win2.Show();
        }
    }
}
