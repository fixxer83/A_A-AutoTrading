<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserLoginPage.aspx.vb" Inherits="UserLoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="UserNameLbl">
        &nbsp;<asp:Label 
            ID="LblUserPg" runat="server" 
            Text="Kindly Enter your login details below!"></asp:Label>
        <asp:Label ID="lblInitLogin" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVeh" runat="server" Text="Vehicles" Width="74px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddVehicle" runat="server" Height="25px" 
            Text="Add Vehicle" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUser" runat="server" Text="Users" Width="74px" />
        &nbsp;&nbsp;
        <asp:Label ID="LblIsAdmin" runat="server" Text="Label"></asp:Label>
        &nbsp;
        <asp:Label ID="lblUserID" runat="server" Text="Label"></asp:Label>
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtPWD" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnLogin" runat="server" Text="Login" Width="70px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnReg" runat="server" Text="Register" Width="70px" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    </div>
    <p>
        &nbsp;</p>
    <p>
        <asp:HyperLink ID="LogoutHL" runat="server">Logout</asp:HyperLink>
        </p>
    <p>
        &nbsp;</p>
    </form>
   
</body>
</html>
