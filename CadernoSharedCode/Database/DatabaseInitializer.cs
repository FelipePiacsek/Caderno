using System;
using System.IO;
using System.Reflection;
using System.Linq;
using SQLite;
using System.Collections.Generic;

namespace Caderno.Shared
{
	public class DatabaseInitializer
	{
		private TableFactory tableFactory;

		public DatabaseInitializer ()
		{
			tableFactory = new TableFactory ();
		}

		public void Initialize()
		{
			List<System.Type> entities = ReflectionUtils.ListClassesWithAttribute<TableAttribute>();
			List<System.Type> manyToManyEntities = ReflectionUtils.ListClassesContainingPropertyWithAttribute<ManyToManyAttribute> (entities);

			tableFactory.CreateEntityTables (entities);
			tableFactory.CreateRelationshipsTables (manyToManyEntities);
		}

	}
}

