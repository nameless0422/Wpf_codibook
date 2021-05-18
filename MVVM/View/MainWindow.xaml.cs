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

        // 타이틀바 드래그
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // 최소화
        private void ToMiniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        // 최대화
        private void ToMaxOrNormalButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        // 닫기
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BookMarkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Mainframe.Navigate(new SearchViewPage());
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            PopUp.UserPopUp userPopUp = new PopUp.UserPopUp();
            userPopUp.Show();
        }

    }
}
