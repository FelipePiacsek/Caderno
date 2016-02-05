using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Caderno.Shared
{
	public abstract class DatebaseUtils
	{
		public static string ManyToManyTableCreationQuery(string tableName, string owner, string owned) { 
			return String.Format("Create table if not exists {0} ({1} integer NOT NULL, {2} integer NOT NULL);", tableName, ManyToManyColumnName(owner), ManyToManyColumnName(owned));
		}

		public static string ManyToManyInsertionQuery(string tableName, string ownerName, string ownedName, int idOwner, List<int> idsOwned) { 
			StringBuilder builder = new StringBuilder ();
			builder.Append(String.Format("INSERT INTO {0} ({1}, {2}) values", tableName, ManyToManyColumnName(ownerName), ManyToManyColumnName(ownedName)));
			for (int i = 0; i < idsOwned.Count - 1; i++) {
				int id = idsOwned [i];
				builder.Append (String.Format ("({0}, {1}),", idOwner, id));
			}
			builder.Append (String.Format ("({0}, {1});", idOwner, idsOwned.Last()));

			return builder.ToString ();
		}

		public static string ManyToManyTableName (string owner, string owned)
		{
			StringBuilder builder = new StringBuilder ();

			builder.Append (StringUtils.ToUnderscoreCase(owner));
			builder.Append ("_vs_");
			builder.Append (StringUtils.ToUnderscoreCase(owned));

			return builder.ToString ();
		}

		public static string ManyToManyTableSelectQuery (string tableName, int ownerId)
		{
			throw new NotImplementedException ();
		}

		private static string ManyToManyColumnName(string column)
		{
			StringBuilder builder = new StringBuilder ();

			builder.Append ("id_");
			builder.Append (StringUtils.ToUnderscoreCase(column));

			return builder.ToString ();	
		}
	}
}

