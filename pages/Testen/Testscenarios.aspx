<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testscenarios.aspx.cs" Inherits="Default2" MasterPageFile="/MasterPage.master" %>



<asp:Content ContentPlaceHolderId="Content" runat="server">
            
    <asp:Button ID="SluitAll" runat="server" Text="Alles sluiten" OnClick="SluitAll_Click" />
    <asp:Button ID="OpenAll" runat="server" Text="Alles openen" OnClick="OpenAll_Click" />

    <asp:Label id="Label1" runat="server" ></asp:Label><br>
    <asp:Label id="Label2" runat="server" ></asp:Label><br>
    <asp:Label id="Label3" runat="server" ></asp:Label><br>

           <asp:TreeView ID="TreeView1" 
                runat="server" 
                DataSourceID="XmlDataSource1" 
                CssClass="tree" 
                CollapseImageUrl="~/images/min.png"
                ExpandImageUrl="~/images/plus.png"
                LeafImageUrl="~/images/not.png" >
                
                <DataBindings>
                    <asp:TreeNodeBinding DataMember="steps" TextField="#InnerText" />
                    <asp:TreeNodeBinding DataMember="text" TextField="#InnerText" />
                    <asp:TreeNodeBinding DataMember="scenario" TextField="text" />
                    <asp:TreeNodeBinding DataMember="feature" TextField="text" />
                </DataBindings>
            </asp:TreeView>
                     </td>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/testscenarios.xml"></asp:XmlDataSource>
           
</asp:Content>




<asp:Content ContentPlaceHolderId="SideBar" runat="server">
    <asp:Button ID="ImportScenarios" runat="server" Height="31px" Text="Import" Width="82px" OnClick="Button1_Click" />
</asp:Content>
