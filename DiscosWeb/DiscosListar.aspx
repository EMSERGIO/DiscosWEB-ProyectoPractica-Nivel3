<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DiscosListar.aspx.cs" Inherits="DiscosWeb.DiscosListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Discos</h1>
    <asp:GridView ID="dgvDiscos" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged"
        OnPageIndexChanging="dgvDiscos_PageIndexChanging"
        AllowPaging="true" PageSize="6">
        <Columns>
            <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
            <asp:BoundField HeaderText="Cantidad de Canciones" DataField="CantidadCanciones" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
            <asp:BoundField HeaderText="Tipo de Edicion" DataField="TipoEdicion.Descripcion" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="📝" />
        </Columns>
    </asp:GridView>
    <a href="FormularioDiscos.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
