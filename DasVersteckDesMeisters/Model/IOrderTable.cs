using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using advtest;
using Phoney_MAUI.Game.General;
using Phoney_MAUI.Core;
using GameCore;

namespace Phoney_MAUI.Model;

public interface IOrderListTable : INotifyPropertyChanged
{
    // public ObservableCollection<OrderListTable>? _olt;
    // public ObservableCollection<OrderTable>? _ot;

    // public string? _name;

    // public int _pt;

    // public int _tmpPt;

    // public bool _zipped;

    public ObservableCollection<OrderTable>? OT { get; set; }
    public ObservableCollection<OrderListTable>? OLT { get; set; }

    public string? Name { get; set; }

    public bool Zipped { get; set; }
    public int Point { get; set; }
    public int TempPoint { get; set; }
}

public interface IOrderTable : INotifyPropertyChanged
{
 
    // public event PropertyChangedEventHandler? PropertyChanged;


    public void NotifyPropertyChanged(string? propName );
    public string? OrderText { get; set; }
 
 
    public bool OrderActive { get; set; }


    // Nur noch aus Kompatibilitätsgründen enthalten
    public double DetailsWidth { get; set; }
  
    public orderType? OrderType { get; set; }


    public string? OrderTypeText { get; set; }

    public int? OrderChoice { get; set; }

    public int No { get; set; }

    public string? OrderResult { get; set; }

    public string? OrderFeedback { get; set; }

    public string? OrderAllResult { get; }
    
    public string? Current { get; set; }

    // public ParseTokenList? PTL { get; set; }

    // public ParseLineList PTLSignatures { get; set; }

    public string? Name();
}


public interface IOrderList : INotifyPropertyChanged
{
    /*
    public int currentOrderListIx;

    public int _currentOLIndex;

    public List<OrderListTable> _otl;

    [JsonIgnore]
    DelOrderList? _cbShowChanges = null;
    [JsonIgnore]
    DelVoid? _cbSaveOrderList = null;
    [JsonIgnore]
    DelInt? _cbZipOrderList = null;
    [JsonIgnore]
    DelIntString? _cbReadZipOrderList = null;
    [JsonIgnore]
    OrderListInfo? _orderListInfo = null;
    [JsonIgnore]
    DelCreateOrderPath _cbCreateOrderPath = null;

    public orderWriteMode orderWriteMode = orderWriteMode.always;

    public int gridRefresh = 0;
    [JsonIgnore]
    string? _collector = null;
    [JsonIgnore]

    private DelInt? _addTable = null;

    public bool _actualGame = false;
    */

    public List<OrderListTable>? OTL { get; set; }
    // public int CurrentOLIndex{ get; set; }
    public DelCreateOrderPath? CBCreateOrderPath { get; set; }

    public int CurrentOrderListIx { get; set; }
    public int CurrentViewOrderListIx { get; set; }
    public DelInt? CBAddTable { get; set; }
    public string? Collector { get; set; }
    public DelOrderList? SetShowChanges { get; set; }

    public DelVoid? SetSaveOrderList { get; set; }
    public DelInt? SetZipOrderList { get; set; }

    public DelIntString? SetReadZipOrderList { get; set; }

    public OrderListInfo? SetOrderListInfo { get; set; }


    public OrderListTable? CurrentOrderListTableEntry { get; set; }


    public bool CompareOrderTables(OrderTable ot1, OrderTable ot2);

    public int GetOrderTableTempPoint();
    public int GetOrderTablePoint();

    public void SaveOrderTable();

    public void ZipOrderTable(int ix);

    public void ReadZipOrderTable(int ix, string name);
    public int FindOrderList(string Name);
    public OrderListTable? InitHierarchy(int index);
    public OrderListTable? InitHierarchy(string Name);
    public OrderTable? CloneOT(OrderTable ot1);

    public void StartCollection();
    public OrderTable? GetNextOrderTable();
    public OrderTable? GetCurrentOrderTable();
    public void FlushCollection();
    public string? ReleaseColletion();

    public bool CompareRuns(OrderListTable otl1, OrderListTable otl2, int otl1ix);

    public bool CheckIndexStillValid(int val);

    public void AddOrderText(string text);

    public bool AddOrderList(string? Name, bool baseEntry = true, IGlobalData.language lang = IGlobalData.language.german);
    public void AddOrderFeedbackCurrentRun(string? context, string? text, bool sysComment = false);
    public void AddOrderFeedback(string? context, string? text, int Index, bool sysComment = false);
    public void AddOrderFeedback(string? context, string? text, bool sysComment = false);
    public bool AddOrder(orderType? ot, string? orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false);
    public bool AddOrder(orderType? ot, string? orderText, int? orderChoice, int Index, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false);
    public bool AddOrderCurrentRun(orderType? ot, string? orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature);
    public string? UniqueOrderListName(string? Name);

    public bool SyncOrderList();
    public (string?, string?, int) GetNameNumber(string s);

    public int CurrentOLIndex { get; set; }
    public bool AddOrderAllTabs(orderType? ot, string? orderText, int? orderChoice, int Index, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false);
}

public class IOrderListInfo 
{

    public int jsonIndex;

    public int listNr;
}


