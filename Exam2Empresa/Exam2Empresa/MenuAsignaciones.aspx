<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="MenuAsignaciones.aspx.cs" Inherits="Exam2Empresa.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container text-center">
     <p>
                 <h2>MENU DE ASIGNACIONES</h2>
        
         <div class="container text-center">
     <asp:GridView runat="server" ID="datagrid" PageSize="10"
         CssClass="auto-style3" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
         RowStyle-CssClass="rows" AllowPaging="True" OnSelectedIndexChanged="Page_Load" Height="186px" Width="805px" HorizontalAlign="Center" style="margin-left: 243px"    />
             </div>
     Codigo de asignacion:<br> 
    <asp:TextBox ID="tasignacion" runat="server"></asp:TextBox>
    <br />
    Codigo de reparacion:<br>
    <asp:TextBox ID="treparacion" runat="server"></asp:TextBox>
     <br />  
    Tecnico:<br>
    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="Page_Load"></asp:DropDownList>
    <br />  
    Fecha:<br>
    <asp:TextBox runat="server" type="date" ID="txtFecha" CssClass="form-control" />
    <br />  
     </p>
 </div>
    <div class="container text-center">
<asp:Button ID="Button1" runat="server" class="btn btn-outline-primary" Text="Agregar" OnClick="Button1_Click" />
<asp:Button ID="Button2" runat="server" class="btn btn-outline-primary" Text="Borrar" OnClick="Button2_Click"/>
<asp:Button ID="Button3" runat="server" class="btn btn-outline-primary" Text="Modificar" OnClick="Button3_Click" />
<asp:Button ID="Button4" runat="server" class="btn btn-outline-primary" Text="Consultar" OnClick="Button4_Click" />

</div>

</asp:Content>
