using System;
using System.Collections.Generic;
using System.Text;

namespace Werknemersbestand {
	public class Adres {
		public enum AdresTypes { Hoofdadres, Kantoor, Buitenverblijf };
		public Adres() { }
		public Adres(AdresTypes tp,string strt="", string postc = "", string huisnr = "", string woonplaats = "", string lnd = "") {
			AdresType = tp;
			Straat = strt;
			Postcode = postc;
			Huisnummer = huisnr;
			Gemeente = woonplaats;
			Land = lnd;
		}

		public AdresTypes AdresType { get; set; } = AdresTypes.Hoofdadres;
		public string Straat { get; set; } = "";
		public string Postcode { get; set; } = "";
		public string Huisnummer { get; set; } = "";
		public string Gemeente { get; set; } = "";
		public string Land { get; set; } = "";
	}
}
