<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="Bet_Frankfurt_NewsLetter.People" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="ListBox1" runat="server" Height="378px" Width="550px"></asp:ListBox>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="הסר איש קשר" />
    </form>
</body>
</html>
