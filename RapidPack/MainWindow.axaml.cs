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
        int HeightInt = int.Parse(HeightStr.Text);
        
        WidthStr = this.FindControl<TextBox>("WidthInputBox");
        int WidthInt = int.Parse(WidthStr.Text);
        
        DepthStr = this.FindControl<TextBox>("DepthInputBox");
        int DepthInt = int.Parse(DepthStr.Text);
        
        WeightStr = this.FindControl<TextBox>("WeightInputBox");
        int WeightInt = int.Parse(WeightStr.Text);
        
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