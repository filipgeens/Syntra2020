using Syntra.Data.Models;
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
  /// Interaction logic for CountryEditDlg.xaml
  /// </summary>
  public partial class CountryEditDlg : Window {

    public CountryViewModel ViewModel { get; }
    public WpfCountry Current { get; set; }
    public CountryEditDlg(CountryViewModel vm) {
      ViewModel = vm;
      Current = new WpfCountry(vm.CurrentCountry);
      InitializeComponent();
      DataContext = Current;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) {
      DialogResult = false;
    }

    private void OkButton_Click(object sender, RoutedEventArgs e) {
      ViewModel.CurrentCountry.Name = Current.Name;
      ViewModel.CurrentCountry.Population = Current.Population;
      ViewModel.CurrentCountry.Capital = Current.Capital;
      ViewModel.CurrentCountry.IsoCode = Current.IsoCode;
      ViewModel.UpdateGui();
      DialogResult = true;
    }
  }
}
