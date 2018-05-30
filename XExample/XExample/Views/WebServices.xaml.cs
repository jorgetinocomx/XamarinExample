using System.Collections.Generic;
using XExample.WebServices;
using XExample.WebServices.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebServices : ContentPage
    {
        private List<XExample.WebServices.Entities.User.Information> UserInformation;

        public WebServices()
        {
            UserInformation = new List<XExample.WebServices.Entities.User.Information>();
            BindingContext = UserInformation;
            InitializeComponent();

        }
        /// <summary>
        /// Triggered when Web service page appears. Today, this method make  an async call for requesting a webservice.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            HeaderLabel.Text = "Requesting Web Service";
            Device.BeginInvokeOnMainThread(async () =>
            {
                IClient RESTClient = new XExample.WebServices.REST.Client();

                var TaskResponse = await RESTClient.Get<User>();
                User Result = (User)TaskResponse;
                if (Result != null)
                {
                    foreach (var UserInfo in Result.Data)
                    {
                        UserInformation.Add(UserInfo);
                    }
                    BindingContext = UserInformation;
                    FooterLabel.Text = "Total: " + Result.UsersPerPage;
                    HeaderLabel.Text = "Web Service Result";
                }
            });

        }
    }
    
}
