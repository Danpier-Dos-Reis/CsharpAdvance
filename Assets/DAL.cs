using System.Data.SQLite;

namespace CsharpAdvance.Assets
{
    public class DAL
    {
        // Ruta de la base de datos SQLite. Si no existe, se creará.
        private string _connectionString = "Data Source=./Assets/db_test.db;Version=3;";

        public string[] GetSecretKeys(){

            List<string> list = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Consultar datos
                string selectDataQuery = "SELECT * FROM SecretKeys";
                using (SQLiteCommand selectDataCmd = new SQLiteCommand(selectDataQuery, connection))
                using (SQLiteDataReader reader = selectDataCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["PrivateKey"].ToString());
                    }
                }
            }
            return list.ToArray();
        }
    }
}