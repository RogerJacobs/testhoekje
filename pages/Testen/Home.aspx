<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home"  MasterPageFile="/MasterPage.master"%>





<asp:Content ContentPlaceHolderId="Content" runat="server">
    <h2>Testen V0.3</h2>
  <p>Testen</p>

    <asp:TextBox ID="TextBox1" runat="server" Width="793px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Aanmaken workspace" OnClick="Button1_Click" />





    <p> 
<iframe ID="VSGIframe"  
	width="600" height="600" style="border:1;" runat="server"></iframe>
</p>

        <p> 
<iframe src="../../screentemplate/IAM.svg" 
	width="500" height="500" style="border:1;"></iframe>
</p>

</asp:Content>









<asp:Content ContentPlaceHolderId="SideBar" runat="server">
    <h2>Individual SideBar</h2>
  <p>Paragraph 1</p>
  <p>Paragraph 2</p>
</asp:Content>