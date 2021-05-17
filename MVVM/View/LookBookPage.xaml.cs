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
    /// LookBookPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LookBookPage : UserControl
    {
        public LookBookPage()
        {
            InitializeComponent();

            ListItem bc = new ListItem();
            bc.ListName = "Black Coordination";
            bc.Item1Site = "8seconds";
            bc.Item1Name = "21SS 블랙 트위드 터틀넥 패딩 점퍼";
            bc.Item1Price = "49,900won";
            bc.Item1Tag = "#outer";

            listControlFirst.ListItemInformation = bc;
        }

        private void addListButton_Click(object sender, RoutedEventArgs e)
        {
            PopUp.AddListPopUp addListPopUp = new PopUp.AddListPopUp();
            addListPopUp.Show();
        }

        private void moreButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
