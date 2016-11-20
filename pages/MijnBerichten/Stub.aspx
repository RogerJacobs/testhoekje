<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stub.aspx.cs" Inherits="pages_MijnBerichten_Stub"  MasterPageFile="/MasterPage.master"%>



<asp:Content ContentPlaceHolderId="Content" runat="server">

     <h3>Stub </h3>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>  
    <asp:Button ID="StartStub" runat="server" Text="Start Stub" OnClick="StartStub_Click" />
    <asp:Label ID="Status" runat="server" Text="Label"></asp:Label>

</asp:Content>



<asp:Content ContentPlaceHolderId="SideBar" runat="server">

      
</asp:Content>

