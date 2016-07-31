<%@ Page Title="User's Panel" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UserPanel.aspx.vb" Inherits="UserPanel" %>

<asp:Content ID="ContentUserPanel" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
    
    <div id="contUserPan">  
            
            <h1> User's Panel </h1>
       <!--Add Your Vehicle Button-->      
       <p> 
       <asp:Button ID="btnAddVeh" runat="server" Text="Add Your Vehicle" Height="30px" Width="120px" Visible="true" /> 
       </p>

    </div>
       <!--Order Gridview-->
       <div id="GridviewsUser1">

            <div id="contUserPan2">  
            
            <h1><asp:Label ID="lblPastOrders" runat="server" Text="Your Past Orders"></asp:Label></h1>

            </div>
           <!--Vehicle Gridview-->
           <asp:GridView ID="gvOrder" CssClass="GridVeh" runat="server" Width="778px" 
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True"  
                GridLines="Horizontal">
                <Columns>
            <asp:TemplateField HeaderText="Order ID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtOrderID" runat="server" Text='<%# Eval("OrderID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User ID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date and Time">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Price">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>           
            </asp:GridView>
            <br />
       </div>
       <!--Orderline Gridview-->
       <div id="GridviewsUser2">
        <asp:GridView ID="gvOrderLine" CssClass="GridVeh" runat="server">
        </asp:GridView>
        <br />
       </div>
       
           
</asp:Content>