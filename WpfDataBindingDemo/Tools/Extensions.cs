using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfDataBindingDemo.Tools {

	public static class Extensions {
		public static BitmapImage ToBitmap(this string src) {
			if (src?.Length > 0) {
				var res = new BitmapImage();
				if (res.FromB64(src)) {
					return res;
				}
			}
			return null;
		}
		public static bool FromBuffer(this BitmapImage src, byte[] data) {
			try {
				if (data?.Length > 0) {
					MemoryStream stream = new MemoryStream(data);
					src.BeginInit();
					src.StreamSource = stream;
					src.EndInit();
					return true;
				}
			} catch { }
			return false;
		}
		public static bool FromB64(this BitmapImage src, string b64Data) => b64Data?.Length > 0 ? src?.FromBuffer(System.Convert.FromBase64String(b64Data)) == true : false;
		public static string ToB64(this BitmapImage src, BitmapEncoder encoder = null) {
			var buffer = src.ToBuffer(encoder);
			return buffer?.Length > 0 ? System.Convert.ToBase64String(buffer) : null;
		}
		public static byte[] ToBuffer(this BitmapImage src, BitmapEncoder encoder = null) {
			if (src != null) {
				encoder ??= new PngBitmapEncoder();
				using MemoryStream ms = new MemoryStream();
				encoder.Frames.Add(BitmapFrame.Create(src));
				encoder.Save(ms);
				return ms.ToArray();
			}
			return null;
		}
	}
}
