using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using advtest;
using Phoney_MAUI.Model;
using Phoney_MAUI.Core;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace GameCore;

public enum orderType { orderText, mcChoice, noText, comment };

[Serializable]

public class OrderListTable : IOrderListTable
{
    public ObservableCollection<OrderListTable>? _olt;
    public ObservableCollection<OrderTable>? _ot;
    public OrderListTable? _oltParent;

     // private IGlobalData? _gd;

    public string? _name;

    public int _pt;

    public int _tmpPt;

    public bool _zipped;

    public OrderListTable()
    {

    }
    public OrderListTable( string Name )
    {
        this.Name = Name;
    }
    public OrderListTable(string name, IGlobalData gd)
    {
        // _gd = gd;
        // if (_gd == null)
        // _gd = loca.GD;

        _ot = new ObservableCollection<OrderTable>();
        _name = name;
        TempPoint = -1;
        Point = 0;
    }
    [JsonIgnore]

    public ObservableCollection<OrderTable>? OT
    {
        get
        {
            return _ot;
        }
        set
        {
            _ot = value;
        }
    }
    [JsonIgnore]
    public ObservableCollection<OrderListTable>? OLT
    {
        get
        {
            return _olt;
        }
        set
        {
            _olt = value;
        }
    }
    public OrderListTable? OLTParent
    {
        get
        {
            return _oltParent;
        }
        set
        {
            _oltParent = value;
        }
    }
    [JsonIgnore]

    public string? Name
    {
        get { return _name; }
        set { if (value != null) _name = value; }
    }
    [JsonIgnore]

    public bool Zipped
    {
        get { return _zipped; }
        set { _zipped = value; }
    }
    [JsonIgnore]

    public int Point
    {
        get { return _pt; }
        set
        {
            if (_pt != value)
            {

                _pt = value;
                if (_pt >= this.OT!.Count)
                {
                    _pt = this.OT!.Count - 1;
                }
             }
        }
    }
    [JsonIgnore]

    public int TempPoint
    {
        get { return _tmpPt; }
        set
        {
            _tmpPt = value;
        }
    }

    /*
          private string _description;
          private ObservableCollection<OrderTable> _orderTables;
          private ObservableCollection<OrderTableTree> _orderTableTrees;

          public string Description
          {
              get => _description;
              set => _description = value;
          }

          public ObservableCollection<OrderTable> OrderTables
          {
              get => _orderTables;
              set => _orderTables = value;
          }
          public ObservableCollection<OrderTableTree> OrderTableTrees
          {
              get => _orderTableTrees;
              set => _orderTableTrees = value;
          }

          public OrderTableTree( string Description )
          {
              this.Description = Description;
          }
      */
    [NonSerialized]
    private PropertyChangedEventHandler? _propertyChanged;

    public event PropertyChangedEventHandler? PropertyChanged
    {
        add { _propertyChanged += value!; }
        remove { _propertyChanged -= value!; }
    }


    public void NotifyPropertyChanged(string? propName = null)
    {
        if (this._propertyChanged != null)
            this._propertyChanged(this, new PropertyChangedEventArgs(propName));
    }

    public void RefreshCurrent()
    {
        if (_pt >= this.OT!.Count!)
        {
            _pt = this.OT!.Count! - 1;
        }
        foreach (OrderTable ot in this.OT)
        {
            if (ot.No - 1 == _pt)
            {
                ot.Current = loca.OrderListTable_RefreshCurrent_16189;
                this.NotifyPropertyChanged(loca.OrderListTable_RefreshCurrent_16190);
                // Debug.WriteLine( ">>> ist jetzt bei " + _pt +"." );
            }
            else
            {
                if (ot.Current != null)
                {
                    this.NotifyPropertyChanged(loca.OrderListTable_RefreshCurrent_16191);
                    ot.Current = null;
                }
            }
        }

    }

}
[Serializable]

public class OrderTable : IOrderTable
{
    public orderType? oTy;

    public string? oTe;

    public int? oCh;

    public string? oRe;

    public string? oFe;

    public string? oPa;

    public bool oAc;

    public IGlobalData.language oLG;

    public int no;

    public bool _current;

    public double _detailsWidth;

    [JsonIgnore]
    [NonSerialized]
    public ParseTokenList? ptl;
    [JsonIgnore]
    [NonSerialized]
    public ParseLineList? ptlSignatures;

    [NonSerialized]
    private PropertyChangedEventHandler? _propertyChanged;

    public event PropertyChangedEventHandler? PropertyChanged
    {
        add { _propertyChanged += value!; }
        remove { _propertyChanged -= value!; }
    }


    public void NotifyPropertyChanged(string? propName = null)
    {
        if (this._propertyChanged != null)
            this._propertyChanged(this, new PropertyChangedEventArgs(propName));
    }

    [JsonIgnore]
    public string? OrderText
    {
        get { return oTe; }
        set
        {
            oTe = value;
            if( value == "restart restart'")
            {

            }
        }
    }

    [JsonIgnore]
    public bool OrderActive
    {
        get { return oAc; }
        set
        {
            oAc = value;
            NotifyPropertyChanged();
        }
    }
    [JsonIgnore]

    public string? OrderPath
    {
        get { return oPa; }
        set
        {
            if( value == null )
            {

            }
            oPa = value;
        }
    }

    // Nur noch aus Kompatibilitätsgründen enthalten
    [JsonIgnore]
    public double DetailsWidth
    {
        get { return _detailsWidth; }
        set
        {
            _detailsWidth = value;
            NotifyPropertyChanged(loca.OrderTable_NotifyPropertyChanged_16171);

        }
    }

