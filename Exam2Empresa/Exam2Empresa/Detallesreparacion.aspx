<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Detallesreparacion.aspx.cs" Inherits="Exam2Empresa.Detallesreparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
     <p>
         <h2>DETALLES DE LAS REPARACIONES</h2>
     </p>
 </div>

 <div>
     <br />
     <br />
     <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
         CssClass="mydatagrid" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="Page_Load"    />
      </div>
</asp:Content>
