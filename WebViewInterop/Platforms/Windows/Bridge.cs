using Maui.Windows.Interfaces;
using Microsoft.UI.Xaml.Controls;

// Windows-Bridge
namespace WebViewInterop;


public partial class Bridge : IWebViewBridge
{
    public static int BridgeAvail = 0;
    public DelVoid? _cbFullyLoaded = null;
    public static DelString? _initProtocol = null;
    public static DelVoidStringProtMode? _addProtocol = null;

    private string? _currentStartupId;

    private WebView2? _webView;

    public static void AddLog(string s1, protMode pm = protMode.crisp)
    {
        if (_addProtocol != null)
            _addProtocol(s1, pm);
    }

    public async Task Connect(WebView2 webView)
  {
        try
        {
            _webView = webView;
            Windows.Foundation.IAsyncAction ias;
            ias = _webView.EnsureCoreWebView2Async();
            await ias; //.GetAwaiter();
            Thread.Sleep(50);

            if (_webView.CoreWebView2 == null)
            {

            }
            // await _webView.EnsureCoreWebView2Async();

            webView.CoreWebView2.Settings.AreDevToolsEnabled = true;
            webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;
            webView.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = true;
            webView.CoreWebView2.Settings.IsScriptEnabled = true;
            webView.CoreWebView2.Settings.IsWebMessageEnabled = true;


            var dispatchAdapter = new WinRTAdapter.DispatchAdapter();

            webView.CoreWebView2.AddHostObjectToScript("bridge", dispatchAdapter.WrapObject(this, dispatchAdapter));
            _currentStartupId = await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(@"window.webViewBridge = chrome.webview.hostObjects.sync.bridge;");

        }
        catch ( Exception ex)
        {
            AddLog("Connect" + ex.Message, protMode.crisp);

        }
    }

  public void Disconnect(WebView2 webView)
  {
    _webView = null;
    webView.CoreWebView2.RemoveScriptToExecuteOnDocumentCreated(_currentStartupId);
    webView.CoreWebView2.RemoveHostObjectFromScript("bridge");
  }

  public void Alert(string message)
  {
    AlertImplementation(message);
  }
    public void AlertStefan(string message)
    {
        AlertStefanImplementation(message);
    }
    public void cbFullyLoaded(string message)
    {
        cbFullyLoadedImplementation(message);
    }
    public void SetYPos(int yPos)
    {
        SetYPosImplementation(yPos);
    }

    public void CaptureSignature(string options)
  {
    CaptureSignatureImplementation(options);
  }

    List<string>? LatestCalls = null;

  public async Task<string>? EvaluateJavascriptAsync(string script)
  {
        try
        {
            if ((!script.StartsWith("window.") || script.StartsWith("window.scrollTo")) && !script.StartsWith("document."))
            {
                script += " console.log( window.pageYOffset );";
                script += " console.log( \"" + script + "\" );";

            }
            if (_webView!.CoreWebView2 == null)
            {
                await _webView!.EnsureCoreWebView2Async();
            }
            if (LatestCalls == null) LatestCalls = new();

            LatestCalls.Add(script);

            var result = await _webView.CoreWebView2!.ExecuteScriptAsync(script);
            return result;
        }
        catch (Exception ex)
        {
            AddLog("EvaluateJavascriptAsync Windows:" + ex.Message, protMode.crisp);
            return null;
        }

    }

    public async void NavigateToString(string htmlPage)
    {
        /*
        if (_webView.CoreWebView2 == null)
        {
            _webView.EnsureCoreWebView2Async().AsTask().ContinueWith((t) =>
            {
                sync.Post((o) => NavigateToString(htmlPage);
            });
        }
        else
        {
            _webView.NavigateToString(htmlPage);

        }
        */
        if (_webView!.CoreWebView2 == null)
        {
            Windows.Foundation.IAsyncAction ias;

            ias = _webView.EnsureCoreWebView2Async();
            await ias; //.GetAwaiter();
            
            if(_webView.CoreWebView2 == null )
            {

            }
            else
            {

            }
        }
        try
        {
            _webView.NavigateToString(htmlPage);
        }
        catch (Exception ex)
        {
            AddLog("NavigateToString:" + ex.Message, protMode.crisp);
        }
    }
    public void SetCBFullyLoaded( DelVoid cbFullyLoaded )
    {
        _cbFullyLoaded = cbFullyLoaded;
    }
    public bool InqCBFullyLoaded()
    {
        if (_cbFullyLoaded != null)
            return true;
        else
            return false;
    }
}
