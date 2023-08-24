<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDiscos.aspx.cs" Inherits="DiscosWeb.FormularioDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Titulo:</label>
                <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtFechaLanzamiento" class="form-label">Fecha de Lanzamiento:</label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtFechaLanzamiento" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCantidadCanciones" class="form-label">Cantidad de Canciones:</label>
                <asp:TextBox runat="server" TextMode="Number" ID="txtCantidadCanciones" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlEstilo" class="form-label">Estilo:</label>
                <asp:DropDownList ID="ddlEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlTipoEdicion" class="form-label">Tipos de Edicion:</label>
                <asp:DropDownList ID="ddlTipoEdicion" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="DiscosListar.aspx">Cancelar</a>
            </div>


        </div>
    </div>
</asp:Content>
