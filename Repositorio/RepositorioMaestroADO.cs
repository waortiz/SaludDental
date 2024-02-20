using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioMaestroADO : IRepositorioMaestro
    {
        public List<Ciudad> ObtenerCiudades(int idDepartamento)
        {
            var ciudades = new List<Ciudad>();

            var cadenaConexion = ConfigurationManager.ConnectionStrings["SaludDental"].ConnectionString;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Nombre FROM Ciudades WHERE IdDepartamento = @IdDepartamento ORDER BY Nombre";
                comando.Connection = conexion;
                comando.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ciudades.Add(new Ciudad() 
                        { 
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        });
                    }
                }                
            }

            return ciudades;
        }

        public List<Departamento> ObtenerDepartamentos()
        {
            var departamentos = new List<Departamento>();

            var cadenaConexion = ConfigurationManager.ConnectionStrings["SaludDental"].ConnectionString;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Nombre FROM Departamentos ORDER BY Nombre";
                comando.Connection = conexion;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departamentos.Add(new Departamento()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        });
                    }
                }
            }

            return departamentos;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            var tiposDocumento = new List<TipoDocumento>();

            var cadenaConexion = ConfigurationManager.ConnectionStrings["SaludDental"].ConnectionString;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Nombre FROM TiposDocumento ORDER BY Nombre";
                comando.Connection = conexion;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposDocumento.Add(new TipoDocumento()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = Convert.ToString(reader["Nombre"])
                        });
                    }
                }
            }

            return tiposDocumento;
        }
    }
}
