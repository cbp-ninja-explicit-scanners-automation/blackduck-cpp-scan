using System;
using System.Data.SqlClient;

class VulnerableApp {
    static void Main() {
        string userInput = "' OR '1'='1";
        string connectionString = "Server=localhost;Database=testdb;User Id=sa;Password=password;";
        using (SqlConnection conn = new SqlConnection(connectionString)) {
            conn.Open();
            // SQL Injection vulnerability
            string query = "SELECT * FROM users WHERE username = '" + userInput + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Console.WriteLine("User: " + reader["username"]);
            }
        }
    }
}
