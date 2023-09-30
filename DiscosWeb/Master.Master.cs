using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace DiscosWeb
{
    public partial class DiscosAspx : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validando desde la master que si no estar logeado no puedas ingresar a diferentes
            //pantallas, y eceptuando las que si se pueden ver sin estar logeados
            //recordando que estamos en la MastewrPage principal, es el primera entrada despues de dar
            //la orden para redirigir a las pantallas a verificar

            if (!(Page is Login))
            {
                if (!Seguridad.sesionActiva(Session["musicoFans"]))
                    Response.Redirect("Login.aspx", false);
            }
        }
    }
}