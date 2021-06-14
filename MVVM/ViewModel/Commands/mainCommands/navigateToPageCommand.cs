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
            MainViewModel MainVM = window.Resources["MainVM"] as MainViewModel;
            
            // 페이지 변경
            // 룩북 뷰 <---> 아이템 뷰
            if (window.Mainframe.Content.GetType() == typeof(LookBookPage) || window.Mainframe.Content.GetType() == typeof(SearchViewPage))
            {
                // itemView 처리
                ItemViewPage itemView = new ItemViewPage();
                ItemViewModel itemVM = itemView.Resources["ItemVM"] as ItemViewModel;
                MainVM.itemVM = itemVM;
                itemVM.setUser(MainVM.user);
                itemVM.setItemlist();
                string temp_str = (window.Resources["WeatherAPI"] as WeatherAPI).T3H;
                int temp = int.Parse(temp_str.Replace("°", ""));
                itemVM.updateWeatherRecommands(temp);
                if (itemVM.recommandsList.Count() > 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        itemVM.recommand_four.Add(itemVM.recommandsList[i]);
                        itemVM.recommand_four[i].x = i;
                    }
                }
                else
                {
                    for (int i = 0; i < itemVM.recommandsList.Count(); i++)
                    {
                        itemVM.recommand_four.Add(itemVM.recommandsList[i]);
                        itemVM.recommand_four[i].x = i;
                    }
                }
                itemView.itemListView.ItemsSource = itemVM.items;
                itemView.recommandListView.ItemsSource = itemVM.recommand_four;
                window.Mainframe.Navigate(itemView);
            }
            else if (window.Mainframe.Content.GetType() == typeof(ItemViewPage) || window.Mainframe.Content.GetType() == typeof(SearchViewPage))
            {

                // lookbookView 처리
                LookBookPage lookBookView = new LookBookPage();
                LookBookViewModel lookBookVM = lookBookView.Resources["lookBookVM"] as LookBookViewModel;
                MainVM.lookBookVM = lookBookVM;
                lookBookVM.setUser(MainVM.user);
                lookBookVM.setLookBookList();
                lookBookView.LookBookListView.ItemsSource = lookBookVM.lookBookItems;
                window.Mainframe.Navigate(lookBookView);
            }
        }
    }
}
