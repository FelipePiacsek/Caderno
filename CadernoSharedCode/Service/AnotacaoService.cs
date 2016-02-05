using System;
using System.Collections.Generic;

namespace Caderno.Shared
{
	public class AnotacaoService : AbstractService<Anotacao>
	{
		private AnotacaoDAO dao;

		private TagService tagService;

		public AnotacaoService ()
		{
			dao = new AnotacaoDAO ();
			tagService = new TagService();
		}

		#region implemented abstract members of AbstractService

		protected override BaseDAO<Anotacao> GetDAO ()
		{
			return dao;
		}

		#endregion

		public override int Save(Anotacao anotacao)
		{
			if (anotacao.Tags != null) 
			{
				List<int> tagIds = new List<int> ();
				foreach (Tag tag in anotacao.Tags) 
				{
					tagService.Save (tag);
					tagIds.Add(tag.ID);
				}
				int anotacaoId = base.Save (anotacao);
				base.SaveCollection<Tag> (anotacaoId, tagIds);
			}
			return 0;
		}
	}
}

