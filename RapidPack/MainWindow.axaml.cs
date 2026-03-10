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
    private string _expressOption;
    private string _serviceOption;
    
    

    private int _heightInt;
    private int _widthInt;
    private int _depthInt;
    private int _weightInt;
    
    
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
        int.TryParse(_heightStr.Text,out _heightInt);
        
        _widthStr = this.FindControl<TextBox>("WidthInputBox")!;
        int.TryParse(_widthStr.Text,out _widthInt);
        
        _depthStr = this.FindControl<TextBox>("DepthInputBox")!;
        int.TryParse(_depthStr.Text,out _depthInt);
        
        _weightStr = this.FindControl<TextBox>("WeightInputBox")!;
        int.TryParse(_weightStr.Text,out _weightInt);
        
        _expressOption = ExpressCheckBox.IsChecked == true ? "Checked" : "Unchecked";
        
        _serviceOption = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";

        
        
    }
    
    
    
    

    public void CalculatePriceButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            double finalPrice = 10;
            if (_serviceOption == "Paleta")
            {
                finalPrice = 100;
            }
            else
            {
                finalPrice += (2 * _weightInt);
                if (_serviceOption == "Ostrożnie (+10zł)")
                {
                    finalPrice += 10;
                }

                if (_expressOption == "Checked")
                {
                    finalPrice += 15;
                }

                if (_heightInt * _widthInt * _depthInt > 150)
                {
                    finalPrice *= 1.5;
                }
                
                
            }

            Size.Text = $"{_heightInt}x{_widthInt}x{_depthInt} cm";
            Weight.Text = $"{_weightInt}kg";
            if (_expressOption == "Checked")
            {
                Express.Text = "Express Jest wybrany";
            }
            else
            {
                Express.Text = "Express NIE jest wybrany";
            }
            ServiceType.Text = $"Rodzaj przesyłki to: {_serviceOption}";
            

            TotalPrice.Text = $"Końcowa cena wynosi: {finalPrice} zł";
            

            StackPanel1.IsVisible = false;
            StackPanel2.IsVisible = false;
            StackPanel2b.IsVisible = false;
            StackPanel3.IsVisible = false;
            StackPanel4.IsVisible = false;
            StackPanel5.IsVisible = true;
            StackPanel5.Background = Brushes.SeaGreen;
            StackPanel5.Width = 500;


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
        
        var heightConv = int.TryParse(_heightStr.Text,out _heightInt);
        var widthConv = int.TryParse(_widthStr.Text,out _widthInt);
        var depthConv = int.TryParse(_depthStr.Text,out _depthInt);
        var weightConv = int.TryParse(_weightStr.Text,out _weightInt);
        _expressOption = ExpressCheckBox.IsChecked == true ? "Checked" : "Unchecked";
        _serviceOption = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";
        
        if (!heightConv)
        {
            HeightInputBox.Background = Brushes.DarkRed;
            HeightInputBox.BorderBrush = Brushes.BlueViolet;
        }
        else
        {
            HeightInputBox.Background = Brushes.DarkSlateGray;
            HeightInputBox.BorderBrush = Brushes.Lavender;
        }
        if (!widthConv)
        {
            WidthInputBox.Background = Brushes.DarkRed;
            WidthInputBox.BorderBrush = Brushes.BlueViolet;
        }
        else
        {
            WidthInputBox.Background = Brushes.DarkSlateGray;
            WidthInputBox.BorderBrush = Brushes.Lavender;
        }
        if (!depthConv)
        {
            DepthInputBox.Background = Brushes.DarkRed;
            DepthInputBox.BorderBrush = Brushes.BlueViolet;
        }
        else
        {
            DepthInputBox.Background = Brushes.DarkSlateGray;
            DepthInputBox.BorderBrush = Brushes.Lavender;
        }
        if (!weightConv || _weightInt > 30)
        {
            WeightInputBox.Background = Brushes.DarkRed;
            WeightInputBox.BorderBrush = Brushes.BlueViolet;
        }
        else
        {
            WeightInputBox.Background = Brushes.DarkSlateGray;
            WeightInputBox.BorderBrush = Brushes.Lavender;
        }
        
        
        if (!heightConv || !widthConv || !depthConv || !weightConv)
        {
            CalculatePriceButton.IsEnabled = false;
            CheckingBox.IsVisible = true;
            CheckingBox.Background = Brushes.DarkRed;
            CheckingBox.Foreground = Brushes.White;
            CheckingBox.Text = "PROSZE WPROWADZIĆ POPRAWNE WARTOŚCI";
        }
        else if (_weightInt > 30)
        {
            CalculatePriceButton.IsEnabled = false;
            CheckingBox.IsVisible = true;
            CheckingBox.Background = Brushes.DarkRed;
            CheckingBox.Foreground = Brushes.White;
            CheckingBox.Text = "WAGA NIE MOŻE BYĆ WIĘKSZA OD 30KG";
            
        }
        else
        {
            CheckingBox.IsVisible = false;
            CalculatePriceButton.IsEnabled = true;
            CalculatePriceButton.Background = Brushes.Green;
            CalculatePriceButton.Content = "WYCEŃ";
        }
        
        
        
        
    }
}