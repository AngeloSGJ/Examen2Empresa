using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exam2Empresa
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDropdown();
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Reparaciones"))
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
        protected void LlenarDropdown()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("consultaestados"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownList2.DataSource = dt;

                            DropDownList2.DataTextField = dt.Columns["ESTADO"].ToString();
                            DropDownList2.DataBind();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.MenuReparaciones.Agregar(int.Parse(treparacion.Text), int.Parse(tequipo.Text));

            if (resultado > 0)
            {
                alertas("El Tecnico ha sido ingresado con exito");
                treparacion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar el tecnico");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.MenuReparaciones.Borrar(int.Parse(treparacion.Text));

            if (resultado > 0)
            {
                alertas("El tecnico ha sido borrado con exito");
                treparacion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al intentar borrar el tecnico");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.MenuReparaciones.Actualizar(int.Parse(treparacion.Text), int.Parse(tequipo.Text));

            if (resultado > 0)
            {
                alertas("El Tecnico ha sido actualizado con exito");
                treparacion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar el tecnico");

            }
        }
        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM REPARACIONES where Reparacionid=" + treparacion.Text + ""))
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
    
