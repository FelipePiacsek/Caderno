using System;

namespace Caderno.Shared
{
	public class AnotacaoService : AbstractService<Anotacao>
	{
		private AnotacaoDAO dao;

		public AnotacaoService ()
		{
			dao = new AnotacaoDAO ();
		}

		#region implemented abstract members of AbstractService

		protected override BaseDAO<Anotacao> GetDAO ()
		{
			return dao;
		}

		#endregion
	}
}

