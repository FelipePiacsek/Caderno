using System;
using System.Linq;
using SQLite;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Caderno.Shared
{
	public class TableFactory
	{
		private ConnectionManager manager;

		public TableFactory ()
		{
			this.manager = new ConnectionManager();
		}


		public void CreateEntityTables (List<Type> entities)
		{
			manager.Connect ();
			foreach (Type entity in entities) {
				manager.GetConnection ().CreateTable (entity);
			}
			manager.Disconnect ();
		}

		public void CreateRelationshipsTables (List<Type> entities)
		{
			List<PropertyInfo> properties;

			string query, owner, owned, tableName;

			manager.Connect ();
			foreach (Type entity in entities) {
				properties = ReflectionUtils.ListPropertiesWithAttribute<ManyToManyAttribute> (entity);
				foreach (PropertyInfo property in properties) {
					owner = entity.Name;
					owned = property.PropertyType.GetGenericArguments ().First ().Name;
					tableName = DatebaseUtils.ManyToManyTableName (owner, owned);
					query = DatebaseUtils.ManyToManyTableCreationQuery(tableName, owner, owned);
					manager.GetConnection ().Execute (query);
				}
			}
			manager.Disconnect ();
		}


	}
}

