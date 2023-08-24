using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace negocio
{
    public class DiscosNegocio
    {
        public List<Discos> listar()
        {
            List<Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select D.Titulo, FechaLanzamiento, UrlImagenTapa, CantidadCanciones, E.Descripcion Estilo, F.Descripcion TiposEdicion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION F where  E.Id = D.IdEstilo and F.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento =lector["FechaLanzamiento"].ToString();
                    aux.CantidadCanciones = lector.GetInt32(3);
                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.TipoEdicion = new TiposEdicion();
                    aux.TipoEdicion.Id = (int)lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)lector["TiposEdicion"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
        public List<Discos> listarConSP()
        {
            List<Discos> lista = new List<Discos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Historico con consulta envevida y sensible
                //string consulta = "select D.Titulo, FechaLanzamiento, UrlImagenTapa, CantidadCanciones, E.Descripcion Estilo, F.Descripcion TiposEdicion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION F where  E.Id = D.IdEstilo and F.Id = D.IdTipoEdicion";
                //datos.setearConsulta(consulta);

                //Nuevo con procedimiento almacenado en DB
                datos.setearProcedimiento("storeListar");
                datos.ejecutarLectura();
                while (datos.lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Titulo = (string)datos.lector["Titulo"];
                    aux.FechaLanzamiento = datos.lector["FechaLanzamiento"].ToString();
                    aux.CantidadCanciones = datos.lector.GetInt32(3);
                    if (!(datos.lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)datos.lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.lector["Estilo"];
                    aux.TipoEdicion = new TiposEdicion();
                    aux.TipoEdicion.Id = (int)datos.lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.lector["TiposEdicion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Discos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo, CantidadCanciones,UrlImagenTapa,FechaLanzamiento,IdEstilo,IdTipoEdicion) values ('"+nuevo.Titulo+"','"+nuevo.CantidadCanciones+"','"+nuevo.UrlImagen+"',@FechaLanzamiento, @idEstilo, @idTipoEdicion)");
                datos.setearParametro("@FechaLanzamiento", nuevo.FechaLanzamiento);
                datos.setearParametro("@idEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", nuevo.TipoEdicion.Id);
                datos.ejecutarAccion(); 
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }
        public void modificar(Discos disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fecha, CantidadCanciones = @cantidadCanciones, UrlImagenTapa = @UrlImagen ,IdEstilo = @idEstilo, IdTipoEdicion = @idtipoEdicion where Id = @Id");
                datos.setearParametro("@titulo", disco.Titulo);
                datos.setearParametro("@fecha", disco.FechaLanzamiento);
                datos.setearParametro("@cantidadCanciones", disco.CantidadCanciones);
                datos.setearParametro("@UrlImagen", disco.UrlImagen);
                datos.setearParametro("@idEstilo", disco.Estilo.Id);
                datos.setearParametro("@idtipoEdicion", disco.TipoEdicion.Id);
                datos.setearParametro("@Id", disco.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from DISCOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Discos> filtrar(string campo, string criterio, string filtro)
        {
            List<Discos> lista = new List<Discos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select D.Titulo, FechaLanzamiento, UrlImagenTapa, CantidadCanciones, E.Descripcion Estilo, F.Descripcion TiposEdicion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION F where  E.Id = D.IdEstilo and F.Id = D.IdTipoEdicion and ";
                if (campo == "Cantidad de Canciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "CantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += "CantidadCanciones = " + filtro;
                            break;
                    }
                }
                else if(campo == "Titulo")
                {

                     switch (criterio)
                     {
                         case "Comienza con":
                             consulta += "D.Titulo like '" + filtro + "%' ";
                             break;
                         case "Termina con":   
                             consulta += "D.Titulo like '%" + filtro + "' ";
                             break;     
                         default:   
                             consulta += "D.Titulo like '%" + filtro + "%' ";
                             break;     
                     }
                }
                else if (campo == "Estilo")
                {

                     switch (criterio)
                     {
                          case "Comienza con":
                              consulta += "E.Descripcion like '" + filtro + "%' ";
                              break;
                          case "Termina con":
                              consulta += "E.Descripcion like '%" + filtro + "' ";
                              break;
                          default:
                              consulta += "E.Descripcion like '%" + filtro + "%' ";
                              break;
                     }
                }
           
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Titulo = (string)datos.lector["Titulo"];
                    aux.FechaLanzamiento = datos.lector["FechaLanzamiento"].ToString();
                    aux.CantidadCanciones = datos.lector.GetInt32(3);
                    if (!(datos.lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)datos.lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.lector["Estilo"];
                    aux.TipoEdicion = new TiposEdicion();
                    aux.TipoEdicion.Id = (int)datos.lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.lector["TiposEdicion"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
