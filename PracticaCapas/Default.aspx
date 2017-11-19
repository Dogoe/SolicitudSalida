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
    <div class="text-center">
        <!--Banner de la UABC-->
        <div class="row">
            <div class="hidden-xs hidden-sm col-md-2 col-lg-2">
                <img src="Resources/img/logouabc.png" height="110">
            </div>
            <div class="col-sm-8 col-md-8 col-lg-8">
                <h1 class="uabc">Universidad Autónoma de Baja California</h1>
                <h3 class="facultad">Facultad de Ingeniería, Arquitectura y Diseño</h3>
            </div>
            <div class="hidden-xs hidden-sm col-md-2 col-lg-2">
                <img src="Resources/img/logofiad.png" class="logo">
            </div>
        </div>				
        <hr>
    </div>
</header>
<div class="container">
    <div myheader></div>
    <h2 class="text-center">Bienvenido al Sistema de Solicitudes de Salida</h2>
    <div>
        <!--Formulario para iniciar sesión-->
        <div class="container" id="login">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Iniciar sesi&oacute;n:</h3>
                        </div>
                        <div class="panel-body">
                            <form  name="myForm">
                                <div ></div>
                              
                                    <div class="form-group">
                                        <label>Correo:</label>
                                        <input  class="form-control" placeholder="Correo" name="correo" type="email"  ng-model="usuarioDTO.Correo" ng-pattern="regex.correo" required>
                                     
                                    </div>
                                    <div class="form-group">
                                        <label>Contraseña:</label>
                                        <input class="form-control" placeholder="Contraseña" name="pswd" type="password" ng-model="usuarioDTO.Contrasenia" required>
                                   
                                    </div>
                                    <input type="submit" ng-keypress="" value="Ingresar" class="btn btn-success btn-block" ng-disabled="!myForm.$valid" ng-click="IniciarSesion()">
                             
                            </form>
                        </div>
                    </div>
                </div>
            </div>
          
        </div>
    </div>
    <div myfooter></div>
    <form id="form1" runat="server">
   
        <div>
            <asp:Button class="btn btn-primary" ID="btnCargarPage" runat="server" Text="Boton Prueba" OnClick="btnCargarPage_Click" />
            <asp:GridView class="table table-bordered table-hover" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                    <asp:BoundField DataField="Id_Rol" HeaderText="Id_Rol" SortExpression="Id_Rol" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbSSConnectionString %>" SelectCommand="SELECT * FROM [usuario]"></asp:SqlDataSource>
        </div>
    </form>
</div>


<script src="Resources/Jquery-3.2.1/js/jquery-3.2.1.min.js"></script>
<script src="Resources/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
</body>
</html>
