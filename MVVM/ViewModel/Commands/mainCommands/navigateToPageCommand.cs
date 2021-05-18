using codibook.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.mainCommands
{
    public class navigateToPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindow window = parameter as MainWindow;


            // 페이지 변경
            // 룩북 뷰 <---> 아이템 뷰
            if (window.Mainframe.Content.GetType() == typeof(LookBookPage) || window.Mainframe.Content.GetType() == typeof(SearchViewPage))
            {
                window.Mainframe.Navigate(new ItemViewPage());
            }
            else if (window.Mainframe.Content.GetType() == typeof(ItemViewPage) || window.Mainframe.Content.GetType() == typeof(SearchViewPage))
            {
                window.Mainframe.Navigate(new LookBookPage());
            }
        }
    }
}
