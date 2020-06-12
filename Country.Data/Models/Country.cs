using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Win32;

namespace Syntra.Data.Models {
	public class Country {
		[JsonPropertyName("iso")]
		public int? IsoCode { get; set; }
		[JsonPropertyName("country")]
		public string Name { get; set; }
		[JsonPropertyName("city")]
		public string Capital { get; set; }
		[JsonPropertyName("continent")]
		public string Continent { get; set; }
		[JsonPropertyName("calling_code")]
		public int? TelephoneCode { get; set; }
		[JsonPropertyName("area")]
		public double? LandArea { get; set; }
		[JsonPropertyName("dish")]
		public string NationalDish { get; set; }
		[JsonPropertyName("expectancy")]
		public int? LifeExpectancy { get; set; }
		[JsonPropertyName("government")]
		public string GovernmentType { get; set; }
		[JsonPropertyName("currency_code")]
		public string CurrencyCode { get; set; }
		[JsonPropertyName("currency_name")]
		public string Currency { get; set; }
		[JsonPropertyName("population")]
		public int? Population { get; set; }
		[JsonPropertyName("languages")]
		public List<string> Languages { get; set; } = new List<string>();
		[JsonPropertyName("temperature")]
		public double? AvarageTemperature { get; set; }
		[JsonPropertyName("flag")]
		public string FlagData { get; set; }
		[JsonPropertyName("abbreviation")]
		public string Abbreviation { get; set; } = "";
		public override string ToString() => Name;
  }
}
