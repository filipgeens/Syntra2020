using Overerving;
using System;
using System.Text.Json;

namespace SyntraAB.Overerving.Test {
	class Program {

		/*
		 /// Func voorbeeld
			 */
		static int Calculate(int[] items, Func<int, int, int> method) {
			if (items?.Length < 1) return 0;
			int res = items[0];
			for (int i = 1;i < items.Length;i++) { res = method(res, items[i]); }
			return res;		
		}
		static int Add(int a, int b) => a + b;
		static int Multiply(int a, int b) => a * b;
		static int Subtract(int a, int b) => a - b;



		static void Main(string[] args) {
			/// Overerving voorbeeld
			Zoo zollozjie = new Zoo();
			foreach (var dier in zollozjie.Dieren) {
				Console.WriteLine($"{dier}");
				Console.WriteLine($"{dier.Naam} maakt volgend geluid: {dier.MaakGeluid()}");
			}
			/// Voorbeeld van late binding:
			Console.WriteLine();
			Console.WriteLine("Interface acties:");
			Console.WriteLine();
			foreach (IDierActie dierActie in zollozjie.Acties) {
				Console.WriteLine($"{dierActie.Naam} maakt volgend geluid: {dierActie.MaakAnderGeluid()}");
			}
			/// Generic voorbeeld
			Generics<string> myGen = new Generics<string>("112");
			myGen.Run();
			/// Func structure voorbeeld
			int[] myNumbers = { 8, 4, 3, 1 };
			Console.WriteLine($" Add numbers : {Calculate(myNumbers, Add)}");
			Console.WriteLine($" Multiply numbers : {Calculate(myNumbers, Multiply)}");
			Console.WriteLine($" Subtract numbers : {Calculate(myNumbers, Subtract)}");


			Console.ReadKey();
		}
	}
	}
