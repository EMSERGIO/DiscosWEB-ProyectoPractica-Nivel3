using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace DiscosWeb
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
                //configuracion inicial de la pantalla
                if (!IsPostBack)
                {
                    EstiloNegocio negocio = new EstiloNegocio();
                    List<Estilo> list = negocio.listar();
                    TipoEdicionNegocio negocio1 = new TipoEdicionNegocio();
                    List<TiposEdicion> list1 = negocio1.listar();

                    ddlEstilo.DataSource = list;
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataBind();

                    ddlTipoEdicion.DataSource = list1;
                    ddlTipoEdicion.DataValueField = "Id";
                    ddlTipoEdicion.DataTextField = "Descripcion";
                    ddlTipoEdicion.DataBind();
                }

                //configuracion si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    DiscosNegocio negocio = new DiscosNegocio();
                    //List<Discos> lista = negocio.listar(id);
                    //Discos seleccionado = lista[0];
                    Discos seleccionado = (negocio.listar(id)[0]);

                    
                    //pre cargar todos los campos...
                    txtId.Text = id;
                    txtTitulo.Text = seleccionado.Titulo;
                    txtFechaLanzamiento.Text = seleccionado.FechaLanzamiento.ToString();
                    txtCantidadCanciones.Text = seleccionado.CantidadCanciones.ToString();
                    txtUrlImagen.Text = seleccionado.UrlImagen;

                    ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                    ddlTipoEdicion.SelectedValue = seleccionado.TipoEdicion.Id.ToString();
                    //hacer un metodo para que precarge la imagen
                    txtUrlImagen_TextChanged(sender, e);


                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //redireccionar a una pantalla de error
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Discos nuevo = new Discos();
                DiscosNegocio negocio = new DiscosNegocio();

                nuevo.Titulo = txtTitulo.Text;
                nuevo.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                nuevo.FechaLanzamiento = txtFechaLanzamiento.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;

                nuevo.Estilo = new Estilo();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);
                nuevo.TipoEdicion = new TiposEdicion();
                nuevo.TipoEdicion.Id = int.Parse(ddlTipoEdicion.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
                    negocio.agregarConSP(nuevo);


                Response.Redirect("DiscosListar.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //redireccionar a una pantalla de error
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgDiscos.ImageUrl = txtUrlImagen.Text;
            //hacer un metodo de esto para que precarge la imagen
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmaEliminacion.Checked)
                {
                    DiscosNegocio negocio = new DiscosNegocio();
                    negocio.eliminarConSP(int.Parse(txtId.Text));
                    Response.Redirect("DiscosListar.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}