using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;

namespace WebViewInterop.Handlers;


public class WebView2a : WebView2
{

}

public class BridgedWebViewHandler : ViewHandler<IBridgedWebView, WebView2>
{
    public static PropertyMapper<IBridgedWebView, BridgedWebViewHandler> BridgedWebViewMapper = new PropertyMapper<IBridgedWebView, BridgedWebViewHandler>(ViewHandler.ViewMapper);

    private Bridge? _bridge;
    private WebView2? _webView;

    private IBridgedWebView? _bridgeWebView;
    bool isAppInitiatedNavigation = false;
    bool isAppCompletingNavigation = false;

    public BridgedWebViewHandler() : base(BridgedWebViewMapper)
     {
     }

    protected override WebView2? CreatePlatformView()
    {
        try
        {
            var webView = new WebView2();

            _bridge = new Bridge();
            _webView = webView;
            InitializeWebView(webView);
            webView.DefaultBackgroundColor = Windows.UI.Color.FromArgb(255, 0, 0, 0);
            webView.RequestedTheme = Microsoft.UI.Xaml.ElementTheme.Dark;

            webView.NavigationStarting += webView_NavigationStarting;
            webView.NavigationCompleted += webView_NavigationCompleted;

            _bridgeWebView = this.VirtualView;

            return webView;
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()!("CreatePlatformView" + ex.Message, protMode.crisp);
            return null;
        }
    }

    private void InitializeWebView(WebView2 webView)
  {
  }

    /*
    public class MySchemeHandler : // ICoreWebView2WebResourceRequestedHandler
    {
        public ICoreWebView2WebResourceResponse Invoke(ICoreWebView2 sender, ICoreWebView2WebResourceRequestedEventArgs args)
        {
            var uri = args.Request.Uri;
            if (uri.StartsWith("myapp://"))
            {
                var path = uri.Substring("myapp://".Length);
                var stream = GetStreamFromPath(path); // Ihre eigene Logik, um einen Stream aus einem Pfad zu erhalten
                var response = sender.Environment.CreateWebResourceResponse(stream, 200, "OK", "");
                return response;
            }
            return null;
        }
    }
    */

    // Windows
    protected override async void ConnectHandler(WebView2 platformView)
  {
        try
        {
            base.ConnectHandler(platformView);

            await _bridge!.Connect(platformView);

            //platformView.Source = new Uri("https://www.google.com");

            platformView.CoreWebView2.SetVirtualHostNameToFolderMapping("wwwroot", "WebApp", CoreWebView2HostResourceAccessKind.Allow);
            platformView.CoreWebView2.Navigate("https://wwwroot/Index.html");
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()!("ConnectHandler: " + ex.Message, protMode.crisp);
        }


    }

    // Überschreibe das NavigationStarting Event, um die Navigation zu überprüfen
    protected override void DisconnectHandler(WebView2 platformView)
    {
        base.DisconnectHandler(platformView);
        _bridge!.Disconnect(platformView);
    }
    public Bridge? GetBridge()
    {
        return _bridge;
    }

    public static DelVoidStringProtMode? GetAddProt()
    {
        return Bridge._addProtocol;
    }

    public void webView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
    {
        try
        {
            // Wenn die Navigation nicht von der Anwendung ausgelöst wurde, breche sie ab
            if (!isAppInitiatedNavigation)
            {
                e.Cancel = true;
            }

            isAppInitiatedNavigation = true;

            if (_bridgeWebView!.Navigating != null)
            {
                WebNavigatingEventArgs wnea = new(WebNavigationEvent.Refresh, null, e.Uri);

                _bridgeWebView.Navigating(sender, wnea);

                if (wnea.Cancel == true)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            // Setze die Variable für die nächste Navigation zurück
            isAppInitiatedNavigation = false;
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()!("webView_NavigationStarting: " + ex.Message, protMode.crisp);
        }

    }
    public void webView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        try
        {
            // Wenn die Navigation nicht von der Anwendung ausgelöst wurde, breche sie ab
            isAppCompletingNavigation = true;

            if (_bridgeWebView!.Navigating != null)
            {
                WebNavigationResult res = new();
                WebNavigatedEventArgs wnea = new(WebNavigationEvent.Refresh, null, null, res);

                _bridgeWebView.Navigated(sender, wnea);

            }
            // Setze die Variable für die nächste Navigation zurück
            isAppCompletingNavigation = false;
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()!("webView_NavigationCompleted: " + ex.Message, protMode.crisp);
        }

    }
}
