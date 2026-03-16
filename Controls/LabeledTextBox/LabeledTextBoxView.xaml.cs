using MottSchottkyAnalizer.Core.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MottSchottkyAnalizer.Controls.Controls.LabeledTextBox;

/// <summary>
/// Interaction logic for LabeledTextBoxView.xaml
/// </summary>
public partial class LabeledTextBoxView : TextBox
{
    public static readonly DependencyProperty LabelProperty = DependencyHelper<LabeledTextBoxView>.Register(x => x.Label);

    public static readonly DependencyProperty LabelFontSizeProperty = DependencyHelper<LabeledTextBoxView>.Register(x => x.LabelFontSize);

    public static readonly DependencyProperty LabelMarginProperty = DependencyHelper<LabeledTextBoxView>.Register(x => x.LabelMargin);

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public double LabelFontSize
    {
        get => (double)GetValue(LabelFontSizeProperty);
        set => SetValue(LabelFontSizeProperty, value);
    }

    public Thickness LabelMargin
    {
        get => (Thickness)GetValue(LabelMarginProperty);
        set => SetValue(LabelMarginProperty, value);
    }

    public LabeledTextBoxView()
    {
        InitializeComponent();
    }
}
