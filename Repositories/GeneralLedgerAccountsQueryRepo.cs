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
            /*var commandText = "SELECT \"A.AccountName\", \"A.AccountNo\", \"A.AccountID\", \"C.ClassName\" " +
                            "FROM \"AccountsDetails\" \"A\" " +
                            "JOIN \"AccountClasses\" \"C\" ON \"A.AccountClassID\" = \"C.AccountClassID\"";*/
            /*            var commandText = "SELECT A.AccountName, A.AccountNo, A.AccountID, C.ClassName " +
                              "FROM AccountsDetails A " +
                              "JOIN AccountClasses C ON A.AccountClassID = C.AccountClassID";*/
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


    }
}
