using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam2Empresa.Clases
{
    public class Equipos
    {
        public static int eqid { get; set; }

        public static string tipo { get; set; }

        public static string modelo { get; set; }

        public static string usid { get; set; }

        public Equipos(int EQID, string Tipo, string Modelo, string USID)
        {
            eqid = EQID;
            tipo = Tipo;
            modelo = Modelo;
            usid = USID;
        }

        public static int Agregar(string tipo, string modelo, string usid) 
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usid));


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


        public static int Borrar(int eqid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAREQUIPOS_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", eqid));
        
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

        public static int Actualizar( int eqid, string tipo, string modelo, int usid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAREQUIPO_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", eqid));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usid));


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