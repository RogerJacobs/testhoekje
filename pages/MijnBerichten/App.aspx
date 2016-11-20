<%@ Page Language="C#" AutoEventWireup="true" CodeFile="App.aspx.cs" Inherits="Default2"  MasterPageFile="/MasterPage.master"%>



<asp:Content ContentPlaceHolderId="Content" runat="server">

     <h3>Mijn Berichten App </h3>
            

            
            <p>
                <asp:Label ID="Label1" runat="server" Text="Rol"></asp:Label><br>
                <asp:ListBox ID="ListBox1" runat="server" Height="100px" SelectionMode="Multiple"  >
                    <asp:ListItem>Machinist</asp:ListItem>
                    <asp:ListItem>Hoofdconducteur</asp:ListItem>
                    <asp:ListItem>Walmedewerker</asp:ListItem>
                    <asp:ListItem>Veiligheid-en-service</asp:ListItem>
                    <asp:ListItem>HoofdconducteurInternational</asp:ListItem>
                    <asp:ListItem>MachinistInternational</asp:ListItem>
                </asp:ListBox>
            </p>
            
            <asp:Button ID="Refresh" runat="server" Text="Refresh" />

 


			<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/Berichten.xml" ></asp:XmlDataSource>
       
     <table style="width: 100%;">
              <tr>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Rechts</td>
                  <td>Links</td>
              </tr>
      </table>
    

</asp:Content>



<asp:Content ContentPlaceHolderId="SideBar" runat="server">

            <asp:DropDownList ID="Omgeving" runat="server"  >
                <asp:ListItem>StubFTP-O</asp:ListItem>
                <asp:ListItem>StubFTP-T</asp:ListItem>
                <asp:ListItem>StubFTP-A</asp:ListItem>
                <asp:ListItem>StubFTP-A1</asp:ListItem>
                <asp:ListItem>StubFTP-A2</asp:ListItem>
                <asp:ListItem>StubFTP-Demo</asp:ListItem>
                <asp:ListItem>NS-FTP-Acceptatie</asp:ListItem>
                <asp:ListItem>NS-FTP-Productie</asp:ListItem>
            </asp:DropDownList><br>
		
            <asp:Button ID="InlezenBreefing" runat="server" Text="Inlezen Brefing"  />
      
</asp:Content>
