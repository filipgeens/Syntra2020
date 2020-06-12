using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SyntraAB.Tools.Extensions {

	public class CopyIgnoreAttribute: Attribute {
		private bool isBigEndean = true;
		public CopyIgnoreAttribute() { }
	}

	public static class ReflectionExtensions {
		public static bool ImplementsInterface(this Type myType, Type interfaceType) {
			return interfaceType?.IsInterface == true ? myType.GetInterfaces().Where(t => t == interfaceType).Count() > 0 : false;
		}
		public static bool CopyFrom<T, DestT>(this DestT dest, T src) where DestT : class where T : class {
			if (dest != null && src != null) {
				List<PropertyInfo> props = typeof(T).GetProperties().Where(p => p.GetMethod?.IsPublic == true && p.SetMethod?.IsPublic == true && (p.PropertyType.IsValueType || p.PropertyType.ImplementsInterface(typeof(ICloneable)) || p.PropertyType.ImplementsInterface(typeof(IList)) || p.PropertyType.IsArray)).ToList();
				PropertyInfo destProp = null;
				object value = null;
				bool ok = props?.Count > 0;
				foreach (var p in props) {
					if (p.GetCustomAttribute<CopyIgnoreAttribute>() == null) {
						destProp = typeof(DestT).GetProperty(p.Name);
						value = p.GetValue(src);
						if (value != null && destProp != null) {
							if (p.PropertyType.IsArray) {
								Array srcArray = value as Array;
								Array destArray = Array.CreateInstance(p.PropertyType.GetElementType(), ((Array)value).Length);
								for (int i = 0; i < srcArray.Length; i++) { destArray.SetValue(p.PropertyType.GetElementType().IsValueType ? srcArray.GetValue(i) : ((ICloneable)srcArray.GetValue(i))?.Clone(), i); }
								destProp.SetValue(dest, destArray);
							} else if (p.PropertyType.ImplementsInterface(typeof(IList))) {
								IList lst = Activator.CreateInstance(p.PropertyType) as IList;
								IList srcList = value as IList;
								if (srcList?.Count > 0 && (srcList[0].GetType().IsValueType || srcList[0] is ICloneable)) {
									for (int i = 0; i < srcList.Count; i++) {
										ICloneable cl = srcList[i] as ICloneable;
										object o = cl?.Clone();
										lst.Add(srcList[0].GetType().IsValueType ? srcList[i] : ((ICloneable)srcList[i]).Clone());
									}
								}
								destProp.SetValue(dest, lst);
							} else {
								destProp.SetValue(dest, p.PropertyType.IsValueType ? value : ((ICloneable)value)?.Clone());
							}
						} else if (value == null && destProp?.PropertyType.IsValueType == false) {
							destProp.SetValue(dest, null);
						} else
							ok = false;
					} else { }
				}
				return ok;
			}
			return false;
		}
	}
}