    [JsonIgnore]
    public orderType? OrderType
    {
        get { return oTy; }
        set { oTy = value; }
    }
    public string? OrderTypeText
    {
        get
        {
            if (oTy == orderType.mcChoice)
                return loca.OrderTable_NotifyPropertyChanged_16172;
            else if (oTy == orderType.noText)
                return loca.OrderTable_NotifyPropertyChanged_16173;
            else if (oTy == orderType.comment)
                return loca.OrderTable_NotifyPropertyChanged_16174;
            else
                return loca.OrderTable_NotifyPropertyChanged_16175;
        }
        set
        {
            if (value == loca.OrderTable_NotifyPropertyChanged_16176)
                oTy = orderType.orderText;
            else if (value == loca.OrderTable_NotifyPropertyChanged_16177 || value == loca.OrderTable_NotifyPropertyChanged_16178)
                oTy = orderType.noText;
            else if (value == loca.OrderTable_NotifyPropertyChanged_16179)
                oTy = orderType.comment;
            else if (value == loca.OrderTable_NotifyPropertyChanged_16180)
                oTy = orderType.mcChoice;

        }
    }
    [JsonIgnore]
    public int? OrderChoice
    {
        get { return oCh; }
        set
        {
            if (value == 0)
                oCh = null;
            else
                oCh = value;
        }
    }
    [JsonIgnore]
    public int No
    {
        get { return no; }
        set { no = value; }
    }

    [JsonIgnore]
    public string? OrderResult
    {
        get
        {
            return oRe;
        }
        set { oRe = value; }
    }
    [JsonIgnore]
    public string? OrderFeedback
    {
        get { return oFe; }
        set { oFe = value; }
    }

    [JsonIgnore]
    public string? OrderAllResult
    {
        get
        {
            if (oFe != "")
            {
                return (oRe + loca.OrderTable_NotifyPropertyChanged_16181 + oFe);
            }
            else
            {
                return (oRe);

            }
        }
    }
 
    public string? Current
    {
        get
        {
            if (_current == true)
                return (loca.OrderTable_NotifyPropertyChanged_16182);
            else
                return ("");
        }
        set
        {
            if (value != null)
            {
                if (_current == false)
                    NotifyPropertyChanged(loca.OrderTable_NotifyPropertyChanged_16183);
                _current = true;
            }
            else
            {
                if (_current == true)
                    NotifyPropertyChanged(loca.OrderTable_NotifyPropertyChanged_16184);

                _current = false;
            }
        }
    }

    // val = 1;
    /*
    public OrderTable(orderType orderType, string orderText, int? orderChoice, IGlobalData.language lang, string orderResult = "", int choice = 0, ParseTokenList? ptl = null, ParseLineList? ptlSignature = null)
    {
        this.oTy = orderType;
        this.oCh = orderChoice;
        this.oLG = lang;
        this.oRe = orderResult;
        this.oFe = "";
        this.No = val++;
        this.OrderActive = true;
        this.DetailsWidth = 400;

        if (OrderType == orderType.mcChoice)
        {
            this.oTe = "(" + choice.ToString() + ") " + orderText;
        }
        else
        {
            this.oTe = orderText;

        }
    }
    */
    public OrderTable(orderType? orderType, string orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl = null, ParseLineList? ptlSignature = null)
    {
        this.oTy = orderType;
        this.oTe = orderText;
        this.oCh = orderChoice;
        this.oLG = lang;
        this.oRe = "";
        this.oFe = "";
        this.OrderActive = true;
         this.DetailsWidth = 400;
    }

    // Möglicherweise ist das hier ein Problem, denn dieser Konstruktur spuckt ungültige OrderTables aus
    public OrderTable()
    {
    }

    public string Name()
    {
        string name;

        if (OrderType == orderType.orderText)
            // Ignores: 001
            name = loca.OrderTable_Name_16185 + OrderText;
        else if (OrderType == orderType.noText)
            // Ignores: 001
            name = loca.OrderTable_Name_16186 + OrderText;
        else if (OrderType == orderType.comment)
            // Ignores: 001
            name = loca.OrderTable_Name_16187 + OrderText;
        else
            name = String.Format(loca.OrderTable_Name_16188, OrderChoice);

        return name;
    }
}

[Serializable]
public class OrderList : IOrderList
{
    public int _currentViewOrderListIx;

    public int currentOrderListIx;

    // public int _currentOLIndex;

    public List<OrderListTable>? _otl;

    
    [JsonIgnore] [NonSerialized]
    DelOrderList? _cbShowChanges = null;
    [JsonIgnore]
    [NonSerialized]
    DelVoid? _cbSaveOrderList = null;
    [JsonIgnore]
    [NonSerialized]
    DelInt? _cbZipOrderList = null;
    [JsonIgnore]
    [NonSerialized]
    DelIntString? _cbReadZipOrderList = null;
    [JsonIgnore]
    OrderListInfo? _orderListInfo = null;
    [JsonIgnore]
    [NonSerialized]
    DelCreateOrderPath? _cbCreateOrderPath = null;

    public orderWriteMode orderWriteMode = orderWriteMode.always;

    public int gridRefresh = 0;
    [JsonIgnore]
    string? _collector = null;
    [JsonIgnore]

    private DelInt? _addTable = null;

    public bool _actualGame = false;

    [JsonIgnore]
    public GlobalData? GD
    {
        get => GlobalData.CurrentGlobalData;
    }
    [JsonIgnore]
    public UIServices? UIS
    {
        get => (UIServices) GlobalData.CurrentGlobalData!.UIS!;
    }
     [JsonIgnore]

    public List<OrderListTable>? OTL
    {
        get { return _otl; }
        set
        {
            if (value != null) 
                _otl = value;
        }
    }

    [JsonIgnore]
    public DelCreateOrderPath? CBCreateOrderPath
    {
        get => _cbCreateOrderPath;
        set => _cbCreateOrderPath = value;
    }


    [JsonIgnore]

    public int CurrentViewOrderListIx
    {
        get { return _currentViewOrderListIx; }
        set
        {
            int oldVal = _currentViewOrderListIx;
            if (value >= 0 && value < OTL!.Count)
            {
                // Wurde der Index verändert? Und entspricht der neue Index auch nicht CurrentOrderListIx?
                if (oldVal != value && oldVal != 0 && value != CurrentOrderListIx)
                {

                    // Dann wird der alte Index archiviert

                    //   ... und der aktuelle Status entfernt, weil der ja schon gezippt ist
                    // _OTL![oldVal].Zipped = true;
                    // _OTL![oldVal].OT = null;
                }
                _currentViewOrderListIx = value;

                if (this.OTL![value].Zipped)
                {
                    ReadZipOrderTable(value, this.OTL![value].Name!);

                }
            }
        }
    }

