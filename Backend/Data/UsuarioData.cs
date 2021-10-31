using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Backend.Data
{
    public class UsuarioData
    {
        public static List<Usuario> Listar()
        {
            List<Usuario> oListarUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListarUsuario.Add(new Usuario()
                            {
                                IdCiudad = Convert.ToInt32(dr["IdCiudad"]),
                                Ciudad = dr["Ciudad"].ToString(),
                                Otro = dr["Otro"].ToString()
                            });
                        }
                    }
                        return oListarUsuario;
                }
                catch (Exception ex)
                {
                    return oListarUsuario;
                }

            }
        }
    }
}