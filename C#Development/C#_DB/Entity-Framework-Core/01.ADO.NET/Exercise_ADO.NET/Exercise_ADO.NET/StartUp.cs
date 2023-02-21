using Microsoft.Data.SqlClient;
using System.Text;

namespace Exercise_ADO.NET
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();
            Console.WriteLine("Connected to DB...");

            //string result = await GetAllVillainsWithTheirMinionsAsync(sqlConnection);
            //Console.WriteLine(result);

            //int villainId = int.Parse(Console.ReadLine());
            //string result = await GetVillainWithAllMinionsByIsAsync(sqlConnection, villainId);
            //Console.WriteLine(result);

            string[] minionInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] villainInfo = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string result = await AddNewMinionsAsync(sqlConnection, minionInfo[1], villainInfo[1]);
            Console.WriteLine(result);
        }

        //Problem 2
        static async Task<string> GetAllVillainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            var sb = new StringBuilder();
            SqlCommand sqlCommand = new SqlCommand(SqlQueries.GetAllVillainsAndCountOfTheirMinions, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        } 

        //Problem 3
        static async Task<string> GetVillainWithAllMinionsByIsAsync(SqlConnection sqlConnection, int villainId)
        {
            SqlCommand getVillainNameCommand = new SqlCommand(SqlQueries.GetVillainNameById, sqlConnection);

            getVillainNameCommand.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObject = await getVillainNameCommand.ExecuteScalarAsync();

            if (villainNameObject == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObject;

            SqlCommand getAllMinionsCommand = new SqlCommand(SqlQueries.GetAllMinionsByVillainId, sqlConnection);

            getAllMinionsCommand.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader minionsReader = await getAllMinionsCommand.ExecuteReaderAsync();

            string output = GenerateVillainWithMinionsOutput(villainName, minionsReader);

            return output;
        }

        private static string GenerateVillainWithMinionsOutput(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villain: {villainName}");

            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNumber = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNumber}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 4
        static async Task<string> AddNewMinionsAsync(SqlConnection sqlConnection, string minionInfo, string villainName)
        {
            var sb = new StringBuilder();
            string[] minionArguments = minionInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string minionName = minionArguments[0];
            int minionAge = int.Parse(minionArguments[1]);
            string townName = minionArguments[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                int townId = await GetTownIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, townName);
                int villainId = await GetVillainIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, villainName);
                int minionId = await AddNewMinionAndReturnIdAsync(sqlConnection, sqlTransaction, minionName, minionAge, townId);

                await SetMinionToBeServentOfVillainAsync(sqlConnection, sqlTransaction, minionId, villainId);
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                await sqlTransaction.CommitAsync();
            }
            catch (Exception e)
            {
                await sqlTransaction.RollbackAsync();
            }

            return sb.ToString().TrimEnd();
        }

        private static async Task<int> GetTownIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string townName)
        {
            SqlCommand getTownIdCommand = new SqlCommand(SqlQueries.GetTownIdByName, sqlConnection, transaction);
            getTownIdCommand.Parameters.AddWithValue("@townName", townName);
            int? townID = (int?) await getTownIdCommand.ExecuteScalarAsync();

            if (!townID.HasValue)
            {
                SqlCommand addNewTownCommand = new SqlCommand(SqlQueries.AddNewTown, sqlConnection, transaction);
                addNewTownCommand.Parameters.AddWithValue("@townName", townName);
                await addNewTownCommand.ExecuteNonQueryAsync();

                townID = (int?) await getTownIdCommand.ExecuteScalarAsync();
                sb.AppendLine($"Town {townName} was added to the database.");
            }

            return townID.Value;
        }

        private static async Task<int> GetVillainIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string villainName)
        {
            SqlCommand getVillainIdCommand = new SqlCommand(SqlQueries.GetVillainIdByName, sqlConnection, transaction);
            getVillainIdCommand.Parameters.AddWithValue("@Name", villainName);
            int? villainId = (int?) await getVillainIdCommand.ExecuteScalarAsync();

            if (!villainId.HasValue)
            {
                SqlCommand addVillainCommand = new SqlCommand(SqlQueries.AddVillainWithDefaultEvilnessFactor, sqlConnection, transaction);
                addVillainCommand.Parameters.AddWithValue("@villainName", villainName);

                await addVillainCommand.ExecuteNonQueryAsync();

                villainId = (int?)await getVillainIdCommand.ExecuteScalarAsync();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        private static async Task<int> AddNewMinionAndReturnIdAsync(SqlConnection sqlConnection, SqlTransaction transaction, string minionName, int minionAge, int townId)
        {
            SqlCommand addMinionCmd = new SqlCommand(SqlQueries.AddNewMinion, sqlConnection, transaction);
            addMinionCmd.Parameters.AddWithValue("@name", minionName);
            addMinionCmd.Parameters.AddWithValue("@age", minionAge);
            addMinionCmd.Parameters.AddWithValue("@townId", townId);

            await addMinionCmd.ExecuteNonQueryAsync();

            SqlCommand getMinionIdCmd = new SqlCommand(SqlQueries.GetMinionIdByName, sqlConnection, transaction);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int) await getMinionIdCmd.ExecuteScalarAsync();

            return minionId;
        }

        private static async Task SetMinionToBeServentOfVillainAsync(SqlConnection sqlConnection, SqlTransaction transaction, int minionId, int villainId)
        {
            SqlCommand addMinionVillainCmd = new SqlCommand(SqlQueries.SetMinionToBeServentOfVillain, sqlConnection, transaction);
            addMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            addMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await addMinionVillainCmd.ExecuteNonQueryAsync();
        }
    }
}