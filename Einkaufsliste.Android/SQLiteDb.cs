﻿using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Einkaufsliste.Droid;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Einkaufsliste.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}

