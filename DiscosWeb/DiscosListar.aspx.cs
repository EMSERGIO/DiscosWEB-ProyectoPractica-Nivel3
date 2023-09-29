using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Web.WebSockets;
using dominio;

namespace DiscosWeb
{
    public partial class DiscosListar : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = ckbAvanzado.Checked;
            if (!IsPostBack)
            {
                //se mantiene el filtro avanzado oculto
                DiscosNegocio negocio = new DiscosNegocio();
                Session.Add("listaDiscos", negocio.listarConSP());
                dgvDiscos.DataSource = Session["listaDiscos"];
                dgvDiscos.DataBind();
            }
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDiscos.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Discos> lista = (List<Discos>)Session["listaDiscos"];
            List<Discos> listaFiltrada = lista.FindAll(x => x.Titulo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvDiscos.DataSource = listaFiltrada;
            dgvDiscos.DataBind();
        }

        protected void ckbAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            //se mantiene el filtro avanzado oculto hasta que lo check y se muestra
            FiltroAvanzado = ckbAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //desde el critero campo cargamos los otros desplegables
       
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Cantidad de Canciones")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DiscosNegocio negocio = new DiscosNegocio();
                dgvDiscos.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(), 
                    ddlCriterio.SelectedItem.ToString(), 
                    txtFiltroAvanzado.Text);
                dgvDiscos.DataBind();
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            Session.Add("listaDiscos", negocio.listarConSP());
            dgvDiscos.DataSource = Session["listaDiscos"];
            dgvDiscos.DataBind();

            txtFiltro.Text = string.Empty;
            txtFiltroAvanzado.Text = string.Empty;
        }
    }
}