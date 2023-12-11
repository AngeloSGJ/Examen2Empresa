using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam2Empresa.Clases
{
    public class MenuReparaciones
    {
        public static int id { get; set; }

        public static int eqid { get; set; }

        public static string fecha { get; set; }

        public static string esta { get; set; }

        public MenuReparaciones(int Id, int Eqid, string Fecha, string Esta)
        {
            id = Id;
            esta = Esta;
            fecha = Fecha;
            esta = Esta;
        }

        public static int Agregar(int id, int eqid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTARREPARACION", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", eqid));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", esta));



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
                    SqlCommand cmd = new SqlCommand("BORRARASIGNACION_ID", Conn)
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

        public static int Actualizar(int id, int eqid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAREPARACION_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", eqid));
                    cmd.Parameters.Add(new SqlParameter("@FECHASOLICITUD", fecha));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", esta));

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