using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HowToWebView.Droid.Renderers;

namespace HowToWebView.Droid
{
    [Activity(Label = "HowToWebView", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// 뒤로가기 버튼을 누를 경우 WebView에 저장되어 있는 url로 회귀합니다.
        /// </summary>
        public override void OnBackPressed()
        {
           
            System.Diagnostics.Debug.WriteLine("안드로이드에서 뒤로가기 버튼을 눌렀습니다.");
            if (CustomWebViewRenderer_android.getInstance.OnBackPressed())
            {

            }
            else
            {
                base.OnBackPressed();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
      

    }
}