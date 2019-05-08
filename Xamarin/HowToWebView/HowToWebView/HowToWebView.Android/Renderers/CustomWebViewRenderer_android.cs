using Android.Content;
using HowToWebView.Droid.Renderers;
using HowToWebView.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Webkit;
using Android.Graphics;
using System.ComponentModel;
using System.Collections.Generic;

//[assembly: Dependency(typeof(CustomWebViewRenderer_android.UrlChanger_android))]
[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer_android))]
namespace HowToWebView.Droid.Renderers
{
    public class CustomWebViewRenderer_android : ViewRenderer<CustomWebView, Android.Webkit.WebView>
    {
        Context _context;
        public static CustomWebViewRenderer_android getInstance { get; set; }
        public Android.Webkit.WebView wv;
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
            getInstance = this;
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
                string targetUrl = (wv.Source as UrlWebViewSource).Url;
                Control.LoadUrl(targetUrl);
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
                wv = new Android.Webkit.WebView(_context);

                Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);
               
                wv.Settings.JavaScriptEnabled = true; // javacript로 이루어진 기능을 사용하기 위함
                wv.Settings.JavaScriptCanOpenWindowsAutomatically = true;//javacript로 팝업창을 띄울 경우가 있는데, 이걸 사용해야 가능함
                wv.Settings.LoadsImagesAutomatically = true; //WebView가 app에 등록되어 있는 이미지 리소스를 자동으로 로드하도록 설정하는 속성
                //wv.Settings.UseWideViewPort = true;//WebView가 wide viewport를 사용하도록 설정하는 속성, 따라서 html 컨텐츠가 WebView에 맞춰서 나타남
                wv.Settings.CacheMode = CacheModes.CacheElseNetwork; // 웹뷰의 캐시모드 설정
                wv.Settings.SetAppCacheEnabled(false); // app 내부 캐시 사용 여부 설정
                wv.Settings.DomStorageEnabled = true;// 로컬 스토리지 사용 여부 설정, ex 하루동안 보지 않기 기능에 필요함
                wv.Settings.AllowFileAccess = true;// WebView 내에서 파일 액세스 활성화 여부
                wv.SetWebChromeClient(new WebChromeClient());
                //wv.Settings.UserAgentString = "app"; // 웹에서 해당 속성을 통해 앱에서 띄운 웹뷰로 인지 할 수 있도록 하기 위함.app으로 할경우 웹페이지가 pc 화면으로 출력됨
                wv.Settings.SetSupportZoom(true);//확대 축소 기능을 사용할 수 있도록 설정하는 속성
                wv.Settings.BuiltInZoomControls = true;
                wv.Settings.AllowUniversalAccessFromFileURLs = true;
                //wv.Settings.BlockNetworkImage = false;
                //wv.VerticalScrollBarEnabled = true; //세로 스크롤을 사용 할 수 있는지 여부
                wv.SetWebViewClient(new MyWebViewClient());

#pragma warning disable CS0618 // 형식 또는 멤버는 사용되지 않습니다.
                wv.LayoutParameters=new Android.Widget.AbsoluteLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, 0, 0);//특수한 케이스로 페이지의 자바스크립트를 올바르게 실행하지 못해 페이지 위치를 잘못 지정할 경우 이 문장을 사용해야한다.
#pragma warning restore CS0618 // 형식 또는 멤버는 사용되지 않습니다.
                SetNativeControl(wv);
            }
            if (e.OldElement != null)
            {
                //Web에서 실행되는 JavaScript 메소드에 반응하기 위한 구문.
                //Control.RemoveJavascriptInterface("jsBridge");
                //var hybridWebView = e.OldElement as HybridWebView;
                //hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                //"http:naver.com"
                wv.LoadUrl("http:naver.com");
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

        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            base.OnPageFinished(view, url);
        }


        //public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, string url)
        //{
        //    view.LoadUrl(url);
        //    return false;
        //}
        //For API level 24 and later
        //public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, IWebResourceRequest request)
        //{
        //    return base.ShouldOverrideUrlLoading(view, request);
        //}


    }
}
