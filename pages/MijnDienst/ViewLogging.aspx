
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewLogging.aspx.cs" Inherits="pages_MijnDienst_ViewLogging"  MasterPageFile="/MasterPage.master"%>





<asp:Content ContentPlaceHolderId="Content" runat="server">

     <h3>Logging ADK</h3>
  
        <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" xmlns:asp="#unknown" Width="560px">
            <columns>
                <asp:hyperlinkfield datatextfield="name" headertext="File Names" />
            </columns>
        </asp:gridview>

</asp:Content>








<asp:Content ContentPlaceHolderId="SideBar" runat="server">
     <asp:Button ID="DeleteAll" runat="server" Text="Delete All"  runat="server" OnClick="DeleteAll_Click"      />
</asp:Content>