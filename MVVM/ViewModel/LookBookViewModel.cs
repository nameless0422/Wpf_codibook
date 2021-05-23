using codibook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel
{
    public class LookBookViewModel
    {
        public User user { get; set; }
        public ObservableCollection<LookBookModel> lookBookItems { get; set; }
        public LookBookViewModel()
        {
            lookBookItems = new ObservableCollection<LookBookModel>();
        }

        public void setUser(User U)
        {
            user = U;
        }

        public void addItem(LookBookModel L)
        {
            lookBookItems.Add(L);
        }
    }
}