    public int CurrentOrderListIx
    {
        get { return currentOrderListIx; }
        set
        {
            int oldVal = currentOrderListIx;

            if (value >= 0 && value < OTL!.Count)
            {
                // Wurde der Index verändert?
                if (oldVal != value && oldVal != 0 && value != CurrentViewOrderListIx )
                {

                    // Dann wird der alte Index archiviert

                  //   ... und der aktuelle Status entfernt, weil der ja schon gezippt ist
                    // _OTL![oldVal].Zipped = true; 
                    // _OTL![oldVal].OT = null;
                }
                currentOrderListIx = value;

                if (this.OTL![value].Zipped)
                {
                    ReadZipOrderTable(value, this.OTL![value].Name!);

                }
            }
        }
    }
    [JsonIgnore]

    public DelInt? CBAddTable
    {
        get { return _addTable!; }
        set { _addTable = value; }
    }
    [JsonIgnore]

    public string? Collector
    {
        get { return _collector!; }
        set { _collector = value; }
    }
    [JsonIgnore]

    public DelOrderList? SetShowChanges
    {
        get { return _cbShowChanges!; }
        set { _cbShowChanges = value; }
    }
    [JsonIgnore]

    public DelVoid? SetSaveOrderList
    {
        get { return _cbSaveOrderList!; }
        set
        {
            if (value != null)
                _cbSaveOrderList = value;
        }
    }
    [JsonIgnore]

    public DelInt? SetZipOrderList
    {
        get { return _cbZipOrderList!; }
        set
        {
            if (value != null)
                _cbZipOrderList = value;
        }
    }
    [JsonIgnore]

    public DelIntString? SetReadZipOrderList
    {
        get { return _cbReadZipOrderList!; }
        set
        {
            if (value != null)
                _cbReadZipOrderList = value;
        }
    }

    public OrderListInfo? SetOrderListInfo
    {
        get { return _orderListInfo; }
        set
        {
            _orderListInfo = value;
        }
    }

    [JsonIgnore]

    public OrderListTable? CurrentOrderListTableEntry
    {
        get
        {
            if (CurrentOrderListIx >= OTL!.Count)
                CurrentOrderListIx = 0;
            return OTL![CurrentOrderListIx];
        }
        set
        {
            for (int loopA = 0; loopA < OTL!.Count; loopA++)
            {
                OrderListTable otlx = OTL![loopA];
                if (otlx == value)
                {
                    CurrentOrderListIx = loopA;
                }
            }
        }
    }

    [JsonIgnore]
    public OrderListTable CurrentViewOrderListTableEntry
    {
        get
        {
            if (CurrentViewOrderListIx >= OTL!.Count)
                CurrentViewOrderListIx = 0;
            return OTL![CurrentViewOrderListIx];
        }
        set
        {
            for (int loopA = 0; loopA < OTL!.Count; loopA++)
            {
                OrderListTable otlx = OTL![loopA];
                if (otlx == value)
                {
                    CurrentViewOrderListIx = loopA;
                }
            }
        }
    }

    public OrderList(DelVoid SaveOrderListExtern, DelInt ZipOrderListExtern, DelIntString ReadZipOrderListExtern, ref OrderListInfo oli, IGlobalData gd, IUIServices uis, bool ReadData = true)
    {
        // int jsonIndex = 0;

        // _gd = gd;
        // UIS = (Phoney_MAUI.Core.UIServices) uis;
        _otl = new List<OrderListTable>();
        SetSaveOrderList = SaveOrderListExtern;
        SetZipOrderList = ZipOrderListExtern;
        SetReadZipOrderList = ReadZipOrderListExtern;
        CurrentOrderListIx = 0;

        if (ReadData)
        {
            UIS!.InitPath();
 
            string? jsonSource = UIS!.LoadString(loca.OrderList_OrderList_16197)!;
            // Laden der Indexer-Datei (und Wert wird dann um eins erhöht)
            if (jsonSource != null)
            {
                SetOrderListInfo = JsonConvert.DeserializeObject<OrderListInfo>(jsonSource);
                SetOrderListInfo!.jsonIndex++;
            }
            else
            {
                SetOrderListInfo = new OrderListInfo();
                SetOrderListInfo!.jsonIndex = 0;
                SetOrderListInfo!.listNr = 1;
            }
            oli = SetOrderListInfo;

            // Indexer-Datei wird gespeichert
            WriteJsonIndex();

            GD!.OrderList = this;
            // Die aktuelle OrderTable wird gesichert über den Indexerwert im Dateinamen
            UIS!.BackupOrdertable();

  
            // Und jetzt laden wir die OrderTable ein
            jsonSource = UIS!.LoadString(loca.OrderList_OrderList_16198);
            if (jsonSource != null)
            {
                // ToDo: Wofür zum Teufel ist diese Zeile gut??
                OrderList? ol2;
                ol2 = JsonConvert.DeserializeObject<OrderList>(jsonSource);


                if (ol2 != null)
                {
                    this.currentOrderListIx = ol2.CurrentOrderListIx;
                    this._otl = ol2._otl;
                    StripOrderList();

                }
                else
                {
                    AddOrderList(loca.OrderList_OrderList_16205, true);
                    CurrentOrderListIx = OTL!.Count - 1;

                }
            }
            else
            {
                AddOrderList(loca.OrderList_OrderList_16206, true);
                CurrentOrderListIx = OTL!.Count - 1;
            }
        }

    }

