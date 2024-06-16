using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Phoney_MAUI.Model;
using Phoney_MAUI.Platform;
using Phoney_MAUI.Game.General;
using advtest;
using System.Collections.ObjectModel;
using System.IO.Compression;
using GameCore;

namespace Phoney_MAUI.Core
{
    public class DataService : IDataService
    {
        public string? SavePath = null;

        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
        }

        public void InitGameDirectory()
        {
            // SavePath = App.GetSavePath();
        }

        public static DataService? _dataService;

        public DataService(IDeviceData deviceData)
        {
            try
            {
                string? currentPath;

                _dataService = this;
                currentPath = DeviceData._deviceData!.GetSavePath();

                if (Directory.Exists(currentPath) == false)
                {
                    Directory.CreateDirectory(currentPath!);

                }
            }
            catch (Exception e)
            {
                GlobalData.AddLog("DataService: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
            }

        }

        public bool WriteJsonIndex(OrderListInfo oli)
        {
            try
            {
                string? pathfileName = DeviceData._deviceData!.GetSavePath()! + loca.OrderList_WriteJsonIndex_16209;

                string? jsonDest = JsonConvert.SerializeObject(oli, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(pathfileName, jsonDest);

                return true;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("WriteJsonIndex: " + ex.Message, IGlobalData.protMode.crisp);
                return false;
            }
        }

        public OrderListInfo ReadJsonIndex()
        {
            try
            {
                OrderListInfo? oli = null;

                // Die Indexer-Datei laden, falls vorhanden
                string? pathfileName = DeviceData._deviceData!.GetSavePath()! + loca.OrderList_WriteJsonIndex_16209;

                // Laden der Indexer-Datei (und Wert wird dann um eins erhöht)
                if (File.Exists(pathfileName))
                {
                    string jsonSource = File.ReadAllText(pathfileName);

                    oli = JsonConvert.DeserializeObject<OrderListInfo>(jsonSource);
                    oli!.jsonIndex++;
                }
                else
                {
                    oli = new OrderListInfo();
                    oli!.jsonIndex = 0;
                    oli!.listNr = 1;
                }

                return oli;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("ReadJsonIndex: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }

        public bool ReadZipOrderTable(int val, string name)
        {
            try
            {
                string orderTableName = "/ordertable.zip";
                // Ignores: 001
                string? pathName = DeviceData._deviceData!.GetSavePath()!;
                // Ignores: 002
                string? pathfileName = pathName + orderTableName;

                // Ignores: 001
                string? jsonName = name + ".json";
                string? jsonString;
                byte[] jsonBytes;



                if (File.Exists(pathfileName))
                {
                    ZipArchive archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);

                    var fileInArchive = archive.GetEntry(jsonName);
                    if (fileInArchive != null)
                    {
                        Stream s = fileInArchive.Open();
                        StreamReader sr = new StreamReader(s);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            sr.BaseStream.CopyTo(ms);
                            jsonBytes = ms.ToArray();

                        }
                        sr.Close();
                        sr.Dispose();
                        s.Close();
                        s.Dispose();

                        if (jsonBytes != null)
                        {
                            // jsonBytes = sr.ReadToEnd();
                            jsonString = Encoding.UTF8.GetString(jsonBytes);

                            // ToDo: Diese Initialisierung kann ich erst vornehmen, wenn die Datenstrukturen komplett sind
                            GD!.OrderList!.OTL![val].OT =
                                JsonConvert.DeserializeObject<ObservableCollection<OrderTable>>(jsonString);
                        }
                        else
                        {
                            // int a = 3;
                        }
                    }

                    archive.Dispose();

                    GD!.OrderList!.OTL![val]!.Zipped = false;
                    // GD.OrderList!.OTL![val].DG = null;
                    if (GD.OrderList.OTL![val].Point >= GD.OrderList.OTL![val].OT?.Count)
                    {
                        GD.OrderList.OTL![val].Point = GD.OrderList!.OTL![val]!.OT!.Count - 1;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("ReadZipOrderTable: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return false;
            }

        }

        public OrderList? ReadOrderTable()
        {
            try
            {

                OrderList? ol2 = new OrderList();
                string pathName = DeviceData._deviceData!.GetSavePath();


                // Die aktuelle OrderTable wird gesichert über den Indexerwert im Dateinamen
                string pathfileName = pathName + loca.OrderList_OrderList_16198;
                if (File.Exists(pathfileName))
                {
                    string pathDestName = pathName + loca.OrderList_OrderList_16199 +
                                          string.Format(loca.OrderList_OrderList_16200,
                                              GlobalSpecs.CurrentOrderList!.SetOrderListInfo!.jsonIndex);
                    File.Copy(pathfileName, pathDestName, true);
                }

                string pathFileNameZip = pathName + loca.OrderList_OrderList_16201 + loca.OrderList_OrderList_16202;
                if (File.Exists(pathFileNameZip))
                {
                    string pathDestNameZip = pathName + loca.OrderList_OrderList_16203 +
                                             string.Format(loca.OrderList_OrderList_16204,
                                                 GlobalSpecs.CurrentOrderList!.SetOrderListInfo!.jsonIndex!);
                    File.Copy(pathFileNameZip, pathDestNameZip, true);

                }

                // Und jetzt laden wir die OrderTable ein
                if (File.Exists(pathfileName))
                {

                    string jsonSource = File.ReadAllText(pathfileName);

                    // OrderList? ol2 = new OrderList(SaveOrderListExtern, ZipOrderListExtern, ReadZipOrderListExtern, ref _orderListInfo!, _gd, false);
                    ol2 = JsonConvert.DeserializeObject<OrderList>(jsonSource);


                    if (ol2 != null)
                    {
                        // ToDo: OrderList konnte eingelesen werden, jetzt wird sie noch initialisiert

                        GD!.OrderList!.OTL = ol2._otl;
                        GD!.OrderList!.CurrentOrderListIx = ol2.CurrentOrderListIx;
                        // this._gd = gd;
                        ol2.StripOrderList();
                    }
                    else
                    {
                        ol2!.AddOrderList(loca.OrderList_OrderList_16205, true);
                        ol2!.CurrentOrderListIx = ol2.OTL!.Count - 1;
                    }
                }
                else
                {
                    // ol2.AddOrderList(loca.OrderList_OrderList_16206, true);
                    // ol2.CurrentOrderListIx = ol2.OTL!.Count - 1;

                    // ToDo: OrderList-Intialisieren, wenn noch nichts gelesen werden konnte
                    ol2.AddOrderList(loca.OrderList_OrderList_16206, true);
                    GD!.OrderList!.OTL = ol2.OTL;
                    GD!.OrderList!.CurrentOrderListIx = GD!.OrderList!.OTL!.Count - 1;
                }

                if (ol2 != null)
                {
                    ol2.SetOrderListInfo = DataService._dataService!.ReadJsonIndex();
                    ol2.SetSaveOrderList = SaveOrderTable;
                    ol2.SetZipOrderList = ZipOrderTable;
                    ol2.SetReadZipOrderList = ReadZipOrderTable;
                }

                return ol2;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("ReadOrderTable: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }

        public bool DeleteFile(string fileName)
        {
            bool deleted = false;

            try
            {
                // Noloca: 003
                string pathName = DeviceData._deviceData!.GetSavePath();

                // Ignores: 002  
                string? pathFileName = pathName + "\\" + fileName;

                if (File.Exists(pathFileName) == true)
                {
                    File.Delete(pathFileName);
                    deleted = true;
                }
            }
            catch (Exception e)
            {
                GlobalData.AddLog("DeleteFile: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
            }


            return deleted;
        }



        public bool ZipOrderTable(int val)
        {
            try
            {
                string orderTableName = "/ordertable.zip";
                // Noloca: 003
                string? pathName = DeviceData._deviceData!.GetSavePath()!;
                string? pathfileName = pathName + orderTableName;


                string? jsonString =
                    JsonConvert.SerializeObject(GD!.OrderList!.OTL![val]!.OT!,
                        Newtonsoft.Json.Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            Formatting = Formatting.Indented
                        }
                    );

                // byte[] compressedBytes;

                var outStream = new MemoryStream();
                ZipArchive archive;

                if (File.Exists(pathfileName))
                {
                    archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);
                }
                else
                {
                    archive = new ZipArchive(outStream, ZipArchiveMode.Update, true);
                }


                // Noloca: 001
                string jsonName = GD.OrderList.OTL![val].Name + ".json";

                var fileInArchive = archive.GetEntry(jsonName);
                if (fileInArchive != null)
                {
                    fileInArchive.Delete();
                    fileInArchive = null;
                }

                if (fileInArchive == null)
                    fileInArchive = archive.CreateEntry(jsonName, CompressionLevel.Optimal);

                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
                // string s2 = Encoding.Unicode.GetString(jsonBytes);

                using (var entryStream = fileInArchive.Open())
                using (var fileToCompressStream = new MemoryStream(jsonBytes))
                {
                    fileToCompressStream.CopyTo(entryStream);
                }

                archive.Dispose();

                using (var fileStream = new FileStream(pathfileName, FileMode.OpenOrCreate))
                {
                    outStream.Position = 0;
                    outStream.WriteTo(fileStream);
                    outStream.Flush();
                }
                outStream.Close();
                outStream.Dispose();

                GD.OrderList.OTL![val].OT = null;
                GD.OrderList.OTL![val].Zipped = true;

                return true;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("ZipOrderTable: " + ex.Message, IGlobalData.protMode.crisp);
                return false;
            }
        }

        public bool DeleteZipOrderTableEntry(string name)
        {
            try
            {
                string? pathName = DeviceData._deviceData!.GetSavePath()!;
                string? pathfileName = pathName + "/ordertable.zip";

                var outStream = new MemoryStream();
                ZipArchive archive;

                if (File.Exists(pathfileName))
                {
                    archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);

                    // Ignores: 001
                    // Noloca: 001
                    string jsonName = name + ".json";

                    var fileInArchive = archive.GetEntry(jsonName);
                    if (fileInArchive != null)
                    {
                        fileInArchive.Delete();
                    }

                    archive.Dispose();

                    using (var fileStream = new FileStream(pathfileName, FileMode.OpenOrCreate))
                    {
                        outStream.Position = 0;
                        outStream.WriteTo(fileStream);
                        outStream.Flush();
                    }
                }
                outStream.Close();
                outStream.Dispose();
            }
            catch (Exception e)
            {
                GlobalData.AddLog("DeleteZipOrderTableEntry: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
            }

            return true;
        }

        public bool RenameZipOrderTableEntry(string oldName, string newName)
        {
            try
            {
                string pathName = DeviceData._deviceData!.GetSavePath();
                string? pathfileName = pathName + "/ordertable.zip";

                var outStream = new MemoryStream();
                ZipArchive archive;

                if (File.Exists(pathfileName))
                {
                    archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);

                    // Noloca: 002
                    // Ignores: 001
                    var fileInArchive = archive.GetEntry(oldName + ".json");
                    if (fileInArchive != null)
                    {
                        // Ignores: 001
                        var newEntry = archive.CreateEntry(newName + ".json");
                        using (var a = fileInArchive.Open())
                        using (var b = newEntry.Open())
                            a.CopyTo(b);
                        fileInArchive.Delete();

                    }

                    archive.Dispose();

                    using (var fileStream = new FileStream(pathfileName, FileMode.OpenOrCreate))
                    {
                        outStream.Position = 0;
                        outStream.WriteTo(fileStream);
                        outStream.Flush();
                    }
                }
                outStream.Close();
                outStream.Dispose();
            }
            catch (Exception e)
            {
                GlobalData.AddLog("RenameZipOrderTableEntry: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
            }

            return true;
        }



        public bool SaveOrderTable()
        {
            try
            {
                // Hier wird gespeichert. Später
                // Noloca: 003

                string? pathName = DeviceData._deviceData!.GetSavePath()!;
                string? pathfileName = pathName + "/ordertable.json";

                if (GD!.SilentMode == true) return false;

                int ix;
                bool fullWrite = false;

                // ToDo: Integration mit dem Spiel
                if (GD.Adventure != null)
                {
                    if (GD.Adventure!.A != null)
                    {
                        if (GD.Adventure!.A.Finish == true)
                        {
                            fullWrite = true;
                        }
                    }
                }

                if (fullWrite)
                {
                    for (ix = 0; ix < GD.OrderList!.OTL!.Count; ix++)
                    {
                        if (!GD.OrderList.OTL![ix].Zipped)
                        {
                            GD.OrderList.ZipOrderTable(ix);
                        }
                    }

                }
                // Es wird erst geschrieben, sobald die Initialisierung erfolgt ist
                else if (GD.OrderList != null)
                {
                    int startVal = 1;
                    int olIndex = GD.OrderList.CurrentViewOrderListIx;

                    /* ToDo: Wofür ist _actualGame gut? Das sieht so derartig fishy aus...
                    if (GD.OrderList._actualGame == false)
                    {
                        startVal = 0;
                    }
                    */
                    for (ix = startVal; ix < GD.OrderList.OTL!.Count; ix++)
                    {
                        if (!GD.OrderList.OTL![ix].Zipped && ix != GD.OrderList.CurrentOrderListIx && ix != olIndex)
                        {
                            GD.OrderList.ZipOrderTable(ix);
                        }
                    }
                }

                string jsonString =
                    JsonConvert.SerializeObject(GD.OrderList,
                        Newtonsoft.Json.Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            Formatting = Formatting.Indented
                        }
                    );
                File.WriteAllTextAsync(pathfileName, jsonString);
                // WriteToFileAsync(pathfileName, jsonString);

                return true;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("SaveOrderTable: " + ex.Message, IGlobalData.protMode.crisp);
                return false;
            }

        }

        /*
        public async Task WriteToFileAsync( string pathfilename, string jsonString )
        {
            using (var sw = new StreamWriter(pathfilename))
            {
                await sw.WriteAsync(jsonString);
            }

        }
        */
    }
}

