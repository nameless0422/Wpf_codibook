using codibook.MVVM.Model;
using codibook.MVVM.View;
using codibook.MVVM.View.PopUp;
using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.mainCommands;
using codibook.MVVM.ViewModel.Commands.titlebarCommands;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace codibook.MVVM.ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {
        private string search_text;

        public string Search_Text
        {
            get { return search_text; }
            set
            {
                search_text = value;
                OnPropertyChanged("Search_Text");
            }
        }

        public User user { get; set; }

        public ItemViewModel itemVM { get; set; }
        public LookBookViewModel lookBookVM { get; set; }

        public navigateToPageCommand navigateToPageCommandProperty { get; set; }
        public BookMarkCommand bookMarkCommandProperty { get; set; }

        public MainCloseCommand mainCloseCommandProperty { get; set; }
        public ToMaxOrNormalCommand toMaxOrNormalCommandProperty { get; set; }
        public ToMiniCommand toMiniCommandProperty { get; set; }
        public MainTitleBarCommand titleBarCommandProperty { get; set; }

        public SettingCommand settingCommandProperty { get; set; }
        public SettingPopUp settingPopUpPage { get; set; }

        public UserCommand userCommandProprety { get; set; }
        public UserPopUp userPopUpPage { get; set; }

        //setting popup이 켜져있는지
        public bool SettingCheck;

        //User popup이 켜져있는지
        public bool UserCheck;

        public MainViewModel()
        {
            SettingCheck = false;
            UserCheck = false;
            navigateToPageCommandProperty = new navigateToPageCommand();
            bookMarkCommandProperty = new BookMarkCommand();
            settingCommandProperty = new SettingCommand();
            settingPopUpPage = new SettingPopUp(this);
            userCommandProprety = new UserCommand();
            userPopUpPage = new UserPopUp(this);
            mainCloseCommandProperty = new MainCloseCommand();
            toMaxOrNormalCommandProperty = new ToMaxOrNormalCommand();
            toMiniCommandProperty = new ToMiniCommand(); 
            titleBarCommandProperty = new MainTitleBarCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
