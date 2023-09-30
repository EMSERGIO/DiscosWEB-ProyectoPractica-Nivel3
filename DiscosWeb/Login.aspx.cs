using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscosWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // nos  va a permitir o no luego navegar en las pantallas permitidas
            MusicoFans musicoFans = new MusicoFans();
            MusicoFansNegocio negocio = new MusicoFansNegocio();
            try
            {
                musicoFans.Email = txtEmail.Text; 
                musicoFans.Pass = txtPassword.Text;
                if(negocio.Login(musicoFans))
                {
                    Session.Add("musicoFans", musicoFans);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Password incorrectos");
                    Response.Redirect("Error.aspx", false );
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}