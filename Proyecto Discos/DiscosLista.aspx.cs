using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Proyecto_Discos
{
    public partial class DiscosLista : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.esAdmin(Session["Sesionactiva"]))
                {
                    Session.Add("error", "Se requiere permiso de Admin");
                    Response.Redirect("Error.aspx", false);
                }

                DiscoNegocio negocio = new DiscoNegocio();
                Session.Add("listaDiscos", negocio.listarconSP());
                dgvDiscos.DataSource = Session["listaDiscos"];
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }  
        }

        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDiscos.aspx?id=" + id);
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> lista = (List<Disco>)Session["listaDiscos"];
            List<Disco> filtrada = lista.FindAll(x => x.Titulo.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvDiscos.DataSource = filtrada;
            dgvDiscos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkAvanzado.Checked;
            txtfiltro.Enabled = !filtroAvanzado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
              
                dgvDiscos.DataSource = negocio.filtrar(DdlCampo.SelectedItem.ToString(),
                DdlCriterio.SelectedItem.ToString(),
                TxtFiltroavanzado.Text);
                dgvDiscos.DataBind();
             


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            DdlCriterio.Items.Clear();
            if (DdlCampo.SelectedItem.ToString() == "Canciones")
            {
                DdlCriterio.Items.Add("Igual a");
                DdlCriterio.Items.Add("Mayor a");
                DdlCriterio.Items.Add("Menor a");

            }
            else
            {
                DdlCriterio.Items.Add("Contiene");
                DdlCriterio.Items.Add("Comienza con");
                DdlCriterio.Items.Add("Termina con");

            }

        }

        protected void DdlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}