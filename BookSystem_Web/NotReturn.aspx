<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.master" AutoEventWireup="true" CodeFile="NotReturn.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftBar" Runat="Server">
    <asp:CheckBoxList ID="LeftBar" runat="server" 
                        style="z-index: 1; left: 11px; top: 310px; position: absolute; height: 158px; width: 123px" AutoPostBack="True" Font-Names="微软雅黑" ForeColor="White">
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
<asp:Label ID="NotReturn_StdID" runat="server" Text="學號" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="NotReturn_StdIDtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<asp:Label ID="NotReturn_Name" runat="server" Text="姓名" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="NotReturn_Nametxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<asp:Label ID="NotReturn_Class" runat="server" Text="班級" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="NotReturn_Classtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
<asp:Button ID="NotReturn_Show" runat="server" Text="顯示未歸還的書籍" OnClick="NotReturn_Show_Click" Height="54px" Width="243px" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="NotReturn_Status" runat="server" style="z-index: 1; left: 940px; top: 251px; position: absolute" Font-Names="微软雅黑 Light"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
<br />
<asp:CheckBoxList ID="NotReturnBookList" runat="server" Height="85px" Width="953px" AutoPostBack="True" Font-Names="微软雅黑">
</asp:CheckBoxList>
<br />
<br />
<br />
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
</asp:Content>

