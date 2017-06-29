using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TataApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : ContentPage
    {
        public EmployeesPage()
        {
            InitializeComponent();

            var employeesViewModel = EmployeesViewModel.GetInstance();
            base.Appearing += (object sender, EventArgs e) =>
            {
                employeesViewModel.RefreshCommand.Execute(this);
            };
        }
    }
}