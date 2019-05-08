using HowToWebView.Views;

namespace HowToWebView.EventHandels
{
    public interface IWebView
    {
        bool LoadingWeb(string url);
        bool ChangeWeb(string _url, CustomWebView _webView);
    }
}
