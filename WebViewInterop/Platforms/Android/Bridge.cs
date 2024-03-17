using Android.Webkit;
using Java.Interop;

// Android Bridge
namespace WebViewInterop;

public partial class Bridge : Java.Lang.Object
{
    public static int BridgeAvail = 0;
    public  DelVoid? _cbFullyLoaded = null;
    private class StringCallback : Java.Lang.Object, IValueCallback
     {
        private TaskCompletionSource<string> source;

        public Task<string> Task { get { return source.Task; } }

        public StringCallback()
        {
          source = new TaskCompletionSource<string>();
        }

        public void OnReceiveValue(Java.Lang.Object value)
        {
            try
            {
            var jstr = value.ToString(); ;
            source.SetResult(jstr.Trim('"'));
            }
            catch (Exception ex)
            {
            source.SetException(ex);
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
        _webView = webView;
        Context.RunOnUiThread(() =>
        {
          webView.AddJavascriptInterface(this, BRIDGE_NAME);
        });
        BridgeAvail = 1;
  }

  public void Disconnect(Android.Webkit.WebView webView)
  {
    Context.RunOnUiThread(() =>
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
        cbFullyLoadedImplementation(message.ToString());
    }
    [JavascriptInterface]
    [Export("setYPos")]
    public void SetYPos(Java.Lang.String? yPos)
    {
        int yPosInt = Int32.Parse((string)yPos!);
        SetYPosImplementation(yPosInt);
    }

    [JavascriptInterface]
  [Export("captureSignature")]
  public void CaptureSignature(Java.Lang.String options)
  {
    CaptureSignatureImplementation(options.ToString());
  }

  public async Task<string> EvaluateJavascriptAsync(string script)
  {
        var javascriptResult = new StringCallback();

        Context!.RunOnUiThread(() =>
        {
            _webView!.EvaluateJavascript(script, javascriptResult);
        });

        var result = await javascriptResult.Task;
        return result;
  }
    public void NavigateToString(string htmlPage)
    {
        Context!.RunOnUiThread(() =>
        {
            _webView!.LoadDataWithBaseURL("file:///android_res/", htmlPage, "text/html; charset=utf-8", "UTF-8", null);
        });
    }
    public void SetCBFullyLoaded(DelVoid cbFullyLoaded)
    {
        Context!.RunOnUiThread(() =>
        {
            _cbFullyLoaded = cbFullyLoaded;
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
