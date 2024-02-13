<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDiscos.aspx.cs" Inherits="Proyecto_Discos.FormularioDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="lblid" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblTitulo" class="form-label">Título</label>
                <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Titulo requerido" ControlToValidate="txtTitulo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblTitulo" class="form-label">Canciones</label>
                <asp:TextBox ID="txtCanciones" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Canciones requeridas" ControlToValidate="txtCanciones" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Sólo números" CssClass="validacion" ValidationExpression="^[0-9]+$" ControlToValidate="txtCanciones" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblGenero" class="form-label">Género</label>
                <asp:DropDownList ID="ddlGenero" CssClass="form-select" runat="server"></asp:DropDownList>
               
            </div>
            <div class="mb-3">
                <label for="lblFormato" class="form-label">Formato</label>
                <asp:DropDownList ID="ddlFormato" CssClass="form-select" runat="server"></asp:DropDownList>
               
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="DiscosLista.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="lblImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" runat="server" />
                    </div>
                    <asp:Image ImageUrl="https://th.bing.com/th/id/OIP.F00dCf4bXxX0J-qEEf4qIQHaD6?rs=1&pid=ImgDetMain" ID="ImageDiscos" Width="80%" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Button Text="Borrar" ID="btnBorrar" CssClass="btn btn-danger" OnClick="btnBorrar_Click"   runat="server" />
                    <% if (ConfirmaEliminacion)
                        { %>

                    <div class="mb-3">
                        <asp:CheckBox Text="Confirma eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="ConfirmaEliminar" OnClick="ConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%  } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
