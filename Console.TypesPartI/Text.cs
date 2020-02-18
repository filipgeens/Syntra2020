using System;
using System.Collections.Generic;
using System.Text;

namespace SyntraAB.Types.Labo {
	public class StringLabo {
		public string VerwijderLetter(string text, int pos) {
			if (pos >= 0 && text?.Length > pos + 1) {
				return text.Remove(pos, 1);
			}
			return text; 
		}

		public string StringNaWaarde(string text, string waarde) {
			if (!string.IsNullOrEmpty(text)) {
				int pos = text.IndexOf("waarde");
				if (pos >= 0 && pos+waarde.Length < text.Length) { return text.Substring(pos + waarde.Length); }
				return text;
			}
			return string.Empty;
		}
	}
}
