<%@ Page Title="Add Vehicle Page" Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="AddVehicle.aspx.vb" Inherits="AddVehicle" %>

<asp:Content ID="ContentAddVehicle" ContentPlaceHolderID="ContentPlaceHolderHome" runat="server">

    <div id="AddVehFieldset">

<fieldset>
    
       <legend> Please fill in your Vehicle details and upload photos below. </legend>
       <!--Text fields area-->
            <p>
            <asp:Label ID="lblVID" runat="server" Text="Vehicle ID:"></asp:Label><br />
            <asp:TextBox ID="txtVID" runat="server" Width="205px"></asp:TextBox><br />

            <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label><br />
            <asp:DropDownList ID="ddlYr" runat="server" Width="205px"></asp:DropDownList><br />

            <asp:Label ID="lblMake" runat="server" Text="Make:"></asp:Label><br />
            <asp:TextBox ID="txtMake" runat="server" Width="205px"></asp:TextBox><br />

            <asp:Label ID="lblModel" runat="server" Text="Model:"></asp:Label><br />
            <asp:TextBox ID="txtModel" runat="server" Width="205px"></asp:TextBox><br />

            <asp:Label ID="lblFuel" runat="server" Text="Fuel:"></asp:Label><br />
            <asp:DropDownList ID="ddlFuel" runat="server" Width="205px"></asp:DropDownList><br />

            <asp:Label ID="lblEngine" runat="server" Text="Engine:"></asp:Label><br />
            <asp:TextBox ID="txtEngine" runat="server" Width="205px"></asp:TextBox><br />

            <asp:Label ID="lblTrans" runat="server" Text="Transmission:"></asp:Label><br />
            <asp:DropDownList ID="ddlTrans" runat="server" Width="205px"></asp:DropDownList><br />

            <asp:Label ID="lblColor" runat="server" Text="Color:"></asp:Label><br />
            <asp:TextBox ID="txtColor" runat="server" Width="205px"></asp:TextBox><br />

            <asp:Label ID="lblCond" runat="server" Text="Condition:"></asp:Label><br />
            <asp:DropDownList ID="ddlCond" runat="server" Width="205px"></asp:DropDownList><br />

            <asp:Label ID="lblCat" runat="server" Text="Category:"></asp:Label><br />
            <asp:DropDownList ID="ddlCat" runat="server" Width="205px"></asp:DropDownList><br />

            <asp:Label ID="lblPrice" runat="server" Text="Price: €"></asp:Label><br />
            <asp:TextBox ID="txtPrice" runat="server" Width="205px"></asp:TextBox><br />  
               
            <asp:Label ID="lblDesc" runat="server" Text="Description:"></asp:Label><br />
            <asp:TextBox ID="txtDesc" runat="server" Width="100%" TextMode="MultiLine" style="resize:none" Rows="8"></asp:TextBox><br />

            <asp:Label ID="lblUpld" runat="server" Text="Label"></asp:Label><br />   
            <asp:Label ID="lblmainAltImg" runat="server" Text="Label"></asp:Label><br />
            <asp:FileUpload ID="fUImage" runat="server" Height="30px" Width="300px" /><br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" Height="21px" Width="85px"/><br />

       </p>      
            <!--Images area-->
            <div id="contAddVehImg">

                <ul>
                    <li><asp:Image ID="VehImg1" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:Image ID="VehImg2" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:Image ID="VehImg3" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:Image ID="VehImg4" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:Image ID="VehImg5" runat="server" Height="90px" Width="140px" /></li>
                    <li><asp:Image ID="VehImg6" runat="server" Height="90px" Width="140px" /></li>
                </ul>

            </div>    

   </fieldset>
      <!--Save Button-->
      <div id="vehSave">
        <asp:Button ID="btnSave" runat="server" Text="Save Vehicle" Height="30px" Width="100px" /><br />
      </div>

</div>
         
</asp:Content>

