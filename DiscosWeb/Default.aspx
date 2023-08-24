<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DiscosWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Llegaste a ver nuestros Discos</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        

        <%--        <%
            foreach (dominio.Discos discos in ListaDiscos)
            {
        %>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%: discos.UrlImagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: discos.Titulo %></h5>
                            <p class="card-text"><%: discos.FechaLanzamiento %></p>
                            <a href="DetalleDiscos.aspx?id=<%: discos.Id %>">Ver Detalle</a>
                        </div>
                    </div>
                </div>
        <%  }  %>   --%>

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Titulo")%></h5>
                            <p class="card-text"><%#Eval("FechaLanzamiento")%></p>
                            <a href="DetalleDiscos.aspx?id=<%#Eval("Id")%>">Ver Detalle</a>
                            <asp:Button Text="Ejemplo" CssClass="btn btn-primary" runat="server" Id="btnEjemplo" CommandArgument='<%#Eval("Id")%>' CommandName="DiscosId" OnClick="btnEjemplo_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </div>
</asp:Content>
