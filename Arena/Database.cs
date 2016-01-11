using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Arena
{
    public static class Database
    {
        /// <summary>
        ///     Gets a new <see cref="OracleConnection" /> instance
        /// </summary>
        /// <returns>
        ///     A new <see cref="OracleConnection" /> with a correct <see cref="OracleConnection.ConnectionString" />
        /// </returns>
        private static OracleConnection GetConnection()
        {
            const string str = "User Id=dbi329403;Password=hawkJoI5WV;Data Source=fhictora01.fhict.local/fhictora";
            return new OracleConnection(str);
        }

        /// <summary>
        ///     Executes an query and parses the resul table with a custom function
        /// </summary>
        /// <typeparam name="TResult">The type of the data that is read by the given func</typeparam>
        /// <param name="query">The query that will be executed on the database server</param>
        /// <param name="func">The function that will be called for every row in the returned table</param>
        /// <returns>An IEnumerable of type TResult/></returns>
        private static IEnumerable<TResult> ExecuteReader<TResult>(string query, Func<OracleDataReader, TResult> func)
        {
            var s = new Stopwatch();
            s.Start();
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed to open the database connection!\n" + e);
                    yield break;
                }
             

                using (var cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return func(reader);
                        }
                    }
                }
          
            }
            s.Stop();
            Debug.WriteLine("Executed query {0} in {1}ms", query, s.ElapsedMilliseconds);
            
        }

        /// <summary>
        ///     Executes an query on the remote database and returns the number of updated rows
        /// </summary>
        /// <param name="query">query to execute on the database</param>
        /// <param name="commit">if commit is true, the database will execute an COMMIT statement after the query</param>
        /// <returns>The number of updated rows</returns>
        /// <exception cref="OracleException" />
        private static int ExecuteNonQuery(string query, bool commit = true)
        {
            var result = 0;
            try
            {
                using (OracleConnection con = GetConnection())
                {
                    con.Open();
                    using (var cmd = new OracleCommand(query, con))
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    if (commit)
                    {
                        using (var cmd = new OracleCommand("COMMIT", con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to execute query '{0}':\n{1}", query, e.Message);
            }
            return result;
        }

        /// <summary>
        ///     Executes a scalar function
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>The first collumn of th first row of the results</returns>
        private static object ExecuteScalar(string query)
        {
            try
            {
                using (OracleConnection con = GetConnection())
                {
                    con.Open();
                    using (var cmd = new OracleCommand(query, con))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to execute query '{query}':");
                Debug.WriteLine(e);
            }
            return null;
        }

        public static int SetAccount(string username, string password, string email, string activationcode)
        {
            int i = 0;
            try
            {
                if (!AccountExist(username))
                {
                    string Username = "'" + username + "'";
                    string Password = "'" + password + "'";
                    string Email = "'" + email + "'";
                    string Activation = "'" + activationcode + "'";
                    string query =
                        "Select COUNT(*) FROM ACCOUNT";
                    int id = Convert.ToInt32(ExecuteScalar(query)) + 1;
                    query =
                        "INSERT INTO ACCOUNT (AccountID,Username, Password, Email, Verification, Rank, Status, Name, Report)" +
                        $"values({id}, {Username}, {Password}, {Email}, {Activation}, null, 'Offline', 'pieter', null )";
                    i = ExecuteNonQuery(query);
                }
                else
                {
                    i = -1;
                }
            }
            catch (Exception)
            {
                i = -1;
            }
            return i;
        }

        private static bool AccountExist(string username)
        {
            string query = "Select COUNT (*) FROM ACCOUNT WHERE Username like '" +username+ "'";
            return Convert.ToInt32(ExecuteScalar(query)) > 0;
        }

        public static int ActivateAccount(string activation)
        {
            try
            {
                string query = "UPDATE ACCOUNT SET Verification = '-' WHERE Verification like '" + activation + "'";
                return ExecuteNonQuery(query);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public static IEnumerable<Account> GetAccounts()
        {
            string query = "SELECT * FROM Account where rank is not null";

            return ExecuteReader(query, reader => new Account
            {
                Username = Convert.ToString(reader["Username"]),
                Rank = Convert.ToInt32(reader["Rank"])
                
            });
        
        }

        public static IEnumerable<Score> GetScore()
        {
            string query = "SELECT * FROM Score";

            return ExecuteReader(query, reader => new Score
            {
                AccountID = Convert.ToInt32(reader["AccountID"]),
                HpLeft = Convert.ToInt32(reader["Hpleft"]),
                Kills = Convert.ToInt32(reader["Kills"]),
                LivesLeft = Convert.ToInt32(reader["Livesleft"]),
                Tijd = Convert.ToInt32(reader["Tijd"])
            });
        }
    }
}