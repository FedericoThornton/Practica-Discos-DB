using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Proyecto_Discos
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["Sesionactiva"]))
                    {
                        Usuario user = (Usuario)Session["Sesionactiva"];
                        txtEmail.Text = user.Email;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                          ImagenNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }




            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // guardar archivo y leer archivo 
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                string ruta = Server.MapPath("./Images/");
                Usuario user = (Usuario)Session["Sesionactiva"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                if (txtimagen.PostedFile.FileName != "")
                {
                    txtimagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                  
                }
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                negocio.actualizar(user);

                Master.FindControl("imgAvatar");

                //leer
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }

            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}