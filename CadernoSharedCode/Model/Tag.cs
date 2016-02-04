using System;
using SQLite;
using System.Collections.Generic;

namespace Caderno.Shared
{
	[Table("Tag")]
	public class Tag : IModel
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string nome { get; set; }

		public int GetId ()
		{
			return this.ID;
		}
	}

}

