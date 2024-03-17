using System;
// using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
// using System.Text.Json;
// using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using CefSharp.DevTools.CSS;

using Phoney_MAUI.Model;

namespace GameCore
{

    public enum orderType { orderText, mcChoice, noText, comment };


    public enum orderWriteMode { always, never};


    public class OrderListInfo
    {

        public int jsonIndex;

        public int listNr; 
    }

    [Serializable]

    public class OrderTable: INotifyPropertyChanged
    {

        public orderType oTy;

        public string oTe;

        public int? oCh;

        public string oRe;

        public string oFe;

        public string oPa;
        public bool oAc;
        public IGlobalData.language oLG;
        [JsonIgnore]

        public ParseTokenList? ptl;
        [JsonIgnore]

        public ParseLineList? ptlSignatures;

        public int no;
        [JsonIgnore]

        public bool _current;
        [JsonIgnore]

        public double _detailsWidth;

        [JsonIgnore]
        [NonSerialized]

        private PropertyChangedEventHandler? _propertyChanged;

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { _propertyChanged += value!; }
            remove { _propertyChanged -= value!; }
        }


        public void NotifyPropertyChanged(string? propName = null )
        {
            if (this._propertyChanged != null)
                this._propertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        [JsonIgnore]

        public string OrderText
        {
            get { return oTe; }
            set 
            {
                /*
                if (this.OrderType != orderType.orderText)
                    this.OrderType = orderType.orderText;
                */
                oTe = value; 
            }
        }
        [JsonIgnore]

        public bool OrderActive
        {
            get { return oAc; }
            set
            {
                if( value == false)
                {
                    // int a = 3;
                }
                oAc = value;
            }
        }
        [JsonIgnore]

        public string OrderPath
        {
            get { return oPa; }
            set
            {
                oPa = value;
            }
        }
        [JsonIgnore]

        public double DetailsWidth
        {
            get { return _detailsWidth; }
            set
            {
                _detailsWidth = value;
                NotifyPropertyChanged( loca.OrderTable_NotifyPropertyChanged_16171);

            }
        }

        [JsonIgnore]

        public orderType OrderType
        {
            get { return oTy; }
            set { oTy = value; }
        }
        [JsonIgnore]

        public string OrderTypeText
        {
            get 
            {
                if (oTy== orderType.mcChoice)
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
                else if (value == loca.OrderTable_NotifyPropertyChanged_16177 || value == loca.OrderTable_NotifyPropertyChanged_16178 )
                    oTy  = orderType.noText;
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
                /*
                if (this.OrderType != orderType.mcChoice)
                    this.OrderType = orderType.mcChoice;
                */
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

        public string OrderResult
        {
            get 
            { 
                return oRe; 
            }
            set { oRe = value; }
        }
        [JsonIgnore]

        public string OrderFeedback
        {
            get { return oFe; }
            set { oFe = value; }
        }
        [JsonIgnore]

        public string OrderAllResult
        {
            get 
            {  
                if( oFe != "")
                {
                    // Ignores: 001
                    return (oRe + loca.OrderTable_NotifyPropertyChanged_16181 +oFe);
                }
                else
                {
                    return (oRe );

                }
            }
        }
        [JsonIgnore]

        public string? Current
        {
            get 
            {
                if (_current == true)
                    return ( loca.OrderTable_NotifyPropertyChanged_16182);
                else
                    return ( "");
            }
            set 
            {
                if (value != null)
                {
                    if( _current == false )
                        NotifyPropertyChanged( loca.OrderTable_NotifyPropertyChanged_16183);
                    _current = true;
                }
                else
                {
                    if (_current == true)
                        NotifyPropertyChanged( loca.OrderTable_NotifyPropertyChanged_16184);
    
                    _current = false;
                }
            }
        }
        [JsonIgnore]

        public ParseTokenList? PTL
        {
            get { return ptl; }
            set { ptl = value; }
        }

        public ParseLineList PTLSignatures
        {
            get { return ptlSignatures!; }
            set { ptlSignatures = value; }
        }


        public OrderTable( orderType orderType, string orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl = null, ParseLineList? ptlSignature = null)
        {
            this.oTy = orderType;
            this.oTe = orderText;
            this.oCh = orderChoice;
            this.oLG = lang;
            this.oRe = "";
            this.oFe = "";
            this.OrderActive = true;
            this.ptl = ptl;
            this.ptlSignatures = ptlSignature;
            this.DetailsWidth = 400;
        }

        public string Name()
        {
            string name;

            if (OrderType  == orderType.orderText)
                // Ignores: 001
                name = loca.OrderTable_Name_16185 +OrderText;
            else if (OrderType == orderType.noText)
                // Ignores: 001
                name = loca.OrderTable_Name_16186 +OrderText;
            else if (OrderType == orderType.comment)
                // Ignores: 001
                name = loca.OrderTable_Name_16187 +OrderText;
            else
                name = String.Format( loca.OrderTable_Name_16188, OrderChoice);

            return name;
        }
    }

    [Serializable]

    public class OrderListTable: INotifyPropertyChanged
    {

        public ObservableCollection<OrderTable>? _ot;

        public string? _name;

        public int _pt;

        public int _tmpPt;

        public bool _zipped;
        [JsonIgnore]
        [NonSerialized]

        public DataGrid? _dg;
        [JsonIgnore]
        [NonSerialized]

        private IGlobalData? _gd;
        [JsonIgnore]
        [NonSerialized]

        public Grid? _g;


        public event PropertyChangedEventHandler? PropertyChanged;


        public void NotifyPropertyChanged(string? propName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
                if( _pt != value )
                {

                    _pt = value;
                    if (_pt >= this.OT!.Count)
                    {
                        _pt = this.OT!.Count - 1;
                    }

                    if (_gd == null &&  _gd?.SilentMode == false)
                    {
                        RefreshCurrent();

                        /*
                        foreach (OrderTable ot in this.OT)
                        {
                            if (ot.No - 1 == _pt)
                            {
                                ot.Current = "1";
                                this.NotifyPropertyChanged( "Current");
                                // Debug.WriteLine( ">>> ist jetzt bei " + _pt +"." );
                            }
                            else
                            {
                                if (ot.Current != null)
                                {
                                    this.NotifyPropertyChanged( "Current");
                                    ot.Current = null;
                                }
                            }
                        }
                        */
                    }


                }

            }
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
                    this.NotifyPropertyChanged( loca.OrderListTable_RefreshCurrent_16190);
                    // Debug.WriteLine( ">>> ist jetzt bei " + _pt +"." );
                }
                else
                {
                    if (ot.Current != null)
                    {
                        this.NotifyPropertyChanged( loca.OrderListTable_RefreshCurrent_16191);
                        ot.Current = null;
                    }
                }
            }

        }
        [JsonIgnore]

