using Avalonia;
using Avalonia.Controls;

namespace PhoneBook.Desktop.Components;

public partial class InputComponent : UserControl
{
    public static readonly StyledProperty<object?> LabelContentProperty = 
        AvaloniaProperty.Register<InputComponent, object?>(nameof(LabelContent));
    public static readonly StyledProperty<string?> InputTextProperty = 
        AvaloniaProperty.Register<InputComponent, string?>(nameof(InputText));
    public static readonly StyledProperty<string?> WatermarkTextProperty =
        AvaloniaProperty.Register<InputComponent, string?>(nameof(WatermarkText));
    public static readonly StyledProperty<bool> UseFloatingWatermarkProperty =
        AvaloniaProperty.Register<InputComponent, bool>(nameof(UseFloatingWatermark), defaultValue: false);
    public static readonly StyledProperty<bool> IsReadOnlyProperty =
        AvaloniaProperty.Register<InputComponent, bool>(nameof(IsReadOnly), defaultValue: false);

    public object? LabelContent
    {
        get => GetValue(LabelContentProperty); 
        set => SetValue(LabelContentProperty, value);
    }

    public string? InputText
    {
        get => GetValue(InputTextProperty);
        set => SetValue(InputTextProperty, value);
    }

    public string? WatermarkText
    {
        get => GetValue(WatermarkTextProperty); 
        set => SetValue(WatermarkTextProperty, value);
    }

    public bool UseFloatingWatermark
    {
        get => GetValue(UseFloatingWatermarkProperty);
        set => SetValue(UseFloatingWatermarkProperty, value);
    }

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }
    
    public InputComponent()
    {
        InitializeComponent();
    }
}