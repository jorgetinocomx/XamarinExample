
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XExample.DB;

namespace XExample.Views.Employees
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class All : ContentPage
    {
        /// <summary>
        /// Start the new <see cref="DB.Models.Employee"/> repository for working with DB.
        /// </summary>
        public All()
        {
            InitializeComponent();
            App.EmployeeRepo = new EmployeeREPO();
            this.Title = "Employee Database";
            var ToolBarItem = new ToolbarItem { Text = "+" };
            ToolBarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Views.Employees.Specific() { BindingContext = new DB.Models.Employee() });
            };
            ToolbarItems.Add(ToolBarItem);
        }

        /// <summary>
        /// Get all employees when this view appears.
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            EmployeeListView.ItemsSource = await App.EmployeeRepo.GetEmployeeAsync();
        }

        /// <summary>
        /// Call the <see cref="Views.Employees.Specific"/>  employee view with selected employee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Item selected.</param>
        private async void Employee_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                await Navigation.PushAsync( new Specific() { BindingContext = e.SelectedItem as DB.Models.Employee});
            }
        }
    }
}
