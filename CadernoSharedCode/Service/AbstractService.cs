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

		public virtual int Save(T model)
		{
			return GetDAO ().Save (model);
		}

		public virtual void SaveCollection<E> (int ownerId, List<int> ownedIds) where E : IModel
		{
			GetDAO().SaveManyToManyCollection<E>(ownerId, ownedIds);
		}

		public virtual int Update(T model)
		{
			return GetDAO ().Update (model);
		}

		public virtual int Remove(T model)
		{
			return GetDAO ().RemoveById (model.GetId ());
		}

		public virtual List<T> ListAll()
		{
			return GetDAO ().FetchAll ();
		}

		public virtual T FindById(int id)
		{
			return GetDAO ().FetchById (id);
		}
	}
}

