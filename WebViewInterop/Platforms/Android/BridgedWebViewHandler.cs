using Android.Views;
using Android.Webkit;
using Microsoft.Maui.Handlers;
using static Android.Views.ViewGroup;

namespace WebViewInterop.Handlers;

public class CustomWebViewClient : WebViewClient
{

    public CustomWebViewClient()
    {
    }

    /*
    public override bool shouldOverrideUrlLoading(Android.Webkit.WebView view, String url)
    {
        Uri uri = Uri.parse(url);
        return handleUri(uri);
    }
    */

    public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView? view, IWebResourceRequest? request)
    {
        try
        {


            bool cancel = false;

            if (!BridgedWebViewHandler.isAppInitiatedNavigation)
            {
                cancel = true;
            }

            BridgedWebViewHandler.isAppInitiatedNavigation = true;

            if (BridgedWebViewHandler._bridgeWebView!.Navigating != null)
            {
                WebNavigatingEventArgs wnea = new(WebNavigationEvent.Refresh, null, request!.Url!.ToString());

                BridgedWebViewHandler._bridgeWebView.Navigating(view, wnea);

                if (wnea.Cancel == true)
                {
                    cancel = true;
                }
                else
                {
                    cancel = false;
                }
            }
            // Setze die Variable für die nächste Navigation zurück
            BridgedWebViewHandler.isAppInitiatedNavigation = false;

            return cancel;
        }
        catch (Exception ex)
        {
            // GetBridge().AddLog(ex.Message, protMode.crisp);0
            BridgedWebViewHandler.GetAddProt()( ex.Message, protMode.crisp);
            return false;
        }
    }
    public override void OnPageFinished(Android.Webkit.WebView? view, string? Url )
    {
        try
        {
            // Wenn die Navigation nicht von der Anwendung ausgelöst wurde, breche sie ab
            BridgedWebViewHandler.isAppCompletingNavigation = true;

            if (BridgedWebViewHandler._bridgeWebView!.Navigating != null)
            {
                WebNavigationResult res = new();
                WebNavigatedEventArgs wnea = new(WebNavigationEvent.Refresh, null, null, res);

                BridgedWebViewHandler._bridgeWebView.Navigated(view, wnea);

            }
            // Setze die Variable für die nächste Navigation zurück
            BridgedWebViewHandler.isAppCompletingNavigation = false;
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()(ex.Message, protMode.crisp);

        }
    }
    /*
     public override void OnPageStarted(Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
     {
         base.OnPageStarted(view, url, favicon);
         // Ihre Logik kommt hier
         // Wenn die Navigation nicht von der Anwendung ausgelöst wurde, breche sie ab
         if (!BridgedWebViewHandler.isAppInitiatedNavigation)
         {
             e.Cancel = true;
         }

         BridgedWebViewHandler.isAppInitiatedNavigation = true;

         if (BridgedWebViewHandler._bridgeWebView.Navigating != null)
         {
             WebNavigatingEventArgs wnea = new(WebNavigationEvent.Refresh, null, url);

             BridgedWebViewHandler._bridgeWebView.Navigating(view, wnea);

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
         BridgedWebViewHandler.isAppInitiatedNavigation = false;
     }
     */
}

public class BridgedWebViewHandler : ViewHandler<IBridgedWebView, Android.Webkit.WebView>
{
    public static PropertyMapper<IBridgedWebView, BridgedWebViewHandler> BridgedWebViewMapper = new PropertyMapper<IBridgedWebView, BridgedWebViewHandler>(ViewHandler.ViewMapper);

    public static bool isAppInitiatedNavigation = false;
    public static bool isAppCompletingNavigation = false;
    public static Bridge? _bridge;
    public static IBridgedWebView? _bridgeWebView;

    private Android.App.Activity? Context
    {
        get { return Microsoft.Maui.ApplicationModel.Platform.CurrentActivity; }
    }


    public BridgedWebViewHandler() : base(BridgedWebViewMapper)
    {
    }

    protected override Android.Webkit.WebView CreatePlatformView()
    {
        try
        {
            var webView = new Android.Webkit.WebView(Context!)
            {
                LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
            };
            _bridge = new Bridge();
            InitializeWebView(webView);

            CustomWebViewClient cwc = new();
            webView.SetWebViewClient(cwc);

            _bridgeWebView = this.VirtualView;
            // Navigating und Navigated bedienen
            return webView;
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()(ex.Message, protMode.crisp);
            return null;
        }
    }


    public void InitializeWebView(Android.Webkit.WebView webView)
    {
        try
        {
            webView.Settings.JavaScriptEnabled = true;

            // enable window.localStorage
            webView.Settings.DatabaseEnabled = true;
            webView.Settings.DomStorageEnabled = true;

            // allow zooming/panning
            webView.Settings.BuiltInZoomControls = false;
            webView.Settings.SetSupportZoom(false);
            webView.Settings.TextZoom = 100;

            // allow file access. without this the access from javascript to linked style sheets will fail
            // document.styleSheets[0].cssRules -> null!!!
            webView.Settings.AllowFileAccess = true;
            webView.Settings.AllowFileAccessFromFileURLs = true;
            webView.Settings.AllowUniversalAccessFromFileURLs = true;
            webView.Settings.MediaPlaybackRequiresUserGesture = false;

            // scrollbar stuff
            webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay; // so there's no 'white line'
            webView.ScrollbarFadingEnabled = false;

            Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);

            /*
              Using WebChromeClient allows you to handle Javascript dialogs, favicons, titles, and the progress. 
              Take a look of this example: Adding alert() support to a WebView

              At first glance, there are too many differences WebViewClient & WebChromeClient. 
              But, basically: if you are developing a WebView that won't require too many features but rendering HTML, 
              you can just use a WebViewClient. On the other hand, if you want to (for instance) load the favicon of 
              the page you are rendering, you should use a WebChromeClient object and override the 
              onReceivedIcon(WebView view, Bitmap icon).

              http://www.phonesdevelopers.com/1752491/
           */
            CookieManager.Instance!.SetAcceptThirdPartyCookies(webView, true);
            webView.SetWebChromeClient(new WebChromeClient());
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()(ex.Message, protMode.crisp);

        }
    }

    protected override void ConnectHandler(Android.Webkit.WebView platformView)
    {
        try
        {
            base.ConnectHandler(platformView);

            _bridge!.Connect(platformView);

            // platformView.LoadUrl("https://www.google.com");

            string? baseUrl = "file:///android_asset/raw/";


            // String html = "<html><head><title>TITLE!!!</title></head>";
            // html += "<body><h1>Image?</h1><img src=\"lx_01.jpg\" /></body></html>";


            // platformView.LoadDataWithBaseURL("file:///android_res/raw/", html, "text/html", "UTF-8", null);

            platformView.LoadUrl("file:///android_asset/WebApp/Index.html");


            // platformView.LoadDataWithBaseURL( baseUrl, 
        }
        catch (Exception ex)
        {
            BridgedWebViewHandler.GetAddProt()(ex.Message, protMode.crisp);

        }

    }

    protected override void DisconnectHandler(Android.Webkit.WebView platformView)
    {
        base.DisconnectHandler(platformView);
        _bridge!.Disconnect(platformView);
    }
    public Bridge? GetBridge()
    {
        return _bridge;
    }

    public static Bridge? GetBridgeStatic()
    {
        return _bridge;
    }
    public static DelVoidStringProtMode? GetAddProt()
    {
        return Bridge._addProtocol;
    }
    public static DelVoidString? GetInitProt()
    {
        return Bridge._initProtocol;
    }
}