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
    public partial class Formulario_web1 : System.Web.UI.Page
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
                    using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones"))
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
                    using (SqlCommand cmd = new SqlCommand("CONSULTARTECNICOS"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                DropDownList2.DataSource = dt;

                                DropDownList2.DataTextField = dt.Columns["nombre"].ToString();
                                DropDownList2.DataBind();
                            }
                        }
                    }
                }
            }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.MenuAsignaciones.Agregar(int.Parse(tasignacion.Text), int.Parse(treparacion.Text));

            if (resultado > 0)
            {
                alertas("La asignacion ha sido agregadaa con exito");
                tasignacion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar asignacion");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.MenuAsignaciones.Borrar(int.Parse(tasignacion.Text));

            if (resultado > 0)
            {
                alertas("Asignacion borrada con exito");
                tasignacion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al intentar borrar la asignacion");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.MenuAsignaciones.Actualizar(int.Parse(tasignacion.Text), int.Parse(treparacion.Text));

            if (resultado > 0)
            {
                alertas("Asignacion actualizada con exito");
                tasignacion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar la asignacion");

            }
        }
        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones where Asignacionid=" + tasignacion.Text + ""))
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
       
