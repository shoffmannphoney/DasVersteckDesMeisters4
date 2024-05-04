using CommunityToolkit.Mvvm.Messaging;
using System.Text.Json;

namespace WebViewInterop;

public partial class Bridge
{
    private const string BRIDGE_NAME = "webViewBridge";


    public Bridge()
    {
        WeakReferenceMessenger.Default.Register<SignatureCaptureResultMessage>(this, (r, m) =>
        {
            ProvideSignature(m.Value);
        });

      
    }

    private async void ProvideSignature(SignatureCaptureResult result)
    {
        var options = new JsonSerializerOptions();
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        var json = JsonSerializer.Serialize(result, options);
        var res = await EvaluateJavascriptAsync($"window.webViewBridgeTarget.provideSignature({json})");
    }

    public async void AlertImplementation(string message)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Application.Current!.MainPage!.DisplayAlert("Information", message.ToString(), "OK");
        });
    }
    public async void AlertStefanImplementation(string message)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Application.Current!.MainPage!.DisplayAlert("Stefan Information", message.ToString(), "Oha");
        });
    }

    public async void    cbFullyLoadedImplementation(string message)
    {
        if( _cbFullyLoaded != null )
        {
            _cbFullyLoaded();
        }
    }

    public async void SetYPosImplementation(int yPos)
    {
#if ANDROID
        AddLog( "SetYPosIn", protMode.extensive);
#endif
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {

            await EvaluateJavascriptAsync("window.scrollTo( 0, " + yPos + " )");

            // await Application.Current.MainPage.DisplayAlert("Stefan Information", message.ToString(), "Oha");
        });
#if ANDROID
        AddLog( "SetYPosOut", protMode.extensive);
#endif
    }

    public void CaptureSignatureImplementation(string options)
    {
        var serializierOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        var o = JsonSerializer.Deserialize<SignatureCaptureOptions>(options, serializierOptions);
        WeakReferenceMessenger.Default.Send(new SignatureCaptureMessage(o!));
    }
}
