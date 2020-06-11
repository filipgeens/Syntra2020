using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDataBindingDemo.Dialogs;
using WpfDataBindingDemo.ViewModel;

namespace WpfDataBindingDemo {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow :Window {
		CountryViewModel _viewModel = null;

		public CountryViewModel ViewModel { get { _viewModel ??= new CountryViewModel(); return _viewModel; } set => _viewModel = value; }

		public MainWindow() {
			InitializeComponent();
			DataContext = ViewModel;
		}
    protected override void OnClosing(CancelEventArgs e) {
			ViewModel?.Repository?.SaveData();
      base.OnClosing(e);
    }
    private void FontSizeEdit_PreviewTextInput(object sender, TextCompositionEventArgs e) {
			e.Handled = !IsNumber(e.Text);
		}
		public bool IsNumber(string txt) => int.TryParse(txt, out int i);

		private void ImportButton_Click(object sender, RoutedEventArgs e) {
			OpenFileDialog openDlg = new OpenFileDialog() {
				Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"
			};
			if (openDlg.ShowDialog()==true) {
				ViewModel.ImportFromFile(openDlg.FileName);
			}
		}

		private void ExportButton_Click(object sender, RoutedEventArgs e) {
			SaveFileDialog saveDlg = new SaveFileDialog() {
				Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"
			};
			if (saveDlg.ShowDialog() == true) {
				ViewModel.ExportToFile(saveDlg.FileName);
			}
		}

    private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e) {
			if (e.ClickCount > 3) {
			}
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e) {
			ViewModel.FilterResult();
    }

    private void InfoButton_Click(object sender, RoutedEventArgs e) {
			InfoDialog dlg = new InfoDialog(ViewModel) { Owner = this };
			if (dlg.ShowDialog() == true) { }
    }

    private void StandardDataButton_Click(object sender, RoutedEventArgs e) {
			ViewModel.FillWithInitialData();
		}

  
  }
}
