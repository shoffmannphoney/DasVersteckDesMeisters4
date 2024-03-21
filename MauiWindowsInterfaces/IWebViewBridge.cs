using System;
using Windows.Foundation;

namespace Maui.Windows.Interfaces
{
  public interface IWebViewBridge
  {
    void Alert(string message);
    void CaptureSignature(string instructions);
       void SetYPos(int yPos);
        void cbFullyLoaded(string message);
    }
}
