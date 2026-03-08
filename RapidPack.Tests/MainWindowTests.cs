using Avalonia.Controls;
using Avalonia.Headless.XUnit;


namespace RapidPack.Tests;

public class MainWindowTests
{
   [AvaloniaFact]
   public void CreateWindow_ShouldCreateANewWindow()
   {
      var window = new MainWindow();
      Assert.NotNull(window);
   }

   [AvaloniaFact]
   public void WeightInt_CannotGoOver30KG()
   {
      var window = new MainWindow();
      
      var height = window.FindControl<TextBox>("HeightInputBox");
      var width = window.FindControl<TextBox>("WidthInputBox");
      var depth = window.FindControl<TextBox>("DepthInputBox");
      var weight = window.FindControl<TextBox>("WeightInputBox");
      var button = window.FindControl<Button>("CalculatePriceButton");
      
      height.Text = "10";
      width.Text = "10";
      depth.Text = "10";
      weight.Text = "31";
      
      window.FormChange(null, null);
      
      Assert.False(button.IsEnabled);
      
   }

   [AvaloniaFact]
   public void InputBox_HigherPriceIfOver150()
   {
      var window = new MainWindow();
      var height = window.FindControl<TextBox>("HeightInputBox");
      var width = window.FindControl<TextBox>("WidthInputBox");
      var depth = window.FindControl<TextBox>("DepthInputBox");
      var weight = window.FindControl<TextBox>("WeightInputBox");
      var totalPrice = window.FindControl<TextBlock>("TotalPrice");
      
      height.Text = "50";
      width.Text = "50";
      depth.Text = "60";
      weight.Text = "10";

      window.FormChange(null, null);
      window.CalculatePriceButton_Click(null, null);
      
      Assert.Contains("45", totalPrice.Text);

      
   }
   
   
   [AvaloniaFact]
   public void ServiceComboBox_PalleteMakesThePrice100()
   {
      var window = new MainWindow();
      var height = window.FindControl<TextBox>("HeightInputBox");
      var width = window.FindControl<TextBox>("WidthInputBox");
      var depth = window.FindControl<TextBox>("DepthInputBox");
      var weight = window.FindControl<TextBox>("WeightInputBox");
      var serviceComboBox = window.FindControl<ComboBox>("ServiceComboBox");
      var totalPrice = window.FindControl<TextBlock>("TotalPrice");
      
      height.Text = "50";
      width.Text = "50";
      depth.Text = "60";
      weight.Text = "20";
      serviceComboBox.SelectedIndex = 2;

      window.FormChange(null, null);
      window.CalculatePriceButton_Click(null, null);
      
      Assert.Contains("100", totalPrice.Text);

      
   }
   
   
   [AvaloniaFact]
   public void ExpressCheckBox_Adds15()
   {
      var window = new MainWindow();
      var height = window.FindControl<TextBox>("HeightInputBox");
      var width = window.FindControl<TextBox>("WidthInputBox");
      var depth = window.FindControl<TextBox>("DepthInputBox");
      var weight = window.FindControl<TextBox>("WeightInputBox");
      var express = window.FindControl<CheckBox>("ExpressCheckBox");
      var totalPrice = window.FindControl<TextBlock>("TotalPrice");
      
      height.Text = "10";
      width.Text = "10";
      depth.Text = "1";
      weight.Text = "10";
      express.IsChecked = true;

      window.FormChange(null, null);
      window.CalculatePriceButton_Click(null, null);
      
      Assert.Contains("45", totalPrice.Text);

      
   }
}