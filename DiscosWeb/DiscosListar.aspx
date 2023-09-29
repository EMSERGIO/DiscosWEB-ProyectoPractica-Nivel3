<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DiscosListar.aspx.cs" Inherits="DiscosWeb.DiscosListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Discos</h1>
    <div class="row">
        <div class="col-4">
            <div class="mb-2">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
        <div class="col-4" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-2">
                <asp:CheckBox Text="Filtro Avanzado"
                    CssClass="" ID="ckbAvanzado" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="ckbAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <div class="mb-2">
                <asp:Button Text="Limpiar Filtros" CssClass="btn btn-outline-danger" ID="btnLimpiarFiltro" runat="server" OnClick="btnLimpiarFiltro_Click" />
            </div>
        </div>
    </div>

    <div class="row">
        <%if (FiltroAvanzado)
            {%>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="txtCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Titulo" />
                        <asp:ListItem Text="Cantidad de Canciones" />
                        <asp:ListItem Text="Estilo" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-1">
                <div class="mb-1">
                    <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <%} %>
    </div>
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="FormularioDiscos.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
