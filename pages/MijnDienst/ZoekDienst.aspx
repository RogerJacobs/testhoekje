<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZoekDienst.aspx.cs" Inherits="pages_MijnDienst_ZoekDienst"  MasterPageFile="/MasterPage.master"%>



<asp:Content ContentPlaceHolderId="Content" runat="server">

     <h3>Zoek Dienst in productie</h3>
            
    
           <asp:Label ID="LabelStandplaats" runat="server" Text="Standplaats"></asp:Label>
            <asp:DropDownList ID="StandPlaats" runat="server"  >
                <asp:ListItem>ut</asp:ListItem>
                <asp:ListItem>amf</asp:ListItem>
                <asp:ListItem>asd</asp:ListItem>
            </asp:DropDownList><br>
		
              <asp:Label ID="Label3" runat="server" Text="FunctieCode"></asp:Label>
            <asp:DropDownList ID="FunctieCode" runat="server"  >
                <asp:ListItem>M</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
            </asp:DropDownList><br>
      
            <asp:Label ID="Label1" runat="server" Text="Van"></asp:Label>
            <asp:TextBox ID="TextBoxVan" runat="server" Height="12px" Width="60px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="tot en met"></asp:Label>
            <asp:TextBox ID="TextBoxTot" runat="server" Height="12px" Width="60px"></asp:TextBox>   
            <asp:Button ID="Zoeken" runat="server" Text="Zoeken"  runat="server" OnClick="Zoeken_Click"     />

  

			<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/Diensten.xml" ></asp:XmlDataSource>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="100" DataSourceID="XmlDataSource1" AllowPaging="True" >
                 <pagersettings mode="Numeric"
                        Position ="Bottom"           
                          />
                <Columns>
                    <asp:TemplateField HeaderText="DienstNr" >
                      <ItemTemplate>
                        <%# XPath("dienstnummer") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Planfase" >
                      <ItemTemplate>
                        <%# XPath("planfase") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rol" >
                      <ItemTemplate>
                        <%# XPath("rol") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start" >
                      <ItemTemplate>
                        <%# XPath("start") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stop">
                      <ItemTemplate>
                        <%# XPath("stop") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Treinnummer">
                      <ItemTemplate>
                        <%# XPath("treinnummer") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Soort">
                      <ItemTemplate>
                        <%# XPath("soort") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mat Nr">
                      <ItemTemplate>
                        <%# XPath("materieelnummers") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stops">
                      <ItemTemplate>
                        <%# XPath("stops") %>
                      </ItemTemplate>

                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>

</asp:Content>

<asp:Content ContentPlaceHolderId="SideBar" runat="server">

 

            
      
</asp:Content>



