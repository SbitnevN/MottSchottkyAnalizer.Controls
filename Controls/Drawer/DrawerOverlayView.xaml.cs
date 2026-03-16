using MottSchottkyAnalizer.DI.Registration;
using System.Windows.Controls;

namespace MottSchottkyAnalizer.Controls.Controls.Drawer;
/// <summary>
/// Interaction logic for DrawerOverlay.xaml
/// </summary>
[View<DrawerOverlayView>]
public partial class DrawerOverlayView : Border
{
    public DrawerOverlayView()
    {
        InitializeComponent();
    }
}
