<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Exam2Empresa.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
     <p>
         <h2>CATALOGO DE TECNICOS</h2>
     </p>
 </div>

 <div>
     <br />
     <br />
     <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
         CssClass="mydatagrid" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="Page_Load" AutoGenerateSelectButton="True"    />
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
<asp:Button ID="Button2" runat="server" class="btn btn-outline-primary" Text="Borrar" />
<asp:Button ID="Button3" runat="server" class="btn btn-outline-primary" Text="Modificar" OnClick="Button3_Click" />
<asp:Button ID="Button4" runat="server" class="btn btn-outline-primary" Text="Consultar" OnClick="Button4_Click" />

</div>
</asp:Content>
