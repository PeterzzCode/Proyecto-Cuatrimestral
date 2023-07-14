<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function soloNumeros(event) {
            var tecla = event.which || event.keyCode;
            if (tecla < 49 || tecla > 50) {
                event.preventDefault();
            }
        }
    </script>

<div style="padding:30px;display:flex;align-items:center; flex-direction:column;justify-content:center;height: 100vh">
    
    
    <form>
        <div class="mb-3">
            <asp:Label for="txtUser" cssclass="form-label" ID="lblUser" runat="server"> Usuario</asp:Label>
           
            <asp:TextBox type="text" cssclass="form-control" aria-describedby="userHelp" ID="txtUser" runat="server" placeholder="Ingrese usuario..." style="width:200px"></asp:TextBox>
          
           
        </div>
        <div class="mb-3">
            <asp:Label ID="lblContraseña" for="txtContraseña" cssclass="form-label" runat="server" >Contraseña</asp:Label>
           
            <asp:TextBox type="password" cssclass="form-control" ID="txtContraseña" runat="server" placeholder="Ingrese contraseña..." style="width:200px"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblTipo" for="txtTipo" cssclass="form-label" runat="server" >Tipo De Usuario</asp:Label>
           
            <asp:TextBox type="text" cssclass="form-control" ID="txtTipo" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="1" placeholder="Ingrese Tipo de Usuario..." style="width:200px"></asp:TextBox>
        </div>
        <div class="mb-3 form-check">
            
            
        </div>
        
        <asp:Button ID="btnRegistro" cssclass="btn btn-primary" OnClick="btnRegistro_Click" runat="server" Text="Ingresar"  style="background-color:aqua;border-color:black;color:black;" />
    </form>

</div>
    

</asp:Content>
