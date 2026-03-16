using Microsoft.Xaml.Behaviors;
using MottSchottkyAnalizer.Core.ViewModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MottSchottkyAnalizer.Controls.Controls.Drawer;

public sealed class DrawerAnimationBehavior : Behavior<FrameworkElement>
{
    public static readonly DependencyProperty IsOpenProperty = DependencyHelper<DrawerAnimationBehavior>.Register(x => x.IsOpen, new PropertyMetadata(false));

    public static readonly DependencyProperty DurationProperty = DependencyHelper<DrawerAnimationBehavior>.Register(x => x.Duration, new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(250))));

    public static readonly DependencyProperty PlacementProperty = DependencyHelper<DrawerAnimationBehavior>.Register(x => x.Placement, new PropertyMetadata(HorizontalAlignment.Right));

    public static readonly DependencyProperty ClosedOffsetProperty = DependencyHelper<DrawerAnimationBehavior>.Register(x => x.ClosedOffset, new PropertyMetadata(double.NaN));

    public bool IsOpen
    {
        get => (bool)GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    public Duration Duration
    {
        get => (Duration)GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public HorizontalAlignment Placement
    {
        get => (HorizontalAlignment)GetValue(PlacementProperty);
        set => SetValue(PlacementProperty, value);
    }

    public double ClosedOffset
    {
        get => (double)GetValue(ClosedOffsetProperty);
        set => SetValue(ClosedOffsetProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        EnsureTranslateTransform();

        AssociatedObject.Loaded += AssociatedObject_Loaded;
        AssociatedObject.SizeChanged += AssociatedObject_SizeChanged;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Loaded -= AssociatedObject_Loaded;
        AssociatedObject.SizeChanged -= AssociatedObject_SizeChanged;

        base.OnDetaching();
    }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.Property == IsOpenProperty)
        {
            UpdatePosition(true);
            return;
        }

        if (e.Property == ClosedOffsetProperty || e.Property == PlacementProperty)
        {
            if (!IsOpen)
            {
                UpdatePosition(false);
            }
        }
    }

    private void AssociatedObject_Loaded(object? sender, RoutedEventArgs e)
    {
        UpdatePosition(false);
    }

    private void AssociatedObject_SizeChanged(object? sender, SizeChangedEventArgs e)
    {
        if (!IsOpen)
        {
            UpdatePosition(false);
        }
    }

    private void UpdatePosition(bool animated)
    {
        if (AssociatedObject == null)
        {
            return;
        }

        TranslateTransform translateTransform = EnsureTranslateTransform();
        double targetX = IsOpen ? 0.0 : GetClosedOffset();

        if (!animated)
        {
            translateTransform.BeginAnimation(TranslateTransform.XProperty, null);
            translateTransform.X = targetX;
            return;
        }

        DoubleAnimation animation = new DoubleAnimation
        {
            To = targetX,
            Duration = Duration,
            AccelerationRatio = 0.2,
            DecelerationRatio = 0.8,
            FillBehavior = FillBehavior.HoldEnd
        };

        translateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
    }

    private TranslateTransform EnsureTranslateTransform()
    {
        if (AssociatedObject.RenderTransform is TranslateTransform translateTransform)
        {
            return translateTransform;
        }

        if (AssociatedObject.RenderTransform is TransformGroup transformGroup)
        {
            int index = 0;
            while (index < transformGroup.Children.Count)
            {
                if (transformGroup.Children[index] is TranslateTransform existingTranslateTransform)
                {
                    return existingTranslateTransform;
                }

                index++;
            }

            TranslateTransform newTranslateTransform = new TranslateTransform();
            transformGroup.Children.Add(newTranslateTransform);
            return newTranslateTransform;
        }

        if (AssociatedObject.RenderTransform == null || AssociatedObject.RenderTransform == Transform.Identity)
        {
            TranslateTransform newTranslateTransform = new TranslateTransform();
            AssociatedObject.RenderTransform = newTranslateTransform;
            return newTranslateTransform;
        }

        Transform existingTransform = AssociatedObject.RenderTransform;
        TransformGroup transformGroupWrapper = new TransformGroup();
        transformGroupWrapper.Children.Add(existingTransform);

        TranslateTransform appendedTranslateTransform = new TranslateTransform();
        transformGroupWrapper.Children.Add(appendedTranslateTransform);

        AssociatedObject.RenderTransform = transformGroupWrapper;
        return appendedTranslateTransform;
    }

    private double GetClosedOffset()
    {
        if (!double.IsNaN(ClosedOffset))
        {
            return ClosedOffset;
        }

        double width = AssociatedObject.ActualWidth;

        return Placement == HorizontalAlignment.Right
            ? width
            : -width;
    }
}
