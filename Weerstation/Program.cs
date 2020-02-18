using System;

namespace Weerstation {
	class Program {
		static void Main(string[] args) {
			Random rand = new Random();
			Weerstation station = new Weerstation();
			WeerDag mijnWeer = new WeerDag();
			double prev = 1;
			foreach (WeerData data in mijnWeer.Data) {
				data.Temperatuur.Celcius = prev+rand.NextDouble();
				data.Windrichting = (WeerData.Windrichtingen)rand.Next(1, 4);
				Console.WriteLine($"Temperatuur is {data.Temperatuur.Celcius} °C");
				data.Windrichting = WeerData.Windrichtingen.NO;
				Console.WriteLine($"Windrichting is {data.Windrichting}");
			}
			station.Dagen.Add(mijnWeer);
			Console.ReadKey();
		}
	}
}