        public DataGrid? DG
        {
            get { return _dg; }
            set { _dg = value; }
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
        [JsonIgnore]

        public OrderTable PointOrderTable
        {
            get { return _pt > 0 ? OT![_pt]! : null! ; }
        }

        public OrderListTable( string name, IGlobalData gd )
        {
            _gd = gd;
            if (gd == null) 
                _gd = loca.GD;

            _ot = new ObservableCollection<OrderTable>();
            _name = name;
        }
    }

    [Serializable]

    public class OrderList
    {

        public int currentOrderListIx;

        public int _currentOLIndex;

        public List<OrderListTable> _otl;
        [JsonIgnore]
        [NonSerialized]

        private IGlobalData _gd;
        private IUIServices _uis;
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

        [JsonIgnore]

        public List<OrderListTable> OTL
        {
            get { return _otl; }
            set { if (value != null) _otl = value; }
        }
        [JsonIgnore]

        public int CurrentOLIndex
        {
            get { return _currentOLIndex;  }
            set { _currentOLIndex = value; }
        }

        [JsonIgnore]
        public DelCreateOrderPath CBCreateOrderPath
        {
            get => _cbCreateOrderPath;
            set => _cbCreateOrderPath = value;
        } 


        [JsonIgnore]

        public int CurrentOrderListIx
        {
            get { return currentOrderListIx; }
            set 
            {
                int oldVal = currentOrderListIx;

                if (value >= 0 && value < OTL.Count)
                {
                    // Wurde der Index verändert?
                    if (oldVal != value && oldVal != 0 )
                    {

                        // Dann wird der alte Index archiviert

                        // ... und der aktuelle Status entfernt, weil der ja schon gezippt ist
                        // _otl[oldVal].Zipped = true; 
                        // _otl[oldVal].OT = null;
                    }
                    currentOrderListIx = value;

                    if( this.OTL[value].Zipped )
                    {
                        ReadZipOrderTable(value, this.OTL[value].Name!);

                    }
                }
            }
        }
        [JsonIgnore]

