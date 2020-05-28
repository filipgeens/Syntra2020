using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfDataBindingDemo.Models {

	public class CountryRepository {
		public string LastError { get; protected set; } = "";
		public List<Country> Members { get; set; } = new List<Country>();
		public int Count { get => Members?.Count > 0 ? Members.Count : 0; }

		public bool Import(string json) {
			try {
				var data = JsonSerializer.Deserialize<List<Country>>(json);
				if (data != null) {
					if (Count > 0) {
						foreach (var ctry in data) {
							var item = Members.Where(t => t.Name == ctry.Name).FirstOrDefault();
							if (item != null) {
								item.Capital = ctry.Capital?.Length > 0 ? ctry.Capital : item.Capital;
								item.Continent = ctry.Continent?.Length > 0 ? ctry.Continent : item.Continent;
								item.TelephoneCode = ctry.TelephoneCode > 0 ? ctry.TelephoneCode : item.TelephoneCode;
								item.LandArea = ctry.LandArea > 0 ? ctry.LandArea : item.LandArea;
								item.IsoCode = ctry.IsoCode > 0 ? ctry.IsoCode : item.IsoCode;
								item.NationalDish = ctry.NationalDish?.Length > 0 ? ctry.NationalDish : item.NationalDish;
								item.LifeExpectancy = ctry.LifeExpectancy > 0 ? ctry.LifeExpectancy : item.LifeExpectancy;
								item.Population = ctry.Population > 0 ? ctry.Population : item.Population;
								item.GovernmentType = ctry.GovernmentType?.Length > 0 ? ctry.GovernmentType : item.GovernmentType;
								item.CurrencyCode = ctry.CurrencyCode?.Length > 0 ? ctry.CurrencyCode : item.CurrencyCode;
								item.Currency = ctry.Currency?.Length > 0 ? ctry.Currency : item.Currency;
								item.Languages = ctry.Languages?.Count > 0 ? ctry.Languages.ToList() : item.Languages;
								item.AvarageTemperature = ctry.AvarageTemperature > 0 ? ctry.AvarageTemperature : item.AvarageTemperature;
							} else {
								Members.Add(ctry);
							}
						}
					} else Members.AddRange(data);
				}
			} catch (Exception ex) { LastError = ex.ToString(); }
			return false;
		}
		public string Export() => JsonSerializer.Serialize(Members, new JsonSerializerOptions() { WriteIndented = true, IgnoreNullValues = true });
	}
}