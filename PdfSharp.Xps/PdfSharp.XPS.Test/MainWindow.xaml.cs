using System.Diagnostics;
using System.Windows;

namespace PdfSharp.Xps.Test
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      var target = @"d:\temp\1.pdf";
      PdfSharp.Xps.XpsConverter.Convert(@"d:\temp\3.xps", target, 0, false);
      Process.Start(target);
    }
  }
}
