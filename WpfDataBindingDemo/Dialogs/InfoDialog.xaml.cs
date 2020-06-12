using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfDataBindingDemo.ViewModel;

namespace WpfDataBindingDemo.Dialogs {
  /// <summary>
  /// Interaction logic for InfoDialog.xaml
  /// </summary>
  public partial class InfoDialog: Window {
    CountryViewModel _viewModel = null;

    public CountryViewModel ViewModel { get => _viewModel; set => _viewModel = value; }

    public InfoDialog(CountryViewModel vm) {
      ViewModel = vm;
      InitializeComponent();
      DataContext = ViewModel;
      StrechModeCombo.ItemsSource= Enum.GetNames(typeof(Stretch));
    }

    private void OKButton_Click(object sender, RoutedEventArgs e) {
      DialogResult = true;
       

    }

    private void LoadImgButton_Click(object sender, RoutedEventArgs e) {
      OpenFileDialog dlg = new OpenFileDialog() {
        Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"
      };
      if (dlg.ShowDialog() == true) {
        ViewModel.SelectedImage = new BitmapImage(new Uri(dlg.FileName));
      }
    }
  }
}
