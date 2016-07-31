<%@ Page Title="Register Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" codeFile="Register.aspx.vb" Inherits="Register" %>

<asp:Content ID="ContentRegister" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">

<div id="RegisterFieldset">

    <fieldset>
    
       <legend> Please enter your details below to Register with us. </legend>
            <!--Register text fields-->
            <p>
                Name:<br />
                <asp:TextBox ID="NameTxt" runat="server" Columns="30"></asp:TextBox><br />
                <br />Surname:<br />
                <asp:TextBox ID="SurnameTxt" runat="server" Columns="30"></asp:TextBox><br />
                <br />Username:<br />
                <asp:TextBox ID="UserNameTxt" runat="server" Columns="30"></asp:TextBox><br />
                <br />Password:<br />
                <asp:TextBox ID="PWDtxt" runat="server" Columns="30" TextMode="Password"></asp:TextBox>
                <asp:Label ID="PwdExLbl" runat="server" Text="Label"></asp:Label><br />
                <br />Re-enter Password:<br />
                <asp:TextBox ID="PWDMatchTxt" runat="server" Columns="30" TextMode="Password"></asp:TextBox>
                <asp:Label ID="PwdMatchExLbl" runat="server" Text="Label" Visible="False"></asp:Label><br />
                   <!--Register Button-->
                   <div class="RegisterButton">
                   <asp:Button ID="btnRegister" runat="server" Text="Register" Width="70px" Height="30px" />
                   </div>
            </p>

   </fieldset>

</div>


</asp:Content>
