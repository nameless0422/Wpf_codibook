﻿using codibook.MVVM.ViewModel;
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
    /// ItemViewPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ItemViewPage : UserControl
    {
        public ItemViewPage()
        {
            InitializeComponent();
        }

        public ItemViewPage(MainViewModel m)
        {
            InitializeComponent();
            ItemViewModel vm = this.Resources["ItemVM"] as ItemViewModel;
            vm.setUser(m.user);
            vm.setItemlist();
            itemListView.ItemsSource = vm.items;
        }

        private void RightArrowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftArrowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WeatherRecommend4_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
