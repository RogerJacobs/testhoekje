<%@ Page Language="C#" AutoEventWireup="true" CodeFile="iam.aspx.cs" Inherits="IAM"  MasterPageFile="/MasterPage.master"%>





<asp:Content ContentPlaceHolderId="Content" runat="server">
    
    <h3>IAM</h3>

  
    
    <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/datasource/IAM_hoofdbaanvaken.xml"></asp:XmlDataSource>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="100" DataSourceID="XmlDataSource2" AllowPaging="True" Width="459px" >
                 <pagersettings mode="Numeric"
                        Position ="Bottom"           
                          />
                 <Columns>
                     <asp:TemplateField HeaderText="Hoofdbaanvakken" >
                      <ItemTemplate>
                        <%# XPath("name") %>
                      </ItemTemplate>
                    </asp:TemplateField>
                 </Columns>
            </asp:GridView>


  
    <h3>Toon hele bericht</h3>
    <asp:Label id="Label1" runat="server" ></asp:Label><br>
    <asp:Label id="Label2" runat="server" ></asp:Label><br>
    <asp:Label id="Label3" runat="server" ></asp:Label><br>


  

    <asp:Xml ID="Xml1" runat="server"></asp:Xml>

    <pre>
        <asp:Literal ID="XmlText" runat="server"></asp:Literal>
   </pre>

    

    <br><asp:Button ID="SluitAll" runat="server" Text="Alles sluiten" OnClick="SluitAll_Click" />
    <asp:Button ID="OpenAll" runat="server" Text="Alles openen" OnClick="OpenAll_Click" />

    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="IAM" TextField="EindeGeldigheidsDatumtijd" ToolTip="adsrsrsf" ToolTipField="#Name" />
            <asp:TreeNodeBinding DataMember="TSB_Aantal" ImageToolTipField="#Name" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="RayonInfoAantal" ImageToolTipField="#Name" Text="dfgdgsdf" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="WegwijzerAantal" ImageToolTipField="#Name" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="HoofdBaanvakCode" ValueField="#InnerText" />
            <asp:TreeNodeBinding DataMember="HoofdBaanvakOmschrijving" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="BaanvakCode" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="BaanvakOmschrijving" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="DienstregelpuntVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="DienstregelpuntTot" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="GeldigheidsDatumTijdVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden1" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden2" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden4" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="DienstregelpuntVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="DienstregelpuntTot" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="GeldigheidsDatumTijdVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden1" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden2" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden3" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden4" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden5" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="GeldigheidsDatumTijdTotenMet" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="GeldigheidsDatumTijdVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="PublicatieDatumTijdVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="DienstregelpuntVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="DienstregelpuntTot" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Richting" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden1" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="Reden2" />
            <asp:TreeNodeBinding DataMember="Spooraanduiding1" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="PlaatsAanduidingVan" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="PlaatsAanduidingTot" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="MaxSnelheidReiziger" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="LAE_BordAanduiding" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="MaxSnelheidGoederen" ImageToolTipField="#Name" TextField="#InnerText" />
            <asp:TreeNodeBinding DataMember="error" TextField="#InnerText" />
        </DataBindings>
    </asp:TreeView>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/IAM.xml"></asp:XmlDataSource>
</asp:Content>









<asp:Content ContentPlaceHolderId="SideBar" runat="server">
           <asp:Label ID="Label" runat="server" Text="Omgeving"></asp:Label>
            <asp:DropDownList ID="Omgeving" runat="server"  >
                <asp:ListItem>Stub_O</asp:ListItem>
                <asp:ListItem>Stub_T</asp:ListItem>
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>P</asp:ListItem>
            </asp:DropDownList><br>

    <asp:Button ID="GetIAM" runat="server" Text="IAM ophalen"  runat="server" OnClick="GetIAM_Click"      />
</asp:Content>