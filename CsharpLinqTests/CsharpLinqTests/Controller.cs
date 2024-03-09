using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLinqTests
{
    public class Controller
    {
        private string DBDirectoryPath = "Data Source=C:\\Users\\Danpier\\Desktop\\Practices\\Csharp_Advance\\CsharpLinqTests\\CsharpLinqTests\\bin\\Debug\\net8.0\\DataBase\\SellsPerArticle.db;Version=3;";
        public bool TestDBConnection()
        {
            DAL dal = new DAL(DBDirectoryPath);
            return dal.TestDBConnection();
        }

        public DataTable GetSells()
        {
            DAL dal = new DAL(DBDirectoryPath);
            DataTable dt = dal.GetSells();
            return dt;
        }
        public IEnumerable<object> GetArticles(Int64 Id_Article)
        {
            DAL dal = new DAL(DBDirectoryPath);
            DataTable dtSells = dal.GetSells();
            DataTable dtArticles = dal.GetArticles();

            var list = from dts in dtSells.AsEnumerable()
                            join dta in dtArticles.AsEnumerable()
                            on dts.Field<Int64>("Id_Article") equals dta.Field<Int64>("Id")
                            where dts.Field<Int64>("Id_Article") == Id_Article
                            select new
                            {
                                IdSell = dts.Field<Int64>("Id"),
                                ClientName = dts.Field<string>("ClientName"),
                                Article = dta.Field<string>("ArticleName"),
                                Quantity = dts.Field<double>("Quantity"),
                                DateSelled = dts.Field<DateTime>("SellDate")
                            };

            return list;
        }
    }
}
