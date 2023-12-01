<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Exam2Empresa.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            border: solid 2px black;
            min-width: 80%;
            margin-left: 116px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
      <h2>CATALOGO DE USUARIOS</h2>
     <p>
     </p>
 </div>

 <div>
     <br />
     <br />
     <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
         CssClass="auto-style3" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="Page_Load" Width="430px" Height="185px"    />
    <br />
    <br />
    <br />

</div>
    <div class="container text-center">

        UsuarioID:
        <asp:TextBox ID="tcodigo" class="from-control" runat="server"></asp:TextBox>
        Nombre:
        <asp:TextBox ID="tnombre" class="from-control" runat="server"></asp:TextBox>
        Correo:
        <asp:TextBox ID="tcorr" class="from-control" runat="server"></asp:TextBox>
        Telefono:
        <asp:TextBox ID="ttel" class="from-control" runat="server"></asp:TextBox>
    </div>
     <br />
    <br />
<div class="container text-center">
<asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Text="Agregar" OnClick="Button1_Click" />
<asp:Button ID="Button2" runat="server" class="btn btn-outline-primary" Text="Borrar" OnClick="Button2_Click" />
<asp:Button ID="Button3" runat="server" class="btn btn-outline-primary" Text="Modificar" OnClick="Button3_Click" />
<asp:Button ID="Button4" runat="server" class="btn btn-outline-primary" Text="Consultar" OnClick="Button4_Click" />

</div>
</asp:Content>
