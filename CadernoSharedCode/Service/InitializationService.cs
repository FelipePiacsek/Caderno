using System;
using Android.App;
using SQLite;
using Caderno.Shared;

namespace Caderno.Shared
{
	public class InitializationService
	{
		private DatabaseInitializer dbInitializer = new DatabaseInitializer();

		public void SetupDatabase ()
		{
			dbInitializer.Initialize ();
		}
		
	}

}