    public bool WriteJsonIndex()
    {
        string? jsonDest = JsonConvert.SerializeObject(SetOrderListInfo, Newtonsoft.Json.Formatting.Indented);
        UIS!.SaveString(loca.OrderList_WriteJsonIndex_16209, jsonDest);
        /*
        string? pathName = GlobalData.CurrentPath(); 
        string? pathfileName = pathName + loca.OrderList_WriteJsonIndex_16209;

        File.WriteAllText(pathfileName, jsonDest);
        */
        return true;
    }

    public void StripOrderList()
    {
        foreach (OrderListTable otl in OTL!)
        {
            if (otl.OT != null)
            {
                foreach (OrderTable ot in otl.OT)
                {
                    if (ot.OrderText != null)
                    {
                        string s = ot.OrderText;
                        // Noloca: 001

                        if (s.StartsWith("--> "))
                            s = s.Substring(4);

                    }

                }
                // otl.Point = otl.OT.Count - 1;
            }
        }
    }

    public OrderList()
    {
        SetOrderListInfo = DataService._dataService!.ReadJsonIndex();

        DataService._dataService.WriteJsonIndex(SetOrderListInfo);
    }

    public bool CompareOrderTables(OrderTable ot1, OrderTable ot2)
    {
        bool identical = true;

        if (ot1.OrderType != ot2.OrderType)
            identical = false;
        if (ot1.OrderText != ot2.OrderText)
            identical = false;
        if (ot1.OrderChoice != ot2.OrderChoice)
            identical = false;

        return (identical);
    }

    public int GetOrderTableTempPoint()
    {
        return (OTL![CurrentOrderListIx].TempPoint);
    }

    public int GetOrderTablePoint()
    {
        return (OTL![CurrentOrderListIx].Point);
    }


    public void SaveOrderTable()
    {

        if (_cbSaveOrderList != null && this.orderWriteMode != orderWriteMode.never) _cbSaveOrderList();
    }

    public void ZipOrderTable(int ix)
    {

        if (_cbZipOrderList != null && this.orderWriteMode != orderWriteMode.never) _cbZipOrderList(ix);
    }

    public void ReadZipOrderTable(int ix, string name)
    {

        if (_cbReadZipOrderList != null && this.orderWriteMode != orderWriteMode.never) _cbReadZipOrderList(ix, name);
    }
    [NonSerialized]
    private PropertyChangedEventHandler? _propertyChanged;

    public event PropertyChangedEventHandler? PropertyChanged
    {
        add { _propertyChanged += value!; }
        remove { _propertyChanged -= value!; }
    }


    public void NotifyPropertyChanged(string? propName = null)
    {
        if (this._propertyChanged != null)
            this._propertyChanged(this, new PropertyChangedEventArgs(propName));
    }

    public int FindOrderList( string Name )
    {
        int ix;

        for( ix = 0; ix < GD!.OrderList!.OTL!.Count; ix ++)
        {
            if(GD!.OrderList!.OTL![ix]!.Name == Name )
            {
                return ix;
            }
        }
        return -1; 
    }

