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
    /// UserPopUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserPopUp : Window
    {
        public MainViewModel viewModel;
        public UserPopUp(MainViewModel VM)
        {
            InitializeComponent();
            viewModel = VM;
        }
        // 타이틀바 드래그
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
