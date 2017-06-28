﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataApp.Views;

namespace TataApp.Services
{
    public class NavigationService
    {
        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                case "LoginPage":
                    App.Current.MainPage = new LoginPage();
                    break;
                case "LoginFacebookPage":
                    App.Current.MainPage = new LoginFacebookPage();
                    break;
            }
        }

        public async Task Navigate(string pageName)
        {
            App.Master.IsPresented = false;

            switch (pageName)
            {
                case "TimesPage":
                    await App.Navigator.PushAsync(new TimesPage());
                    break;
                case "NewTimePage":
                    await App.Navigator.PushAsync(new NewTimePage());
                    break;
                case "LocationsPage":
                    await App.Navigator.PushAsync(new LocationsPage());
                    break;
            }
        }

        public async Task Back()
        {
            await App.Navigator.PopAsync();
        }
    }
}
