using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SyntraAB.Tools.Extensions {
	public static class Extension {
		public static bool NotEmpty(this IList lst) {
			return lst != null && lst.Count > 0;
		}
	}
}
