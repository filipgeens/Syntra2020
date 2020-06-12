using Syntra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using WpfDataBindingDemo.Tools;
using SyntraAB.Tools.Extensions;
namespace WpfDataBindingDemo.ViewModel {
	public class WpfCountry: Country, ICloneable {


		/// <summary>
		/// We moeten de Country model aanpassen omdat enkel WPF projecten een BitmapImage kennen. 
		/// De model is gemaakt in een class library, en die kent geen WPF. Dus ook geen BitmapImage.
		/// CopyFrom:
		/// We maken ons object met de Flag bitmap om in de WPF schermen te kunnen gebruiken. 
		/// Daarvoor moeten we het oorspronkelijke Model importeren in het nieuwe WPF model. Hiervoor hebben we de CopyFrom functie gebruikt. 
		/// In de extensions zit ook een automatische functie om dit te doen. (2de functie in commentaar)
		/// </summary>
		public WpfCountry() {	}
		public WpfCountry(Country src) {
			CopyFrom(src);
			// CopyFrom extension source code vind je in de Tools DLL. 
			//this.CopyFrom<Country,WpfCountry>(src);
		}
		private void CopyFrom(Country src) {
			IsoCode = src.IsoCode;
			Name = src.Name;
			Capital = src.Capital;
			FlagData = src.FlagData;
			Capital = src.Capital;
			Currency = src.Currency;
			Languages = src.Languages;
			NationalDish = src.NationalDish;
			CurrencyCode = src.CurrencyCode;
			TelephoneCode = src.TelephoneCode;
			GovernmentType = src.GovernmentType;
			Continent = src.Continent;
			TelephoneCode = src.TelephoneCode;
			LandArea = src.LandArea;
			LifeExpectancy = src.LifeExpectancy;
			Population = src.Population;
			AvarageTemperature = src.AvarageTemperature;
			Abbreviation = src.Abbreviation;
		}
		/// <summary>
		/// De Flag property leest de raw bitmap data uit het model en maakt er via extension functies een WPF bitmap van (en omgekeerd).
		/// De ToBitmap() en ToB64 extensions vind je in de Tools folder.
		/// </summary>
		public BitmapImage Flag {
			get {
				return FlagData.ToBitmap();
			}
			set {
				FlagData = value.ToB64();
			}
		}

		public object Clone() {
			return MemberwiseClone();
		}
	}
}
