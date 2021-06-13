using codibook.MVVM.View;
using codibook.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace codibook.Classes
{
    public class ItemID_ItemPage_Class
    {
        public int ItemID;
        public ItemViewPage _ItemViewPage;

        public ItemID_ItemPage_Class(int id, ItemViewPage vp)
        {
            ItemID = id;
            _ItemViewPage = vp;
        }

        public ItemID_ItemPage_Class(object id, object vp)
        {
            ItemID = (int)id;
            _ItemViewPage = vp as ItemViewPage;
        }
    }

    public class ParamToIDItemViewModelConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new ItemID_ItemPage_Class(values[0], values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
