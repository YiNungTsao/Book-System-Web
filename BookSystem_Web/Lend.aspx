<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.master" AutoEventWireup="true" CodeFile="Lend.aspx.cs" Inherits="Default2" %>

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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Lend_StdID" runat="server" Text="學號" Font-Names="微软雅黑"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="Lend_StdIDtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Lend_BookID" runat="server" Text="書籍代碼" Font-Names="微软雅黑"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="Lend_BookIDtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Lend_Name" runat="server" Text="姓名" Font-Names="微软雅黑"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="Lend_Nametxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Lend_BookName" runat="server" Text="書名" Font-Names="微软雅黑"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="Lend_BookNametxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Lend_Class" runat="server" Text="班級" Font-Names="微软雅黑"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="Lend_Classtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Lend_StartDate" runat="server" Text="借出日期" Font-Names="微软雅黑"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="Lend_StartDatetxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;<br />
<br />
    <asp:Label ID="Lend_Status" runat="server" Font-Names="微软雅黑 Light" style="z-index: 1; left: 643px; top: 397px; position: absolute"></asp:Label>
    <br />
    <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Lend_ReadData" runat="server" Text="查詢" OnClick="Lend_ReadData_Click" Height="46px" Width="117px" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Lend_InsertData" runat="server" Text="借出" OnClick="Lend_InsertData_Click" Height="46px" Width="117px" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" />
<br />
<br />
</asp:Content>

