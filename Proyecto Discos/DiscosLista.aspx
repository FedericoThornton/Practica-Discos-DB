<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DiscosLista.aspx.cs" Inherits="Proyecto_Discos.DiscosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color: aqua; text-align: center">Lista de Discos</h1>
    <div class="row">
        <div class="col-6">
            <asp:Label Text="Filtrar" runat="server" />
            <asp:TextBox AutoPostBack="true" ID="txtfiltro" CssClass="form-control" OnTextChanged="filtro_TextChanged" runat="server" />
        </div>

        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado"
                    CssClass="" ID="chkAvanzado" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>
    <% if (chkAvanzado.Checked)
        { %>
     <div class="row">
     <div class="col-3">
         <div class="mb-3">
             <asp:Label Text="Campo" ID="LblCampo" runat="server" CssClass="form-label" />
             <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="DdlCampo" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" runat="server">
                 <asp:ListItem Text="Título" />
                 <asp:ListItem Text="Canciones" />
                 <asp:ListItem Text="Género" />
                 <asp:ListItem Text="Formato" />
             </asp:DropDownList>
         </div>
     </div>
     <div class="col-3">
         <div class="mb-3">
             <asp:Label Text="Criterio" ID="LblCriterio" runat="server" CssClass="form-label" />
             <asp:DropDownList CssClass="form-control" ID="DdlCriterio" OnSelectedIndexChanged="DdlCriterio_SelectedIndexChanged" runat="server">
             </asp:DropDownList>
         </div>
     </div>
     <div class="col-3">
         <div class="mb-3">
             <asp:Label Text="Filtro" ID="lblFitroavanzado" runat="server" CssClass="form-label" />
             <asp:TextBox CssClass="form-control" runat="server" ID="TxtFiltroavanzado">
             </asp:TextBox>
         </div>
         </div>
       </div>
  
 <div class="row">
     <div class="col">
         <div class="mb-3">
         <asp:Button Text="Buscar" ID="btnBuscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
     </div>
 </div>
 </div>
      <%} %>
    <hr />
    <asp:GridView ID="dgvDiscos" CssClass="table table-success table-striped" AutoGenerateColumns="false" DataKeyNames="Id"
        AllowPaging="true" PageSize="3" runat="server"
        OnPageIndexChanging="dgvDiscos_PageIndexChanging"
        OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Canciones" DataField="Canciones" />
            <asp:BoundField HeaderText="Genero" DataField="Genero.Descripcion" />
            <asp:BoundField HeaderText="Formato" DataField="Edicion.Descripcion" />
            <asp:CommandField HeaderText="Acción" SelectText="Modificar" ShowSelectButton="true" />

        </Columns>
    </asp:GridView>
    <a href="FormularioDiscos.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
