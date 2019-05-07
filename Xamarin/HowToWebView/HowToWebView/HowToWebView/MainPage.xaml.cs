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
        protected override bool OnBackButtonPressed()
        {
            if (cwv_Main.CanGoBack)
            {
                cwv_Main.GoBack();
                return true;
            }
            else return base.OnBackButtonPressed();
        }

        /// <summary>
        /// 이거 안되네 왜 안대지.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cwv_Main_Navigating(object sender, WebNavigatingEventArgs e)
        {
            //NavigationPage.SetHasNavigationBar(this, e.Url != Url);
        }
    }
}
