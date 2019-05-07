using Android.Content;
using HowToWebView.Droid.Renderers;
using HowToWebView.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Webkit;
using Android.Graphics;
using System.ComponentModel;

//[assembly: Dependency(typeof(CustomWebViewRenderer_android.UrlChanger_android))]
[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer_android))]
namespace HowToWebView.Droid.Renderers
{
    public class CustomWebViewRenderer_android : ViewRenderer<CustomWebView, Android.Webkit.WebView>
    {
        Context _context;
        //static CustomWebViewRenderer_android currentWebView;
        //public class UrlChanger_android : IWebView
        //{

        //    public bool ChangeWeb(string _url, CustomWebView _webView)
        //    {
                
        //        currentWebView.Control.LoadUrl(_url);
        //        return true;

        //    }

        //    public bool LoadingWeb(string url)
        //    {
        //        return true;
        //    }
        //}
        public CustomWebViewRenderer_android(Context context) : base(context)
        {
            _context = context;
            //currentWebView = this;
        }
        /// <summary>
        /// 관련된 프로퍼티가 무언가 변경되었을때 반응하는 메소드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName=="Source")
            {
                Xamarin.Forms.WebView wv = sender as Xamarin.Forms.WebView;
                Control.LoadUrl((wv.Source as UrlWebViewSource).Url);
            }
        }
        /// <summary>
        /// 요소를 생성/ 파괴 시에만 호출되는 메소드
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var wv = new Android.Webkit.WebView(_context);
                wv.Settings.JavaScriptEnabled = true;
                wv.Settings.CacheMode = CacheModes.NoCache;
                wv.Settings.SetAppCacheEnabled(false);
                wv.Settings.DomStorageEnabled = true;
                wv.Settings.SetSupportZoom(true);
                wv.Settings.AllowUniversalAccessFromFileURLs = true;
                wv.SetWebViewClient(new MyWebViewClient());

                SetNativeControl(wv);
            }
            if (e.OldElement != null)
            {
                //Control.RemoveJavascriptInterface("jsBridge");
                //var hybridWebView = e.OldElement as HybridWebView;
                //hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                //"http://192.168.100.190:11014/login/login.do"
                Control.LoadUrl("http://192.168.100.190:11014/login/login.do");
                
            }
        }
    }

    /// <summary>
    /// WebView 클라이언트 재정의, 메소드 하나만 쓰려고했는데...
    /// </summary>
    public class MyWebViewClient : WebViewClient
    {
        public override void OnPageStarted(Android.Webkit.WebView view, string url, Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);
        }
    }
}