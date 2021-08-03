<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.master" AutoEventWireup="true" CodeFile="AddStudents.aspx.cs" Inherits="Default2" %>

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
<asp:Label ID="AddStd_Name" runat="server" Text="姓名" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="AddStd_Nametxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Label ID="AddStd_ID" runat="server" Text="學號" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="AddStd_StdIDtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Label ID="AddStd_Class" runat="server" Text="班級" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="AddStd_Classtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="AddStd_Build" runat="server" Text="新建資料" OnClick="AddStd_Build_Click" Height="46px" Width="117px" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" />
    <asp:Label ID="AddStd_Status" runat="server" style="z-index: 1; left: 911px; top: 395px; position: absolute" Font-Names="微软雅黑 Light"></asp:Label>
<br />
</asp:Content>

