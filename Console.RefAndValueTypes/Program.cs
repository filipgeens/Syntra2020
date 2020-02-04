using System;

namespace Syntra.RefAndValueTypes {
	class Program {
		static void Main(string[] args) {
			ValueTemp a = new ValueTemp();
			a.max = 6;
			a.min = 2;
			ValueTemp b = a;
			RefTemp ra = new RefTemp();
			ra.max = 6;
			ra.min = 2;
			RefTemp rb = ra;
			Console.WriteLine($"Value van a= min: {a.min} max: {a.max}");
			Console.WriteLine($"Value van b= min: {b.min} max: {b.max}");
			a.min = 6;
			a.max = 25;
			Console.WriteLine($"Value van a= min: {a.min} max: {a.max}");
			Console.WriteLine($"Value van b= min: {b.min} max: {b.max}");
			Console.WriteLine($"Ref Value van ra= min: {ra.min} max: {ra.max}");
			Console.WriteLine($"Ref Value van rb= min: {rb.min} max: {rb.max}");
			ra.min = 6;
			ra.max = 25;
			Console.WriteLine($"Ref Value van ra= min: {ra.min} max: {ra.max}");
			Console.WriteLine($"Ref Value van rb= min: {rb.min} max: {rb.max}");
		}
		public struct ValueTemp {
			public int min;
			public int max;
			string a;
		}
		public class RefTemp {
			public int min;
			public int max;
		}
	}
}
