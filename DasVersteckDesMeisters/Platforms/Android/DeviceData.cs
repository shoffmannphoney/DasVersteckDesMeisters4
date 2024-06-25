using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Phoney_MAUI.Model;

namespace Phoney_MAUI.Platform;
public class DeviceData : IDeviceData
{
    public string GetSavePath()
    {
        // string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Phoney Island MAUI";

        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

        string path = docsDirectory + "/The Masters Lair";
        return path;
    }
    public static string GetSavePathStatic()
    {
        // string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Phoney Island MAUI";

        var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);

        string path = docsDirectory + "/The Masters Lair";
        return path;
    }
    public static DeviceData? _deviceData;

    public DeviceData()
    {
        _deviceData = this;
    }

    public Microsoft.Maui.Graphics.Point GetAbsolutePosition(Button b1)
    {
         Microsoft.Maui.Graphics.Point point2 = new();

  
        return point2;
    }
}