using ExceptionPerf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WpfApp1 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow :Window {
		const string FailMessage = "Int parse is mislukt";
		public ExceptionTestViewModel ViewModel { get; set; } = new ExceptionTestViewModel();
		public MainWindow() {
			InitializeComponent();
			DataContext = ViewModel;
			ViewModel.UiDispatcher = this.Dispatcher;
		}

		private void StartBt_Click(object sender, RoutedEventArgs e) {
			Start();
		}

		private void Start() {
			ViewModel.TryParseResult.Clear();
			ViewModel.ParseResult.Clear();
			ViewModel.TryParsePerformance = ViewModel.UseTryParse ? "" : ViewModel.TryParsePerformance;
			ViewModel.ParsePerformance = ViewModel.UseParse ? "" : ViewModel.ParsePerformance;
			ViewModel.Update();
			if (ViewModel.UseParse) {
				Task.Run(() => { NumberFromText(false); });
			}
			if (ViewModel.UseTryParse) {
				Task.Run(() => { NumberFromText(true); });
			}
		}

		private void NumberFromText(bool useTry) {
			Stopwatch watch = new Stopwatch();
			watch.Start();
			string result;
			for (int i = 0;i < ViewModel.Repeat;i++) {
				if (useTry) {
					if (int.TryParse(ViewModel.NumberValue, out int num)) {
						result = num.ToString();
					} else result = FailMessage;
				} else {
					try {
						result = int.Parse(ViewModel.NumberValue).ToString();
					} catch (Exception ex) { result = FailMessage; }
				}
				ViewModel.SetResult(result, useTry);
			}
			watch.Stop();
			ViewModel.SetPerformance(watch.ElapsedMilliseconds, useTry);
		}
		private void RepeatValue_PreviewTextInput(object sender, TextCompositionEventArgs e) {
			e.Handled = !int.TryParse(e.Text, out int val);
		}
	}
}
