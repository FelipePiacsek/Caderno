using System;
using System.Linq;
using System.Collections.Generic;

using SQLite;
using System.IO;
using System.Data;
using System.Linq.Expressions;

namespace Caderno.Shared
{
	public abstract class BaseDAO<T> where T : IModel, new()
	{
		
		protected ConnectionManager connectionManager;

		public BaseDAO ()
		{
			this.connectionManager = new ConnectionManager ();
			this.connectionManager.Connect ();
		}

		~BaseDAO()
		{
			this.connectionManager.Disconnect ();
			this.connectionManager = null;
		}

		public int Save(T model)
		{
			return this.connectionManager.GetConnection().Insert (model);
		}

		public void SaveManyToManyCollection<E> (int ownerId, List<int> ownedIds) where E : IModel
		{
			string ownerName = typeof(T).Name;
			string ownedName = typeof(E).Name;
			string tableName = DatebaseUtils.ManyToManyTableName (ownerName, ownedName);
			string query = DatebaseUtils.ManyToManyInsertionQuery (tableName, ownerName, ownedName, ownerId, ownedIds);
			this.connectionManager.GetConnection ().Execute (query);
		}

		public IEnumerable<E> FetchManyToManyCollection<E>(int ownerId) where E : IModel
		{
			string ownerName = typeof(T).Name;
			string ownedName = typeof(E).Name;
			string tableName = DatebaseUtils.ManyToManyTableName (ownerName, ownedName);
			string queryManyToManyTable = DatebaseUtils.ManyToManyTableSelectQuery (tableName, ownerId);
			List<int> collectedIds = this.connectionManager.GetConnection ().Query<int> (queryManyToManyTable).ToList ();



		}

		public int Update(T model)
		{
			return this.connectionManager.GetConnection().Update (model);
		}

		public T FetchById(int id)
		{
			object primaryKey = id;
			return this.connectionManager.GetConnection().Get<T> (primaryKey);
		}


		public List<T> FetchAll()
		{
			var table = this.connectionManager.GetConnection().Table<T> ();
			return table.ToList ();
		}

		public int RemoveById(int id)
		{
			return this.connectionManager.GetConnection().Delete<T> (id);
		}

		public List<T> FetchAll(Expression<Func<T, bool>> predicate)
		{
			var table = this.connectionManager.GetConnection().Table<T> ().Where (predicate);
			return table.ToList ();
		} 
	}
}