        public DelInt CBAddTable
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

        public DelOrderList SetShowChanges
        {
            get { return _cbShowChanges!; }
            set { _cbShowChanges = value; }
        }
        [JsonIgnore]

        public DelVoid SetSaveOrderList
        {
            get { return _cbSaveOrderList!; }
            set 
            { 
                if( value != null )
                    _cbSaveOrderList = value; 
            }
        }
        [JsonIgnore]

        public DelInt SetZipOrderList
        {
            get { return _cbZipOrderList!; }
            set
            {
                if (value != null)
                    _cbZipOrderList = value;
            }
        }
        [JsonIgnore]

        public DelIntString SetReadZipOrderList
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

        public OrderListTable CurrentOrderListTableEntry
        {
            get 
            { 
                if (CurrentOrderListIx >= OTL.Count) 
                    CurrentOrderListIx = 0; 
                return OTL[CurrentOrderListIx]; 
            }
            set
            {
                for( int loopA = 0; loopA < OTL.Count; loopA++)
                {
                    OrderListTable otlx = OTL[loopA];
                    if ( otlx == value )
                    {
                        CurrentOrderListIx = loopA;
                    }
                }
            }
        }


        public bool CompareOrderTables( OrderTable ot1, OrderTable ot2)
        {
            bool identical = true;

            if (ot1.OrderType!= ot2.OrderType) 
                identical = false;
            if (ot1.OrderText != ot2.OrderText) 
                identical = false;
            if (ot1.OrderChoice != ot2.OrderChoice) 
                identical = false;

            return ( identical);
        }

        public bool CompareRuns( OrderListTable otl1, OrderListTable otl2, int otl1ix)
        {
            bool identical = true;

            // if (otl1.Name != otl2.Name) identical = false;

            if (otl1.Zipped)
                ReadZipOrderTable(otl1ix, otl1!.Name!);

            if (otl1.OT!.Count != otl2.OT!.Count ) identical = false;
            int x = 0;

            if( identical == true )
            {
                for (x = 0; x < otl1.OT!.Count; x++)
                {
                    if (CompareOrderTables(otl1.OT[x], otl2.OT[x]!) == false)
                    {
                        identical = false;
                        break;
                    }
                }

            }

            return identical;
        }





        public OrderList(DelVoid SaveOrderListExtern, DelInt ZipOrderListExtern, DelIntString ReadZipOrderListExtern, ref OrderListInfo oli, IGlobalData gd, IUIServices uis, bool ReadData = true)
        {
            // int jsonIndex = 0;

            _gd = gd;
            _uis = uis;
            _otl = new List<OrderListTable>();
            SetSaveOrderList = SaveOrderListExtern;
            SetZipOrderList = ZipOrderListExtern;
            SetReadZipOrderList = ReadZipOrderListExtern;
            CurrentOrderListIx = 0;

            if (ReadData)
            {
                _uis.InitPath();
                /*

                // Die Indexer-Datei laden, falls vorhanden
                string? pathName = GlobalData.CurrentPath(); 
                // Ignores: 002
                string? pathfileName = pathName + loca.OrderList_OrderList_16197;

                if (Directory.Exists(pathName) == false)
                {
                    Directory.CreateDirectory(pathName);
                }
                */

                string jsonSource = _uis.LoadString(loca.OrderList_OrderList_16197);
                // Laden der Indexer-Datei (und Wert wird dann um eins erhöht)
                if ( jsonSource != null )
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

                _uis.GD.OrderList = this;
                // Die aktuelle OrderTable wird gesichert über den Indexerwert im Dateinamen
                _uis.BackupOrdertable();

                /*
                string pathfileName = pathName + loca.OrderList_OrderList_16198;
                if (File.Exists(pathfileName))
                {
                    string pathDestName = pathName + loca.OrderList_OrderList_16199 + string.Format(loca.OrderList_OrderList_16200, SetOrderListInfo.jsonIndex);
                    File.Copy(pathfileName, pathDestName);
                }
                string pathFileNameZip = pathName + loca.OrderList_OrderList_16201 + loca.OrderList_OrderList_16202;
                if (File.Exists(pathFileNameZip))
                {
                    string pathDestNameZip = pathName + loca.OrderList_OrderList_16203 + string.Format(loca.OrderList_OrderList_16204, SetOrderListInfo.jsonIndex);
                    File.Copy(pathFileNameZip, pathDestNameZip);
                }
                */

                // Und jetzt laden wir die OrderTable ein
                jsonSource = _uis.LoadString(loca.OrderList_OrderList_16198);
                if (jsonSource != null )
                {
                    // ToDo: Wofür zum Teufel ist diese Zeile gut??
                    // OrderList? ol2 = new OrderList(SaveOrderListExtern, ZipOrderListExtern, ReadZipOrderListExtern, ref _orderListInfo!, _gd, false);
                    OrderList? ol2;
                    ol2 = JsonConvert.DeserializeObject<OrderList>(jsonSource);


                    if (ol2 != null)
                    {
                        this.currentOrderListIx = ol2.CurrentOrderListIx;
                        this._otl = ol2._otl;
                        this._gd = gd;
                        StripOrderList();

                    }
                    else
                    {
                        AddOrderList(loca.OrderList_OrderList_16205, true);
                        // AddOrderList(null);
                        CurrentOrderListIx = OTL.Count - 1;

                    }
                }
                else
                {
                    AddOrderList(loca.OrderList_OrderList_16206, true);
                    // AddOrderList(null);
                    CurrentOrderListIx = OTL.Count - 1;
                }
            }

        }


