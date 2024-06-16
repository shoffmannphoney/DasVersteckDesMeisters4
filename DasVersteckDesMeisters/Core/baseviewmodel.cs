using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Phoney_MAUI.Core;
public abstract class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    private string _title = string.Empty;
    public event PropertyChangedEventHandler? PropertyChanged;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
    public virtual Task Initialize()
    {
        return Task.FromResult(default(object));
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? PropertyName = null, Action? onChanged = null)
    {
        try
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(PropertyName);
            return true;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("SetProperty: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
            return false;
        }

    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
    {
        try
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        catch (Exception e)
        {
            GlobalData.AddLog("BaseViewModel.OnPropertyChanged: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
        }
    }
}
