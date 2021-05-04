﻿using codibook.MVVM.View;
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

namespace codibook
{

    enum View{
        Item,
        LookBook,
        Search
    }

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class MainWindow : Window
    {
        View view_;
        public MainWindow()
        {
            InitializeComponent();

            this.Mainframe.Navigate(new ItemViewPage());
            view_ = View.Item;
            
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

        // 페이지 변경
        // 룩북 뷰 <---> 아이템 뷰
        private void NavigateToPage_Click(object sender, RoutedEventArgs e)
        {
            if (view_ == View.Item)
            {
                this.Mainframe.Navigate(new LookBookPage());
            }else if(view_ == View.LookBook)
            {
                this.Mainframe.Navigate(new ItemViewPage());
            }
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
