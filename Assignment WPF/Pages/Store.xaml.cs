using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Assignment_WPF.Data;
using static Assignment_WPF.Data.EFModels;
using System.Collections.Generic;

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Page
    {
        public Store()
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Grid btnGrid = new Grid();
            ColumnDefinition c0 = new ColumnDefinition();
            ColumnDefinition c1 = new ColumnDefinition();
            btnGrid.ColumnDefinitions.Add(c0);
            btnGrid.ColumnDefinitions.Add(c1);              //Grid with 2 columns of same width
            sv.Content = btnGrid;                           //wrap grid with scrollviewer
            using (var context = new AppContext())          //Connection to database
            {
                int _buttonCount = 0;       //no. of buttons to create
                List<string> categoryNameList = new List<string>();
                foreach (var category in context.Category)
                {
                    _buttonCount++;
                    categoryNameList.Add(category.CategoryName);
                }
                for (int x = 0; x < _buttonCount / 2; x++)          //no.of rows of same width to define
                {
                    RowDefinition rowDef = new RowDefinition();
                    rowDef.Height = new GridLength((sp.Height / 2)-1);
                    btnGrid.RowDefinitions.Add(rowDef);
                }
                int _buttonNo = 0;                                  //Button tag
                for (int i = 0; i < _buttonCount - (_buttonCount / 2); i++) //Start of row loop
                {
                    for (int j = 0; j < 2; j++)                         //Start of column loop
                    {

                        Button newBtn = new Button()                //New Button object
                        {
                            Tag = _buttonNo
                        };

                        newBtn.Content = categoryNameList[_buttonNo];
                        newBtn.Name = "Button" + _buttonNo.ToString();
                        newBtn.HorizontalAlignment = HorizontalAlignment.Stretch;
                        newBtn.VerticalAlignment = VerticalAlignment.Stretch;
                        newBtn.Click += new RoutedEventHandler(button_Click);
                        btnGrid.Children.Add(newBtn);
                        Grid.SetRow(newBtn, i);
                        Grid.SetColumn(newBtn, j);
                        _buttonNo++;
                    }//end of column loop
                }//end of row loop
            }//end of using

        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            int collectedItemId = Int32.Parse(((Button)sender).Tag.ToString());
            MessageBox.Show(collectedItemId.ToString());
            // NavigationService.Navigate(new Cleaner(collectedItemId));

        }//end of button_Click
        void btnpkgclean_Click(object sender, RoutedEventArgs e)
        {
        }
        void btncleaner_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}




