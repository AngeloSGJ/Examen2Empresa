using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Exam2Empresa.Clases
{
    public class MenuAsignaciones
    {
        public static int id { get; set; }

        public static int reid { get; set; }

        public static int tecid { get; set; }

        public static string fecha { get; set; }

        public MenuAsignaciones(int Id, int Reid, int Tecid, string Fecha)
        {
            id = Id;
            reid = Reid;
            tecid = Tecid;
            fecha = Fecha;
        }

        public static int Agregar(int id, int reid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTARASIGNACION", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ReparacionD", reid));
                    cmd.Parameters.Add(new SqlParameter("@Tecnicoid", tecid));



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

        public static int Actualizar(int id, int reid)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConeccion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZARASIGNACION_ID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id ));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reid));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecid));
                    cmd.Parameters.Add(new SqlParameter("@FECHAASIGNACION", fecha));

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