<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.MisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .contenedora {
            display: flex;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }

        .LabelRegistrar {
            display: flex;
            width: 300px;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }

        .form-compra {
            display: flex;
            width: 300px;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }

        .botonCompra {
            display: flex;
            width: 300px;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }
    </style>

    <div class="contenedora">
        <div class="LabelRegistrar">
            <asp:Label Text="" runat="server" ID="lblAviso" />
            <asp:Label ID="lblAgregarCompra" runat="server" Text="Informacion del Pedido Registrado"></asp:Label>
        </div>
        <div class="form-compra">

              <asp:Label ID="lblProducto" runat="server" Text="Producto: "></asp:Label>
              <asp:TextBox ID="TextNombre" runat="server" CssClass="form form-control" class="textbox"></asp:TextBox>

              <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:    "></asp:Label>
              <asp:TextBox ID="TextBox1" runat="server" CssClass="form form-control" class="textbox"></asp:TextBox>
            </div>
      
           
            <asp:Label ID="lblTotalPedido" runat="server" Text="Total Pedido:"></asp:Label>  
           <asp:TextBox ID="TextBox2" runat="server" CssClass="form form-control" class="textbox"></asp:TextBox>
         

        </div>


    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>



</asp:Content>
