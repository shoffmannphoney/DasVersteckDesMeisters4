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
        var handler =  this.Handler;
        try
        {
            while( handler == null )
            {
                await Task.Delay(100);
                handler = this.Handler;
            }
            var result = await (handler as BridgedWebViewHandler)!.GetBridge()!.EvaluateJavascriptAsync(script);

            return result;
        }
        catch (Exception ex)
        {
            
        }
        return null;
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
            return false;
        }
    }

    public void SetProtocol(DelVoidString ds1, DelVoidStringProtMode dspm1)
    {

        try
        {
#if ANDROID
            Platform.CurrentActivity!.RunOnUiThread(() =>
            {
                this.BackgroundColor = Colors.Black;
                var handler = this.Handler;

                if (Handler != null)
                    (handler as BridgedWebViewHandler)!.GetBridge().SetProtocol( ds1, dspm1 );
            });
#endif
        }
        catch (Exception ex)
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
                (handler as BridgedWebViewHandler)!.GetBridge().SetCBFullyLoaded(cbFullyLoaded);
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

        }
    }
    public EventHandler<WebNavigatingEventArgs>? Navigating { get; set; }
    public EventHandler<WebNavigatedEventArgs>? Navigated { get; set; }

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

        }
    }
}