using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class AgregarCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes Loguearte Para Ingresar");
                Response.Redirect("Error.aspx", false);
            }
            
            if (!IsPostBack)
            {
               
                cargarMediosDePago();
                CargarProductos();
            }

        }
        public void CargarProductos()
        {
            ddlProductos.Items.Add("Producto1");
            ddlProductos.Items.Add("Producto2");
            





        }


        public void cargarMediosDePago()
        {
            
            ddlMediosPago.Items.Add("Tarjeta de Credito");
            ddlMediosPago.Items.Add("Tarjeta de debito");
            ddlMediosPago.Items.Add("Transferencia");
            
        }



        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();


            try
            {
                if (ddlProductos.SelectedItem != null && ddlProductos.SelectedItem.Value != null)
                {
                    string ProductoSeleccionado = ddlProductos.SelectedItem.Value;
                    int cant = int.Parse(txtCantidad.Text);

                    if (cant > 0)
                    {
                        Response.Redirect("MisCompras.aspx");
                        Compra aux = new Compra();
                        CompraNegocio compraNegocio = new CompraNegocio();

                        aux.Codigo = compraNegocio.TraerUltimoId();

                        aux.FechaCompra = DateTime.Now;

                        aux.Producto = new Producto();
                        aux.Producto.Codigo = int.Parse(ProductoSeleccionado);

                        aux.Proveedor = new Proveedor();
                       

                     

                       
                    

                        aux.FormaPago = ddlMediosPago.SelectedItem.Text;

                        compraNegocio.Agregar(aux);
                    

                        negocio.modificarStock(ProductoSeleccionado, cant);



                        lblAviso.Text = "Pedido registrado con éxito";
                        lblAviso.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAviso.Text = "Seleccionar cantidad";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    lblAviso.Text = "Por favor seleccione un producto";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {


            ProductoNegocio negocio = new ProductoNegocio();


        }
    }
}