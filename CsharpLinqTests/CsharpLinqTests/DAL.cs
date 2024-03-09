using System.Data;
using System.Data.SQLite;

namespace CsharpLinqTests
{
    public class DAL
    {
        private string _DBConnection;
        public DAL(string DBConnection) { _DBConnection = DBConnection; }

        public bool TestDBConnection()
        {
            bool r = false;
            using (SQLiteConnection conn = new SQLiteConnection(_DBConnection))
            {
                try { conn.Open(); r = true; }
                catch (Exception e) { Console.WriteLine(e.Message);}
                finally { conn.Close(); }
            }
            return r;
        }

        public DataTable GetSells()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Sells;";
            if (TestDBConnection())
            {
                using (SQLiteConnection conn = new SQLiteConnection(_DBConnection))
                {
                    conn.Open();

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetArticles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Articles;";
            if (TestDBConnection())
            {
                using (SQLiteConnection conn = new SQLiteConnection(_DBConnection))
                {
                    conn.Open();

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}