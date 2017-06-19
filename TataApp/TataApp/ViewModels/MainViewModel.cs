using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TataApp.ViewModels
{
    class MainViewModel
    {

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; } 
        public LoginViewModel Login { get; set; }
        #endregion

        #region Contructors
        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Login = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Title = "Register Timer",
                Icon = "ic_access_alarm.png",
                PageName = "RegisterTimePage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Sick Leaves",
                Icon = "ic_favorite.png",
                PageName = "SickLeavesPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Localizate Employees",
                Icon = "ic_location_on.png",
                PageName = "LocalizatePage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Close Sesion",
                Icon = "ic_exit_to_app.png",
                PageName = "LoginPage",
            });
        } 
        #endregion
    }
}
