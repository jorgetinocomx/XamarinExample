using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace XExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRReader : ContentPage
    {
        public QRReader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open the new scanning page.
        /// </summary>
        /// <remarks>
        /// You can find custom  in https://blog.xamarin.com/barcode-scanning-made-easy-with-zxing-net-for-xamarin-forms/</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scan_Clicked(object sender, EventArgs e)
        {
           
            var ScanPage = new ZXingScannerPage() ;
            Navigation.PushAsync(ScanPage);
            ScanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                ScanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    MyCode.Text = result.Text;
                });
            };
        }
    }
}
