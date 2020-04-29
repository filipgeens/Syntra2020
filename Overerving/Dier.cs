using System;
using System.Collections.Generic;
using System.Text;

namespace SyntraAB.Overerving.Test {
	public class Dier {
		public Dier() { Soort = GetType().Name; }
		protected Dier(Diergroep grp, GeslachtsKenmerk sexe, DateTime geborenOp) { Groep = grp;  Geslacht = sexe;GeboorteDatum = geborenOp; }
		public enum GeslachtsKenmerk { Mannelijk, Vrouwelijk, Tweeslachtig, Onbekend, Andere }
		public enum Diergroep { onbekend, spinachtigen, insecten, reptielen, amfibieën, vissen, weekdieren, zoogdieren, vogels };
		public Diergroep Groep { get; protected set; } = Diergroep.onbekend;
		public GeslachtsKenmerk Geslacht { get; set; } = GeslachtsKenmerk.Onbekend;
		public string Soort { get; protected set; } = "";
		public string Naam { get; set; }
		public DateTime GeboorteDatum { get; set; }
		public virtual string MaakGeluid() { return "stilte"; }
		public override string ToString() { return $"Dit is een {Soort} en de naam is {Naam}. Geslacht : {Geslacht} Leeftijd :"; }
	}
	public class Aap :Dier {
		public Aap(string naam,GeslachtsKenmerk sexe, DateTime geborenOp) { Groep = Diergroep.zoogdieren;Naam = naam; Geslacht = sexe; GeboorteDatum = geborenOp; }
		public override string MaakGeluid() { return "OeOeOe"; }
	}
	public class Regenworm :Dier {
		public Regenworm(string naam, DateTime geborenOp) {
			Groep = Diergroep.weekdieren;
			Geslacht = GeslachtsKenmerk.Tweeslachtig;
			GeboorteDatum = geborenOp;
			Naam = naam;
		}
		public override string MaakGeluid() { return base.MaakGeluid(); }
	}

	public class Haai :Dier {
		public Haai(string naam, GeslachtsKenmerk sexe, DateTime geborenOp) { Groep = Diergroep.vissen; Naam = naam; Geslacht = sexe; GeboorteDatum = geborenOp; }
		public override string MaakGeluid() { return "Blup"; }
	}

	public class Zoo {
		public List<Dier> Dieren { get; } = new List<Dier>();

		public Zoo() {
			Dieren.Add(new Aap("Guust", Dier.GeslachtsKenmerk.Mannelijk, new DateTime(1985, 1, 10)));
			Dieren.Add(new Aap("Rihanna", Dier.GeslachtsKenmerk.Vrouwelijk, new DateTime(2008,8 , 5)));
			Dieren.Add(new Regenworm("Chitah", new DateTime(2020, 4, 1)));
			Dieren.Add(new Haai("GraafGraaf", Dier.GeslachtsKenmerk.Mannelijk, new DateTime(2011, 11, 11)));
		}
	}
}
