using System;

namespace Caderno.Shared
{
	public class AnotacaoDAO : BaseDAO<Anotacao>
	{
		public AnotacaoDAO ()
		{
		}

		public Anotacao findCompleteById(int id)
		{
			Anotacao anotacao = base.FetchById (id);

		}
	}
}

