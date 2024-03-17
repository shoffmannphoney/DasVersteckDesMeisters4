using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoney_MAUI.Core;
public interface INavigationService
{
    Task GoToAsync(string location);
    Task GoToAsync(string location, bool animate);
    Task GoToAsync(string location, Dictionary<string, object> parameters);
    Task GoToAsync(string location, bool animate, Dictionary<string, object> parameters);
}
