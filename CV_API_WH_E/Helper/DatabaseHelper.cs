using CV_API_WH_E.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Helper
{
    public class DatabaseHelper: IDatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(this._connectionString);

            return conn;
        }
    }
}
