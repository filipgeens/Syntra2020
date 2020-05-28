using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using WpfDataBindingDemo.Models;
using System.Linq;
using System.IO;

namespace WpfDataBindingDemo.ViewModel {
	public class CountryViewModel :INotifyPropertyChanged {
		#region Info
		/// Class : CountryViewModel
		/// ViewModel is de tussenschakel tussen de data en de grafische user interface (GUI).
		/// Door de PropertyChangedEventhandler kan de ViewModel de GUI verwittigen als er een verandering is 
		/// Door gebruik te maken van ObservableCollection list kunnen we de list objecten in de GUI up to date houen
		#endregion Info
		#region Definitions 
		#endregion Definitions
		#region Fields
		public event PropertyChangedEventHandler PropertyChanged;

		CountryRepository _repo = null;
		ObservableCollection<Country> _countries = null;
		Country _currentCountry = null;
		#endregion Fields
		#region Constructors
		#endregion Constructors
		#region Properties
		public CountryRepository Repository { get { _repo ??= new CountryRepository(); return _repo; } set => _repo = value; }
		public ObservableCollection<Country> Countries {
			get {
				_countries ??= new ObservableCollection<Country>(Repository.Members); return _countries;
			}
			set => Repository.Members = value.ToList();
		}
		public Country CurrentCountry { get => _currentCountry; set { _currentCountry = value; RaisePropertyChanged("CurrentCountry"); } }
		#endregion Properties
		#region Methods
		public void ResetCountryList() {
			Countries.Clear();
			foreach (var country in Repository.Members) { Countries.Add(country); }		
		}
		public bool UpdateCountryList() {
			if (Countries?.Count > 0) {
				Repository.Members = new List<Country>(Countries);
				return true;
			}
			return false;
		}
		protected void RaisePropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		public  bool Import(string json) {
			var ok=Repository.Import(json);
			ResetCountryList();
			return ok;
		}
		public string Export() {
			UpdateCountryList();
			return Repository?.Export();
		}
		public bool ImportFromFile(string path) {
			if (File.Exists(path)) {
				return Import(File.ReadAllText(path))==true;
			}
			return false;
		}
		public bool ExportToFile(string path) {
			try {
				File.WriteAllText(path, Export());
				return File.Exists(path);
			} catch { }
			return false;
		}
		#endregion Methods      
	}
}
