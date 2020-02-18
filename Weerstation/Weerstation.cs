using System;
using System.Collections.Generic;
using System.Text;


namespace Weerstation {
	public class Weerstation {
		public List<WeerDag> Dagen { get; private set; } = new List<WeerDag>();
	}
	public class WeerDag { 
		public WeerDag() {
			for (int i = 0;i < Data.Length;i++) {
				Data[i] = new WeerData();
			}
		}
		public WeerData[] Data { get; private set; } = new WeerData[24];
		public DateTime Today { get; private set; } = DateTime.Now;
		public TemperatuurData MaxTemperatuur {
			get {
				TemperatuurData max = new TemperatuurData(-100); 
				foreach (WeerData data in Data) {
					if (data.Temperatuur.Celcius > max.Celcius) { max = data.Temperatuur; }
				}
				return max;
			}
		}
	}
}
