using MottSchottkyAnalizer.Core.ViewModel;
using MottSchottkyAnalizer.DI.Registration;

namespace MottSchottkyAnalizer.Controls.Controls.Drawer;

[ViewModel<DrawerOverlayViewModel>]
public class DrawerOverlayViewModel : ViewModelBase
{
    public event Action? OverlayClosed;

    public bool IsOverlayOpen
    {
        get => field;
        set => Set(ref field, value);
    }

    public IRelayCommand CloseOverlay { get; }

    public DrawerOverlayViewModel()
    {
        CloseOverlay = new RelayCommand(OnCloseOverlay);
    }

    private void OnCloseOverlay()
    {
        IsOverlayOpen = false;
        OverlayClosed?.Invoke();
    }
}
