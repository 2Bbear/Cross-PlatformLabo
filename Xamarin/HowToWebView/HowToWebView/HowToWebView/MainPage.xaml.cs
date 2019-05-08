
using HowToWebView.CommonClass;
using System;
using Xamarin.Forms;

namespace HowToWebView
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            MyInitComponent();
        }
        
        public void MyInitComponent()
        {
            editor_url.Text = LoadResourceText.GetText("PreSavedText.txt");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var urlChanger = DependencyService.Get<IWebView>();
            //urlChanger.ChangeWeb(editor_url.Text, cwv_Main);
            LoadResourceText.SaveText("PreSavedText.txt", editor_url.Text);
            cwv_Main.Source = handleLoadUrl(editor_url.Text);
            cwv_Main.Source=(cwv_Main.Source as UrlWebViewSource).Url;
        }

        /// <summary>
        /// url ediotr에 http등이 붙지 않은 url을 적을 경우 http를 붙이는 메소드
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private string handleLoadUrl(string arg)
        {
            string url= arg;
            if (url.StartsWith("http://"))
            {

            }
            else if (url.StartsWith("http:"))
            {

            }
            else if (url.StartsWith("https://"))
            {

            }
            else if (url.StartsWith("file:"))
            {

            }
            else
            {
                url = String.Format("http://{0}", url);
            }
            return url;
        }


       
    }
}
