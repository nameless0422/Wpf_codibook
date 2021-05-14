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
    /// UserControlLookBookView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlLookBookView : UserControl
    {
        private ListItem listItemInformation;

        public ListItem ListItemInformation
        {
            get { return listItemInformation; }
            set
            {
                listItemInformation = value;
                listName.Text = ListItemInformation.ListName;
                listItem1Site.Text = ListItemInformation.Item1Site;
                listItem1Name.Text = ListItemInformation.Item1Name;
                listItem1Price.Text = ListItemInformation.Item1Price;
                listItem1Tag.Text = ListItemInformation.Item1Tag;
            }
        }

        public UserControlLookBookView()
        {
            InitializeComponent();
        }

        private void moreButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    public class ListItem
    {
        public String ListName { get; set; }
        public String Item1Site { get; set; }
        public String Item1Name { get; set; }
        public String Item1Price { get; set; }
        public String Item1Tag { get; set; }
    }
}
