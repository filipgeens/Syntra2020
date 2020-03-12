using System;
using System.Collections.Generic;
using System.Text;

namespace Werknemersbestand {
	public class Werknemer {
		string _id = null;
		string _voorNaam = "";
		static string _baas = "";
		string _achterNaam = "";
		DateTime _inDienst = DateTime.MinValue;
		DateTime _uitDienst = DateTime.MaxValue;
		List<Adres> _adressen = new List<Adres>();
		List<Contact> _contacten = new List<Contact>();
		public string Id { get { if (_id == null) { _id = Guid.NewGuid().ToString(); } return _id; } set { _id = value; } }
		public string VoorNaam { get => _voorNaam; set => _voorNaam = value; }
		public string AchterNaam { get => _achterNaam; set => _achterNaam = value; }
		public DateTime InDienst { get => _inDienst; set => _inDienst = value; }
		public DateTime UitDienst { get => _uitDienst; set => _uitDienst = value; }
		public List<Adres> Adressen { get => _adressen; set => _adressen = value; }
		public List<Contact> Contacten { get => _contacten; set => _contacten = value; }
		public bool IsInDienst { get { return UitDienst == DateTime.MaxValue && InDienst > DateTime.MinValue; } }

		public static string Baas { get => _baas; set => _baas = value; }
		public void OntslaDiePersoon() { UitDienst = DateTime.Now; }
		public override string ToString() {
			return $"id:{Id} Voornaam:{VoorNaam} Achternaam {AchterNaam} Baas:{Baas}";
		}
	}
}
