using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace SyntraAB.Tools.Extensions {
	public static class Extension {
		public static int ToInt(this string src) {
			if (int.TryParse(src, out int i)) {
				return i;
			}
			return 0;
		}
		public static bool IsEmpty(this string src) => string.IsNullOrEmpty(src) == true;
		public static bool NotEmpty(this string src) => string.IsNullOrEmpty(src) == false;
		public static bool NotEmpty(this IList lst) {
			return lst != null && lst.Count > 0;
		}
	}

	public static class SerializingExtensions {
		public static string ToJson<T>(this T src, JsonSerializerOptions options = null) where T : new() {
			options ??= new JsonSerializerOptions() { WriteIndented = true };
			return JsonSerializer.Serialize<T>(src, options);
		}
		public static T FromJson<T>(this string json, JsonSerializerOptions options = null) where T : new() {
			return JsonSerializer.Deserialize<T>(json, options);
		}	
		public static string ToXml(this object src) {
			if (src != null) {
				XmlSerializer serializer = new XmlSerializer(src.GetType());
				StringBuilder sb = new StringBuilder();
				StringWriter writer = new StringWriter(sb);
				serializer.Serialize(writer, src);
				return sb.ToString();
			}
			return null;
		}
		public static T FromXml<T>(this string src) where T : new() {
			if (src != null) {
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				StringReader reader = new StringReader(src);
				return (T)serializer.Deserialize(reader);
			}
			return default;
		}
	}
}
