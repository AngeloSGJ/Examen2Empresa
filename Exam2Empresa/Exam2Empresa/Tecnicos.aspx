<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Exam2Empresa.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            border: solid 2px black;
            min-width: 80%;
            margin-left: 145px;
            margin-top: 39;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
     <p>
         <h2>CATALOGO DE TECNICOS</h2>
     <p>
     </p>
 </div>

 <div>
     <br />
     <br />
     <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
         CssClass="auto-style3" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="Page_Load" Width="438px" Height="117px"    />
    <br />
    <br />
    <br />

</div>
    <div class="container text-center">
        TecnicoID:
        <asp:TextBox ID="tcodigo" class="from-control" runat="server"></asp:TextBox>
        Nombre:
        <asp:TextBox ID="tdescripcion" class="from-control" runat="server"></asp:TextBox>
        Especialidad:
         <asp:TextBox ID="tespec" class="from-control" runat="server"></asp:TextBox>

    </div>
    <br />
    <br />
<div class="container text-center">
<asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Text="Agregar" OnClick="Button1_Click" />
<asp:Button ID="Button2" runat="server" class="btn btn-outline-primary" Text="Borrar" OnClick="Button2_Click"/>
<asp:Button ID="Button3" runat="server" class="btn btn-outline-primary" Text="Modificar" OnClick="Button3_Click" />
<asp:Button ID="Button4" runat="server" class="btn btn-outline-primary" Text="Consultar" OnClick="Button4_Click" />

</div>
</asp:Content>
