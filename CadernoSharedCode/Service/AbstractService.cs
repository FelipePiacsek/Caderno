using System;
using System.Collections.Generic;

namespace Caderno.Shared
{
	public abstract class AbstractService<T> where T : IModel, new()
	{
		protected abstract BaseDAO<T> GetDAO ();

		public AbstractService ()
		{
		}

		public int SaveOrUpdate(T model)
		{
			return GetDAO ().SaveOrUpdate (model);
		}

		public int Remove(T model)
		{
			return GetDAO ().RemoveById (model.GetId ());
		}

		public List<T> ListAll()
		{
			return GetDAO ().FetchAll ();
		}

		public T FindById(int id)
		{
			return GetDAO ().FetchById (id);
		}
	}
}

