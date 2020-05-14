using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SerializeAndIODemo {
	public class PrivateData {
		public string RijksregisterNummer { get; set; }
		public string VoorNaam { get; set; }
		public string AchterNaam { get; set; }
		[JsonIgnore]
		public string BankRekeningNummer { get; set; }
		public DateTime GeboorteDatum { get; set; } = DateTime.MinValue;
		public int Pincode { get; set; }
		public string BankkaartNummer { get; set; }
		[JsonPropertyName("contacten")]
		public List<string> PrivateRelaties { get; set; } = new List<string>();
		public override string ToString() {
			return $"{VoorNaam} {AchterNaam} {RijksregisterNummer} {Pincode}";
		}
	}
}
