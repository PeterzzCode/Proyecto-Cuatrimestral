﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class AgregarProducto : System.Web.UI.Page
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



            ProductoNegocio negocio = new ProductoNegocio();

            if (Request.QueryString["id"] != null)
            {
                btnAgregar.Visible = false;
                lblAgregar.Visible = false;

                int id = int.Parse(Request.QueryString["id"]);

                List<Producto> listProductos = new List<Producto>();

                listProductos = negocio.TraerUnRegistro(id);
                if(!IsPostBack)
                {
                    txtCodigo.Text = listProductos[0].Codigo.ToString();
                    txtDescripcion.Text = listProductos[0].Descripcion;
                    txtGanancia.Text = listProductos[0].Ganancia.ToString();
                    txtPrecio.Text = listProductos[0].Precio.ToString();
                   
                    txtProducto.Text = listProductos[0].NombreProducto;
                    txtStock.Text = listProductos[0].Stock.ToString();
                    txtStockMin.Text = listProductos[0].StockMin.ToString();

                }

                //Modificar

                try
                    {

                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        ddListMarca.DataSource = marcaNegocio.listar();
                        ddListMarca.DataBind();
                        ddListCategoria.DataSource = categoriaNegocio.listar();
                        ddListCategoria.DataBind();


                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                
            }
            else
            {
                //Agregar
               
                    try
                    {

                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        btnModificar.Visible = false;
                        lblModificar.Visible = false;    

                        int cod = negocio.TraerUltimoId();
                        txtCodigo.Text = cod.ToString();

                        ddListMarca.DataSource = marcaNegocio.listar();
                        ddListMarca.DataBind();
                        ddListCategoria.DataSource = categoriaNegocio.listar();
                        ddListCategoria.DataBind();


                    }

                    catch (Exception ex)
                    {

                        throw ex;
                    }

                
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
            

            try
            {

                Producto aux = new Producto();
                            
                aux.Codigo =int.Parse(txtCodigo.Text);
                aux.NombreProducto = txtProducto.Text;

                if (txtProducto.Text != "")
                {
                    


                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    aux.Marca = new Marca();
                    string nombre = ddListMarca.SelectedItem.Text;
                    aux.Marca.Codigo = marcaNegocio.TraerIdparaGuardar(nombre);

                    aux.Ganancia = int.Parse(txtGanancia.Text);
                    aux.Stock = int.Parse(txtStock.Text);
                    aux.StockMin = int.Parse(txtStockMin.Text);
                    aux.Precio = int.Parse(txtPrecio.Text);
                    aux.Descripcion = txtDescripcion.Text;

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    aux.Categoria = new Categoria();
                    nombre = ddListCategoria.SelectedItem.Text;

                    aux.Categoria.Codigo = categoriaNegocio.TraerIDGuardar(nombre);


                    negocio.Agregar(aux);


                    lblAviso.Text = "PRODUCTO AÑADIDO CORRECTAMENTE";
                    lblAviso.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAviso.Text = "Por favor ingrese un nombre al producto";
                    txtProducto.BackColor = System.Drawing.Color.Red;
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();


            try
            {


                Producto aux = new Producto();

                aux.Codigo = int.Parse(txtCodigo.Text);
                aux.NombreProducto = txtProducto.Text;

                if((txtProducto.Text!= ""))
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    aux.Marca = new Marca();
                    string nombre = ddListMarca.SelectedItem.Text;
                    aux.Marca.Codigo = marcaNegocio.TraerIdparaGuardar(nombre);

                    aux.Ganancia = int.Parse(txtGanancia.Text);
                    aux.Stock = int.Parse(txtStock.Text);
                    aux.StockMin = int.Parse(txtStockMin.Text);

                    aux.Precio = decimal.Parse(txtPrecio.Text);

                    aux.Descripcion = txtDescripcion.Text;

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    aux.Categoria = new Categoria();
                    nombre = ddListCategoria.SelectedItem.Text;

                    aux.Categoria.Codigo = categoriaNegocio.TraerIDGuardar(nombre);


                    negocio.Modificar(aux);

                    lblAviso.Text = "PRODUCTO Modificado CORRECTAMENTE";
                    lblAviso.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblAviso.Text = "Por favor ingrese un nombre al producto";
                    txtProducto.BackColor = System.Drawing.Color.Red;
                    lblAviso.ForeColor = System.Drawing.Color.Red;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}