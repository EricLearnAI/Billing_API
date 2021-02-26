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

        public Dictionary<string, string> GetGroupingByUnblendedCostByAccountId(string id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (var connection = (_databaseHelper.GetConnection()))
            {
                connection.Open();
                var cmd = new SQLiteCommand("SELECT ProductName, sum(UnblendedCost) FROM Billing WHERE usageaccountid = $id GROUP BY productname", connection);
                cmd.Parameters.AddWithValue("$id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var productName = (string)reader["ProductName"];

                    var readunblendedCost = (double)reader["sum(UnblendedCost)"];
                    var unblendedCost = $"sum({readunblendedCost})";

                    result.Add(productName, unblendedCost);
                }
                reader.Close();

                return result;
            }
        }

        public List<dailyUsage> GetGroupingByUsageAmountByAccountId(string id)
        {
            List<dailyUsage> result = new List<dailyUsage>();
            using (var connection = (_databaseHelper.GetConnection()))
            {
                connection.Open();
                var cmd = new SQLiteCommand("SELECT ProductName, sum(UsageAmount), UsageStartDate, UsageEndDate FROM Billing WHERE usageaccountid = $id GROUP BY productname, UsageStartDate, UsageEndDate;", connection);
                cmd.Parameters.AddWithValue("$id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var dailyUsage = new dailyUsage();

                    dailyUsage.ProductName = (string)reader["ProductName"];
                    dailyUsage.UsageStartDate = (DateTime)reader["UsageStartDate"];
                    dailyUsage.UsageEndDate = (DateTime)reader["UsageEndDate"];
                    dailyUsage.UsageAmount = (double)reader["sum(UsageAmount)"];

                    result.Add(dailyUsage);
                }
                reader.Close();

                return result;
            }
        }
    }
}
