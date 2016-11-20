<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZoekTreinrit.aspx.cs" Inherits="pages_MijnDienst_ZoekTreinrit"  MasterPageFile="/MasterPage.master"%>



<asp:Content ContentPlaceHolderId="Content" runat="server">

     <h3>Zoek Treinrit in productie</h3>
            
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br>
 

            <asp:DropDownList ID="DropDownList1" runat="server" >
               <asp:ListItem Value="1-99">Treinreeks: 1 (99)</asp:ListItem>
                    <asp:ListItem Value="120-129">Treinreeks: 120 (10)</asp:ListItem>
                    <asp:ListItem Value="140-159">Treinreeks: 140 (20)</asp:ListItem>
                    <asp:ListItem Value="220-229">Treinreeks: 220 (10)</asp:ListItem>
                    <asp:ListItem Value="240-249">Treinreeks: 240 (10)</asp:ListItem>
                    <asp:ListItem Value="300-318">Treinreeks: 300 (19)</asp:ListItem>
                    <asp:ListItem Value="400-417">Treinreeks: 400 (18)</asp:ListItem>
                    <asp:ListItem Value="430-456">Treinreeks: 430 (27)</asp:ListItem>
                    <asp:ListItem Value="500-599">Treinreeks: 500 (100)</asp:ListItem>
                    <asp:ListItem Value="700-999">Treinreeks: 700 (300)</asp:ListItem>
                    <asp:ListItem Value="1100-1235">Treinreeks: 1100 (136)</asp:ListItem>
                    <asp:ListItem Value="1400-1426">Treinreeks: 1400 (27)</asp:ListItem>
                    <asp:ListItem Value="1500-1799">Treinreeks: 1500 (300)</asp:ListItem>
                    <asp:ListItem Value="1900-2299">Treinreeks: 1900 (400)</asp:ListItem>
                    <asp:ListItem Value="2400-2899">Treinreeks: 2400 (500)</asp:ListItem>
                    <asp:ListItem Value="3000-3199">Treinreeks: 3000 (200)</asp:ListItem>
                    <asp:ListItem Value="3300-3699">Treinreeks: 3300 (400)</asp:ListItem>
                    <asp:ListItem Value="3800-3899">Treinreeks: 3800 (100)</asp:ListItem>
                    <asp:ListItem Value="4000-4499">Treinreeks: 4000 (500)</asp:ListItem>
                    <asp:ListItem Value="4600-4699">Treinreeks: 4600 (100)</asp:ListItem>
                    <asp:ListItem Value="4900-5899">Treinreeks: 4900 (1000)</asp:ListItem>
                    <asp:ListItem Value="6000-6099">Treinreeks: 6000 (100)</asp:ListItem>
                    <asp:ListItem Value="6300-6499">Treinreeks: 6300 (200)</asp:ListItem>
                    <asp:ListItem Value="6800-7099">Treinreeks: 6800 (300)</asp:ListItem>
                    <asp:ListItem Value="7400-7699">Treinreeks: 7400 (300)</asp:ListItem>
                    <asp:ListItem Value="7900-8099">Treinreeks: 7900 (200)</asp:ListItem>
                    <asp:ListItem Value="8500-8599">Treinreeks: 8500 (100)</asp:ListItem>
                    <asp:ListItem Value="8800-8899">Treinreeks: 8800 (100)</asp:ListItem>
                    <asp:ListItem Value="9100-9369">Treinreeks: 9100 (270)</asp:ListItem>
                    <asp:ListItem Value="9400-9899">Treinreeks: 9400 (500)</asp:ListItem>
                    <asp:ListItem Value="9920-9920">Treinreeks: 9920 (1)</asp:ListItem>
                    <asp:ListItem Value="12199-12199">Treinreeks: 12199 (1)</asp:ListItem>
                    <asp:ListItem Value="12500-12599">Treinreeks: 12500 (100)</asp:ListItem>
                    <asp:ListItem Value="12700-12799">Treinreeks: 12700 (100)</asp:ListItem>
                    <asp:ListItem Value="13600-13699">Treinreeks: 13600 (100)</asp:ListItem>
                    <asp:ListItem Value="14000-14299">Treinreeks: 14000 (300)</asp:ListItem>
                    <asp:ListItem Value="14400-14599">Treinreeks: 14400 (200)</asp:ListItem>
                    <asp:ListItem Value="15400-15499">Treinreeks: 15400 (100)</asp:ListItem>
                    <asp:ListItem Value="16000-16099">Treinreeks: 16000 (100)</asp:ListItem>
                    <asp:ListItem Value="17400-17499">Treinreeks: 17400 (100)</asp:ListItem>
                    <asp:ListItem Value="17800-17899">Treinreeks: 17800 (100)</asp:ListItem>
                    <asp:ListItem Value="18500-18599">Treinreeks: 18500 (100)</asp:ListItem>
                    <asp:ListItem Value="19500-19599">Treinreeks: 19500 (100)</asp:ListItem>
                    <asp:ListItem Value="19800-19899">Treinreeks: 19800 (100)</asp:ListItem>
                    <asp:ListItem Value="20800-20899">Treinreeks: 20800 (100)</asp:ListItem>
                    <asp:ListItem Value="21400-21499">Treinreeks: 21400 (100)</asp:ListItem>
                    <asp:ListItem Value="24000-24216">Treinreeks: 24000 (217)</asp:ListItem>
                    <asp:ListItem Value="24218-24898">Treinreeks: 24218 (681)</asp:ListItem>
                    <asp:ListItem Value="25000-25483">Treinreeks: 25000 (484)</asp:ListItem>
                    <asp:ListItem Value="26000-26377">Treinreeks: 26000 (378)</asp:ListItem>
                    <asp:ListItem Value="27000-27199">Treinreeks: 27000 (200)</asp:ListItem>
                    <asp:ListItem Value="28300-28399">Treinreeks: 28300 (100)</asp:ListItem>
                    <asp:ListItem Value="28500-28899">Treinreeks: 28500 (400)</asp:ListItem>
                    <asp:ListItem Value="29400-29799">Treinreeks: 29400 (400)</asp:ListItem>
                    <asp:ListItem Value="29900-29999">Treinreeks: 29900 (100)</asp:ListItem>
                    <asp:ListItem Value="30700-31499">Treinreeks: 30700 (800)</asp:ListItem>
                    <asp:ListItem Value="31800-32419">Treinreeks: 31800 (620)</asp:ListItem>
                    <asp:ListItem Value="36700-36899">Treinreeks: 36700 (200)</asp:ListItem>
                    <asp:ListItem Value="37000-38099">Treinreeks: 37000 (1100)</asp:ListItem>
                    <asp:ListItem Value="39500-39599">Treinreeks: 39500 (100)</asp:ListItem>
                    <asp:ListItem Value="39700-39799">Treinreeks: 39700 (100)</asp:ListItem>
            </asp:DropDownList>

               <asp:Button ID="Zoeken" runat="server" Text="Zoeken"  runat="server" OnClick="Zoeken_Click"     />


			<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/datasource/Treinritten.xml" ></asp:XmlDataSource>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="100" DataSourceID="XmlDataSource1" AllowPaging="True" Width="990px" >
                 <pagersettings mode="Numeric"
                        Position ="Bottom"           
                          />
                <Columns>
 
                    <asp:TemplateField HeaderText="Treinnummer">
                      <ItemTemplate>
                        <%# XPath("treinnummer") %>
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



