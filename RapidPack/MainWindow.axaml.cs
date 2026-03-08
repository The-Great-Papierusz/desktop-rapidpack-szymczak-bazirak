using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RapidPack;

public partial class MainWindow : Window
{
    public TextBox HeightStr;
    public TextBox WidthStr;
    public TextBox DepthStr;
    public TextBox WeightStr;
    public string ExpressOption;
    public string ServiceOption;
    
    public MainWindow()
    {
        InitializeComponent();
        CalculatePriceButton.Click += CalculatePriceButton_Click;
        
        HeightStr = this.FindControl<TextBox>("HeightInputBox");
        var HeightConv = int.TryParse(HeightStr.Text,out int HeightInt);
        
        WidthStr = this.FindControl<TextBox>("WidthInputBox");
        var WidthConv = int.TryParse(WidthStr.Text,out int WidthInt);
        
        DepthStr = this.FindControl<TextBox>("DepthInputBox");
        var DepthConv = int.TryParse(DepthStr.Text,out int DepthInt);
        
        WeightStr = this.FindControl<TextBox>("WeightInputBox");
        var WeightConv = int.TryParse(WeightStr.Text,out int WeightInt);
        
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
}