        public bool WriteJsonIndex()
        {
            string? jsonDest = JsonConvert.SerializeObject(SetOrderListInfo, Newtonsoft.Json.Formatting.Indented);
            _uis.SaveString(loca.OrderList_WriteJsonIndex_16209, jsonDest);
            /*
            string? pathName = GlobalData.CurrentPath(); 
            string? pathfileName = pathName + loca.OrderList_WriteJsonIndex_16209;

            File.WriteAllText(pathfileName, jsonDest);
            */
            return true;
        }

        public void StripOrderList()
        {
            foreach (OrderListTable otl in this.OTL)
            {
                if( otl.OT != null )
                {
                    foreach( OrderTable ot in otl.OT )
                    {
                        if( ot.OrderText != null )
                        {
                            string s = ot.OrderText;
                            // Noloca: 001

                            if (s.StartsWith( "--> "))
                                s = s.Substring(4);

                        }

                    }
                    // otl.Point = otl.OT.Count - 1;
                }
            }
        }


        public bool AddOrder(orderType ot, string orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int  newIndex, bool silent = false)
        {
            if (CurrentOrderListIx == 0) return false;

            return AddOrderAllTabs(ot, orderText, orderChoice, CurrentOrderListIx, lang, ptl, ptlSignature, ref newIndex, silent);
        }

        public bool AddOrder(orderType ot, string orderText, int? orderChoice, int Index, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature, ref int newIndex, bool silent = false)
        {
            return AddOrderAllTabs(ot, orderText, orderChoice, Index, lang, ptl, ptlSignature, ref newIndex, silent);
        }


