using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace RapidPack;

public partial class MainWindow : Window
{
    private readonly TextBox _heightStr;
    private readonly TextBox _widthStr;
    private readonly TextBox _depthStr;
    private readonly TextBox _weightStr;
    public string ExpressOption;
    public string ServiceOption;
    
    

    public int HeightInt;
    public int WidthInt;
    public int DepthInt;
    public int WeightInt;
    
    
    public MainWindow()
    {
        InitializeComponent();
        CalculatePriceButton.IsEnabled = false;
        HeightInputBox.TextChanged += FormChange;
        WidthInputBox.TextChanged += FormChange;
        DepthInputBox.TextChanged += FormChange;
        WeightInputBox.TextChanged += FormChange;
        ExpressCheckBox.IsCheckedChanged += FormChange;
        ServiceComboBox.SelectionChanged += FormChange;
        
        
        
        CalculatePriceButton.Click += CalculatePriceButton_Click;
        
        
        
        _heightStr = this.FindControl<TextBox>("HeightInputBox")!;
        var heightConv = int.TryParse(_heightStr.Text,out HeightInt);
        
        _widthStr = this.FindControl<TextBox>("WidthInputBox")!;
        var widthConv = int.TryParse(_widthStr.Text,out WidthInt);
        
        _depthStr = this.FindControl<TextBox>("DepthInputBox")!;
        var depthConv = int.TryParse(_depthStr.Text,out DepthInt);
        
        _weightStr = this.FindControl<TextBox>("WeightInputBox")!;
        var weightConv = int.TryParse(_weightStr.Text,out WeightInt);
        
        ExpressOption = ExpressCheckBox.IsChecked == true ? "Checked" : "Unchecked";
        
        ServiceOption = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";

        
        
    }
    
    
    
    

    public void CalculatePriceButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            double finalPrice = 10;
            if (ServiceOption == "Paleta")
            {
                finalPrice = 100;
            }
            else
            {
                finalPrice += (2 * WeightInt);
                if (ServiceOption == "Ostrożnie (+10zł)")
                {
                    finalPrice += 10;
                }

                if (ExpressOption == "Checked")
                {
                    finalPrice += 15;
                }

                if (HeightInt * WidthInt * DepthInt > 150)
                {
                    finalPrice *= 1.5;
                }
                
                
            }

            Size.Text = $"{HeightInt}x{WidthInt}x{DepthInt} cm";
            Weight.Text = $"{WeightInt}kg";
            if (ExpressOption == "Checked")
            {
                Express.Text = "Express Jest wybrany";
            }
            else
            {
                Express.Text = "Express NIE jest wybrany";
            }
            ServiceType.Text = $"Rodzaj przesyłki to: {ServiceOption}";
            

            TotalPrice.Text = $"Końcowa cena wynosi: {finalPrice} zł";
            

            StackPanel1.IsVisible = false;
            StackPanel2.IsVisible = false;
            StackPanel3.IsVisible = false;
            StackPanel4.IsVisible = false;
            StackPanel5.IsVisible = true;


        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
            throw;
        }
    }
    
    

    public void FormChange(object? sender, RoutedEventArgs e)
    {
        CalculatePriceButton.Background = Brushes.Green;
        
        var heightConv = int.TryParse(_heightStr.Text,out HeightInt);
        var widthConv = int.TryParse(_widthStr.Text,out WidthInt);
        var depthConv = int.TryParse(_depthStr.Text,out DepthInt);
        var weightConv = int.TryParse(_weightStr.Text,out WeightInt);
        ExpressOption = ExpressCheckBox.IsChecked == true ? "Checked" : "Unchecked";
        ServiceOption = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";
        
        
        
        if (WeightInt > 30 || !weightConv)
        {
            CalculatePriceButton.IsEnabled = false;
            CalculatePriceButton.Background = Brushes.DarkRed;
            CalculatePriceButton.Content = "WAGA NIE MOŻE BYĆ WIĘKSZA OD 30KG";
            
        }
        else if (!heightConv || !widthConv || !depthConv || !weightConv)
        {
            CalculatePriceButton.IsEnabled = false;
            
            CalculatePriceButton.Content = "PROSZE WPROWADZIĆ POPRAWNE WARTOŚCI";
        }
        else
        {
            CalculatePriceButton.IsEnabled = true;
            CalculatePriceButton.Background = Brushes.Green;
            CalculatePriceButton.Content = "WYCEŃ";
        }

        
        
    }
}