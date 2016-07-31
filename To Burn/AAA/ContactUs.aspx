<%@ Page Title="Contact Us Page" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="ContactUs" %>

<asp:Content ID="ContentContactUs" ContentPlaceHolderID="ContentPlaceHolderHome" Runat="Server">

   
   <fieldset>
    
       <legend> Feel free to fill in your details and send us any queries below. </legend>
            
            <p>
                From:<br />
                <asp:TextBox ID="txtbFromAdd" runat="server" Columns="30"></asp:TextBox><br />
                Subject:<br />
                <asp:TextBox ID="txtbSubject" runat="server" Columns="70"></asp:TextBox><br />
                Message:<br />
                <asp:TextBox ID="txtbMessage" runat="server" Width="100%" TextMode="MultiLine" style="resize:none" Rows="15"></asp:TextBox><br />

                   <div class="ContactUsSend">
                   <asp:Button ID="btnSend" runat="server" Text="Send" Width="60px" Height="30px" />
                   <asp:Button ID="btnReset" runat="server" Text="Reset" Width="60px" Height="30px"/>
                   </div>
            </p>
   </fieldset>
   
</asp:Content>

