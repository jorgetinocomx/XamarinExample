using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XExample.WebServices.SOAP;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SOAPServicexaml : ContentPage
    {
        private static Calculator ServiceManager;
        public SOAPServicexaml()
        {
            InitializeComponent();
            ServiceManager = new Calculator();
        }

        /// <summary>
        /// Trigerred when user clicks on "Add" button for adding the two numbers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            WaitService.IsRunning = true;
            AddButton.IsEnabled = false;
            AddButton.BackgroundColor = Color.Red;
            int NumberOne,NumberTwo;
            int.TryParse(FirstNumber.Text,out NumberOne);
            int.TryParse(SecondNumber.Text,out NumberTwo);
          
            Device.BeginInvokeOnMainThread(async () => {
                var ServiceResult = await ServiceManager.AddTwoNumbers(NumberOne, NumberTwo);
                AddButton.IsEnabled = true;
                AddButton.BackgroundColor = Color.BlueViolet;
                WaitService.IsRunning = false;
                await DisplayAlert("Result", "Result is: "+ServiceResult, "OK");
            });
        }
    }
}
