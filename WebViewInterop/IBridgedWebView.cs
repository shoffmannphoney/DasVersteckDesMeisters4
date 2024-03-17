namespace WebViewInterop;

public interface IBridgedWebView : IView
{
    public EventHandler<WebNavigatingEventArgs> Navigating { get; set; }
    public EventHandler<WebNavigatedEventArgs> Navigated { get; set; }
}
