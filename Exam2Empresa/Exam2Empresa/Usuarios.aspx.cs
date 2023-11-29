using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace Exam2Empresa
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
        protected void LlenarGrid()
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                datagrid.DataSource = dt;
                                datagrid.DataBind();
                            }
                        }
                    }
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuario.Agregar(tnombre.Text, tcorr.Text, ttel.Text);

            if (resultado > 0)
            {
                alertas("El usuario ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar usuario");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuario.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("El usuario ha sido borrado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al intentar borrar el usuario");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuario.Actualizar(int.Parse(tcodigo.Text),tnombre.Text, tcorr.Text , int.Parse(ttel.Text));

            if (resultado > 0)
            {
                alertas("El usuario Se ha actualizado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al intentar actualizar el usuario");

            }
        }
        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios where Usuarioid=" + tcodigo.Text + ""))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Filtro();
        }
    }
} 