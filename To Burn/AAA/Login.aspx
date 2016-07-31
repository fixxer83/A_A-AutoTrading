<%@ Page Title="Login Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">

    <div id="LoginFieldset">

<fieldset>
    
       <legend> Please enter your login credentials below. </legend>
            <!--Login labels and textboxes-->
            <p>
                <asp:Label ID="lblCredentialsVal" runat="server" Text="lblCredentialsVal"></asp:Label><br />
                <asp:Label ID="lblUserID" runat="server" Text="lblUserID"></asp:Label>
                <asp:Label ID="lblIsAdmin" runat="server" Text="lblIsAdmin"></asp:Label><br />
                
                Username:<br />
                <asp:TextBox ID="txtUserName" runat="server" Columns="30"></asp:TextBox>
                <asp:Label ID="lblUserNameVal" runat="server" Text="lblUserNameVal"></asp:Label><br />
                <br />Password:<br />
                <asp:TextBox ID="txtPWD" runat="server" Columns="30"></asp:TextBox>
                <asp:Label ID="lblPwdVal" runat="server" Text="lblPwdVal"></asp:Label><br />
               
                   <div class="LoginButton">
                   <asp:Button ID="btnLogin" runat="server" Text="Login" Width="60px" Height="30px" /><br />
                   </div>
            </p>

   </fieldset>

 </div>

</asp:Content>
