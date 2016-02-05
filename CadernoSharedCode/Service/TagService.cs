using System;

namespace Caderno.Shared
{
	public class TagService : AbstractService<Tag>
	{

		private TagDAO dao;

		public TagService ()
		{
			dao = new TagDAO ();
		}

		#region implemented abstract members of AbstractService

		protected override BaseDAO<Tag> GetDAO ()
		{
			return this.dao;
		}

		#endregion
	}
}

