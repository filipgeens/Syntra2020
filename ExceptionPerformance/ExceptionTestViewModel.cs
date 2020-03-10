using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Threading;

namespace ExceptionPerf {
	public class ExceptionTestViewModel :INotifyPropertyChanged {



		public event PropertyChangedEventHandler PropertyChanged;
		public Dispatcher UiDispatcher { get; set; } = null;
		public string NumberValue { get; set; } = null;
		public int Repeat { get; set; } = 1000;
		public ObservableCollection<string> ParseResult { get; set; } = new ObservableCollection<string>();
		public ObservableCollection<string> TryParseResult { get; set; } = new ObservableCollection<string>();
		public bool UseParse { get; set; } = true;
		public bool UseTryParse { get; set; } = true;
		public string ParsePerformance { get; set; }
		public string TryParsePerformance { get; set; }

		public bool SetResult(string res, bool isTryParse) => isTryParse ? SetTryParseResult(res) : SetParseResult(res);
		public bool SetParseResult(string res) { UiDispatcher?.Invoke(() => { ParseResult.Add(res); }); return true; }
		public bool SetTryParseResult(string res) { UiDispatcher?.Invoke(() => { TryParseResult.Add(res);  }); return true; }

		internal void Update() {
			OnPropertyRaised("");
		}

		public void SetPerformance(long res, bool isTryParse) {
			string val = res > 5000 ? $"{(int)TimeSpan.FromMilliseconds(res).TotalSeconds} Sec" : $"{res} Ms";
			if (isTryParse) { UiDispatcher?.Invoke(() => { TryParsePerformance = val; OnPropertyRaised("TryParsePerformance"); }); } else { UiDispatcher?.Invoke(() => { ParsePerformance = val; OnPropertyRaised("ParsePerformance"); }); }
		}
		private void OnPropertyRaised(string propertyname) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
	}
}
