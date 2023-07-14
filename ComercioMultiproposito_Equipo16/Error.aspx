<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .h1{
            padding: 30px;
            display: center;
        }
        .lbl{
            padding: 50px;
            display: center;
        }
        .btn{
            padding: 30px;
            display: center;
            border-color: aqua;
            margin-top: 100px;
            background-color: blue;
            margin: 50px;
        }
    </style>
    <h1 class="h1">Hubo un Problema</h1>

        <asp:Label Text="text" class="lbl" cssclass="alert alert-danger" ID="lblMensaje" runat="server" />

        <asp:Button ID="btnLogin" runat="server" Text="Login" cssclass="btn btn-primary" class="btn" OnClick="btnLogin_Click" />

            <asp:Button ID="btnRegistro" runat="server" Text="Register" cssclass="btn btn-primary" class="btn" OnClick="btnRegistro_Click" />

   

</asp:Content>
