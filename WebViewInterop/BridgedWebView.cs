using WebViewInterop.Handlers;

namespace WebViewInterop;

public delegate bool DelString(string s);
public delegate bool DelIntString(int val, string s);
public delegate bool DelSelection(int Selection);
public delegate bool DelAdvObject(int ID);
public delegate bool DelDouble(double d);
public delegate bool DelVoid();
public delegate bool Del4Double(double a, double b, double c, double d);
public delegate void DelVoidSenderObject(object o, EventArgs ea);

public delegate bool DelInt(int val);

public class BridgedWebView : View, IBridgedWebView
{
    public string? LatestString { get; set; } = null;

    /*
    public async Task<string> EvaluateJavascriptAsync(string script )
    {
        var handler = this.Handler;

        var result = await (handler as  BridgedWebViewHandler).GetBridge().EvaluateJavascriptAsync(script);

        return result;

        
    }
    */
    public async Task<string> EvaluateJavaScriptAsync(string script)
    {
        var handler = this.Handler;

        var result = await (handler as BridgedWebViewHandler)!.GetBridge()!.EvaluateJavascriptAsync(script);

        return result;


    }

    public void NavigateToString( string htmlPage )
    {
        LatestString = htmlPage;

        var handler = this.Handler;

        (handler as BridgedWebViewHandler)!.GetBridge()!.NavigateToString(htmlPage);
    }

    public bool InqCBFullyLoaded()
    {
        var handler = this.Handler; 

        if( handler == null )
        {
            return false;
        }
        else if((handler as BridgedWebViewHandler)!.GetBridge() == null )
        {
            return false;
        }
        else
        {
            return (handler as BridgedWebViewHandler)!.GetBridge()!.InqCBFullyLoaded();
        }
    }
    public void SetCBFullyLoaded(DelVoid cbFullyLoaded )
    {
#if ANDROID
        Platform.CurrentActivity!.RunOnUiThread(() =>
        {
            this.BackgroundColor = Colors.Red;
            var handler = this.Handler;

            if (Handler != null)
                (handler as BridgedWebViewHandler)!.GetBridge().SetCBFullyLoaded(cbFullyLoaded);
        });
#else
        this.BackgroundColor = Colors.Red;
        var handler = this.Handler;

        if (Handler != null)
            (handler as BridgedWebViewHandler)!.GetBridge()!.SetCBFullyLoaded(cbFullyLoaded);
#endif
    }
    public EventHandler<WebNavigatingEventArgs>? Navigating { get; set; }
    public EventHandler<WebNavigatedEventArgs>? Navigated { get; set; }

    // Definiert eine virtuelle Methode, die das Ereignis auslöst
    protected virtual void OnNavigating(WebNavigatingEventArgs e)
    {
        // Prüft, ob es Abonnenten für das Ereignis gibt
        if (Navigating != null)
        {
            // Löst das Ereignis aus
            Navigating(this, e);

        }
    }
    protected virtual void OnNavigated(WebNavigatedEventArgs e)
    {
        // Prüft, ob es Abonnenten für das Ereignis gibt
        if (Navigated != null)
        {
            // Löst das Ereignis aus
            Navigated(this, e);

        }
    }
}