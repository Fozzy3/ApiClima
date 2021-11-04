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

         public static bool Registrar (Guardar oGuardar)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ciudad", oGuardar.Ciudad);
                cmd.Parameters.AddWithValue("@Otro", oGuardar.Otro);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }catch(Exception e)
                {
                    return false;
                }

            }
        }
        public static List<Usuario> Listar()
        {
            List<Usuario> oListarUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar_inicio", oConexion);
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
                                ID = Convert.ToInt32(dr["ID"]),
                                Ciudad = dr["Ciudad"].ToString(),
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

        public static List<Inicio> ListarInicio()
        {
            List<Inicio> oListarInicio = new List<Inicio>();
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
                            oListarInicio.Add(new Inicio()
                            {
                                idCiudad = Convert.ToInt32(dr["idCiudad"]),
                                Ciudad = dr["Ciudad"].ToString(),
                                Otro = dr["Otro"].ToString()
                            });
                        }
                    }
                    return oListarInicio;
                }
                catch (Exception ex)
                {
                    return oListarInicio;
                }

            }
        }
    }
}