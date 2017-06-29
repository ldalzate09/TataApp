using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TataApp.Models;
using TataApp.Services;

namespace TataApp.ViewModels
{
    public class EmployeeItemViewModel : Employee
    {
        #region Attributes
        NavigationService navigationService;
        #endregion

        #region Constructors
        public EmployeeItemViewModel()
        {
            navigationService = new NavigationService();
        }
        #endregion

        #region Commands
        public ICommand SelectEmployeeCommand
        {
            get { return new RelayCommand(SelectEmployee); }
        }

        async void SelectEmployee()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.EmployeeDetail = new EmployeeDetailViewModel(this);
            await navigationService.Navigate("EmployeeDetailPage");
        }
        #endregion
    }
}
