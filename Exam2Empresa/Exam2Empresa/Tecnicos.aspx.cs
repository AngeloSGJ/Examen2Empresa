using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;

namespace Exam2Empresa
{
    public partial class Tecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM  Tecnicos"))
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
            int resultado = Clases.Tecnicos.Agregar(tdescripcion.Text , tespec.Text);

            if (resultado > 0)
            {
                alertas("El Tecnico ha sido ingresado con exito");
                tdescripcion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar el tecnico");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Tecnicos.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("El tecnico ha sido borrado con exito");
                tcodigo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al intentar borrar el tecnico");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Tecnicos.Actualizar(int.Parse(tcodigo.Text), tdescripcion.Text, tespec.Text);

            if (resultado > 0)
            {
                alertas("El Tecnico ha sido actualizado con exito");
                tcodigo.Text = string.Empty;
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos where Tecnicoid=" + tcodigo.Text + ""))
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