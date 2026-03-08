using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace RapidPack;

public partial class MainWindow : Window
{
    public TextBox HeightStr;
    public TextBox WidthStr;
    public TextBox DepthStr;
    public TextBox WeightStr;
    public string ExpressOption;
    public string ServiceOption;

    public int HeightInt;
    public int WidthInt;
    public int DepthInt;
    public int WeightInt;
    public MainWindow()
    {
        InitializeComponent();
        HeightInputBox.TextChanged += FormChange;
        WidthInputBox.TextChanged += FormChange;
        DepthInputBox.TextChanged += FormChange;
        WeightInputBox.TextChanged += FormChange;
        
        CalculatePriceButton.Click += CalculatePriceButton_Click;
        
        HeightStr = this.FindControl<TextBox>("HeightInputBox")!;
        var heightConv = int.TryParse(HeightStr.Text,out HeightInt);
        
        WidthStr = this.FindControl<TextBox>("WidthInputBox")!;
        var widthConv = int.TryParse(WidthStr.Text,out WidthInt);
        
        DepthStr = this.FindControl<TextBox>("DepthInputBox")!;
        var depthConv = int.TryParse(DepthStr.Text,out DepthInt);
        
        WeightStr = this.FindControl<TextBox>("WeightInputBox")!;
        var weightConv = int.TryParse(WeightStr.Text,out WeightInt);
        
        ExpressOption = ExpressCheckBox.IsChecked == true ? "Checked" : "Unchecked";
        
        ServiceOption = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";

        
        
    }

    private void CalculatePriceButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
            throw;
        }
    }

    private void FormChange(object? sender, TextChangedEventArgs textChangedEventArgs)
    {
        var heightConv = int.TryParse(HeightStr.Text,out HeightInt);
        var widthConv = int.TryParse(WidthStr.Text,out WidthInt);
        var depthConv = int.TryParse(DepthStr.Text,out DepthInt);
        var weightConv = int.TryParse(WeightStr.Text,out WeightInt);
        if (WeightInt > 30 || !weightConv)
        {
            CalculatePriceButton.IsEnabled = false;
            CalculatePriceButton.Background = Brushes.DarkRed;
            CalculatePriceButton.Content = "WAGA NIE MOŻE BYĆ WIĘKSZA OD 30KG";
            
        }
        else
        {
            CalculatePriceButton.IsEnabled = true;
            CalculatePriceButton.Background = Brushes.Green;
            CalculatePriceButton.Content = "WYCEŃ";
        }

        if (!heightConv || !widthConv || !depthConv)
        {
            CalculatePriceButton.IsEnabled = false;
            CalculatePriceButton.Content = "PROSZE WPROWADZIĆ POPRAWNĄ WARTOŚĆ";
        }
        else
        {
            CalculatePriceButton.IsEnabled = true;
        }
    }
}