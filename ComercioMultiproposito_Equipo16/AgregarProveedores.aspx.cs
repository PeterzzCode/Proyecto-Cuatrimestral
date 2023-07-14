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
    public partial class AgregarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes Loguearte Para Ingresar");
                Response.Redirect("Error.aspx", false);
            }
            if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario != Dominio.TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes Ser Admin");
                Response.Redirect("ErrorLogin.aspx", false);
            }
            if (Request.QueryString["id"] != null)
            {
                ProveedoresNegocio negocio = new ProveedoresNegocio();

                lblAgregarProveedores.Visible = false;
                btnAgregarProveedores.Visible = false;

                string nom = Request.QueryString["id"];
                int num = int.Parse(Request.QueryString["id"]);

                List<Proveedor> listaProveedores = new List<Proveedor>();

                string cadena = negocio.TraerNombreProveedor(nom);
                listaProveedores = negocio.TraerUnRegistro(num);
                lblModificar.Text += cadena;
                if (!IsPostBack)
                {
                    txtNombreProveedores.Text = listaProveedores[0].Nombre;
                    txtEmailProveedores.Text = listaProveedores[0].Email;
                    txtDireccionProveedores.Text = listaProveedores[0].Domicilio;
                    txtTelefonoProveedores.Text = listaProveedores[0].Telefono;
                }
            }
            else
            {
                lblModificar.Visible = false;
                btnModificar.Visible = false;
            }



        }

        protected void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            string nombre = txtNombreProveedores.Text;
            string direccion = txtDireccionProveedores.Text;
            string telefono = txtTelefonoProveedores.Text;
            string correo = txtEmailProveedores.Text;

            if (nombre != "")
            {
                if (negocio.ExisteNombreProveedor(nombre) == false)
                {
                    Proveedor aux = new Proveedor();

                    aux.Codigo = negocio.TraerUltimoId();
                    aux.Nombre = nombre;
                    aux.Domicilio = direccion;
                    aux.Telefono = telefono;
                    aux.Email = correo;

                    negocio.AgregarProveedor(aux);
                    lblAviso.Text = "PROVEEDOR AÑADIDO CORRECTAMENTE";
                    lblAviso.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAviso.Text = "EL PROVEEDOR YA EXISTE";
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAviso.Text = "PROVEEDOR SIN NOMBRE, POR FAVOR INGRESE UNA NOMBRE PARA EL PROVEEDOR";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }



        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            string id = Request.QueryString["id"];

            string nombre = txtNombreProveedores.Text;

            if (nombre != "")
            {


                    Proveedor aux = new Proveedor();

                    aux.Codigo = negocio.TraerUltimoId();


                    if (txtTelefonoProveedores.Text != "" || txtEmailProveedores.Text != "")
                    {

                        aux.Telefono = txtTelefonoProveedores.Text;
                        aux.Domicilio = txtDireccionProveedores.Text;
                        aux.Email = txtEmailProveedores.Text;

                        if (txtNombreProveedores.Text != "")
                        {
                            aux.Nombre = txtNombreProveedores.Text;
                            negocio.ModificarProveedor(id, aux);
                            lblAviso.Text = "PROVEEDOR MODIFICADO CORRECTAMENTE";
                            lblAviso.ForeColor = System.Drawing.Color.Green;

                        }
                        else
                        {
                            lblAviso.Text = "POR FAVOR AÑADA UN NOMBRE";
                            lblAviso.ForeColor = System.Drawing.Color.Red;
                            txtNombreProveedores.BackColor = System.Drawing.Color.Red;
                        }


                    }
                    else
                    {
                        txtEmailProveedores.BackColor = System.Drawing.Color.Red;
                        txtTelefonoProveedores.BackColor = System.Drawing.Color.Red;
                        lblAviso.Text = "POR FAVOR AGREGAR UN CONTACTO: EMAIL O TELEFONO CELULAR";
                        lblAviso.ForeColor = System.Drawing.Color.Red;
                    }

             }


         }
     }
 }