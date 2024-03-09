using System.Data;
using System.Data.SqlClient;

namespace LinqTestSQLSERVER
{
    public class DAL
    {
        string _connectionString = "Server=DANPIER2024;Database=Polar20240202;User Id=sa;Password=samantha;";

        public bool TestDBConection()
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try { conn.Open(); result = true; }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conn.Close(); }
            }
            return result;
        }

        public DataTable GetSells()
        {
            DataTable dt = new DataTable();
            string query = "SELECT\r\n\t(AV.Serie+'/'+LTRIM(RTRIM(STR(AV.Numero)))) AlbaranVenta,\r\n\tAV.Id_FacturaVenta,\r\n\tLAVA.Id_Articulo,\r\n\tLAVA.Cantidad,\r\n\tLAVA.ImporteNetoTrans\r\nFROM AlbaranesVenta AV\r\nINNER JOIN LineasAlbaranVenta LAV ON AV.Id = LAV.Id_AlbaranVenta\r\nINNER JOIN LineasAlbaranVentaArticulo LAVA ON LAV.Id = LAVA.Id_LineaAlbaranVenta\r\nWHERE AV.Serie <> ''";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conn.Close(); }
            }

                return dt;
        }
        public DataTable GetArticles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT\r\n\tA.Id,\r\n\tA.Nombre NombreArticulo\r\nFROM Articulos A";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conn.Close(); }
            }

            return dt;
        }
        public DataSet GetFacturasVenta()
        {
            DataSet ds = new DataSet();

            //Return Data from Facturas
            DataTable dtFV = new DataTable(); DataTable dtAV = new DataTable();
            string queryFV = "SELECT Id, FacturasVenta, SUM(ImporteNetoTrans) ImporteTotal FROM (SELECT\r\n\tFV.Id,\r\n\t(FV.Serie+'/'+LTRIM(RTRIM(STR(FV.Numero)))) FacturasVenta,\r\n\tLAVA.ImporteNetoTrans\r\nFROM FacturasVenta FV\r\nINNER JOIN AlbaranesVenta AV ON FV.Id = AV.Id_FacturaVenta\r\nINNER JOIN LineasAlbaranVenta LAV ON AV.Id = LAV.Id_AlbaranVenta\r\nINNER JOIN LineasAlbaranVentaArticulo LAVA ON LAV.Id = LAVA.Id_LineaAlbaranVenta\r\nWHERE AV.Serie <> '')T\r\nGROUP BY Id, FacturasVenta";
            string queryAV = "SELECT\r\n\t(AV.Serie+'/'+LTRIM(RTRIM(STR(AV.Numero)))) AlbaranVenta,\r\n\tAV.Id_FacturaVenta\r\nFROM AlbaranesVenta AV";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryFV, conn);
                    adapter.Fill(dtFV); ds.Tables.Add(dtFV);

                    adapter = adapter = new SqlDataAdapter(queryAV, conn);
                    adapter.Fill(dtAV); ds.Tables.Add(dtAV);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conn.Close(); }
            }

            return ds;
        }
    }
}
