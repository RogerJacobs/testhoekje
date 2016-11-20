<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Briefing.aspx.cs" Inherits="Default2"  MasterPageFile="/MasterPage.master"%>



<asp:Content ContentPlaceHolderId="Content" runat="server">

     <h3>Briefing </h3>
            

            
            <p>
                <asp:Label ID="Label1" runat="server" Text="Rol"></asp:Label><br>
                <asp:ListBox ID="ListBox1" runat="server" Height="100px" SelectionMode="Multiple"  >
                    <asp:ListItem>Machinist-NSR</asp:ListItem>
                    <asp:ListItem>Hoofdconducteur-NSR</asp:ListItem>
                    <asp:ListItem>Servicemedewerker</asp:ListItem>
                    <asp:ListItem>Procesleider-Perron</asp:ListItem>
                    <asp:ListItem>Veiligheid-en-service</asp:ListItem>
                    <asp:ListItem>Trainmanager-ICBrussel</asp:ListItem>
                    <asp:ListItem>Trainmanager-ICE</asp:ListItem>
                    <asp:ListItem>Trainmanager-Thalys</asp:ListItem>
                    <asp:ListItem>Machinist-ICE</asp:ListItem>
                    <asp:ListItem>Machinist-ICBrussel</asp:ListItem>
                    <asp:ListItem>Machinist-Thalys</asp:ListItem>
                </asp:ListBox>
            </p>
      
    
          
            <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="Refresh_Click" />

  

			<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/Berichten.xml" ></asp:XmlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="100" DataSourceID="XmlDataSource1" AllowPaging="True" >
                 <pagersettings mode="Numeric"
                        Position ="Bottom"           
                          />

                <Columns>
                    <asp:TemplateField HeaderText="Id" >
                      <ItemTemplate>
                        <%# XPath("id") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Titel" >
                      <ItemTemplate>
                        <%# XPath("titel") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="categorie">
                      <ItemTemplate>
                        <%# XPath("categorie") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="rollen">
                      <ItemTemplate>
                        <%# XPath("rollen") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Van">
                      <ItemTemplate>
                        <%# XPath("geldigheidVan") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tot">
                      <ItemTemplate>
                        <%# XPath("geldigheidTot") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

</asp:Content>



<asp:Content ContentPlaceHolderId="SideBar" runat="server">

                <script type="text/javascript" language="javascript">
                    function Disabel_InlezenBreefing() {
<%--                        document.getElementById('ModalPopup').style.visibility = 'visible';
                        document.getElementById("<%= InlezenBreefing.ClientID %>").disabled = true;
                        document.getElementById("<%= InlezenBreefing.ClientID %>").value = "even wachten";--%>


                       
                    }
                </script>

  


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
		
     
 
   

            <asp:Button ID="InlezenBreefing" runat="server" Text="Inlezen Brefing"  runat="server" OnClick="InlezenBreefing_Click" OnClientClick="return Disabel_InlezenBreefing()"   />

            
      
</asp:Content>

