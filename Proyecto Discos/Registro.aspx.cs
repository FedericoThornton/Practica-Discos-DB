﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Proyecto_Discos
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {

           
                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
             

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = negocio.insertarNuevo(user);
                Session.Add("Sesionactiva", user);

                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }
    }
}