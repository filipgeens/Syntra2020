using System;
using System.Collections.Generic;
using System.Text;

namespace SyntraAB.Types.Labo {
	public class GetallenLabo {
		public int CelciusNaarFahrenheit(int value) {
			return ((value * 18) / 10) + 32;
		}
		public int CelciusNaarKelvin(int value) {
			return value + 273;
		}
		public bool IsEenVeelvoudVan(int getal, int veelvoud) {
			return getal % veelvoud == 0;
		}
		public double KilometerNaarMijl(double km) {
			return km * 0.621371;
		}
		public double MijlNaarKilometer(double mijl) {
			return mijl * 1.60934;
		}
	}
}
