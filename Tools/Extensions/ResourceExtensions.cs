using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SyntraAB.Tools.Extensions {
  public static class ResourceExtensions {
		public static byte[] ReadToEnd(this Stream s) {
			if (s?.CanRead == true) {
				List<byte> buffer = new List<byte>((int)s.Length);
				int b = 0;
				do {
					b = s.ReadByte();
					if (b >= 0) { buffer.Add(Convert.ToByte(b)); }
				} while (b >= 0);
				return buffer.ToArray();
			}
			return null;
		}
		public static string FindResourceName(this Type objType, string name) {
			if (name?.Length > 0 && objType != null) {
				return objType.Assembly.GetManifestResourceNames().Where(t => t.Contains(name)).First();
			}
			return null;
		}
		public static string GetEmbeddedResource(this Type objType, string name) {
			try {
				string resName = objType?.FindResourceName(name);
				if (resName?.Length > 0) {
					using Stream vStream = objType.Assembly.GetManifestResourceStream(resName);
					using StreamReader vReader = new StreamReader(vStream);
					return vReader.ReadToEnd();
				}
			} catch (Exception ex) { throw (ex); }
			return null;
		}
		public static byte[] LoadResource(this Type tp, string name) {
			Stream s = tp.FindResource(name);
			if (s?.CanRead == true) {
				return s.ReadToEnd();
			}
			return null;
		}
		public static Stream FindResource(this Type tp, string name) {
			if (name.NotEmpty()) {
				string item = tp?.Assembly.GetManifestResourceNames().Where(t => t.ToLower().Contains(name.ToLower())).FirstOrDefault();
				if (item.NotEmpty()) { return tp.Assembly.GetManifestResourceStream(item); }
			}
			return null;
		}
	}
}
