using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcesionarioApp
{
    public static class Conexion
    {
        private static readonly string connectionString =
        "Data Source=UNO\\SQLEXPRESS;Initial Catalog=ConcesionarioDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

    }
}
