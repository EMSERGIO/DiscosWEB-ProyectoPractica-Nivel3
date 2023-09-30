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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try 
            {
                MusicoFans user = new MusicoFans();
                MusicoFansNegocio musicoFansNegocio = new MusicoFansNegocio();
                EmailService emailService = new EmailService();
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = musicoFansNegocio.insertarNuevo(user);

                emailService.armarCorreo(user.Email, "Bienvenido Musico Fans", "Hola te damos la bienvenida a la aplicacion...");
                emailService.enviarEmail();
                Response.Redirect("Default", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}