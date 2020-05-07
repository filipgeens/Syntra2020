using System;
using System.Collections.Generic;
using System.Text;

namespace Overerving {
	public class Generics<T> {
		T _value=default(T);

		public Generics() {

		}
		public Generics(T myVal) {
			_value = myVal;
		}

		public void Run() {
			Console.WriteLine(this);		
		}
		public override string ToString() => $"T is van het type {typeof(T)} en heeft als waarde {_value?.ToString() ?? "null"}";

	}
}
