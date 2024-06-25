using Android.Webkit;
using Java.Interop;

// Android Bridge
namespace WebViewInterop;

public partial class Bridge : Java.Lang.Object
{
    public static int BridgeAvail = 0;
    public  DelVoid? _cbFullyLoaded = null;
    public static DelVoidString? _initProtocol = null;
    public static DelVoidStringProtMode? _addProtocol = null;
    private class StringCallback : Java.Lang.Object, IValueCallback
     {
        private TaskCompletionSource<string> source;

        public Task<string> Task { get { return source.Task; } }

        public StringCallback()
        {
          source = new TaskCompletionSource<string>();
        }

        public  void OnReceiveValue(Java.Lang.Object? value)
        {
            try
            {
                var jstr = value!.ToString(); ;
                source.SetResult(jstr.Trim('"'));
            }
            catch (Exception ex)
            {
                AddLog(ex.Message, protMode.crisp);
            }
        }
     }

    private Android.Webkit.WebView? _webView;

    private Android.App.Activity? Context
    {
    get { return Microsoft.Maui.ApplicationModel.Platform.CurrentActivity; }
    }

  public void Connect(Android.Webkit.WebView webView)
  {
        try
        {
            _webView = webView;
            Context!.RunOnUiThread(() =>
            {
                webView.AddJavascriptInterface(this, BRIDGE_NAME);
            });
            BridgeAvail = 1;
        }
        catch (Exception ex)
        {
            AddLog(ex.Message, protMode.crisp);

        }
    }

    public void Disconnect(Android.Webkit.WebView webView)
    {
        Context!.RunOnUiThread(() =>
        {
            webView.RemoveJavascriptInterface(BRIDGE_NAME);
        });
        _webView = null;
    }

    [JavascriptInterface]
    [Export("alert")]
    public void Alert(Java.Lang.String message)
    {
        AlertImplementation(message.ToString());
    }

    [JavascriptInterface]
    [Export("alertStefan")]
    public void AlertStefan(Java.Lang.String message)
    {
        AlertStefanImplementation(message.ToString());
    }
    [JavascriptInterface]
    [Export("cbFullyLoaded")]
    public void cbFullyLoaded(Java.Lang.String message)
    {
        AddLog( "FullyLoadedIn", protMode.medium);
        cbFullyLoadedImplementation(message.ToString());
        AddLog("FullyLoadedOut", protMode.medium);
    }
    [JavascriptInterface]
    [Export("setYPos")]
    public void SetYPos(Java.Lang.String? yPos)
    {
        AddLog("SetYPos in", protMode.medium);

        int yPosInt = Int32.Parse((string)yPos!);
        SetYPosImplementation(yPosInt);

        AddLog("SetYPos ou", protMode.medium);
    }

    [JavascriptInterface]
  [Export("captureSignature")]
  public void CaptureSignature(Java.Lang.String options)
  {
    CaptureSignatureImplementation(options.ToString());
  }

    public async Task<string>? EvaluateJavascriptAsync(string script)
    {
        try
        {
            int len = script.Length;
            if (len > 100)
                len = 100;

            AddLog( "JS Call: " + script.Substring(0, len), protMode.extensive);
            var javascriptResult = new StringCallback();

            Context!.RunOnUiThread(() =>
            {
                _webView!.EvaluateJavascript(script, javascriptResult);
            });

            var result = await javascriptResult.Task;
            return result;
        }
        catch (Exception ex)
        {
            AddLog("Exception EvaluateJavascriptAsync: " + ex.Message, protMode.crisp);
            return null;
        }

    }
    public void NavigateToString(string htmlPage)
    {
        try
        {
            Context!.RunOnUiThread(() =>
            {
                _webView!.LoadDataWithBaseURL("file:///android_res/", htmlPage, "text/html; charset=utf-8", "UTF-8", null);
            });
        }
        catch (Exception ex)
        {
            AddLog( "NavigateToStrign: " + ex.Message, protMode.crisp);

        }
    }   
    public void SetCBFullyLoaded(DelVoid cbFullyLoaded)
    {
        Context!.RunOnUiThread(() =>
        {
            _cbFullyLoaded = cbFullyLoaded;
        });
    }

    public void AddLogNonstatic( string s1, protMode pm = protMode.crisp )
    {
        AddLog(s1, pm);
    }

    public static void AddLog( string s1, protMode pm = protMode.crisp )
    {
        if( _addProtocol != null )
            _addProtocol(s1, pm );   
    }
    public static void InitLog( string s1)
        {
        if( !_initProtocol!.Equals( null ) )
            _initProtocol(s1);
    }
    public void SetProtocol(DelVoidString initProtocol, DelVoidStringProtMode addProtocol)
    {
        Context!.RunOnUiThread( () =>
        {
            _initProtocol = initProtocol;
            _addProtocol = addProtocol;
        });
    }
    public bool InqCBFullyLoaded()
    {
        if (_cbFullyLoaded != null)
            return true;
        else
            return false;
    }
}
