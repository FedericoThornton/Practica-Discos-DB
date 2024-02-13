using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Proyecto_Discos
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
        
            if (!(Page is Login || Page is Default || Page is Registro))
            {
                if (!(Seguridad.sesionActiva(Session["Sesionactiva"])))
                {
                    Response.Redirect("Login.aspx", false);
                } else
                {
                    Usuario user = (Usuario)Session["Sesionactiva"];
                    lblUser.Text = user.Email;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        ImgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["Sesionactiva"]).ImagenPerfil;
                    }
                }
            }
          
            
               
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}