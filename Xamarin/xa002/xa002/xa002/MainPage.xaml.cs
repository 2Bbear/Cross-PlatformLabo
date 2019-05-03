using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xa002
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Click!");
            var dialer = DependencyService.Get<IDialer>();
            dialer.dial("010-2552-4444");
        }
    }
}
