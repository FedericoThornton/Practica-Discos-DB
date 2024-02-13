<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_Discos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color: aqua; text-align: center">Discos Web</h1>
    <p style="color: darkblue; text-align: center">La mejor web de discos</p>

    <div class="card-group">

        <%
            foreach (Dominio.Disco disco in ListaDiscos)
            { %>
        <div class="card">
            <img src=<%:disco.UrlImagen %> class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><%: disco.Titulo %></h5>
                <p class="card-text"><%:disco.Genero %></p>
            </div>
            <div class="card-footer">
                <small class="text-body-secondary"><%: disco.Edicion %></small>
            </div>
        </div>

         <%  }  %>
    </div>




</asp:Content>
