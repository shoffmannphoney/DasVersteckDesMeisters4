using Phoney_MAUI.Core;
using System;
using System.Threading;
using Microsoft.Maui.Controls;

#if WINDOWS


#endif

namespace Phoney_MAUI;

public partial class App : Application
{
    public static Page? AppMainPage;
    public static Page? CurrentPage;
    public static Window? MainWindow;

    private Phoney_MAUI.Model.DelVoid? DestroyCallback { get; set; }
    private Phoney_MAUI.Model.DelVoid? StoppedCallback { get; set; }

    // Erstellen Sie einen Delegaten für die asynchrone Methode
    // Func<Task<bool>>? asyncMethod; 
    public static App? ThisApplication { get; set; }

    public enum appState { running, closing }
    public static appState AppState { get; set; }
 

    public App()
	{
		InitializeComponent();

        ThisApplication = this;

        MainPage = new AppShell();
		AppMainPage = MainPage;

        

    }

#if WINDOWS
    private void Window_SizeChanged(object? sender, EventArgs e)
    {
        // Führe hier deine Logik aus
    }

#endif
    private void Window_Destroyer(object? sender, EventArgs e)
    {
        AppState = appState.closing;
        if (DestroyCallback != null)
        {
            DestroyCallback();
            DestroyCallback = null;
        }
        OnDestroy();
    }
    protected void OnDestroy()
    {
        AppState = appState.closing;
        if (DestroyCallback != null)
        {
            DestroyCallback();
            DestroyCallback = null;
        }
    }
    protected override Window CreateWindow(IActivationState? activationState)
    {   
        MainWindow = base.CreateWindow(activationState);

#if ANDROID
        MainWindow.Stopped+= (s, e) =>
        {
            if( StoppedCallback != null)
            {
                StoppedCallback();
            }   
        };
#endif
        
        AppState = appState.running;
#if WINDOWS
        Phoney_MAUI.Model.ILayoutDescription? ld = UIServices.ReadConfig();
        if (ld != null)
        {
            MainWindow.X = ld!.WinX;
            MainWindow.Y = ld!.WinY;
            MainWindow.Width = ld!.WinWidth;
            MainWindow.Height = ld!.WinHeight;


        }
        MainWindow.MinimumWidth = 600;
        MainWindow.MinimumHeight = 400;
        MainWindow.SizeChanged += Window_SizeChanged;
        MainWindow.Destroying += Window_Destroyer;

        
        Application.Current!.UserAppTheme = AppTheme.Dark;

        // this.SetAppThemeColor( ) = AppTheme.Dark;


#else
        MainWindow.Destroying += Window_Destroyer;

#endif

        return MainWindow;
    }

    public void SetDestroyCallback( Phoney_MAUI.Model.DelVoid destroyCallback)
    {
        DestroyCallback = destroyCallback;
    }
    public void SetStoppedCallback(Phoney_MAUI.Model.DelVoid stoppedCallback)
    {
        StoppedCallback = stoppedCallback;
    }
}

public class AsyncDemo
{
    // The method to be executed asynchronously.
    public string TestMethod(int callDuration, out int threadId)
    {
        Console.WriteLine("Test method begins.");
        Thread.Sleep(callDuration);
        threadId = Thread.CurrentThread.ManagedThreadId;
        return String.Format("My call time was {0}.", callDuration.ToString());
    }
}
public delegate string AsyncMethodCaller(int callDuration, out int threadId);
public class AsyncMain
{
    public static void Schubidu()
    {
        // Create an instance of the test class.
        AsyncDemo ad = new AsyncDemo();

        // Create the delegate.
        AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

        // The threadId parameter of TestMethod is an out parameter, so
        // its input value is never used by TestMethod. Therefore, a dummy
        // variable can be passed to the BeginInvoke call. If the threadId
        // parameter were a ref parameter, it would have to be a class-
        // level field so that it could be passed to both BeginInvoke and
        // EndInvoke.
        int dummy = 0;

        // Initiate the asynchronous call, passing three seconds (3000 ms)
        // for the callDuration parameter of TestMethod; a dummy variable
        // for the out parameter (threadId); the callback delegate; and
        // state information that can be retrieved by the callback method.
        // In this case, the state information is a string that can be used
        // to format a console message.
        IAsyncResult result = caller.BeginInvoke(3000,
            out dummy,
            new AsyncCallback(CallbackMethod),
            "The call executed on thread {0}, with return value \"{1}\".");

        Console.WriteLine("The main thread {0} continues to execute...",
            Thread.CurrentThread.ManagedThreadId);

        // The callback is made on a ThreadPool thread. ThreadPool threads
        // are background threads, which do not keep the application running
        // if the main thread ends. Comment out the next line to demonstrate
        // this.
        Thread.Sleep(4000);

        Console.WriteLine("The main thread ends.");
    }

    // The callback method must have the same signature as the
    // AsyncCallback delegate.
    static void CallbackMethod(IAsyncResult ar)
    {
         /*
        // Retrieve the delegate.
        AsyncResult result = (AsyncResult)ar;
        AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;

        // Retrieve the format string that was passed as state
        // information.
        string formatString = (string)ar.AsyncState;

        // Define a variable to receive the value of the out parameter.
        // If the parameter were ref rather than out then it would have to
        // be a class-level field so it could also be passed to BeginInvoke.
        int threadId = 0;

        // Call EndInvoke to retrieve the results.
        string returnValue = caller.EndInvoke(out threadId, ar);

        // Use the format string to format the output message.
        Console.WriteLine(formatString, threadId, returnValue);
        */
    }
}
