using System.Configuration;
using MongoDB.Driver;
using Simple.Data;
using Simple.Data.MongoDB;

namespace Shared
{
    public static class DatabaseFactory
    {
        private static readonly object LockObject = new object();
        private static string connectionName;
        private static dynamic database;

        public static void SetConnectionName(string name)
        {
            connectionName = name;
        }

        public static void SetDatabase(dynamic newDatabase)
        {
            database = newDatabase;
        }

        public static dynamic GetMongoDatabase()
        {
            if (database == null)
            {
                lock (LockObject)
                {
                    if (database == null)
                    {
                        var connectionStrings = ConfigurationManager.ConnectionStrings[connectionName];
                        if (connectionStrings != null)
                        {
                            var connectionString = connectionStrings.ConnectionString;
                            database = Database.Opener.OpenMongo(connectionString);
                        }
                    }
                }
            }

            return database;
        }
    }
}
