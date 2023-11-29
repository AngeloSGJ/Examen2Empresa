using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam2Empresa.Clases
{
    public class Usuario
    {
        public static int id { get; set; }

        public static string nombre { get; set; }

        public static string correo { get; set; }

        public static int tel { get; set; }

        public Usuario(int Id, string Nombre, string Correo, int Tel)
        {
            id = Id;
            nombre = Nombre;
            correo = Correo;
            tel = Tel;
        }

        public static int Agregar(string nombre, string correo, string tel ) 
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTARUSUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", tel));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int Borrar(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARUSUARIOS_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
 
              
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int Actualizar(int id, string nombre, string correo, int tel)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZARUSUARIO_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", tel));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}