using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XExample.Views.Employees
{
    /// <summary>
    /// Shows  an specific employee when selected in "All" employees view. Or  show empty view for saving a new employe when clicking in "+" button.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Specific : ContentPage
    {
        public Specific()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Save/Update employee created in this view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Save_Clicked(object sender, EventArgs e)
        {
            DB.Models.Employee NewEmployee = (DB.Models.Employee)BindingContext;
            await App.EmployeeRepo.SaveEmployeeAsync(NewEmployee);
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Return to "All" employees view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
