<%@ Page Title="New Cars Page" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NewCars.aspx.vb" Inherits="NewCars" %>

<asp:Content ID="ContentNewCars" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">
      
      <div id="contNew"> 
       <p>
            <h1> New Cars for sale at A & A Autotrading Limited </h1>
       </p>

       <div id="GridviewVeh">
           <!--Vehicle Gridview-->
           <asp:GridView ID="gvVehicle" CssClass="GridVeh" runat="server" Width="778px" 
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True"  
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
                    <asp:TemplateField Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sold:" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSold" runat="server" Text='<%# Eval("Sold") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSold" runat="server" Text='<%# Eval("Sold") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            
            </asp:GridView>
        
        </div>
    </div>

           
</asp:Content>



