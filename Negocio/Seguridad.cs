using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            MusicoFans musicoFans =user != null ? (MusicoFans)user : null;
            if (musicoFans != null && musicoFans.Id != 0)
                return true;
            else
                return false;
        }
        public static bool esAdmin(object user)
        {
            MusicoFans musicoFans = user != null ? (MusicoFans)user : null;
            return musicoFans != null ? musicoFans.Admin : false;
        }
    }
}
