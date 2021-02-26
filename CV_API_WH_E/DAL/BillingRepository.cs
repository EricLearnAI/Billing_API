using CV_API_WH_E.Database;
using CV_API_WH_E.Interface;
using CV_API_WH_E.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CV_API_WH_E.DAL
{
    public class BillingRepository: IBillingRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public BillingRepository(IDatabaseHelper databaseHelper)
        {
            this._databaseHelper = databaseHelper;
        }

        public Dictionary<string,double> GetGroupingByUnblendedCostByAccountId(string id)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            using (var connection = (_databaseHelper.GetConnection()))
            {
                var cmd = new SQLiteCommand("SELECT ProductName, sum(UnblendedCost) FROM Billing WHERE usageaccountid = $id GROUP BY productname", connection);
                cmd.Parameters.AddWithValue("$id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var productName = (string)reader["ProductName"];
                    var unblendedCost = (double)reader[" sum(UnblendedCost)"];

                    result.Add(productName, unblendedCost);
                }
                reader.Close();

                return result;
            }
        }

        public Dictionary<string, double> GetGroupingByUsageAmountByAccountId(string id)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            using (var connection = (_databaseHelper.GetConnection()))
            {
                var cmd = new SQLiteCommand("SELECT ProductName, sum(UsageAmount) FROM Billing WHERE usageaccountid = $id GROUP BY productname", connection);
                cmd.Parameters.AddWithValue("$id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var productName = (string)reader["ProductName"];
                    var UsageAmount = (double)reader[" sum(UsageAmount)"];

                    result.Add(productName, UsageAmount);
                }
                reader.Close();

                return result;
            }
        }
    }
}
