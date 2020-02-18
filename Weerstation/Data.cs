using System;
using System.Collections.Generic;
using System.Text;

namespace Weerstation {
	public class TemperatuurData {
		public TemperatuurData() { }
		public TemperatuurData(double celcius) {
			Celcius = celcius;
		}
		public double Celcius { get; set; } = 0.1;
		public double Fahrenheit {
			get {
				return ((Celcius * 18) / 10) + 32;
			}
		}
		public double Kelvin {
			get {
				return Celcius + 273;
			}
			set {
				Celcius = value - 273;
			}
		}
	}
	public class WeerData {
		TemperatuurData _temperatuur = new TemperatuurData(0);
		byte _vochtigheid = 0;
		public enum Windrichtingen { ONBEKEND, N, NO, O, ZO, ZW, W };
		public TemperatuurData Temperatuur { get { _temperatuur ??= new TemperatuurData(); return _temperatuur; } set => _temperatuur = value; }
		public Windrichtingen Windrichting { get; set; } = Windrichtingen.ONBEKEND;
		public int Windsnelheid { get; set; } = 0;
		public double Neerslag { get; set; } = 0;
		public byte VochtigheidInPct { get => _vochtigheid;  set { if (value < 100) { _vochtigheid = value; } } }
	}
}
