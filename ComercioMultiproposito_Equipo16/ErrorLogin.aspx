<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="ErrorLogin.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.ErrorLogin" %>
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
    </style>
    <h1 class="h1">Hubo un Problema</h1>

        <asp:Label Text="text" class="lbl" cssclass="alert alert-danger" ID="lblMensaje" runat="server" />

    <asp:Button ID="bntUnlog" runat="server" Text="Unlog" cssclass="btn btn-primary" class="btn" OnClick="btnUnlog_Click" />

   

</asp:Content>
