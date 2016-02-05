using System;
using SQLite;
using System.IO;

namespace Caderno.Shared
{
	public class ConnectionManager
	{
		private SQLiteConnection connection;

		private string DatabaseFilePath
		{
			get 
			{ 
				var sqliteFilename = "CadernoDatabase.db3";
				#if NETFX_CORE
					var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
				#else

					#if SILVERLIGHT
						var path = sqliteFilename;
					#else

						#if __ANDROID__
							string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
						#else
							string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
							string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
						#endif

						var path = Path.Combine (libraryPath, sqliteFilename);
					#endif

				#endif
				return path;	
			}
		}

		public ConnectionManager ()
		{
		}

		public void Connect()
		{
			this.connection = new SQLiteConnection (DatabaseFilePath);
		}

		public void Disconnect()
		{
			if (this.connection != null) 
			{
				this.connection.Close ();
			}
			this.connection = null;
		}

		public SQLiteConnection GetConnection()
		{
			if (connection == null) 
			{
				throw new Exception ("Connection not opened.");	
			}

			return this.connection;
		}
	}
}

