using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Collections;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Codigo, Nombre,A.Descripcion as Detalle, ImagenUrl as UrlImagen, Precio , C.Descripcion as Categoria, M.Descripcion as Marcas, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A,CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria and M.Id = A.IdMarca";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Detalle"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Precio = (float)(Decimal)lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.Marcas = new Marcas();
                    aux.Marcas.Id = (int)lector["IdMarca"];
                    aux.Marcas.Descripcion = (string)lector["Marcas"];


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
        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
             try
             {
                datos.setearConsulta("Insert Into Articulos (Codigo, Nombre, Descripcion, ImagenUrl, Precio, IdMarca, IdCategoria) values (@Codigo, @Nombre, @Descripcion, @ImagenUrl, @Precio, @IdMarca, @IdCategoria)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdMarca", nuevo.Marcas.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);

                datos.ejecutarAccion();
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
        public void modificar(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @UrlImagen, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marcas.Id);
                datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                datos.setearParametro("@UrlImagen", modificar.UrlImagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}

        }
        public void eliminar (int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Codigo, Nombre,A.Descripcion as Detalle, ImagenUrl as UrlImagen, Precio , C.Descripcion as Categoria, M.Descripcion as Marcas, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A,CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria and M.Id = A.IdMarca and ";
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            case "Igual a":
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro +"%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marcas":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)datos.lector["Id"];
                    aux.Codigo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Detalle"];
                    aux.UrlImagen = (string)datos.lector["UrlImagen"];
                    aux.Precio = (float)(Decimal)datos.lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.lector["Categoria"];
                    aux.Marcas = new Marcas();
                    aux.Marcas.Id = (int)datos.lector["IdMarca"];
                    aux.Marcas.Descripcion = (string)datos.lector["Marcas"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void verDetalle(Articulos detalle)
        {
        }

    }
    
}
