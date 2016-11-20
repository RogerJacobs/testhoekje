<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestResults.aspx.cs" Inherits="TestResults"  MasterPageFile="/MasterPage.master"%>



<asp:Content ContentPlaceHolderId="Content" runat="server">
    <h2>Test resultaten</h2>
 
    
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource_TestResults"></asp:TreeView>
  
    <asp:XmlDataSource ID="XmlDataSource_TestResults" runat="server"></asp:XmlDataSource>
  
</asp:Content>









<asp:Content ContentPlaceHolderId="SideBar" runat="server">
    <h2>Individual SideBar</h2>
  <p>Paragraph 1</p>
  <p>Paragraph 2</p>
</asp:Content>