    public OrderTable CloneOT(OrderTable ot1)
    {
        OrderTable ot2 = new();

        ot2.no = ot1.no;
        ot2.oAc = ot1.oAc;
        ot2.oCh = ot1.oCh;
        ot2.oFe = ot1.oFe;
        ot2.oLG = ot1.oLG;
        ot2.oPa = ot1.oPa;
        ot2.oRe = ot1.oRe;
        ot2.oTe = ot1.oTe;
        ot2.oTy = ot1.oTy;

        return ot2;
    }
    public OrderListTable InitHierarchy( int index )
    {
       
        OrderListTable? olt = GD!.OrderList!.OTL![index];
        OrderListTable? olt2 = new();
        OrderListTable? olt3 = olt2;

        if (olt.Zipped == true)
        {
            GD.OrderList.ReadZipOrderTable(index, olt.Name!);
        }


        List<string> currentPath = new();
        string[] tempPath;

        for ( int pathSegmentCount = 0; pathSegmentCount < 5; pathSegmentCount ++)
        {
            currentPath.Add( "Segment " + pathSegmentCount );
        }

        int level = 0;
        int ix;

        try
        {
            if (olt.OT == null)
                olt.OT = new();

            int len =  olt.OT.Count;

            for (ix = 0; ix < len; ix++)
            {
                bool initTempPath = false;
                // bool pathGetDeeper = false;
                bool decreaseIx = false;

                if (olt.OT[ix].No == 18 )
                {

                }

                if (ix == 0)
                {
                    initTempPath = true;
                }
                else if (ix > 0 && olt.OT![ix - 1].OrderPath != olt.OT![ix].OrderPath)
                {
                    initTempPath = true;
                }
                if (initTempPath == true)
                {
                    if (olt!.OT![ix]!.OrderPath != null)
                    {
                        tempPath = olt!.OT![ix]!.OrderPath!.Split('/');

                        // Phase 1: Wir gehen tiefer in den Baum
                        while (level < tempPath.Length /* && tempPath[level] != currentPath[level]*/ )
                        {
                            if (olt3!.OT != null)
                            {
                                currentPath[level] = tempPath[level];

                                OrderListTable oltx = new();
                                oltx.Name = tempPath[level];
                                if (olt3.OLT == null)
                                    olt3.OLT = new();
                                olt3.OLT.Add(oltx);
                                oltx.OLTParent = olt3;
                                olt3 = oltx;
                                // olt3.OT = new();
                                level++;
                            }
                            else
                            {
                                currentPath[level] = tempPath[level];

                                OrderListTable oltx = new();
                                oltx.Name = tempPath[level];
                                if (olt3.OLT == null)
                                    olt3.OLT = new();
                                olt3.OLT.Add(oltx);
                                oltx.OLTParent = olt3;
                                olt3 = oltx;
                                // olt3.OT = new();
                                level++;
                            }
                        }
                    }
                    else
                    {

                    }
                    /*
                    if (level > 0)
                        level--;
                    */
                }

                initTempPath = true;

                while (initTempPath == true)
                {
                    OrderTable ot = CloneOT(olt.OT![ix]);
                    OrderListTable oltx = new();
                    oltx.Name = "Mon dieu";
                    oltx.OT = new();
                    oltx.OT.Add(ot);
                    if( olt3!.OLT == null )
                    {
                        olt3!.OLT = new();
                    }
                    olt3!.OLT.Add(oltx);
                    ix++;

                    if (ix >= olt.OT.Count)
                        break;

                    /*
                    // Reparaturcode: Wenn der Path aus irgendeinem Grund nicht gesetzt wird, dann wird er hier
                    // gesetzt - in der Annahme, dass dieser Eintrag keine Veränderung im Pfad auslöst.
                    if (olt.OT![ix].OrderPath == null && ix > 0)
                    {
                        olt.OT![ix].OrderPath = olt.OT![ix - 1].OrderPath;
                    }
                    */

                    if (ix >= olt.OT.Count)
                    {
                        initTempPath = false;
                    }
                    else if (ix > 0 && olt.OT![ix - 1].OrderPath != olt.OT![ix].OrderPath)
                    {
                        // Mon dieu
                        if( level >= 3)
                        {
                            olt3 = olt3!.OLTParent;
                            level--;

                            if (olt!.OT![ix]!.OrderPath == null && ix > 0 && olt!.OT![ix - 1]!.OrderPath != null)
                                olt!.OT![ix]!.OrderPath = olt!.OT![ix - 1]!.OrderPath;

                                string[] s1Path = olt!.OT![ix]!.OrderPath!.Split('/');
                            if(s1Path.Length > level )
                            {
                                initTempPath = false;
                                decreaseIx = true;

                            }
                        }
                        else
                        {
                            initTempPath = false;
                            decreaseIx = true;

                        }

                        // string[] tempPath2 = olt.OT![ix].OrderPath.Split('/');
                        /*
                        if (tempPath2.Length >= level)
                        {
                            pathGetDeeper = true;
                        }
                        */
                    }
                }
 
                /*
                if (pathGetDeeper == true)
                {
                    ix--;
                }
                else 
                */
                if (ix < olt.OT.Count)
                {
                    bool decreaseLevel = false;

                    if (olt.OT![ix].OrderPath != null)
                        tempPath = olt!.OT![ix]!.OrderPath!.Split('/');
                    else
                    {
                        tempPath = new string[5];
                        tempPath[0] = "";
                        tempPath[1] = "";
                        tempPath[2] = "";
                        tempPath[3] = "";
                        tempPath[4] = "";
                    }
                    // string[] tempPath2 = currentPath; //  olt.OT![ix-1].OrderPath.Split('/');

                    if ( ix == 437 )
                    {
                        // int a = 5;
                    }

                    if (level >= tempPath.Length)
                    {
                        decreaseLevel = true;
                        if (decreaseLevel && level == 1)
                        {
                            // int a = 5;
                        }
                    }
                    else if (level < tempPath.Length && level > 0 && ComparePathesUntilLevelUnequal(tempPath, currentPath, level -1)  )
                    {
                        decreaseLevel = true;

                        if (decreaseLevel && level == 1)
                        {
                            // int a = 5;
                        }
                    }

                    while (decreaseLevel == true)
                    {
                        olt3 = olt3!.OLTParent;
                        level--;

                        if (level >= tempPath.Length)
                        {
                            decreaseLevel = true;

                            if (decreaseLevel && level == 1)
                            {
                                // int a = 5;
                            }
                        }
                        else if (level < tempPath.Length && level > 0 && ComparePathesUntilLevelUnequal( tempPath, currentPath, level -1) )
                        {
                            decreaseLevel = true;

                            if( decreaseLevel && level == 1)
                            {
                                // int a = 5;
                            }
                        }
                        else
                            decreaseLevel = false;
                    }
                }
                if (decreaseIx)
                    ix--;

            }
        }
        catch 
        {
            // int a = 5;
        }
        return olt2;
    }

    public bool ComparePathesUntilLevelUnequal(string[] path1, List<string> path2, int level )
    {
        bool unequal = false;

        for( int ix = level; ix >= 0; ix--)
        {
            if( path1[ix] != path2[ix] )
            {
                unequal = true;
                break;
            }
        }

        return unequal;
    }

    public OrderListTable InitHierarchy( string Name )
    {
        return (InitHierarchy(FindOrderList(Name)));
    }
    public void StartCollection()
    {
        Collector = "";
        // Collector = null;
        /*
        if (_gd!.FeedbackWindow == false)
        else
            Collector = null;
        */
    }
    public OrderTable GetNextOrderTable()
    {
        OrderTable ot1;

        if (OTL![CurrentOrderListIx].TempPoint < OTL![CurrentOrderListIx]!.OT!.Count)
        {
            bool success = false;
            ot1 = OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx]!.TempPoint]!;

