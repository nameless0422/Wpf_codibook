using codibook.MVVM.Model;
using codibook.MVVM.ViewModel.Commands.lookbookCommands;
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
        public AddListCommand addListCommand { get; set; }
        public MoreListCommand moreListCommand { get; set; }

        public bool AddListCheck;

        public bool MoreListCheck;
        public LookBookViewModel()
        {
            lookBookItems = new ObservableCollection<LookBookModel>();
            addListCommand = new AddListCommand();
            moreListCommand = new MoreListCommand();
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
