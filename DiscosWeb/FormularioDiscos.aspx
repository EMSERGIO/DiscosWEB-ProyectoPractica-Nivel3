<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDiscos.aspx.cs" Inherits="DiscosWeb.FormularioDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" TextMode="Number" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Titulo:</label>
                <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtFechaLanzamiento" class="form-label">Fecha de Lanzamiento:</label>
                <asp:TextBox runat="server" TextMode="DateTime" ID="txtFechaLanzamiento" CssClass="form-control" />
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
                <a href="DiscosListar.aspx" class="btn btn-outline-danger">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCantidadCanciones" class="form-label">Cantidad de Canciones:</label>
                <asp:TextBox runat="server" TextMode="Number" ID="txtCantidadCanciones" CssClass="form-control" />
            </div>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url Imagen:</label>
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://img2.freepng.es/20180603/jx/kisspng-user-interface-design-computer-icons-default-stephen-salazar-photography-5b1462e1b19d70.1261504615280626897275.jpg"
                        runat="server" ID="imgDiscos" Width="70%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                    </div>
                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
