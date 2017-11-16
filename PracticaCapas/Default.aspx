<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PracticaCapas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solicitud de Salida</title>
    <meta name= "viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, minimun-scale=1.0, minimun-scale=1.0">
    <link rel="stylesheet" href="Resources/bootstrap-3.3.7-dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="Resources/estilos.css">
</head>
<body>
<header>
    <div class="container">
        <h1 style="text-align:center">Sistema Integral de Solicitud de Salida</h1>
    </div>
</header>
    <form id="form1" runat="server">
   
        <div>
             <h2>HELLO</h2>
            <asp:Button class="btn btn-primary" ID="btnCargarPage" runat="server" Text="Saca las panochas prro!" OnClick="btnCargarPage_Click" />
            <asp:GridView class="table table-bordered table-hover" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idUsuario" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" InsertVisible="False" ReadOnly="True" SortExpression="idUsuario" />
                    <asp:BoundField DataField="nombreUsuario" HeaderText="nombreUsuario" SortExpression="nombreUsuario" />
                    <asp:BoundField DataField="correoUsuario" HeaderText="correoUsuario" SortExpression="correoUsuario" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
             </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbPracticaCapasConnectionString %>" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
        </div>
    </form>
    
<script src="Resources/Jquery-3.2.1/js/jquery-3.2.1.min.js"></script>
<script src="Resources/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
</body>
</html>
