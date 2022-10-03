using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
            const string SqlConnectionString =
                "Server=.;Database=MinionsDB;Integrated Security=true";

        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            //InitialSetup(connection);
            //GetVillainNames(connection);
            //SqlCommand command = MinionNames(connection);
            //Problem04(connection);
            //SqlCommand updateCommand = Problem05(connection);
            //SqlCommand sqlCommand, sqlDeleteMVCommand, sqlDeleteVCommand;
            //Problem06(connection, out sqlCommand, out sqlDeleteMVCommand, out sqlDeleteVCommand);
            //SqlCommand selectCommand;
            //SqlDataReader reader;
            //Problem07(connection, out selectCommand, out reader);
            //SqlCommand selectCommand;
            //SqlDataReader reader;
            //Problem08(connection, out selectCommand, out reader);
            //SqlCommand command, selectCommand;
            //SqlDataReader reader;
            //Problem09(connection, out command, out selectCommand, out reader);
        }

        private static void Problem09(SqlConnection connection, out SqlCommand command, out SqlCommand selectCommand, out SqlDataReader reader)
        {
            int id = int.Parse(Console.ReadLine());

            string query = "EXEC usp_GetOlder @id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            string selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@id", id);
            reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }
        }

        private static void Problem08(SqlConnection connection, out SqlCommand selectCommand, out SqlDataReader reader)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string updateMinionsQuery = @" UPDATE Minions
                           SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                         WHERE Id = @Id";

            foreach (var id in minionIds)
            {
                using var sqlCommand = new SqlCommand(updateMinionsQuery, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

            var selectMinions = @"SELECT Name, Age FROM Minions";
            selectCommand = new SqlCommand(selectMinions, connection);
            reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }

        private static void Problem07(SqlConnection connection, out SqlCommand selectCommand, out SqlDataReader reader)
        {
            var minionsQuery = @"SELECT Name FROM Minions";
            selectCommand = new SqlCommand(minionsQuery, connection);
            reader = selectCommand.ExecuteReader();
            var minions = new List<string>();
            while (reader.Read())
            {
                minions.Add((string)reader[0]);
            }

            int counter = 0;

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[0 + counter]);
                Console.WriteLine(minions.Count - 1 - counter);
                counter++;
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }

        private static void Problem06(SqlConnection connection, out SqlCommand sqlCommand, out SqlCommand sqlDeleteMVCommand, out SqlCommand sqlDeleteVCommand)
        {
            int value = int.Parse(Console.ReadLine());

            string evilNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
            sqlCommand = new SqlCommand(evilNameQuery, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", value);
            var name = (string)sqlCommand.ExecuteScalar();

            if (name == null)
            {
                Console.WriteLine("No such villain was found.");
            }

            var deleteMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
                                  WHERE VillainId = @villainId";
            sqlDeleteMVCommand = new SqlCommand(deleteMinionsVillainsQuery, connection);
            sqlDeleteMVCommand.Parameters.AddWithValue("@villainId", value);
            var affectedRows = sqlDeleteMVCommand.ExecuteNonQuery();


            var deleteVillainQuery = @"DELETE FROM Villains
                                    WHERE Id = @villainId";
            sqlDeleteVCommand = new SqlCommand(deleteVillainQuery, connection);
            sqlDeleteVCommand.Parameters.AddWithValue("@villainId", value);
            sqlDeleteVCommand.ExecuteNonQuery();


            Console.WriteLine($"{name} was deleted.");
            Console.WriteLine($"{affectedRows} minions were released.");
        }

        private static SqlCommand Problem05(SqlConnection connection)
        {
            string countryName = Console.ReadLine();

            string updateTownNamesQuery = @"UPDATE Towns
                    SET Name = UPPER(Name)
                WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            string selectTownNamesQuery = @" SELECT t.Name 
                           FROM Towns as t
                           JOIN Countries AS c ON c.Id = t.CountryCode
                          WHERE c.Name = @countryName";
            var updateCommand = new SqlCommand(updateTownNamesQuery, connection);
            updateCommand.Parameters.AddWithValue("@countryName", countryName);
            var affectedRows = updateCommand.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected.");

                using var selectCommand = new SqlCommand(selectTownNamesQuery, connection);
                selectCommand.Parameters.AddWithValue("@countryName", countryName);

                using var reader = selectCommand.ExecuteReader();
                var towns = new List<string>();
                while (reader.Read())
                {
                    towns.Add((string)reader[0]);
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }

            return updateCommand;
        }

        private static void Problem04(SqlConnection connection)
        {
            string[] minionInfo = Console.ReadLine().Split();

            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int age = int.Parse(minionInfo[2]);
            string town = minionInfo[3];

            int? townId = GetTownId(connection, town);

            if (townId == null)
            {
                string createTownQuery = "INSERT INTO Towns (Id, Name) VALUES (1, @name)";
                using var sqlCommand = new SqlCommand(createTownQuery, connection);
                sqlCommand.Parameters.AddWithValue("@name", town);
                sqlCommand.ExecuteNonQuery();
                townId = GetTownId(connection, town);

                Console.WriteLine($"Town {town} was added to the database.");
            }

            string villainName = villainInfo[1];
            int? villainId = GetVillainId(connection, villainName);

            if (villainId == null)
            {
                string createVillain = "INSERT INTO Villains (Id, Name, EvilnessFactorId)  VALUES (1, @villainName, 4)";
                using var sqlCommand = new SqlCommand(createVillain, connection);
                sqlCommand.Parameters.AddWithValue("@villainName", villainName);
                sqlCommand.ExecuteNonQuery();
                villainId = GetVillainId(connection, villainName);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            CreateMinion(connection, minionName, age, townId);
            var minionId = GetMinionId(connection, minionName);

            InsertMinionVillain(connection, villainId, minionId);
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
        }

        private static void InsertMinionVillain(SqlConnection connection, int? villainId, int? minionId)
        {
            var insertIntoMinVil = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            var sqlCommand = new SqlCommand(insertIntoMinVil, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", villainId);
            sqlCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand.ExecuteNonQuery();
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            var minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            var sqlCommand = new SqlCommand(minionIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@Name", minionName);
            var minionId = sqlCommand.ExecuteScalar();
            return (int?)minionId;
        }

        private static void CreateMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string createMinion = "INSERT INTO Minions (Id, Name, Age, TownId) VALUES (1, @name, @age, @townId)";
            using var sqlCommand = new SqlCommand(createMinion, connection);
            sqlCommand.Parameters.AddWithValue("@name", minionName);
            sqlCommand.Parameters.AddWithValue("@age", age);
            sqlCommand.Parameters.AddWithValue("@townId", townId);
            sqlCommand.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string query = "SELECT Id FROM Villains WHERE Name = @Name";
            using var sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Name", villainName);
            var villainId = sqlCommand.ExecuteScalar();
            return (int?)villainId;
        }

        private static int? GetTownId(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using var sqlCommand = new SqlCommand(townIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@townName", town);
            var townId = sqlCommand.ExecuteScalar();
            return (int?)townId;
        }

        private static SqlCommand MinionNames(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());

            string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
            var command = new SqlCommand(villainNameQuery, connection);
            command.Parameters.AddWithValue("@Id", id);

            var result = command.ExecuteScalar();

            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            if (result == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {result}");

                using var minionCommand = new SqlCommand(minionsQuery, connection);

                minionCommand.Parameters.AddWithValue("@Id", id);

                using var reader = minionCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                }

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                }
            }

            return command;
        }

        private static object ExecuteScalar(SqlConnection connection, string query)
        {
            using var command = new SqlCommand(query, connection);
            var result = command.ExecuteScalar();
            return result;
        }

        private static void GetVillainNames(SqlConnection connection)
        {
            string query = @"SELECT Name, COUNT(mv.MinionId)
                                FROM Villains v
                                JOIN MinionsVillains mv ON mv.VillainId = v.Id
                             GROUP BY v.Id, v.Name";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader[0];
                var count = reader[1];

                Console.WriteLine($"{name} - {count}");
            }
        }

        private static void InitialSetup(SqlConnection connection)
        {
            //string createDatabase = "CREATE DATABASE MinionsDB";
            var createTableStatements = GetCreateTableStatements();
            foreach (var query in createTableStatements)
            {
                ExecuteNonQuery(connection, query);
            }

            var insertStatements = GetInsertDataStatements();

            foreach (var query in insertStatements)
            {
                ExecuteNonQuery(connection, query);
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string createDatabase)
        {
            using var command = new SqlCommand(createDatabase, connection);
           var result = command.ExecuteNonQuery();
        }

        private static string[] GetInsertDataStatements()
        {
            var result = new string[]
            {
                "INSERT INTO Countries (Id, Name) VALUES (1, 'Bulgaria'), (2, 'Norway'), (3, 'Cyrpus'), (4, 'Greece'), (5, 'UK')",
                "INSERT INTO Towns (Id, Name, CountryCode) VALUES (1, 'Sofia', 1), (2, 'Oslo', 2), (3, 'Larnaca', 3), (4, 'Athens', 4), (5, 'London', 5)",
                "INSERT INTO Minions (Id, Name, Age, TownId) VALUES (1, 'Plamena', 20, 1), (2, 'Vais', 1, 2), (3, 'Oreo', 3, 3), (4, 'Bobi', 22, 4), (5, 'Pl', 25, 5)",
                "INSERT INTO EvilnessFactors (Id, Name) VALUES (1, 'super good'), (2, 'good'), (3, 'bad'), (4, 'evil'), (5, 'super evil')",
                "INSERT INTO Villains (Id, Name, EvilnessFactorId) VALUES (1, 'Gru', 4), (2, 'Oreo', 1), (3, 'Vais', 3), (4, 'Bo', 5), (5, 'Pl', 2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)"
            };

            return result;
        }

        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries(Id INT PRIMARY KEY, Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY, Name VARCHAR(50),CountryCode INT REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY, Name VARCHAR(50),Age INT,TownId INT REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY, Name VARCHAR(50))",
                "CREATE TABLE Villains(Id INT PRIMARY KEY, Name VARCHAR(50),EvilnessFactorId INT REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains(MinionId INT REFERENCES Minions(Id), VillainId INT REFERENCES Villains(Id) " +
                "CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))"
            };

            return result;
        }
    }
}
