using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Linq.Expressions;

namespace ConexionADODatasetsEntity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Forma ADO.net Data Provider
            Console.WriteLine("Forma ADO");
            string conectionString = "Data Source=localhost;" +
                "Initial Catalog=ConexionPrueba;" +
                "User id=sa;" +
                "Password=root;";
            string query = "SELECT * FROM Nombres";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0},{1},{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Forma DATASET
            Console.WriteLine("Forma Dataset");
            var ta = new MiDataSetTableAdapters.NombresTableAdapter();
            var dt = ta.GetData();

            foreach (MiDataSet.NombresRow row in dt.Rows)
            {
                Console.WriteLine("{0},{1},{2}",
                            row.id,row.Nombre,row.Apellido);
            }
            dt.Dispose();
            ta.Dispose();

            //Forma DATASET
            Console.WriteLine("Forma Entity Framework");
            using (var db = new Model.ConexionPruebaEntities())
            {
                var lst = db.Nombres;
                foreach (var row in lst)
                    Console.WriteLine("{0},{1},{2}",
                          row.id, row.Nombre, row.Apellido);
            }

         }
    }
}
