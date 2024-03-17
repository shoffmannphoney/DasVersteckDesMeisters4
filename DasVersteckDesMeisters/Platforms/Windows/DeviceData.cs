



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoney_MAUI.Model;


namespace Phoney_MAUI.Platform;
public class DeviceData : IDeviceData
{
    public string GetSavePath()
    {
        string? up = System.Environment.GetEnvironmentVariable("USERPROFILE");
        string? pathName = up + "\\documents\\My Games\\Das Versteck des Meisters";

        return pathName;
    }
    public static DeviceData? _deviceData;
    public static string GetSavePathStatic()
    {
        string? up = System.Environment.GetEnvironmentVariable("USERPROFILE");
        string? pathName = up + "\\documents\\My Games\\Das Versteck des Meisters";

        return pathName;
    }

    public DeviceData()
    {
        _deviceData = this;
    }

    public Microsoft.Maui.Graphics.Point GetAbsolutePosition( Button? b1)
    {
        Microsoft.UI.Xaml.Window? window = (Microsoft.UI.Xaml.Window)App.Current!.Windows!.First<Window>()!.Handler!.PlatformView!;
        var platformview = ( b1!.Handler!.PlatformView as Microsoft.Maui.Platform.MauiButton)!;
        var point = ( platformview!.TransformToVisual(window.Content).TransformPoint(new Windows.Foundation.Point(0, 0)) );

        Microsoft.Maui.Graphics.Point point2 = new();

        point2.X = point.X;
        point2.Y = point.Y;

        return point2;
    }

}
