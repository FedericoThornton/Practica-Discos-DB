using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Web.Services.Discovery;
using System.Runtime.InteropServices;

namespace Proyecto_Discos
{
    public partial class FormularioDiscos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    EstiloNegocio negocio = new EstiloNegocio();
                    FormatoNegocio formatonegocio = new FormatoNegocio();

                    List<Estilo> lista = negocio.listar();
                    List<Formato> listaformato = formatonegocio.listar();

                    ddlFormato.DataSource = listaformato;
                    ddlFormato.DataValueField = "Id";
                    ddlFormato.DataTextField = "Descripcion";
                    ddlFormato.DataBind();

                    ddlGenero.DataSource = lista;
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataBind();


                }
                // configuracion de modificacion siempre abajo para que se carquen los desplegables 
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)

                {
                    DiscoNegocio negocio = new DiscoNegocio();
                    Disco seleccionado = negocio.listar(id)[0];

                    txtId.Text = id;
                    txtTitulo.Text = seleccionado.Titulo;
                    txtCanciones.Text = seleccionado.Canciones.ToString();
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    ddlFormato.SelectedValue = seleccionado.Edicion.Id.ToString();
                    ddlGenero.SelectedValue = seleccionado.Genero.Id.ToString();
                    txtUrlImagen_TextChanged(sender, e);



                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                Disco nuevo = new Disco();
                DiscoNegocio negocio = new DiscoNegocio();

                nuevo.Titulo = txtTitulo.Text;
                nuevo.Canciones = int.Parse(txtCanciones.Text);
                nuevo.UrlImagen = txtUrlImagen.Text;
                nuevo.Genero = new Estilo();
                nuevo.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                nuevo.Edicion = new Formato();
                nuevo.Edicion.Id = int.Parse(ddlFormato.SelectedValue);



                if (Request.QueryString["id"] != null)
                {

                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }


                else
                {
                    negocio.agregarconSP(nuevo);
                }



                Response.Redirect("DiscosLista.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            ImageDiscos.ImageUrl = txtUrlImagen.Text;
        }


        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void ConfirmaEliminar_Click(object sender, EventArgs e)
        {
       //     try
       //     {
       //         if (chkConfirmaEliminacion.Checked)
       //         {

       //             DiscoNegocio negocio = new DiscoNegocio();
       //             negocio.EliminarconSP = int.Parse(txtId.Text);
       //             Response.Redirect("DiscosLista.aspx");
       //         }


        //    }
      //      catch (Exception ex)
      //      {
       //         Session.Add("error", ex.ToString());
       //         Response.Redirect("Error.aspx");

       //     }
        }
    }
}