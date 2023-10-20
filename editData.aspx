<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editData.aspx.cs" Inherits="AdoCourse1.editData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Id :-&nbsp;
            <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
            <br />
            <br />
            name :-&nbsp;
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit" />
        </div>
    </form>
</body>
</html>
