using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoney_MAUI.Game.General;
using GameCore;

namespace Phoney_MAUI.Model;
public interface IDataService
{
    public void InitGameDirectory();
    public bool WriteJsonIndex(OrderListInfo oli);
    public OrderListInfo ReadJsonIndex();
    public bool ReadZipOrderTable(int val, string name);
    public OrderList? ReadOrderTable();
    public bool SaveOrderTable();
    public bool ZipOrderTable(int val);
}