        public bool AddOrderAllTabs(orderType ot, string orderText, int? orderChoice, int Index, IGlobalData.language lang,  ParseTokenList? ptl, ParseLineList? ptlSignature, ref int  newIndex, bool silent = false )
        {   

            // Split des aktuellen Runs, wenn mitten im Run ein neuer Befehl auftaucht. Ausnahme: Index == 0. Dieser Fall wird nicht auftreten, also muss auch
            // der Run nicht gesplittet werden.
            if ( ( OTL[Index].Point < ( OTL[Index].OT!.Count - 1 ) ) && Index != 0 ) 
            {
                
                // Ignores: 001
                string newName = OTL[Index].Name + loca.OrderList_AddOrderAllTabs_16210 +(OTL[Index].Point + 1);
                int lastOrderListIx = Index;

                AddOrderList(newName, false);
                if (CBAddTable != null)
                    CBAddTable(Index);
                // OTL[CurrentOrderListIx].DG.DataGrid_SetTabItem(CurrentOrderListIx);

                for ( int ix = 0; ix <= OTL[lastOrderListIx].Point; ix++ )
                {
                    OTL[OTL.Count - 1]!.OT!.Add(new OrderTable(OTL![lastOrderListIx]!.OT![ix]!.OrderType!, OTL![lastOrderListIx]!.OT![ix]!.OrderText!, OTL![lastOrderListIx]!.OT![ix]!.OrderChoice!, OTL![lastOrderListIx]!.OT![ix]!.oLG!, OTL![lastOrderListIx]!.OT![ix]!.ptl!, OTL![lastOrderListIx]!.OT![ix]!.ptlSignatures!));
                    OTL[OTL.Count - 1]!.OT![ix]!.OrderResult = OTL![lastOrderListIx]!.OT![ix]!.OrderResult!;
                    OTL[OTL.Count - 1]!.OT![ix]!.OrderFeedback = OTL![lastOrderListIx]!.OT![ix]!.OrderFeedback!;
                    OTL[OTL.Count - 1]!.OT![ix]!.OrderActive= OTL![lastOrderListIx].OT![ix].OrderActive;

 
                    if ( OTL[OTL.Count - 1].DG != null )
                        OTL![OTL!.Count - 1]!.OT![ix]!.DetailsWidth = OTL![OTL!.Count - 1]!.DG!.Width - 50;
                }
                Index = OTL.Count - 1;

                newIndex = Index;
                /*
                if( newIndex != null)
                {
                    newIndex = Index;
                }
                */
            }
            OrderTable otx = new OrderTable(ot, orderText, orderChoice, lang, ptl, ptlSignature);
            OTL![Index]!.OT!.Add( otx );
            if (_cbCreateOrderPath != null)
                //  OTL![Index]!.OT![OTL![Index]!.OT!.Count - 1 ].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
                _cbCreateOrderPath(OTL![Index].OT, OTL![Index].OT.Count-1);
            if (OTL[OTL.Count - 1].DG != null)
            {
                if (OTL![OTL!.Count - 1]!.DG!.IsVisible)
                {
                    OTL![Index]!.OT![OTL![Index]!.OT!.Count - 1]!.DetailsWidth = OTL![Index]!.DG!.Width - 50;


                }

            }

            otx.No = OTL![Index]!.OT!.Count!;
            OTL[Index].Point = OTL![Index]!.OT!.Count-1;

            if(!silent)
            {
                SyncOrderList();
                SaveOrderTable();

            }

            
            return (true);
        }


        public void StartCollection()
        {
            Collector = "";
            /*
            if (_gd!.FeedbackWindow == false)
            else
                Collector = null;
            */
        }


        public void FlushCollection()
        {
            string col = ReleaseColletion()!;


            OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx]!.OT!.Count - 1]!.OrderResult = col;
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

