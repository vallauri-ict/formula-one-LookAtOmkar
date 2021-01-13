<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FormulaOne</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav style="background-color:red; height: 57px;" class="row">
          <img  src="F1_LOGO.jpg" style="width: 209px; height: 58px; margin-left: 0px; margin-bottom: 0px;"/>   
        </nav>
        <div>
            <br />
            <asp:Label runat="server" Text="Scegli una tabella da visualizzare" />
            <br />
        </div>

        <div>
            <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="cmbDatabase_changed" AutoPostBack="true" Height="16px" Width="108px"></asp:DropDownList>
            <asp:GridView ID="gridViewData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
