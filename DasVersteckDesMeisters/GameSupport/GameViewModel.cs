using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Phoney_MAUI.Viewmodel;
using Phoney_MAUI.Core;
using Phoney_MAUI.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Phoney_MAUI.Game.General;
public class GameViewModel : BaseViewModel
{
    private string? _message;
    private DelVoid? _sendcallback;

    private readonly IDataService? _dataService;
    private readonly INavigationService? _navigationService;
    public string? Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged( );
        }
    } 
    public string Name
    {
        get;
        set;
    } = "Me llamo";

    public ICommand? UpdateMessageCommand { get; set; }

    public GameViewModel()
    {
        UpdateMessageCommand = new Command(UpdateMessage, CanUpdateMessage);
        _sendcallback = null;
    }
    public void SetSendCallback( DelVoid DoSendCallback)
    {
        _sendcallback = DoSendCallback;
    }

    public GameViewModel(IDataService dataService,
                         INavigationService navigationService)
    {
        _dataService = dataService;
        _navigationService = navigationService;
        // LoadDataCommand = new Command(async () => await LoadDataAsync());
        // NavigateToDishCommand = new Command<Dish>(NavigateToDish);

        Message = "Hooray";
    }

    private async Task LoadDataAsync()
    {
        await Task.Delay(1);
    }

    public ICommand? LoadDataCommand { get; }

    private void UpdateMessage()
    {
        try
        {
            if (_sendcallback != null)
                _sendcallback();
        }
        catch (Exception e)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("UpdateMessage: " + e.Message, IGlobalData.protMode.crisp);

            // int a;
        }
    }
    private bool CanUpdateMessage()
    {
        return !string.IsNullOrEmpty(Name);
    }

    public override async Task Initialize()
    {
        try
        {
            await LoadDataAsync();
            await base.Initialize();
        }
        catch (Exception e)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("GameViewModel.Initialize: " + e.Message, IGlobalData.protMode.crisp);

            // int a;
        }

    }
    public void ChangeOrientation(IGlobalData.screenMode sm)
    {
        if (sm == IGlobalData.screenMode.portrait)
            Message = "Kellerloser Fensterraum";
        // Message = "Fensterloser Kellerraum";
         else if (sm == IGlobalData.screenMode.landscape)
            Message = "Fensterloser Kellerraum";
    }
}




