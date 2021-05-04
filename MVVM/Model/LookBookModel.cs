using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class LookBookModel
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { }
        }
        private List<ItemModel> ItemList;
        public LookBookModel(string name, List<ItemModel> itemlist)
        {
            Name = name;
            ItemList = itemlist;
        }
    }
}
