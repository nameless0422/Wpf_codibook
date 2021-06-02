using codibook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace codibook.MVVM.View.UserControls
{
    /// <summary>
    /// ItemViewUserControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ItemViewUserControl : UserControl
    {


        public ItemViewUserControl()
        {
            InitializeComponent();
        }

        public ItemModel item
        {
            get { return (ItemModel)GetValue(itemProperty); }
            set { SetValue(itemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty itemProperty =
            DependencyProperty.Register("item", typeof(ItemModel), typeof(ItemViewUserControl), new PropertyMetadata(null));

    }
}
