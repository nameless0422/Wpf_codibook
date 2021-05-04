using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class ItemModel
    {

        private string _Link;
        public string Link
        {
            get { return _Link; }
            set {  }
        }
        private int Liked;
        private List<string> Category;

        public ItemModel(string link, int liked, List<string> category)
        {
            Link = link;
            Liked = liked;
            Category = category;
        }
    }
}
