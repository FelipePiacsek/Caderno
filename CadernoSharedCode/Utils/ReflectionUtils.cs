using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Caderno.Shared
{
	public abstract class ReflectionUtils
	{
		public static List<Type> ListClassesWithAttribute<T>() where T : Attribute
		{
			return ListClassesWithAttribute<T> (Assembly.GetExecutingAssembly ().GetTypes ().ToList());
		}

		public static List<Type> ListClassesWithAttribute<T>(List<Type> types) where T : Attribute
		{
			return (from classe in types
				let attributes = classe.GetCustomAttributes(typeof(T), false)
				where classe.IsClass && attributes != null && attributes.Length > 0
				select classe).ToList();
		}

		public static List<Type> ListClassesContainingPropertyWithAttribute<T>(List<Type> types) where T : Attribute
		{
			return (from type in types
			        let listProperties = ListPropertiesWithAttribute<T> (type)
			        where listProperties != null && listProperties.Count > 0
				select type).ToList();
		}

		public static List<PropertyInfo> ListPropertiesWithAttribute<T>(Type type) where T : Attribute
		{
			return (from property in type.GetProperties ()
				let att = property.GetCustomAttributes (typeof(T), false)
				where att != null && att.Length > 0
				select property).ToList ();
		}
	}
}

