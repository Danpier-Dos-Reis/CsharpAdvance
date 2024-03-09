using System.Data;
using System.IO;

namespace LinqTestSQLSERVER
{
    public class Controller
    {
        public bool TestDBConection()
        {
            return new DAL().TestDBConection();
        }
        public IEnumerable<object> GetSellsPerArticle()
        {
            DAL dal = new DAL();
            DataTable tAlbaranesVenta = dal.GetSells();
            DataTable tArticulos = dal.GetArticles();

            var sellsperAricle = from albaran in tAlbaranesVenta.AsEnumerable()
                                 join articulo in tArticulos.AsEnumerable()
                                 on albaran.Field<int>("Id_Articulo") equals articulo.Field<int>("Id")
                                 select new
                                 {
                                     AlbaranVenta = albaran.Field<string>("AlbaranVenta"),
                                     Articulo = articulo.Field<string>("NombreArticulo"),
                                     CantidadVendida = albaran.Field<decimal>("Cantidad"),
                                     ImporteNetoTrans = albaran.Field<decimal>("ImporteNetoTrans")
                                 };

            return sellsperAricle;
        }
        public IEnumerable<object> GetAVLeftFV()
        {
            DAL dal = new DAL();
            DataTable tAlbaranesVenta = dal.GetFacturasVenta().Tables[1];
            DataTable tFacturasVenta = dal.GetFacturasVenta().Tables[0];

            var lav = tAlbaranesVenta.AsEnumerable().ToList(); //ItemArray[1]==Id_FacturaVenta
            var lfv = tFacturasVenta.AsEnumerable().ToList(); //ItemArray[0]==Id

            var AVLeftFV = from av in lav
                           join fv in lfv on av.ItemArray[1] equals fv.ItemArray[0] into join_avfv
                           from avfv in join_avfv.DefaultIfEmpty()
                           select new
                           {
                               AlbaranVenta = av.ItemArray[0],
                               FacturaVenta = avfv == null ? null : (avfv.ItemArray[1] == null ? null : avfv.ItemArray[1]),
                               ImporteNeto = avfv == null ? null : (avfv.ItemArray[2] == null ? null : avfv.ItemArray[2])
                           };




            return AVLeftFV;
        }
    }
}
