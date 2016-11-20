<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Versies.aspx.cs" Inherits="Default2"  MasterPageFile="/MasterPage.master"  enableEventValidation="true"%>




<asp:Content ContentPlaceHolderId="Content" runat="server">
			
    
    <asp:Label ID="Label1" runat="server" Text="Omgeving"></asp:Label>
            <asp:DropDownList ID="Omgeving" runat="server"  >
                <asp:ListItem>T</asp:ListItem>
                <asp:ListItem>O</asp:ListItem>
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>P</asp:ListItem>

            </asp:DropDownList><br>
		<asp:Label ID="Label2" runat="server" Text="Release"></asp:Label>
           <asp:DropDownList ID="Release" runat="server"  >
                <asp:ListItem>r28</asp:ListItem>
                <asp:ListItem>r27</asp:ListItem>
                <asp:ListItem>r26</asp:ListItem>
                <asp:ListItem>r25</asp:ListItem>
                <asp:ListItem>r24</asp:ListItem>
           </asp:DropDownList><br>
 
   

            <asp:Button ID="GetVersion" runat="server" Text="Ophalen versies"  runat="server" OnClick="GetVersion_Click"   />
            <asp:Button ID="Clean" runat="server" Text="Opschonen lijst"  runat="server" OnClick="Clean_Click"   />
        
    <br>
    <h3>Versie van Azure componenten</h3>


    			<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/Versie.xml" ></asp:XmlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="100" DataSourceID="XmlDataSource1" AllowPaging="True" >
                 <pagersettings mode="Numeric"
                        Position ="Bottom"           
                          />
                 <Columns>
                     <asp:TemplateField HeaderText="Omgeving" >
                      <ItemTemplate>
                        <%# XPath("omgeving") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Release" >
                      <ItemTemplate>
                        <%# XPath("release") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="App Api" >
                      <ItemTemplate>
                        <%# XPath("appapi") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Versie Router" >
                      <ItemTemplate>
                        <%# XPath("versieRouter") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Berichten Backend">
                      <ItemTemplate>
                        <%# XPath("berichtenbackend") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dienst Backend">
                      <ItemTemplate>
                        <%# XPath("dienstbackend") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Treinrit Backend">
                      <ItemTemplate>
                        <%# XPath("treinritbackend") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Configuratie">
                      <ItemTemplate>
                        <%# XPath("configuratie") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Internal">
                      <ItemTemplate>
                        <%# XPath("internal") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loggingsportaal">
                      <ItemTemplate>
                        <%# XPath("loggingsportaal") %>
                      </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Laatste Update">
                      <ItemTemplate>
                        <%# XPath("laatsteupdate") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                 </Columns>
            </asp:GridView>
      
    


</asp:Content>









<asp:Content ContentPlaceHolderId="SideBar" runat="server">




    
      
</asp:Content>

		
	