        public void AddOrderText( string text)
        {

            if( text == null || text == "" ) return;

            text = Helper.FirstUpper(text)!;

            if (Collector != null)
                Collector += text + loca.OrderList_AddOrderText_16211;
            else
            {
                if (OTL![CurrentOrderListIx].Zipped == true)
                {
                    ReadZipOrderTable(CurrentOrderListIx, OTL![CurrentOrderListIx].Name!);
                }

                if (OTL[CurrentOrderListIx].TempPoint >= 0)
                {
                    if (OTL[CurrentOrderListIx].TempPoint > 0)
                    {
                        if (OTL[CurrentOrderListIx].TempPoint > OTL![CurrentOrderListIx].OT.Count)
                            OTL![CurrentOrderListIx].TempPoint = OTL![CurrentOrderListIx].OT.Count;
                        OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].TempPoint - 1].OrderResult += text + loca.OrderList_AddOrderText_16212;

                        if (_cbCreateOrderPath != null)
                            // OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx].TempPoint - 1].OrderPath = _cbCreateOrderPath(OTL![CurrentOrderListIx].OT, OTL![CurrentOrderListIx].TempPoint - 1);
                            _cbCreateOrderPath(OTL![CurrentOrderListIx].OT, OTL![CurrentOrderListIx].TempPoint - 1);

                    }
                }
                else if (OTL![CurrentOrderListIx]!.Point >= 0 && OTL![CurrentOrderListIx]!.Point < OTL![CurrentOrderListIx]!.OT!.Count)
                {
                    OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].Point].OrderResult += text + loca.OrderList_AddOrderText_16213;
                    if (_cbCreateOrderPath != null)
                        // OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx].Point].OrderPath = _cbCreateOrderPath(OTL![CurrentOrderListIx].OT, OTL![CurrentOrderListIx].Point);
                        _cbCreateOrderPath(OTL![CurrentOrderListIx].OT, OTL![CurrentOrderListIx].Point);
                }
                if (CurrentOrderListIx != 0 )
                {
                    if (this._actualGame == true)
                    {

                        if (OTL[CurrentOrderListIx].TempPoint >= 0)
                        {
                            if (OTL[CurrentOrderListIx].TempPoint > 0)
                            {
                                int val = OTL[CurrentOrderListIx].TempPoint - 1;


                                if (val >= OTL[0].OT!.Count)
                                {
                                    val = OTL[0].OT!.Count - 1;
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

        public void AddOrderFeedback(string? context, string? text, int Index, bool sysComment = false)
        {
            if (text == null || text == "") return;

            if (OTL[Index].TempPoint >= 0)
            {
                if (OTL[Index].TempPoint > 0)
                {
                    if (OTL![Index].OT![OTL![Index]!.TempPoint - 1].OrderText == context)
                    {
                        if (OTL![Index].OT![OTL![Index].TempPoint-1].OrderFeedback != "")
                        {
                            // int a = 5;
                        }

                        OTL![Index].OT![OTL[Index].TempPoint - 1].OrderFeedback += text + loca.OrderList_AddOrderFeedback_16216;
                        if (_cbCreateOrderPath != null)
                            // OTL![Index]!.OT![OTL![Index].TempPoint - 1].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
                            _cbCreateOrderPath(OTL![Index].OT, OTL[Index].TempPoint - 1);
                        // OTL[CurrentOrderListIx].TempPoint++;
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
                else if (!sysComment )
                {
                    OTL![Index]!.OT![OTL![Index].Point]!.OrderType = orderType.noText;
                }

                if(OTL![Index].OT![OTL![Index].Point].OrderFeedback != "")
                {
                    // int a = 5;
                }

                OTL![Index].OT![OTL![Index].Point].OrderFeedback += text + loca.OrderList_AddOrderFeedback_16217;

                if (_cbCreateOrderPath != null)
                    // OTL![Index]!.OT![OTL![Index].Point - 1].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
                    _cbCreateOrderPath(OTL![Index].OT, OTL![Index].Point);
            }

        }

        public void AddOrderFeedback(string context, string text, bool sysComment = false)
        {
            AddOrderFeedback(context, text, CurrentOrderListIx, sysComment);
            /*
            if (text == null || text == "") return;

            if (OTL[CurrentOrderListIx].TempPoint >= 0)
            {
                if (OTL[CurrentOrderListIx].TempPoint > 0)
                {
                    if(OTL[CurrentOrderListIx].OT[OTL[CurrentOrderListIx].TempPoint - 1].OrderText == context)
                    {
                        OTL[CurrentOrderListIx].OT[OTL[CurrentOrderListIx].TempPoint - 1].OrderFeedback += text + "\n";
                        // OTL[CurrentOrderListIx].TempPoint++;
                    }
                }
            }
            else if (OTL[CurrentOrderListIx].Point >= 0 && OTL[CurrentOrderListIx].Point < OTL[CurrentOrderListIx].OT.Count)
            {
                if (OTL[CurrentOrderListIx].OT[OTL[CurrentOrderListIx].Point].OrderText != context && !sysComment)
                {
                    AddOrder(orderType.noText, context, null, null, null, true);
                }
                else
                {
                    OTL[CurrentOrderListIx].OT[OTL[CurrentOrderListIx].Point].orderType = orderType.noText;
                }

                OTL[CurrentOrderListIx].OT[OTL[CurrentOrderListIx].Point].OrderFeedback += text + "\n";
            }
 */
        }

        public void AddOrderFeedbackCurrentRun(string? context, string? text, bool sysComment = false )
        {
            if( this._actualGame == true )
                AddOrderFeedback(context, text, 0, sysComment);
            /*
            OrderTable otx = new OrderTable(orderType.noText, context, null, null, null);
            OTL[0].OT.Add(otx);
            otx.No = OTL[0].OT.Count;
            // OTL[0].Point = OTL[CurrentOrderListIx].OT.Count - 1;
            // SaveOrderTable();
            OTL[0].Point = OTL[0].OT.Count - 1;
            OTL[0].OT[OTL[0].Point].OrderFeedback += text + "\n";
            */

            /*
            if (text == null || text == "") return;

            if (OTL[0].Point >= 0 && OTL[0].Point < OTL[0].OT.Count)
            {

                if (OTL[0].OT[OTL[0].Point].OrderText != context)
                {
                    AddOrder(orderType.noText, context, null, null, null, true);
                }

                OTL[0].OT[OTL[0].Point].OrderFeedback += text + "\n";
            }
            else
                a = 5;
            */

        }


        public bool DoCreateOrderPath( ObservableCollection<OrderTable> otl, int Index)
        {
            bool done = false;

            if (_cbCreateOrderPath != null)
            {
                // OTL![Index]!.OT![OTL![Index].Point - 1].OrderPath = _cbCreateOrderPath(OTL![Index].OT, Index);
                _cbCreateOrderPath(otl, Index);
                done = true;
            }
            return done;
        }

        public bool AddOrderCurrentRun(orderType ot, string? orderText, int? orderChoice, IGlobalData.language lang, ParseTokenList? ptl, ParseLineList? ptlSignature)
        {
            if (this._actualGame == true)
            {

                OrderTable otx = new OrderTable(ot, orderText!, orderChoice, lang, ptl, ptlSignature);
                OTL[0].OT!.Add(otx);
                otx.No = OTL[0].OT!.Count!;
                // OTL[0].Point = OTL[CurrentOrderListIx].OT.Count - 1;
                OTL[0].Point = OTL[0]!.OT!.Count - 1;
                if (OTL[0].DG != null)
                    OTL![0].OT![OTL![0].Point]!.DetailsWidth = OTL![0]!.DG!.Width - 50;

                SaveOrderTable();
                // OTL[0].Point = OTL[0].OT.Count - 1;
            }
            return true;
        }

        public bool ResetCurrentRun()
        {
            if (this._actualGame == true)
            {
                OTL[0].OT = new ObservableCollection<OrderTable>();
                // AddOrderCurrentRun(orderType.orderText, "restart restart", null, null, null);
            }
            return true; 
        }

        public OrderTable GetOrderTable( int ListNr, int EntryNr )
        {
            return OTL![ListNr].OT![EntryNr]!;
        }

        public OrderListTable GetOrderListTable(int ListNr )
        {
            return OTL[ListNr];
        }


        // Obsolet?
        public bool Switch( int newOrderListTable)
        {
            CurrentOrderListIx = newOrderListTable;
            return true;
        }



        public (string?, string?, int) GetNameNumber( string s)
        {
            string? sWithoutNumber = null;
            // int position = 1;
            int number = 0;

            if (s[s.Length - 1] == ')')
            {
                int ix = s.Length - 2;

                while( ix >= 0 && s[ix] != '(' && Char.IsNumber( s[ix] ) )
                {
                    ix--;
                }
                if( ix >= 0 && s[ix] == '(')
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
        // Stellt sicher, dass ein Orderlist-Name noch nie vergeben wurde (we

        public string UniqueOrderListName( string Name )
        {
            var splitName = GetNameNumber(Name);

            bool unique = true;
            // bool found = false;
            int highestNumber = 0;
            string? destName = null;

            for (int ix = 0; ix < OTL.Count; ix++)
            {
                var splitNameCurrent = GetNameNumber(OTL[ix].Name!);
                if (splitNameCurrent.Item2 ==splitName.Item2)
                {
                    unique = false;
                    if (splitNameCurrent.Item3 > highestNumber)
                        highestNumber = splitNameCurrent.Item3;
                }
            }

            if( unique )
            {
                destName = Name;
            }
            else
            {
                destName = String.Format( loca.OrderList_UniqueOrderListName_16218, splitName.Item2, highestNumber + 1);
            }

            return destName;
        }

        public bool AddOrderList( string Name, bool baseEntry = true, IGlobalData.language lang = IGlobalData.language.german)
        {
            if( Name == null )
            {
                Name = String.Format( loca.OrderList_AddOrderList_16219, SetOrderListInfo!.listNr);
                SetOrderListInfo.listNr++;
            }


            Name = UniqueOrderListName(Name);

            OTL.Add( new OrderListTable( Name, _gd ) );
            SyncOrderList();
            SaveOrderTable();
            CurrentOrderListIx = OTL.Count - 1;

            if (baseEntry)
            {
                int val = 0;
                if( loca.GD!.Language == IGlobalData.language.english)
                    AddOrderAllTabs(orderType.orderText, loca.OrderList_AddOrderList_16220e, null, CurrentOrderListIx, lang, null, null, ref val);
                else
                    AddOrderAllTabs(orderType.orderText, loca.OrderList_AddOrderList_16220, null, CurrentOrderListIx, lang, null, null, ref val);
            }
            return (true);
        }


        public bool SyncOrderList()
        {
            if( _cbShowChanges != null)
            {
                _cbShowChanges( this );
                return true;
            }
            else
            {
                return false;
            }
        }


        // Obsolet?
        /*
        public OrderList Clone()
        {
            OrderList olClone = (OrderList) this.MemberwiseClone();

            return olClone;
        }
        */

        public void DisableTempOrderList()
        {
            if( CurrentOrderListIx < OTL.Count )
                OTL[CurrentOrderListIx].TempPoint = -1;
            if (this._actualGame == true)
            {

                OTL[0].TempPoint = -1;
            }
        }


        public void ResetTempOrderList()
        {
            OTL[CurrentOrderListIx].TempPoint = 0;
            foreach( OrderTable ot1 in OTL[CurrentOrderListIx]!.OT! )
            {
                ot1.OrderResult = "";
                ot1.OrderFeedback = "";
            }
        }

        public void ResetTempOrderListCurrentRun()
        {
            if (this._actualGame == true)
            {

                OTL[0].TempPoint = 0;
                foreach (OrderTable ot1 in OTL[0]!.OT!)
                {
                    ot1.OrderResult = "";
                    ot1.OrderFeedback = "";
                }
            }
        }

        public bool CheckIndexStillValid( int val )
        {
            if ( (val +1 ) >=  OTL[CurrentOrderListIx].TempPoint )
                return true;
            else
                return false;
        }

        public OrderTable GetNextOrderTable()
        {
            OrderTable ot1;

            if (OTL[CurrentOrderListIx].TempPoint < OTL[CurrentOrderListIx]!.OT!.Count)
            {
                bool success = false;
                ot1 = OTL![CurrentOrderListIx]!.OT![OTL![CurrentOrderListIx]!.TempPoint]!;

                while (!success)
                {
                    ot1 = OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx]!.TempPoint]!;
                    OTL[CurrentOrderListIx].TempPoint++;

                    // Dieser Wert wird nirgends auf true gesetzt - wozu gibt es ihn dann?
                    if (this._actualGame == true)
                    {
                        if (CurrentOrderListIx > 0)
                            OTL[0].TempPoint++;
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
                OTL[CurrentOrderListIx].TempPoint++;
                if (this._actualGame == true)
                {

                    if (CurrentOrderListIx > 0)
                        OTL[0].TempPoint++;
                }
            }
            return ot1;
        }

        public OrderTable GetCurrentOrderTable()
        {
            OrderTable? ot1 = null ;

            if (OTL[CurrentOrderListIx].TempPoint > 0 )
            {
                ot1 = OTL![CurrentOrderListIx].OT![OTL![CurrentOrderListIx].TempPoint - 1 ]!;

            }
            return ot1!;
        }

        public OrderTable GetOrderTable( int ix )
        {
            OrderTable? ot1 = null;
            
            if( ix < OTL[CurrentOrderListIx]!.OT!.Count! )
            {
                ot1 = OTL[CurrentOrderListIx]!.OT![ix];

            }

            return ot1!;
        }

  
        public int GetOrderTableTempPoint()
        {
            return (OTL[CurrentOrderListIx].TempPoint);
        }

        public int GetOrderTablePoint()
        {
            return (OTL[CurrentOrderListIx].Point);
        }


        public void SaveOrderTable()
        {

            if (_cbSaveOrderList != null && this.orderWriteMode != orderWriteMode.never ) _cbSaveOrderList();
        }

        public void ZipOrderTable(int ix)
        {

            if (_cbZipOrderList != null && this.orderWriteMode != orderWriteMode.never) _cbZipOrderList( ix );
        }

        public void ReadZipOrderTable(int ix, string name )
        {

            if (_cbReadZipOrderList != null && this.orderWriteMode != orderWriteMode.never) _cbReadZipOrderList(ix, name);
        }


    }
}
