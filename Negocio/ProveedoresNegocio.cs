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
                datos.setearQuery("Select p.id as Id,p.nombre as Nombre,p.direccion as Direccion,p.telefono as Telefono,p.correo as Correo from Proveedores as p");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();



                    if (!(datos.Lector["id"] is DBNull))
                        aux.Codigo = (int)datos.Lector["id"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["nombre"];

                    if (!(datos.Lector["direccion"] is DBNull))
                        aux.Direccion = (string)datos.Lector["direccion"];

                    if (!(datos.Lector["telefono"] is DBNull))
                        aux.Telefono = (string)datos.Lector["telefono"];

                    if (!(datos.Lector["correo"] is DBNull))
                        aux.Correo = (string)datos.Lector["correo"];

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

        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Insert into Proveedores (id, Nombre, direccion, telefono, correo)  values (" + proveedor.Codigo + ", '" + proveedor.Nombre + "', '" + proveedor.Direccion + "', '" + proveedor.Telefono + "', '" + proveedor.Correo + "')");
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
                datos.setearQuery("delete from Proveedores where id= "+codigo);
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
                    string nombre =(string) datos.Lector["nombre"];
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


        public void ModificarProveedor(string id, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update Proveedores set nombre = '" + nombre + "' where id = " + id);
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

    }
}
