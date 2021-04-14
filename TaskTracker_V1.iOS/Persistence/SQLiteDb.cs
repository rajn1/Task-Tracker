using Foundation;
using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using TaskTracker_V1.iOS;
using TaskTracker_V1.Persistence;


[assembly: Dependency(typeof(SQLiteDb))]

namespace TaskTracker_V1.iOS
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