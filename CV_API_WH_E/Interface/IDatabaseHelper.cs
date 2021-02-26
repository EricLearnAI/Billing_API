using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace CV_API_WH_E.Interface
{
    public interface IDatabaseHelper
    {
        public SQLiteConnection GetConnection();
    }
}
