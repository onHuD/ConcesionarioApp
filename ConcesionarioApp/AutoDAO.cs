using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcesionarioApp
{
    public class AutoDAO
    {
        // LEER SELECT

        public List<Auto> ObtenerTodos()
        {
            var lista = new List<Auto>();
            string query = "SELECT Id, Marca, Modelo, Anio, Color, Precio, Stock FROM Autos ORDER BY Id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Auto
                        {
                            Id = lector.GetInt32(0),
                            Marca = lector.GetString(1),
                            Modelo = lector.GetString(2),
                            Anio = lector.GetInt32(3),
                            Color = lector.GetString(4),
                            Precio = lector.GetDecimal(5),
                            Stock = lector.GetInt32(6)
                        });
                    }
                }
            }
            return lista;
        }

        // CREAR INSERT

        public bool Agregar(Auto auto)
        {
            string query = "INSERT INTO Autos (Marca, Modelo, Anio, Color, Precio, Stock) VALUES (@Marca, @Modelo, @Anio, @Color, @Precio, @Stock)";
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Marca", auto.Marca);
                comando.Parameters.AddWithValue("@Modelo", auto.Modelo);
                comando.Parameters.AddWithValue("@Anio", auto.Anio);
                comando.Parameters.AddWithValue("@Color", auto.Color);
                comando.Parameters.AddWithValue("@Precio", auto.Precio);
                comando.Parameters.AddWithValue("@Stock", auto.Stock);
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }

        }

        // ACTUALIZAR UPDATE

        public bool Modificar(Auto auto)
        { 
        
            string query = "UPDATE Autos " +
                "SET Marca = @Marca, Modelo = @Modelo, Anio = @Anio, Color = @Color, Precio = @Precio, Stock = @Stock " +
                "WHERE Id = @Id";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Id", auto.Id);
                comando.Parameters.AddWithValue("@Marca", auto.Marca);
                comando.Parameters.AddWithValue("@Modelo", auto.Modelo);
                comando.Parameters.AddWithValue ("@Anio", auto.Anio);
                comando.Parameters.AddWithValue("@Color", auto.Color);
                comando.Parameters.AddWithValue("@Precio", auto.Precio);
                comando.Parameters.AddWithValue("@Stock", auto.Stock);
                
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        // ELIMINAR DELETE

            public bool Eliminar(int id)
            {
                string query = "DELETE FROM Autos WHERE Id = @Id";
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
    }
}