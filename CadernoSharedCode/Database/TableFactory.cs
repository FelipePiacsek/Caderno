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

			string query = "Create table if not exists {0} ({1} integer NOT NULL, {2} integer NOT NULL);";

			string owner, owned, tableName, ownerColumnName, ownedColumnName;

			owned = owner = tableName = ownerColumnName = ownedColumnName = "";

			manager.Connect ();
			foreach (Type entity in entities) {
				properties = ReflectionUtils.ListPropertiesWithAttribute<ManyToManyAttribute> (entity);
				foreach (PropertyInfo property in properties) {
					owner = StringUtils.ToUnderscoreCase (entity.Name);
					owned = StringUtils.ToUnderscoreCase (property.PropertyType.GetGenericArguments().First().Name);
					tableName = BuildTableName (owner, owned);
					ownerColumnName = BuildColumnName (owner);
					ownedColumnName = BuildColumnName (owned);
					query = String.Format (query, tableName, ownerColumnName, ownedColumnName);
					manager.GetConnection ().Execute (query);
				}
			}
			manager.Disconnect ();
		}

		private string BuildTableName (string owner, string owned)
		{
			StringBuilder builder = new StringBuilder ();

			builder.Append (owner);
			builder.Append ("_vs_");
			builder.Append (owned);

			return builder.ToString ();
		}

		private string BuildColumnName(string column)
		{
			StringBuilder builder = new StringBuilder ();

			builder.Append ("id_");
			builder.Append (column);

			return builder.ToString ();	
		}

	}
}

