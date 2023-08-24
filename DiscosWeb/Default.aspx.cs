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
    public partial class Default : System.Web.UI.Page
    {
        public List<Discos> ListaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            ListaDiscos = negocio.listarConSP();

            //cargando el Repetidor
            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaDiscos;
                repRepetidor.DataBind();
            }
                
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}