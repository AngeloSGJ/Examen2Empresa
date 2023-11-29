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
    public partial class Equipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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
            int resultado = Clases.Equipos.Agregar(tdescripcion.Text, tmodelo.Text, tusid.Text);

            if (resultado > 0)
            {
                alertas("El equipo ha sido ingresado con exito");
                tdescripcion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar tipo");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Equipos.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("Equipo borrado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al intentar borrar el equipo");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Equipos.Actualizar(int.Parse(tcodigo.Text), tdescripcion.Text, tmodelo.Text, int.Parse(tusid.Text));

            if (resultado > 0)
            {
                alertas("El equipo ha sido actualizado con exito");
                tdescripcion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar equipo");

            }
        }

        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos where Equipoid=" + tcodigo.Text + ""))
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