﻿using System.Configuration;
using Simple.Data;
using Simple.Data.MongoDB;

namespace Bennington.Cms.InputModelAggregateRoot
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
