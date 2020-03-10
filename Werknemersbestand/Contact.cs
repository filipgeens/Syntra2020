using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Werknemersbestand {
	public class Contact {

		public Contact() {

		}
		public Contact(ContactTypes tp,string contact) {
			ContactType = tp;
			ContactGegevens = contact;
		}
		string _contactGegevens = "";
		public enum ContactTypes { Telefoon, Mobiel, EMail };
		public ContactTypes ContactType { get; set; } = ContactTypes.EMail;
		public string ContactGegevens { get => _contactGegevens; set { if (Controleer(value)) { _contactGegevens = value; } } }

		private bool Controleer(string value) {
			if (ContactType == ContactTypes.EMail) {
				return Regex.IsMatch(value, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
			} else return true;
		}
	}
}
