using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class _Master : ContentPage
    {
        public _Master()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Trigerred when database  button menu is pressed in the master detail page. 
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments</param>
        private async void btnDBs_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new Views.Database());

        }
    }
}
