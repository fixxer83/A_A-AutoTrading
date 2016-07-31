<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserVehicle.aspx.vb" Inherits="UserVehicle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvUserVehicle" runat="server" Width="778px" 
            AutoGenerateColumns="False" 
            style="margin-top: 3px; text-align: center; margin-right: 0px;" Height="151px" 
            AutoGenerateSelectButton="True" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
            GridLines="Horizontal">
            <Columns>
                <asp:TemplateField HeaderText="Image:">
                    <ItemTemplate>
                        <asp:Image ID="MainImg" runat="server" ImageUrl='<%#"~/Images/"+Eval("MainImage") %>' Height="110" Width="150" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMainImg" runat="server" Text='<%#"~/Images/"+Eval("MainImage") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vehicle ID:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtVID" runat="server" Text='<%# Eval("V_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblVID" runat="server" Text='<%# Eval("V_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Year:">
                    <ItemTemplate>
                        <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtYear" runat="server" Text='<%# Eval("Year") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Make:">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMake" runat="server" Text='<%# Eval("Make") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMake" runat="server" Text='<%# Eval("Make") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Model:">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtModel" runat="server" Text='<%# Eval("Model") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblModel" runat="server" Text='<%# Eval("Model") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fuel:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFuel" runat="server" Text='<%# Eval("Fuel") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFuel" runat="server" Text='<%# Eval("Fuel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Engine cc:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEngine" runat="server" Text='<%# Eval("Engine") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEngine" runat="server" Text='<%# Eval("Engine") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transmission" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTrans" runat="server" Text='<%# Eval("Transmission") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTrans" runat="server" Text='<%# Eval("Transmission") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Color:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtColor" runat="server" Text='<%# Eval("Color") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblColor" runat="server" Text='<%# Eval("Color") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price:">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        €<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDesc" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Condition:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCond" runat="server" Text='<%# Eval("Condition") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCond" runat="server" Text='<%# Eval("Condition") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category:" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCatID" runat="server" Text='<%# Eval("[CatID]") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCatID" runat="server" Text='<%# Eval("[CatID]") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
