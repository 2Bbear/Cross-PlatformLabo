using HowToWebView.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HowToWebView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var urlChanger = DependencyService.Get<IWebView>();
            //urlChanger.ChangeWeb(editor_url.Text, cwv_Main);
            cwv_Main.Source = editor_url.Text;
            cwv_Main.Source=(cwv_Main.Source as UrlWebViewSource).Url;


        }
    }
}
