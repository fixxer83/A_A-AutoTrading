<%@ Page Title="Checkout Page" Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="Checkout.aspx.vb" Inherits="Checkout" %>

<asp:Content ID="ContentCheckout" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">

    <div id="contChkOut">  
            
            <h1> Thank you for your order! </h1>
    
        <p><asp:Button ID="lbViewOrders" runat="server" Text="Past Orders" Height="30px" Width="100px" Visible="True"/></p>

    </div>

</asp:Content>