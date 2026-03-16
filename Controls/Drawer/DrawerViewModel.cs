using MottSchottkyAnalizer.Core.ViewModel;
using MottSchottkyAnalizer.DI.Registration;
using System.Windows;

namespace MottSchottkyAnalizer.Controls.Controls.Drawer;

[ViewModel<DrawerViewModel>]
public class DrawerViewModel : ViewModelBase
{
    private DrawerOverlayViewModel? _drawerOverlay;

    public bool IsDrawerOpen
    {
        get => field;
        set => Set(ref field, value);
    }

    public double DrawerOffset
    {
        get => field;
        set => Set(ref field, value);
    }

    public IRelayCommand OpenDrawer { get; }
    public IRelayCommand CloseDrawer { get; }

    public DrawerViewModel()
    {
        OpenDrawer = new RelayCommand(OnOpenDrawer);
        CloseDrawer = new RelayCommand(OnCloseDrawer);
    }

    public void SetDrawerOverlay(DrawerOverlayViewModel drawerOverlay)
    {
        _drawerOverlay = drawerOverlay;
        _drawerOverlay.OverlayClosed += OnCloseDrawer;
    }

    public void OnOpenDrawer()
    {
        IsDrawerOpen = true;
        _drawerOverlay?.IsOverlayOpen = true;
    }

    public void OnCloseDrawer()
    {
        IsDrawerOpen = false;
    }

    private void UpdateDrawerOffset(double width, HorizontalAlignment alignment)
    {
        DrawerOffset = alignment == HorizontalAlignment.Right ? width : -width;
    }
}
