﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
       
            if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario != Dominio.TipoUsuario.ADMIN)
            {
             

                Response.Redirect("MisCompras.aspx");//para ver pedido
              

            }

            
        }
    }
}