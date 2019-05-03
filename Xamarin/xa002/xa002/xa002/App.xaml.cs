using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace xa002
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            switch (Device.Idiom)
            {
                case TargetIdiom.Unsupported:
                    {

                    }
                    break;
                case TargetIdiom.Phone:
                    {
                        MainPage = new MainPage();
                    }
                    break;
                case TargetIdiom.Tablet:
                    {

                    }
                    break;
                case TargetIdiom.Desktop:
                    {
                        MainPage = new Page_Desktop();
                    }
                    break;
                case TargetIdiom.TV:
                    {

                    }
                    break;
                case TargetIdiom.Watch:
                    {

                    }
                    break;

                    
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
