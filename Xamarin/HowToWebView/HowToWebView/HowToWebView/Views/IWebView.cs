using System;
using System.Collections.Generic;
using System.Text;

namespace HowToWebView.Views
{
    public interface IWebView
    {
        bool LoadingWeb(string url);
        bool ChangeWeb(string _url, CustomWebView _webView);
    }
}
