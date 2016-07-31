<%@ Page Title="Car Description Page" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="CarsSingleView.aspx.vb" Inherits="CarsSingleView" %>

<asp:Content ID="ContentCarsSingleView" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">

<div id="carSingVw">

    <fieldset>
    
       <legend> Selected Car detailed Description and Images. </legend>
        <!--Vehicle Property Labels-->
        <p>
            <asp:Label ID="lblShopItems" runat="server" Text="Label" Visible="False"></asp:Label> 
            <asp:Label ID="lblTotal" runat="server" Text="Total: €" Visible="False"></asp:Label>
            <asp:Label ID="lblUserID" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Label ID="lblVID" runat="server" Text="Label" Visible="False"></asp:Label><br />
            <br /><asp:Label ID="VName" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="VTrans" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="VEngine" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="VFuel" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="VColor" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="VCond" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label><br />
            <br /><asp:Label ID="lblDesc" runat="server" Text="Description:"></asp:Label>
            <br /><asp:TextBox ID="VDescTxt" runat="server"  Width="100%" TextMode="MultiLine" style="resize:none" Rows="8"></asp:TextBox><br />
            
        </p>
           <!--Vehicle Main Image-->
           <div id="largeImgs">
                <asp:Image ID="LargeVImg" runat="server"/>
           </div>
            <!--Vehicle Alternate Image/s-->
            <div id="smallImgs">
                <ul>
                    <li><asp:ImageButton ID="btnImg1" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:ImageButton ID="btnImg2" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:ImageButton ID="btnImg3" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:ImageButton ID="btnImg4" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:ImageButton ID="btnImg5" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:ImageButton ID="btnImg6" runat="server" Height="90px" Width="140px" /></li>
                </ul>
            </div>

    </fieldset>
            <!--Add To Cart / Delete Vehicle Buttons-->
            <div id="btnscarSingVw">
                <asp:Button ID="btnAddCart" runat="server" Height="30px" Width="100px" Text="Add To Cart" /><br />
                <asp:Button ID="btnVehDel" runat="server" Height="30px" Width="100px" Text="Delete Vehicle" />
            </div>
        
       
            <!--Vehicle Gridview (for vehicle details only, will not be visible)-->
            <asp:GridView ID="gvVehicle" runat="server" Width="750px" 
            AutoGenerateColumns="False" 
            AutoGenerateSelectButton="True" style="margin-top: 3px">
                <Columns>
                    <asp:TemplateField HeaderText="Vehicle ID:" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtVID" runat="server" Text='<%# Eval("V_ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblVID" runat="server" Text='<%# Eval("V_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Year:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtYear" runat="server" Text='<%# Eval("Year") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year") %>'></asp:Label>
                        </ItemTemplate>
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
                    <asp:TemplateField HeaderText="Fuel:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFuel" runat="server" Text='<%# Eval("Fuel") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFuel" runat="server" Text='<%# Eval("Fuel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Engine cc:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEngine" runat="server" Text='<%# Eval("Engine") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEngine" runat="server" Text='<%# Eval("Engine") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transmission">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTrans" runat="server" Text='<%# Eval("Transmission") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTrans" runat="server" Text='<%# Eval("Transmission") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Color:">
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
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Condition:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCond" runat="server" Text='<%# Eval("Condition") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCond" runat="server" Text='<%# Eval("Condition") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image:" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMainImage" runat="server" Text='<%# Eval("MainImage") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMainImage" runat="server" Text='<%# Eval("MainImage") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Category Desc:" SortExpression="C.Description">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCatDesc" runat="server" Text='<%# Eval("CatDesc") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCatDesc" runat="server" Text='<%# Eval("CatDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtActImg" runat="server" Text='<%#"~/Images/"+Eval("MainImage") %>' 
                                Tooltip='<%#"~/Images/"+Eval("Image") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="lblActImg" runat="server" AlternateText='<%#"~/Images/"+Eval("MainImage") %>' 
                                ImageUrl='<%#"~/Images/"+Eval("MainImage") %>' />
                        </ItemTemplate>
                        <ControlStyle Height="110px" Width="160px" />
                    </asp:TemplateField>
                           <asp:TemplateField HeaderText="Alt Image/s" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblAltImg" runat="server" Text='<%# Eval("AlternateImgs") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAltImgs" runat="server" Text='<%# Eval("AlternateImgs") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UserID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:TextBox>
                        </EditItemTemplate>
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

</asp:Content>
