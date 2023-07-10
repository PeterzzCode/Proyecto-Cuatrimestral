<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Cuando se ingresa una compra, se debe generar un pedido el cual debe figurar en Ventas. la cual sólo tendría que ser vista por administrador.
    El Stock "en vivo" debe ser modificado al momento de que se genera una compra/pedido.
  
    <div>

        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblComprar" runat="server" Text="Compras"></asp:Label>


    </div>

    <div>

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar nueva compra"  CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
        <asp:Button ID="btnMostrar" runat="server" Text="Mis Compras" CssClass="btn btn-primary" OnClick="btnMostrar_Click"/>
        

    </div>

</asp:Content>