            while (!success)
            {
                ot1 = OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx]!.TempPoint]!;
                OTL![CurrentOrderListIx].TempPoint++;

                // Dieser Wert wird nirgends auf true gesetzt - wozu gibt es ihn dann?
                if (this._actualGame == true)
                {
                    if (CurrentOrderListIx > 0)
                        OTL![0].TempPoint++;
                }
                // Wenn kein aktiver Eintrag gefunden wurde, dann ist das kein Erfolg - und wir machen mit dem nächsten Eintrag weiter.
                if (ot1.OrderActive == true)
                    success = true;
                else
                {
                    // int a = 5;
                }
            }
        }
        else
        {
            // Das hier dürfte ziemlich sicher in einen Fehler führen.
            ot1 = new OrderTable(orderType.noText, loca.OrderList_GetNextOrderTable_16221, null, IGlobalData.language.german, null, null);
            OTL![CurrentOrderListIx].TempPoint++;
            if (this._actualGame == true)
            {

                if (CurrentOrderListIx > 0)
                    OTL![0].TempPoint++;
            }
        }
        return ot1;
    }
    public OrderTable GetCurrentOrderTable()
    {
        OrderTable? ot1 = null;

        if (OTL![CurrentOrderListIx].TempPoint > 0)
        {
            ot1 = OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].TempPoint - 1]!;

        }
        return ot1!;
    }
    public void FlushCollection()
    {
        string col = ReleaseColletion()!;


        OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx]!.OT!.Count - 1]!.OrderResult += col;
        if (CurrentOrderListIx > 0)
        {
            if (this._actualGame == true)
            {
                OTL![0]!.OT![OTL![0]!.OT!.Count - 1]!.OrderResult = col;
                // MW.UpdateOrderList(MW.OrderList);
            }
        }

    }
    public string? ReleaseColletion()
    {
        string? s = Collector;
        Collector = null;
        return s;
    }
    public string GiveCollection()
    {
        return Collector!;
    }

    public int _currentOLIndex;
    public int CurrentOLIndex
    {
        get { return _currentOLIndex; }
        set { _currentOLIndex = value; }
    }
    public bool CompareRuns(OrderListTable otl1, OrderListTable otl2, int otl1ix)
    {
        bool identical = true;

        // if (otl1.Name != otl2.Name) identical = false;

        if (otl1.Zipped)
            ReadZipOrderTable(otl1ix, otl1!.Name!);

        if (otl1.OT == null || otl2.OT == null) 
            identical = false;
        else if (otl1.OT!.Count != otl2.OT!.Count) 
            identical = false;

        int x = 0;

        if (identical == true)
        {
            for (x = 0; x < otl1.OT!.Count; x++)
            {
                if (CompareOrderTables(otl1.OT![x], otl2.OT![x]!) == false)
                {
                    identical = false;
                    break;
                }
            }

        }

        return identical;
    }
    public bool CheckIndexStillValid(int val)
    {
        if ((val + 1) >= OTL![CurrentOrderListIx].TempPoint)
            return true;
        else
            return false;
    }
    public void AddOrderText(string text)
    {

        if (text == null || text == "" || OTL == null ) return;
        
        if( text.Length >= 2 && text.Substring( 0, 2 ) == "> ")
        {
            return;
        }
        text = Helper.FirstUpper(text)!;

        if (Collector != null)
            Collector += text + loca.OrderList_AddOrderText_16211;
        else
        {
            if (OTL![CurrentOrderListIx].Zipped == true)
            {
                ReadZipOrderTable(CurrentOrderListIx, OTL![CurrentOrderListIx].Name!);
            }

            if (OTL![CurrentOrderListIx].TempPoint >= 0)
            {
                /*
                OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].TempPoint].OrderResult += text + loca.OrderList_AddOrderText_16213;
                if (_cbCreateOrderPath != null)
                    _cbCreateOrderPath(OTL![CurrentOrderListIx].OT!, OTL![CurrentOrderListIx].TempPoint);
                */
                if (OTL![CurrentOrderListIx].TempPoint > 0)
                {
                     if (OTL![CurrentOrderListIx].TempPoint > OTL![CurrentOrderListIx]!.OT!.Count)
                         OTL![CurrentOrderListIx].TempPoint = OTL![CurrentOrderListIx]!.OT!.Count;
                     OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].TempPoint - 1].OrderResult += text + loca.OrderList_AddOrderText_16212;

                    if (_cbCreateOrderPath != null)
                        // OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx].TempPoint - 1].OrderPath = _cbCreateOrderPath(OTL![CurrentOrderListIx].OT, OTL![CurrentOrderListIx].TempPoint - 1);
                        _cbCreateOrderPath(OTL![CurrentOrderListIx].OT!, OTL![CurrentOrderListIx].TempPoint - 1);

                }
            }
            else if (OTL![CurrentOrderListIx]!.Point >= 0 && OTL![CurrentOrderListIx]!.Point < OTL![CurrentOrderListIx]!.OT!.Count)
            {
                OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].Point].OrderResult += text + loca.OrderList_AddOrderText_16213;
                if (_cbCreateOrderPath != null)
                    // OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx].Point].OrderPath = _cbCreateOrderPath(OTL![CurrentOrderListIx].OT, OTL![CurrentOrderListIx].Point);
                    _cbCreateOrderPath(OTL![CurrentOrderListIx].OT!, OTL![CurrentOrderListIx].Point);
            }
            if (CurrentOrderListIx != 0)
            {
                if (this._actualGame == true)
                {

                    if (OTL![CurrentOrderListIx].TempPoint >= 0)
                    {
                        if (OTL![CurrentOrderListIx].TempPoint > 0)
                        {
                            int val = OTL![CurrentOrderListIx].TempPoint - 1;


                            if (val >= OTL![0].OT!.Count)
                            {
                                val = OTL![0].OT!.Count - 1;
                            }
                            OTL![0]!.OT![val].OrderResult += text + loca.OrderList_AddOrderText_16214;
                            if (_cbCreateOrderPath != null)
                                // OTL![0]!.OT![val].OrderPath = _cbCreateOrderPath(OTL![0]!.OT!, val);
                                _cbCreateOrderPath(OTL![0]!.OT!, val);
                        }
                    }
                    else if (OTL![CurrentOrderListIx].Point >= 0 && OTL![CurrentOrderListIx].Point < OTL![0]!.OT!.Count)
                    {
                        OTL![0].OT![OTL![CurrentOrderListIx].Point]!.OrderResult += text + loca.OrderList_AddOrderText_16215;
                        if (_cbCreateOrderPath != null)
                            // OTL![0]!.OT![OTL![CurrentOrderListIx].Point].OrderPath = _cbCreateOrderPath(OTL![0]!.OT!, OTL![CurrentOrderListIx].Point);
                            _cbCreateOrderPath(OTL![0]!.OT!, OTL![CurrentOrderListIx].Point);
                    }
                }
            }
        }

    }
    public bool AddOrderList(string? Name, bool baseEntry = true, IGlobalData.language lang = IGlobalData.language.german)
    {
        try
        {
            if (Name == null)
            {
                Name = String.Format(loca.OrderList_AddOrderList_16219, SetOrderListInfo!.listNr);
                SetOrderListInfo.listNr++;
            }

            if (OTL == null)
            {
                OTL = new List<OrderListTable>();
            }

            Name = UniqueOrderListName(Name);

            OTL!.Add(new OrderListTable(Name!, GD!));
            SyncOrderList();
            SaveOrderTable();
            CurrentOrderListIx = OTL!.Count - 1;

            if (baseEntry)
            {
                int val = 0;
                if (loca.GD!.Language == IGlobalData.language.english)
                    AddOrderAllTabs(orderType.orderText, loca.OrderList_AddOrderList_16220e, null, CurrentOrderListIx, lang, null, null, ref val);
                else
                    AddOrderAllTabs(orderType.orderText, loca.OrderList_AddOrderList_16220, null, CurrentOrderListIx, lang, null, null, ref val);
            }
        }
        catch (Exception ex)
        {
        }

        return (true);
    }
    public void AddOrderFeedbackCurrentRun(string? context, string? text, bool sysComment = false)
    {
        if (this._actualGame == true)
            AddOrderFeedback(context, text, 0, sysComment);

    }
    public void AddOrderFeedback(string? context, string? text, int Index, bool sysComment = false)
    {
        if (text == null || text == "") return;

        if (OTL![Index].TempPoint >= 0)
        {
            if (OTL![Index].TempPoint > 0)
            {
                if (OTL![Index].OT![OTL![Index]!.TempPoint - 1].OrderText == context)
                {
                    if (OTL![Index].OT![OTL![Index].TempPoint - 1].OrderFeedback != "")
                    {
                        // int a = 5;
                    }

                    OTL![Index].OT![OTL![Index].TempPoint - 1].OrderFeedback += text + loca.OrderList_AddOrderFeedback_16216;
                    if (_cbCreateOrderPath != null)
                        // OTL![Index]!.OT![OTL![Index].TempPoint - 1].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
                        _cbCreateOrderPath(OTL![Index].OT!, OTL![Index].TempPoint - 1);
                    // OTL![CurrentOrderListIx].TempPoint++;
                }
            }
        }
        else if (OTL![Index]!.Point >= 0 && OTL![Index]!.Point < OTL![Index]!.OT!.Count)
        {
            if (OTL![Index]!.OT![OTL![Index].Point]!.OrderText != context && !sysComment)
            {
                int val = -1;
                AddOrder(orderType.noText, context!, null, Index, loca.GD!.Language, null, null, ref val, true);
                if (val >= 0)
                    Index = val;
            }
            else if (!sysComment)
            {
                OTL![Index]!.OT![OTL![Index].Point]!.OrderType = orderType.noText;
            }

            if (OTL![Index].OT![OTL![Index].Point].OrderFeedback != "")
            {
                // int a = 5;
            }

            OTL![Index].OT![OTL![Index].Point].OrderFeedback += text + loca.OrderList_AddOrderFeedback_16217;

            if (_cbCreateOrderPath != null)
                // OTL![Index]!.OT![OTL![Index].Point - 1].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
                _cbCreateOrderPath(OTL![Index].OT!, OTL![Index].Point);
        }

    }

    public void AddOrderFeedback(string? context, string? text, bool sysComment = false)
    {
        AddOrderFeedback(context, text, CurrentOrderListIx, sysComment);
    }

    public bool DoCreateOrderPath(ObservableCollection<OrderTable> otl, int Index)
    {
        bool done = false;

        if (_cbCreateOrderPath != null)
        {
            _cbCreateOrderPath(otl, Index);
            done = true;
        }
        return done;
    }

    public string? UniqueOrderListName(string? Name)
    {
        var splitName = GetNameNumber(Name!);

        bool unique = true;
        // bool found = false;
        int highestNumber = 0;
        string? destName = null;

        for (int ix = 0; ix < OTL!.Count; ix++)
        {
            var splitNameCurrent = GetNameNumber(OTL![ix].Name!);
            if (splitNameCurrent.Item2 == splitName.Item2)
            {
                unique = false;
                if (splitNameCurrent.Item3 > highestNumber)
                    highestNumber = splitNameCurrent.Item3;
            }
        }

        if (unique)
        {
            destName = Name;
        }
        else
        {
            destName = String.Format(loca.OrderList_UniqueOrderListName_16218, splitName.Item2, highestNumber + 1);
        }

        return destName;
    }
    public bool SyncOrderList()
    {
        if (_cbShowChanges != null)
        {
            _cbShowChanges(this);
            return true;
        }
        else
        {
            return false;
        }
    }
    public (string?, string?, int) GetNameNumber(string s)
    {
        string? sWithoutNumber = null;
        // int position = 1;
        int number = 0;

        if (s[s.Length - 1] == ')')
        {
            int ix = s.Length - 2;

            while (ix >= 0 && s[ix] != '(' && Char.IsNumber(s[ix]))
            {
                ix--;
            }
            if (ix >= 0 && s[ix] == '(')
            {
                number = Int32.Parse(s.Substring(ix + 1, s.Length - ix - 2));
                sWithoutNumber = s.Substring(0, ix);
            }
        }
        else
        {
            sWithoutNumber = s;
            number = 0;
        }

        return (s, sWithoutNumber, number);
    }
    public bool AddOrder(orderType? ot, string? orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false)
    {
        if (CurrentOrderListIx == 0) return false;

        return AddOrderAllTabs(ot, orderText, orderChoice, CurrentOrderListIx, lang, ptl, ptlSignature, ref newIndex, silent);
    }

    public bool AddOrder(orderType? ot, string? orderText, int? orderChoice, int Index, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false)
    {
        return AddOrderAllTabs(ot, orderText, orderChoice, Index, lang, ptl, ptlSignature, ref newIndex, silent);
    }

    public bool AddOrderAllTabs(orderType? ot, string? orderText, int? orderChoice, int Index, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false)
    {

        // Split des aktuellen Runs, wenn mitten im Run ein neuer Befehl auftaucht. Ausnahme: Index == 0. Dieser Fall wird nicht auftreten, also muss auch
        // der Run nicht gesplittet werden.
        // Der Split ist nur noch möglich im Debug-Modus
        if (OTL![Index].OT == null )
        {
            
        }
        else if ((OTL![Index].Point < (OTL![Index].OT!.Count - 1)) && Index != 0)
        {

            // Ignores: 001
            string newName = OTL![Index].Name + loca.OrderList_AddOrderAllTabs_16210 + (OTL![Index].Point + 1);
            int lastOrderListIx = Index;

            AddOrderList(newName, false);
            if (CBAddTable != null)
                CBAddTable(Index);
            // OTL![CurrentOrderListIx].DG.DataGrid_SetTabItem(CurrentOrderListIx);

            for (int ix = 0; ix <= OTL![lastOrderListIx].Point; ix++)
            {
                OTL![OTL!.Count - 1]!.OT!.Add(new OrderTable(OTL![lastOrderListIx]!.OT![ix]!.OrderType!, OTL![lastOrderListIx]!.OT![ix]!.OrderText!, OTL![lastOrderListIx]!.OT![ix]!.OrderChoice!, OTL![lastOrderListIx]!.OT![ix]!.oLG!, OTL![lastOrderListIx]!.OT![ix]!.ptl!, OTL![lastOrderListIx]!.OT![ix]!.ptlSignatures!));
                OTL![OTL!.Count - 1]!.OT![ix]!.OrderResult = OTL![lastOrderListIx]!.OT![ix]!.OrderResult!;
                OTL![OTL!.Count - 1]!.OT![ix]!.OrderFeedback = OTL![lastOrderListIx]!.OT![ix]!.OrderFeedback!;
                OTL![OTL!.Count - 1]!.OT![ix]!.OrderActive = OTL![lastOrderListIx].OT![ix].OrderActive;

                /* ToDo DataGrid weg
                if (OTL![OTL!.Count - 1].DG != null)
                    OTL![OTL!.Count - 1]!.OT![ix]!.DetailsWidth = OTL![OTL!.Count - 1]!.DG!.Width - 50;
                */
            }
            Index = OTL!.Count - 1;

            newIndex = Index;
            /*
            if( newIndex != null)
            {
                newIndex = Index;
            }
            */
        }
        OrderTable otx = new OrderTable(ot, orderText!, orderChoice, lang, ptl, ptlSignature);
        OTL![Index]!.OT!.Add(otx);
        if (_cbCreateOrderPath != null)
            //  OTL![Index]!.OT![OTL![Index]!.OT!.Count - 1 ].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
            _cbCreateOrderPath(OTL![Index].OT!, OTL![Index]!.OT!.Count - 1);
        /* ToDo: DataGrid weg
        if (OTL![OTL!.Count - 1].DG != null)
        {
            if (OTL![OTL!.Count - 1]!.DG!.IsVisible)
            {
                OTL![Index]!.OT![OTL![Index]!.OT!.Count - 1]!.DetailsWidth = OTL![Index]!.DG!.Width - 50;


            }

        }
        */

        otx.No = OTL![Index]!.OT!.Count!;
        OTL![Index].Point = OTL![Index]!.OT!.Count - 1;

        if (!silent)
        {
            SyncOrderList();
            if( Collector != null )
            { 
                FlushCollection();
                StartCollection();
            }
            SaveOrderTable();

        }


        return (true);
    }
    public bool AddOrderCurrentRun(orderType? ot, string? orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature)
    {
        if (this._actualGame == true)
        {

            OrderTable otx = new OrderTable(ot, orderText!, orderChoice, lang, ptl, ptlSignature);
            OTL![0].OT!.Add(otx);
            otx.No = OTL![0].OT!.Count!;
            // OTL![0].Point = OTL![CurrentOrderListIx].OT.Count - 1;
            OTL![0].Point = OTL![0]!.OT!.Count - 1;
            /* DataGrid, go home!
            if (OTL![0].DG != null)
                OTL![0].OT![OTL![0].Point]!.DetailsWidth = OTL![0]!.DG!.Width - 50;
            */
            SaveOrderTable();
            // OTL![0].Point = OTL![0].OT.Count - 1;
        }
        return true;
    }
    public bool ResetCurrentRun()
    {
        if (this._actualGame == true)
        {
            OTL![0].OT = new ObservableCollection<OrderTable>();
            // AddOrderCurrentRun(orderType.orderText, "restart restart", null, null, null);
        }
        return true;
    }
    public OrderTable GetOrderTable(int ListNr, int EntryNr)
    {
        return OTL![ListNr].OT![EntryNr]!;
    }
    public OrderTable GetOrderTable(int ix)
    {
        OrderTable? ot1 = null;

        if (ix < OTL![CurrentOrderListIx]!.OT!.Count!)
        {
            ot1 = OTL![CurrentOrderListIx]!.OT![ix];

        }

        return ot1!;
    }

    public OrderListTable GetOrderListTable(int ListNr)
    {
        return OTL![ListNr];
    }
    public void DisableTempOrderList()
    {
        if (CurrentOrderListIx < OTL!.Count)
            OTL![CurrentOrderListIx].TempPoint = -1;
        if (this._actualGame == true)
        {

            OTL![0].TempPoint = -1;
        }
    }
    public void ResetTempOrderList()
    {
        OTL![CurrentOrderListIx].TempPoint = 0;
        foreach (OrderTable ot1 in OTL![CurrentOrderListIx]!.OT!)
        {
            ot1.OrderResult = "";
            ot1.OrderFeedback = "";
        }
    }
    public void ResetTempOrderListCurrentRun()
    {
        if (this._actualGame == true)
        {

            OTL![0].TempPoint = 0;
            foreach (OrderTable ot1 in OTL![0]!.OT!)
            {
                ot1.OrderResult = "";
                ot1.OrderFeedback = "";
            }
        }
    }
}

public class OrderListInfo
{

    public int jsonIndex;

    public int listNr;
}

public enum orderWriteMode { always, never };
