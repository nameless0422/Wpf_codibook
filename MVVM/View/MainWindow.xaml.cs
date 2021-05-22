﻿using codibook.MVVM.Model;
using codibook.MVVM.View;
using codibook.MVVM.ViewModel;
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


namespace codibook.MVVM.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class MainWindow : Window
    {

        User user;

        public MainWindow()
        {
            InitializeComponent();
            this.Mainframe.Navigate(new ItemViewPage());
        }

        public MainWindow(User U)
        {
            InitializeComponent();
            this.user = U;
            this.Mainframe.Navigate(new ItemViewPage());
        }
    }
}
