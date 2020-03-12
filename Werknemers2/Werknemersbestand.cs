using System;
using System.Collections.Generic;
using System.Text;

namespace Werknemersbestand {
	public class Werknemersbestand {
		Dictionary<string, Werknemer> _lijst = new Dictionary<string, Werknemer>();

		public Dictionary<string, Werknemer> Lijst { get => _lijst; set => _lijst = value; }

		public Werknemer Add(string voornaam, string achternaam) {
			Werknemer wn = new Werknemer() { AchterNaam = achternaam, VoorNaam = voornaam, InDienst = DateTime.Now };
			if (Add(wn)) {
				return wn;
			}
			return null;
		}
		public bool Add(Werknemer nieuw) {
			if (!Lijst.ContainsKey(nieuw.Id)) {
				Lijst.Add(nieuw.Id, nieuw);
				return true;
			}
			return false;
		}
		public bool ChangeID(Werknemer wn, string newID) {
			if (Lijst.ContainsKey(wn.Id) && !Lijst.ContainsKey(newID)) {
				Lijst.Remove(wn.Id);
				wn.Id = newID;
				Lijst.Add(wn.Id,wn);
				return true;
			}
			return false;
		}
		public List<Werknemer> ZoekOpNaam(string naam) {
			List<Werknemer> res = new List<Werknemer>();
			if (naam?.Length > 0) {
				naam = naam.ToLower();
				foreach (Werknemer werknemer in Lijst.Values) {
					if (werknemer.VoorNaam?.ToLower().Contains(naam)==true || werknemer.AchterNaam?.ToLower().Contains(naam)==true) {
						res.Add(werknemer);
					}
				}
			}
			return res;
		}
		public bool Remove(Werknemer weg) { 
			return Remove(weg.Id); 
		}

			public bool Remove(string id) {
				return Lijst.Remove(id);
		}
	}
}
