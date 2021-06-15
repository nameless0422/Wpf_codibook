using codibook.Classes;
using codibook.MVVM.Model;
using codibook.MVVM.View.PopUp;
using codibook.MVVM.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.closeCommands
{
    public class ItemPopupCloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (parameter.GetType() == typeof(ItemPopup)) {
                ItemPopup popup = parameter as ItemPopup;
                ItemViewModel vm = popup.Resources["ItemVM"] as ItemViewModel;
                ItemPopupViewModel popVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
                ItemModel model = new ItemModel(popVM.Item_ID, popVM.Name, popVM.Shop_Name, popVM.Price, popVM.Temp, popVM.Link, popVM.Memo, popVM.Liked ? 1 : 2);
                model.Category = popVM.Category;
                DBConnecter.updateItem(model);
                vm.setItemlist();
                vm.updateWeatherRecommands(vm.Temp);
                vm.recommand_four = new ObservableCollection<ItemModel>();
                if (vm.recommandsList.Count() > 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        vm.recommand_four.Add(vm.recommandsList[i]);
                        vm.recommand_four[i].x = i;
                    }
                }
                else
                {
                    for (int i = 0; i < vm.recommandsList.Count(); i++)
                    {
                        vm.recommand_four.Add(vm.recommandsList[i]);
                        vm.recommand_four[i].x = i;
                    }
                }
                vm.itemViewPage.itemListView.ItemsSource = vm.items;
                vm.itemViewPage.recommandListView.ItemsSource = vm.recommand_four;
                vm.IsItemPopup = false;
                popup.Close();
            }else if(parameter.GetType() == typeof(AddItemPopup))
            {
                AddItemPopup popup = parameter as AddItemPopup;
                ItemViewModel vm = popup.Resources["ItemVM"] as ItemViewModel;
                ItemPopupViewModel popVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
                ItemModel model = new ItemModel(popVM.Item_ID, popVM.Name, popVM.Shop_Name, popVM.Price, popVM.Temp, popVM.Link, popVM.Memo, popVM.Liked ? 1 : 2);
                model.Category = popVM.Category;
                DBConnecter.setItem(vm.user,model);
                vm.setItemlist();
                vm.updateWeatherRecommands(vm.Temp);
                vm.recommand_four = new ObservableCollection<ItemModel>();
                if (vm.recommandsList.Count() > 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        vm.recommand_four.Add(vm.recommandsList[i]);
                        vm.recommand_four[i].x = i;
                    }
                }
                else
                {
                    for (int i = 0; i < vm.recommandsList.Count(); i++)
                    {
                        vm.recommand_four.Add(vm.recommandsList[i]);
                        vm.recommand_four[i].x = i;
                    }
                }
                vm.itemViewPage.itemListView.ItemsSource = vm.items;
                vm.itemViewPage.recommandListView.ItemsSource = vm.recommand_four;
                vm.IsItemPopup = false;
                popup.Close();
            }
        }
    }
}
