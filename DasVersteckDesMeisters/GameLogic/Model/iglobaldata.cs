using advtest;
using GameCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.DevTools.Debugger;
using System.Threading;

namespace Phoney_MAUI.Model;


public interface ISlotDescription
{

    public List<string>? SlotDescriptions { get; set; }

    public void Init();

}

public interface IGlobalData
{
    public enum language { german, english }

    public byte[]? StartStatusSerialized { get; set; }

    public GameCore.OrderList? OrderList { get; set; }

    public int OrderListFinalIx { get; set; }

    public bool UseMoreBuffer { get; set; }
    public bool SimpleMC { get; set; }
    public language Language { get; set; }

    public bool Highlighting { get; set; }

    public bool Brief { get; set; }

    public bool LastCommandSucceeded { get; set; }

    public bool ValidRun { get; set; }

    public bool InterruptedDialog { get; set; }

    public bool FeedbackWindow { get; set; }

    public int InteruptedDialogID { get; set; }

    public bool InterruptedDialogCanBeInterruped { get; set; }

    public DelMCMSelection? InterruptedDialogMCMSelection { get; set; }

    public MCMenu? InterruptedDialogMCM { get; set; }
    public Phoney_MAUI.Core.Version Version { get; set; }

    public bool SilentMode { get; set; }
    public bool UISuppressed { get; set; }

    public void InitRandom(int num);

    public int RandomNumber(int min, int max);

    public void ResetLanguageCallbacks();
    public void AddLanguageCallback(DelVoid method);

    // public static string? CurrentPath();
    // public static string CurrentPathPlusFilename(string FileName);

    public string LastRunResult { get; set; }
    public bool AskForPlayLevel { get; set; }

    public bool RenameZipOrderTableEntry(string oldName, string newName);
    public Phoney_MAUI.Core.SlotDescription SlotDescriptions { get; set; }
    public string? JSSelectionText { get; set; }

    public SaveObj? StartStatus { get; set; }
}

public interface IVersion
{

    public int Version1 { get; set; }

    public int Version2 { get; set; }

    public int Version3 { get; set; }

    public DateTime VersionDate { get; set; }

    public string GetVersion();

    public string GetVersionDate();


    public bool CheckVersion(IVersion v);

    public void Save();
    public IVersion Read();
}

