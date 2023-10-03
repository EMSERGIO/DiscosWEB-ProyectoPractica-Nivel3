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
        public void actualizar(MusicoFans user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set imagenPerfil = @imagen where ID = @id");
                datos.setearParametro("@imagen", user.ImagenPerfil);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

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
                return datos.ejecutarAccionScalar();


                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool Login(MusicoFans musicoFans)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin from USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", musicoFans.Email);
                datos.setearParametro("@pass", musicoFans.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    musicoFans.Id = (int)datos.Lector["id"];
                    musicoFans.Admin = (bool)datos.Lector["admin"];
                    return true;
                }
                return false;   

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }
    }
}
