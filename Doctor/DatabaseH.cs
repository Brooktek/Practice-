using System;
using System.Data;
using MySql.Data.MySqlClient;

public static class DatabaseH
{
    private static string connectionString = "Server=localhost;Database=hospitalms;Uid=root;Pwd=yourpassword;";

    // Open connection to the database
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    // Execute a query and return a DataTable (for SELECT queries)
    public static DataTable ExecuteSelectQuery(string query, MySqlParameter[] parameters = null)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    // Execute a query without returning data (for INSERT, UPDATE, DELETE queries)
    public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }

    // Execute a scalar query (e.g., COUNT or single value retrieval)
    public static object ExecuteScalar(string query, MySqlParameter[] parameters = null)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
