using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ejemplo01
{
    public partial class formulario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarNombre(txtNombre.Text))
            {
                ddlNombre.Items.Add(txtNombre.Text);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Nombre repetido" + "');", true);
            }

            limpiarTexBox(txtNombre);

            ordenarDropDownList(ddlNombre);
        }

        private void ordenarDropDownList(DropDownList ddlNombre)
        {
            int i = 0;
            string[] arreglo = new string[ddlNombre.Items.Count];

            foreach(ListItem lista in ddlNombre.Items)
            {
                arreglo[i] = lista.ToString();
                i++;
            }

            Array.Sort(arreglo);

            ddlNombre.DataSource = arreglo;
            ddlNombre.DataBind();
        }

        private bool validarNombre(string nombre)
        {
            for(int i = 0;  i < ddlNombre.Items.Count; i++)
            {
                if (nombre.ToLower().Equals(ddlNombre.Items[i].ToString().ToLower()))
                {
                    return false;
                }

            }
            return true;
        }

        private void limpiarTexBox(TextBox text)
        {
            text.Text = string.Empty;
        }

    }
}