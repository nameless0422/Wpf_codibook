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
using System.Windows.Shapes;

namespace codibook.MVVM.View.PopUp
{
    /// <summary>
    /// AddListPopUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LookBookPopUp : Window
    {
        private LookBookViewModel lookBookViewModel;

        public LookBookPopUp()
        {
            InitializeComponent();
        }

        public LookBookPopUp(LookBookViewModel lookBookViewModel)
        {
            this.lookBookViewModel = lookBookViewModel;
        }

        // 타이틀바 드래그
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RightArrowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftArrowButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
