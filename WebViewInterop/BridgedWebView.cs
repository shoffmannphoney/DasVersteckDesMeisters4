using WebViewInterop.Handlers;

namespace WebViewInterop;

public enum protMode { off, crisp, medium, extensive };

public delegate bool DelString(string s);
public delegate void DelVoidString(string s);
public delegate bool DelIntString(int val, string s);
public delegate bool DelSelection(int Selection);
public delegate bool DelAdvObject(int ID);
public delegate bool DelDouble(double d);
public delegate bool DelVoid();
public delegate bool Del4Double(double a, double b, double c, double d);
public delegate void DelVoidSenderObject(object o, EventArgs ea);
public delegate bool DelStringProtMode(string s1, protMode PM );
public delegate void DelVoidStringProtMode(string s1, protMode PM);


public delegate bool DelInt(int val);

public class BridgedWebView : View, IBridgedWebView
{
    public static DelVoidString? _initProtocol = null;
    public static DelVoidStringProtMode? _addProtocol = null;
    public string? LatestString { get; set; } = null;

    /*
    public async Task<string> EvaluateJavascriptAsync(string script )
    {
        var handler = this.Handler;

        var result = await (handler as  BridgedWebViewHandler).GetBridge().EvaluateJavascriptAsync(script);

        return result;

        
    }
    */
      public async Task<string?> EvaluateJavaScriptAsync(string script)
    {
        try
        {
            string? result = null;
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var handler = this.Handler;
                try
                {
                    while (handler == null)
                    {
                        await Task.Delay(100);
                        handler = this.Handler;
                    }
                    result = await (handler as BridgedWebViewHandler)!.GetBridge()!.EvaluateJavascriptAsync(script)!;

                    // return result;
                }
                catch (Exception ex)
                {
                    if (_addProtocol != null)
                        _addProtocol("Execution JS failed: " + ex.Message.ToString(), protMode.crisp);

                }
            });
            return result;
        }
        catch (Exception ex)
        {
            if (_addProtocol != null)
                _addProtocol("Exception webView_NavigationCompleted: " + ex.Message.ToString(), protMode.crisp);
            return null;
        }

    }

    public void NavigateToString(string htmlPage)
    {
        try
        {
            LatestString = htmlPage;

            var handler = this.Handler;
            /*
            while (handler == null)
            {
                Task.Delay(100);
                handler = this.Handler;
            }
            */

            if( handler != null )
                 (handler as BridgedWebViewHandler)!.GetBridge()!.NavigateToString(htmlPage);
        }
        catch (Exception ex)
        {

            if (_addProtocol != null)
                _addProtocol("NavigateToString failed: " + ex.Message.ToString(), protMode.crisp);
        }
    }

    public bool InqCBFullyLoaded()
    {
        try
        {
            var handler = this.Handler;

            if (handler == null)
            {
                return false;
            }
            else if ((handler as BridgedWebViewHandler)!.GetBridge() == null)
            {
                return false;
            }
            else
            {
                return (handler as BridgedWebViewHandler)!.GetBridge()!.InqCBFullyLoaded();
            }
        }
        catch (Exception ex)
        {
            if (_addProtocol != null)
                _addProtocol("InqCBFullyLoaded failed: " + ex.Message.ToString(), protMode.crisp);
            return false;
        }
    }

    public void SetProtocol(DelVoidString ds1, DelVoidStringProtMode dspm1)
    {

        try
        {
            _initProtocol = ds1;
            _addProtocol = dspm1;

#if ANDROID
            Platform.CurrentActivity!.RunOnUiThread(() =>
            {
                this.BackgroundColor = Colors.Black;
                var handler = this.Handler;

                if (Handler != null)
                    (handler as BridgedWebViewHandler)!.GetBridge()!.SetProtocol( ds1, dspm1 );
            });
#endif
        }
        catch // (Exception ex)
        {

        }
    }
    public void SetCBFullyLoaded(DelVoid cbFullyLoaded )
    {
        try
        { 
#if ANDROID
        Platform.CurrentActivity!.RunOnUiThread(() =>
        {
            this.BackgroundColor = Colors.Black;
            var handler = this.Handler;

            if (Handler != null)
                (handler as BridgedWebViewHandler)!.GetBridge()!.SetCBFullyLoaded(cbFullyLoaded);
        });
#else
        this.BackgroundColor = Colors.Black;
        var handler = this.Handler;

        if (Handler != null)
            (handler as BridgedWebViewHandler)!.GetBridge()!.SetCBFullyLoaded(cbFullyLoaded);
#endif
        }
        catch (Exception ex)
        {

            if (_addProtocol != null)
                _addProtocol("SetCBFullyLoaded failed: " + ex.Message.ToString(), protMode.crisp);
        }
    }
    public EventHandler<WebNavigatingEventArgs> Navigating { get; set; }
    public EventHandler<WebNavigatedEventArgs> Navigated { get; set; }

    // Definiert eine virtuelle Methode, die das Ereignis auslöst
    protected virtual void OnNavigating(WebNavigatingEventArgs e)
    {
        try
        {
            // Prüft, ob es Abonnenten für das Ereignis gibt
            if (Navigating != null)
            {
                // Löst das Ereignis aus
                Navigating(this, e);

            }
        }
        catch (Exception ex)
        {

            if (_addProtocol != null)
                _addProtocol("OnNavigating failed: " + ex.Message.ToString(), protMode.crisp);
        }
    }
    protected virtual void OnNavigated(WebNavigatedEventArgs e)
    {
        try
        {
            // Prüft, ob es Abonnenten für das Ereignis gibt
            if (Navigated != null)
            {
                // Löst das Ereignis aus
                Navigated(this, e);

            }
        }
        catch (Exception ex)
        {
            if (_addProtocol != null)
                _addProtocol("OnNavigated failed: " + ex.Message.ToString(), protMode.crisp);

        }
    }
}