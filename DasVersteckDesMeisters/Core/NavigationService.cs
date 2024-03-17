using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoney_MAUI.Core;

public class NavigationService : INavigationService
{
    public async Task GoToAsync(string location)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Shell.Current.GoToAsync(location);
        });
    }
    public async Task GoToAsync(string location, bool animate)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Shell.Current.GoToAsync(location, false);
            Shell.Current.IsVisible = false;
        });
    }
    public async Task GoToAsync(string location, Dictionary<string, object> Parameters)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Shell.Current.GoToAsync(location, Parameters);
        });
    }
    public async Task GoToAsync(string location, bool animate, Dictionary<string, object> Parameters)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Shell.Current.GoToAsync(location, animate, Parameters);
        });
    }
}
