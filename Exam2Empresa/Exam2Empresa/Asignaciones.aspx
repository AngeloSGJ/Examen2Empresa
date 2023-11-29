<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Exam2Empresa.Asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border: solid 2px black;
            min-width: 80%;
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
     <p>
         <h2>ASIGNACIONES</h2>
     </p>
 </div>

 <divcontainer text-center>
    
   
                 &nbsp;&nbsp;&nbsp;&nbsp;
    
   
                 <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
                    CssClass="auto-style1" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                   RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="Page_Load" Height="256px" Width="529px"    />
    <br />
    <br />
  



</asp:Content>
