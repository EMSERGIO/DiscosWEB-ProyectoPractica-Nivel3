using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MusicoFansNegocio
    {
        //id, email, pass, admin false

        //nombre, apellido, fecha, imagen

        public int insertarNuevo(MusicoFans nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);


                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
