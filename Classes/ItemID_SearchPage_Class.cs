using codibook.MVVM.View.SearchViewListPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace codibook.Classes
{
    public class ItemID_SearchPage_Class
    {
        public int ItemID;
        public SearchItemPage _SearchItemPage;

        public ItemID_SearchPage_Class(int idx, SearchItemPage sp)
        {
            ItemID = idx;
            _SearchItemPage = sp;
        }

        public ItemID_SearchPage_Class(object idx, object sp)
        {
            ItemID = (int)idx;
            _SearchItemPage = sp as SearchItemPage;
        }
    }

    public class ParamToIDSearchPageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new ItemID_SearchPage_Class(values[0], values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
