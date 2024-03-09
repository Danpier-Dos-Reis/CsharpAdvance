using System;
using System.Data;
using System.Reflection.Emit;

namespace CsharpLinqTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            
            if (controller.TestDBConnection())
            { Console.WriteLine("Connection Successfull"); }
            else
            { Console.WriteLine("Connection is not Successfull"); }

            //PrintSells(controller);
            //PrintSellOne(controller);
            PrintSellsPerArticles(controller);
        }

        private static void PrintSellsPerArticles(Controller controller)
        {
            Console.Write("Write a number Id of an product: ");
            Int64 value = Convert.ToInt64(Console.ReadLine());

            if (value is Int64)
            {
                IEnumerable<object> result = controller.GetArticles(value);

                foreach (object item in result)
                {
                    Console.Write(item.ToString() + "\n");
                }
            }
            else { Console.Write("\n\nNo escribiste un número"); }

        }

        private static void PrintSellOne(Controller controller)
        {
            DataTable tbl = controller.GetSells();

            // Filtra las filas donde el valor de la columna "Id" sea igual a 1
            var rowsWithIdOne = from DataRow row in tbl.Rows
                                where Convert.ToInt32(row[0]) == 1
                                select row;

            // Crea un nuevo DataTable con las filas filtradas
            DataTable tblOne = tbl.Clone();
            foreach (DataRow row in rowsWithIdOne)
            {
                tblOne.ImportRow(row);
            }

            //Print Columns
            int columnNumber = 1;
            foreach (DataColumn c in tblOne.Columns)
            {
                Console.Write(c.ColumnName + (5 == columnNumber ? "\n\n" : " ; "));
                columnNumber++;
            }

            //Print Rows
            columnNumber = 1;
            foreach (DataRow r in tblOne.Rows)
            {
                foreach (DataColumn c in tblOne.Columns)
                {
                    Console.Write(r[c].ToString() + (5 == columnNumber ? "\n" : " ; "));
                    columnNumber++;
                }
                columnNumber = 1;
            }

        }

        private static void PrintSells(Controller controller)
        {
            DataTable table = controller.GetSells();

            //Print Columns
            int columnNumber = 1;
            foreach (DataColumn c in table.Columns)
            {
                Console.Write(c.ColumnName + (5 == columnNumber ? "\n\n" : " ; "));
                columnNumber++;
            }

            //Print Rows
            columnNumber = 1;
            foreach (DataRow r in table.Rows)
            {
                foreach (DataColumn c in table.Columns)
                {
                    Console.Write(r[c].ToString() + (5 == columnNumber ? "\n" : " ; "));
                    columnNumber++;
                }
                columnNumber = 1;
            }
        }
    }
}