﻿using System.Threading.Tasks;

namespace TataApp.Services
{
    class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Accept");
        }

        public async Task<bool> ShowConfirm(string title, string message)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
        }
    }
}
