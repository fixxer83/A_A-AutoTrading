<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Kindly enter your details below:<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Namelbl" runat="server" Text="Name:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="SurnameLbl" runat="server" Text="Surname:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="SurnameTxt" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="UserNameLbl" runat="server" Text="Username:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="UserNameTxt" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="PasswordLbl" runat="server" Text="Password:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="PWDTxt" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="PwdExLbl" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:Label ID="PWDMatchLbl" runat="server" Text="Re-Enter Password:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="PWDMatchTxt" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="PwdMatchExLbl" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="IsAdminLbl" runat="server" Text="Is Admin:"></asp:Label>
        &nbsp;<asp:CheckBox ID="IsAdminChk" runat="server" />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="RegBtn" runat="server" Text="Register" />
    </div>
    </form>
    <div>
    
    </div>
    </form>
</body>
</html>
