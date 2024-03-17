using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoney_MAUI.Model;

public interface IMenuExtension
{
    public Grid? GetMenuGridLeft();
    public Grid? GetMenuGridTotal();
    public Grid? GetMenuGridMenu();
    public Button? GetMenuButton();
    public Grid? WebView_Grid();
    public Grid? Page_Grid();
    public IUIServices? GetUIServices();
}

