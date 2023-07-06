using Accounts.Models;
using Accounts.Models.VM;
using Accounts.Services;
using Accounts.Services.Command;
using Npgsql;

namespace Accounts.Repositories
{
    public class GeneralLedgerAccountsQueryRepo : IGeneralLedgerAccountsQuery
    {
        private const string _accountsTable = "AccountsDetails";
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        public GeneralLedgerAccountsQueryRepo(IConfiguration config)
        {
            _config = config;
        }
        private void OpenConnection()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }



        public async Task<IEnumerable<AccountDetail>> GetAllAccounts()
        {
            OpenConnection();
            List<AccountDetail> accounts = new List<AccountDetail>();
            var commandText = "SELECT A.\"AccountName\", A.\"AccountNo\", A.\"AccountID\", C.\"ClassName\" " +
                              "FROM \"AccountsDetails\" A " +
                              "JOIN \"AccountClasses\" C ON A.\"AccountClassID\" = C.\"AccountClassID\"";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                         AccountClass className= new AccountClass();
                        className.ClassName = (string)reader["AccountName"];



                        accounts.Add(new AccountDetail
                        {
                            AccountClass = new AccountClass { ClassName = (string)reader["ClassName"] },
                            AccountID = reader.GetInt32(reader.GetOrdinal("AccountID")),
                            AccountNo = reader.GetInt32(reader.GetOrdinal("AccountNo")),
                            AccountName = (string)reader["AccountName"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accounts.Count == 0)
                return null;
            return accounts;
        }

        public async Task<AccountDetail> GetAccountDetails(int accountID)
        {
            OpenConnection();
            AccountDetail accountDetails = null;

            var commandText = $"SELECT \"AccountID\", \"AccountNo\", \"AccountName\", \"AccountClassID\"  " +
                               $"FROM \"AccountsDetails\" " +
                               $"WHERE \"AccountID\" = {accountID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        accountDetails = new AccountDetail
                        {
                            //AccountClass = new AccountClass { ClassName = (string)reader["ClassName"] },
                            AccountID = reader.GetInt32(reader.GetOrdinal("AccountID")),
                            AccountNo = reader.GetInt32(reader.GetOrdinal("AccountNo")),
                            AccountName = (string)reader["AccountName"]
                        };
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountDetails == null)
                return null;
            return accountDetails;
        }

        public async Task<IEnumerable<CashFlowCategory>> GetActiveCashFlowCategories()
        {
            OpenConnection();
            List<CashFlowCategory> cashFlowCategories = new List<CashFlowCategory>();
            var commandText = $"SELECT \"CashFlowCategoryID\", \"Name\", \"Type\"  " +
                               $"FROM \"CashFlowCategories\" " +
                               $"WHERE \"IsActive\" = 1 ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cashFlowCategories.Add(new CashFlowCategory
                        {
                            CashFlowCategoryID = reader.GetInt32(reader.GetOrdinal("CashFlowCategoryID")),
                            Name = (string)reader["Name"],
                            Type = (string)reader["Type"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (cashFlowCategories.Count == 0)
                return null;
            return cashFlowCategories;
        }

        public async Task<IEnumerable<AccountClass>> GetAllAccountClasses()
        {
            OpenConnection();
            List<AccountClass> accountClasses = new List<AccountClass>();
            var commandText = $"SELECT \"AccountClassID\", \"AccountType\", \"ClassName\"  " +
                               $"FROM \"AccountClasses\" ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountClasses.Add(new AccountClass
                        {
                            AccountClassID = reader.GetInt32(reader.GetOrdinal("AccountClassID")),
                            AccountType = (int)reader["AccountType"],
                            ClassName = (string)reader["ClassName"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountClasses.Count == 0)
                return null;
            return accountClasses;
        }

        public async Task<IEnumerable<SubAccountDetail>> GetAllSubAccountsByAccountID(int accountID)
        {
            OpenConnection();
            List<SubAccountDetail> accountSunAccounts = new List<SubAccountDetail>();
            /*  var commandText = $"SELECT \"AccountID\", \"ConfigurationType\", \"CurrentBalance\"" +
                                  $" \"IsActive\", \"IsLocked\", \"Name\"  " +
                                 $"FROM \"SubAccountsDetails\" " +
                                 $"WHERE \"AccountID\" = {accountID} ";*/
            var commandText = $"SELECT *  " +
                               $"FROM \"SubAccountsDetails\" " +
                               $"WHERE \"AccountID\" = {accountID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountSunAccounts.Add(new SubAccountDetail
                        {
                            AccountID = (int)reader["AccountID"],
                            ConfigurationType = (int)reader["ConfigurationType"],
                            CurrentBalance = (int)reader["CurrentBalance"],
                            IsActive= (int)reader["IsActive"],
                            IsLocked= (int)reader["IsLocked"],
                            Name= (string)reader["Name"],
                            SubAccountID= (int)reader["SubAccountID"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountSunAccounts.Count == 0)
                return null;
            return accountSunAccounts;
        }
    }
}
