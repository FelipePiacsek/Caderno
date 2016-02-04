using System;
using SQLite;
using System.Collections.Generic;

namespace Caderno.Shared
{
	[Table("Anotacao")]
	public class Anotacao : IModel
	{

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string Texto { get; set; }

		public string Titulo { get; set; }

		public string ImagemPath { get; set; }

		[Ignore, ManyToMany]
		public ISet<Tag> Tags { get; set; }

		public DateTime DataCriacao  { get; set; }

		public Anotacao ()
		{
		}

		public int GetId ()
		{
			return this.ID;
		}
		
	}
}

