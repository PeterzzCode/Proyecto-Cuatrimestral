using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ProveedoresNegocio
    {

        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select p.id as ID,p.nombre as Nombre,p.direccion as Domicilio, p.telefono as Telefono, p.correo as Email from Proveedores as p");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();



                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Codigo = (int)datos.Lector["ID"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Domicilio"] is DBNull))
                        aux.Domicilio = (string)datos.Lector["Domicilio"];

                    if (!(datos.Lector["Telefono"] is DBNull))
                        aux.Telefono = (string)datos.Lector["Telefono"];

                    if (!(datos.Lector["Email"] is DBNull))
                        aux.Email = (string)datos.Lector["Email"];




                    lista.Add(aux);
                }

                return lista;
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


        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearQuery("select top(1) id from Proveedores order by id desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cont = (int)datos.Lector["id"];
                }

                return cont + 1;
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


        public List<Producto> buscarProductos(string codigo)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();



            try
            {
                datos.setearQuery("Select p.id as ID,p.nombre as Nombre,p.id_marca as IdMarca,p.id_categoria as IdCategoria,p.stock_actual as Stock,p.stock_minimo as StockMin,p.descripcion as Descripcion,p.ganancia as Ganancia from Productos as p inner join Proveedores_Productos as pxp on pxp.id_producto = p.id inner join Proveedores as proveedor on proveedor.id = pxp.id_proveedor where pxp.id_proveedor = " + codigo);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    if (!(datos.Lector["ID"] is DBNull))
                        aux.Codigo = (int)datos.Lector["ID"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.NombreProducto = (string)datos.Lector["Nombre"];

                    aux.Marca = new Marca();

                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.Codigo = (int)datos.Lector["IdMarca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];

                    if (!(datos.Lector["Stock"] is DBNull))
                        aux.Stock = (int)datos.Lector["Stock"];

                    if (!(datos.Lector["StockMin"] is DBNull))
                        aux.StockMin = (int)datos.Lector["StockMin"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Ganancia"] is DBNull))
                        aux.Ganancia = (int)datos.Lector["Ganancia"];

                    lista.Add(aux);
                }

                return lista;
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

        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("INSERT INTO Proveedores (id, Nombre, Direccion, Telefono, Correo) VALUES (" + proveedor.Codigo + ", '" + proveedor.Nombre + "', '" + proveedor.Domicilio + "', '" + proveedor.Telefono + "', '" + proveedor.Email + "')");
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




        public void EliminarProveedor(string codigo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("delete from Proveedores where id= " + codigo);
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
        public bool ExisteNombreProveedor(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select id from Proveedores where nombre = '" + nombre + "'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
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

        public string TraerNombreProveedor(string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {


                datos.setearQuery("select nombre from Proveedores where id =" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string nombre = (string)datos.Lector["nombre"];
                    return nombre;
                }

                return "";

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


        public void ModificarProveedor(string id, Proveedor proveedor)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("UPDATE Proveedores SET nombre = '" + proveedor.Nombre + "', telefono = '" + proveedor.Telefono + "', " + "direccion = '" + proveedor.Domicilio + "', correo = '" + proveedor.Email + "' WHERE id = " + id);
                datos.ejecutarLectura();

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

        public List<Proveedor> TraerUnRegistro(int cod)
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("select c.id as id,c.nombre as nombre,c.direccion as domicilio,c.telefono as telefono,c.correo as correo from Proveedores as c");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();

                    if (cod == (int)datos.Lector["id"])
                    {
                        if (!(datos.Lector["Id"] is DBNull))
                            aux.Codigo = (int)datos.Lector["Id"];


                        if (!(datos.Lector["nombre"] is DBNull))
                            aux.Nombre = (string)datos.Lector["nombre"];


                        if (!(datos.Lector["domicilio"] is DBNull))
                            aux.Domicilio = (string)datos.Lector["domicilio"];
                        else
                            aux.Domicilio = "Sin Domicilio registrado";

                        if (!(datos.Lector["correo"] is DBNull))
                            aux.Email = (string)datos.Lector["correo"];

                        if (!(datos.Lector["telefono"] is DBNull))
                            aux.Telefono = (string)datos.Lector["telefono"];



                        lista.Add(aux);
                        return lista;
                    }

                }

                return lista;
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

    }
}
