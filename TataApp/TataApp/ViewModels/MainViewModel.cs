using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TataApp.Models;
using TataApp.Services;

namespace TataApp.ViewModels
{
    class MainViewModel
    {
        #region Attributes
        NavigationService navigationServices;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; } 
        public LoginViewModel Login { get; set; }
        public TimesViewModel Times { get; set; }
        public NewTimeViewModel NewTime { get; set; }
        public LocationsViewModel Locations { get; set; }
        public EmployeesViewModel Employees { get; set; }
        public EmployeeDetailViewModel EmployeeDetail { get; set; }
        public Employee Employee { get; set; }
        #endregion

        #region Contructors
        public MainViewModel()
        {
            instance = this;

            navigationServices = new NavigationService();

            Menu = new ObservableCollection<MenuItemViewModel>();
            Login = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Title = "Register Timer",
                Icon = "ic_access_alarm.png",
                PageName = "TimesPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Employees",
                Icon = "ic_people_outline.png",
                PageName = "EmployeesPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Locations",
                Icon = "ic_location_on.png",
                PageName = "LocationsPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Close Sesion",
                Icon = "ic_exit_to_app.png",
                PageName = "LoginPage",
            });
        }
        #endregion

        #region Commands
        public ICommand NewTimeCommand
        {
            get { return new RelayCommand(GoNewTime); }
        }

        private async void GoNewTime()
        {
            NewTime = new NewTimeViewModel();
            await navigationServices.Navigate("NewTimePage");
        }

        #endregion
    }
}
