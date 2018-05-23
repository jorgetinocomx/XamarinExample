using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XExample
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Views._Master();
            this.Detail = new NavigationPage(new Views._Detail());
            App.MasterD = this;
        }
    }
}
