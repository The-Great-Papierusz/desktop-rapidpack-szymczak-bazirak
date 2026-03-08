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
        
        HeightStr = this.FindControl<TextBox>("HeightInputBox");
        var HeightConv = int.TryParse(HeightStr.Text,out HeightInt);
        
        WidthStr = this.FindControl<TextBox>("WidthInputBox");
        var WidthConv = int.TryParse(WidthStr.Text,out WidthInt);
        
        DepthStr = this.FindControl<TextBox>("DepthInputBox");
        var DepthConv = int.TryParse(DepthStr.Text,out DepthInt);
        
        WeightStr = this.FindControl<TextBox>("WeightInputBox");
        var WeightConv = int.TryParse(WeightStr.Text,out WeightInt);
        
        ExpressOption = ExpressCheckBox.IsChecked == true ? "Checked" : "Unchecked";
        
        ServiceOption = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";

        
        
    }

    private void CalculatePriceButton_Click(object sender, RoutedEventArgs e)
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

    private void FormChange(object sender, RoutedEventArgs e)
    {
        var HeightConv = int.TryParse(HeightStr.Text,out HeightInt);
        var WidthConv = int.TryParse(WidthStr.Text,out WidthInt);
        var DepthConv = int.TryParse(DepthStr.Text,out DepthInt);
        var WeightConv = int.TryParse(WeightStr.Text,out WeightInt);
        
    }
}