using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacion1
{
    public partial class formulario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarNombre(txtNombre.Text) == true) /// 
            {
                ddlNombre.Items.Add(txtNombre.Text);
                ordenarDropDownList(ddlNombre);
            }
            else
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "miAlerta",
                    "alert('" + " Nombre repetido" + "');",
                    true
                    );
            
            }
            limpiarTextBox(txtNombre);

        }

        private void ordenarDropDownList(DropDownList dropDownList)
        {
            // RECORRER INDICES DEL ARREGLO
            int i = 1;

            // DECLARO ARREGLO DE STRING
            string[] arreglo = new string[ddlNombre.Items.Count];

            // COPIAR CONTENIDO DEL DDL EN EL ARREGLO
            foreach (ListItem item in ddlNombre.Items)
            {
                arreglo[i] = item.ToString();
                i++;
            }

            /// ORDENAR
            Array.Sort(arreglo);

            /// COPIAR CONTENIDO DEL ARREGLO DDL
            ddlNombre.DataSource = arreglo;
            ddlNombre.DataBind();
        }

        private void limpiarTextBox(TextBox txtNombre)
        {
            txtNombre.Text = string.Empty;
        }

        ///  ESPECIFICADORES DE ACCESO
        ///  PRIVATE    -- NO PERMITE ACCESO POR FUERA DE LA CLASE -- NO PERMITE HERENCIA
        ///  PROTECTED  -- NO PERMITE ACCESO POR FUERA DE LA CLASE -- SI PERMITE HERENCIA
        ///  PUBLIC     --- HERENCIA---ACCEDO POR FUERA DE LA CLASE

        private bool validarNombre(string nombre)
        {
            /// SI EL NOMBRE SE RETIPE
            for (int i = 0; i < ddlNombre.Items.Count; i++)
            {
                if (nombre.ToUpper().Equals(ddlNombre.Items[i].ToString().ToUpper()))
                {
                     return false;
                }
            } 
            /// EL NOMBRE NO SE REPITE
            return true;
        }
    }
}