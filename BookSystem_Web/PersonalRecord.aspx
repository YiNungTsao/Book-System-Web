<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.master" AutoEventWireup="true" CodeFile="PersonalRecord.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftBar" Runat="Server">
    <asp:CheckBoxList ID="LeftBar" runat="server" 
                        style="z-index: 1; left: 11px; top: 310px; position: absolute; height: 158px; width: 190px" AutoPostBack="True" Font-Names="微软雅黑" ForeColor="White">
    <asp:ListItem>借書</asp:ListItem>
    <asp:ListItem>還書</asp:ListItem>
        <asp:ListItem>尚未歸還</asp:ListItem>
    <asp:ListItem>個人紀錄</asp:ListItem>
    <asp:ListItem>班級紀錄</asp:ListItem>
    <asp:ListItem>新增學生資料</asp:ListItem>
    <asp:ListItem>新增書本資料</asp:ListItem>
    <asp:ListItem>刪除學生資料</asp:ListItem>
        <asp:ListItem>借錯歸還</asp:ListItem>
        <asp:ListItem>更新書本資料</asp:ListItem>
    <asp:ListItem>更新學生資料</asp:ListItem>
</asp:CheckBoxList>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Result" Runat="Server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="PersonalRecord_StdID" runat="server" Text="學號" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="PersonalRecord_StdIDtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<asp:Label ID="PersonalRecord_Name" runat="server" Text="姓名" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="PersonalRecord_Nametxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<asp:Label ID="PersonalRecord_Class" runat="server" Text="班級" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="PersonalRecord_Classtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<br />
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="PersonalRecord_Record" runat="server" Text="顯示個人歷史紀錄" OnClick="PersonalRecord_Record_Click" Height="54px" Width="243px" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="PersonalRecord_Status" runat="server" Font-Names="微软雅黑 Light" style="z-index: 1; left: 889px; top: 332px; position: absolute"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
<br />
&nbsp;&nbsp;&nbsp;
<br />
<asp:GridView ID="PersonalRecord_View" runat="server" CellPadding="4" Font-Size="Medium" style="z-index: 1; left: 324px; top: 425px; position: absolute; height: 133px; width: 761px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" Font-Names="微软雅黑 Light">
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <HeaderStyle BackColor="#FF9933" Font-Bold="True" ForeColor="White" Font-Names="微软雅黑" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SortedAscendingCellStyle BackColor="#EDF6F6" />
    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
    <SortedDescendingCellStyle BackColor="#D6DFDF" />
    <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
<br />
<br />
</asp:Content>

