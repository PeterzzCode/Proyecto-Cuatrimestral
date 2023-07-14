using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ComercioMultiproposito_Equipo16
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                bool sino = false;
                if (int.Parse(txtTipo.Text) == 2)
                {
                    sino = true;
                }
                if (int.Parse(txtTipo.Text) == 1)
                {
                    sino = false;
                }
                Usuario usuario = new Usuario(txtUser.Text, txtContraseña.Text, sino);
                UsuarioNegocio negocio = new UsuarioNegocio();
                

                usuario.User = txtUser.Text;
                usuario.Pass = txtContraseña.Text;
                if(int.Parse(txtTipo.Text) == 2)
                {
                    usuario.TipoUsuario = TipoUsuario.ADMIN;
                }
                if (int.Parse(txtTipo.Text) == 1)
                {
                    usuario.TipoUsuario = TipoUsuario.VENDEDOR;
                }

                int id = negocio.Registrar(usuario);

                Response.Redirect("Login.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            
        }
    }
}