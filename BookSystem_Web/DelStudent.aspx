<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.master" AutoEventWireup="true" CodeFile="DelStudent.aspx.cs" Inherits="Default2" %>

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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<asp:Label ID="DelStd_ID" runat="server" Text="學號" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="DelStd_StdIDtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
&nbsp;&nbsp;<asp:Label ID="DelStd_Name" runat="server" Text="姓名" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="DelStd_Nametxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
    &nbsp;
<asp:Label ID="DelStd_Class" runat="server" Text="班級" Font-Names="微软雅黑"></asp:Label>
<asp:TextBox ID="DelStd_Classtxt" runat="server" Font-Names="微软雅黑 Light"></asp:TextBox>
<br />
<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<br />
    <asp:Button ID="DelStd_Delete" runat="server" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" Height="46px" OnClick="DelStd_Delete_Click" style="z-index: 1; left: 646px; top: 353px; position: absolute" Text="刪除資料" Width="117px" />
<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="DelStd_ReadData" runat="server" BackColor="#FF9933" Font-Names="微软雅黑" ForeColor="White" Height="46px" OnClick="DelStd_ReadData_Click" style="z-index: 1; left: 339px; top: 353px; position: absolute" Text="查詢資料" Width="117px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
<asp:Label ID="DelStd_Status" runat="server" style="z-index: 1; left: 976px; top: 382px; position: absolute" Font-Names="微软雅黑 Light"></asp:Label>
    <asp:Label ID="DelStudent_Warning" runat="server" BorderStyle="Dashed" Font-Names="微软雅黑" Font-Size="X-Large" ForeColor="#0033CC" style="z-index: 1; left: 332px; top: 446px; position: absolute" Text="刪除學生資料前，要先確認是否還有書本沒有歸還"></asp:Label>
</asp:Content>

