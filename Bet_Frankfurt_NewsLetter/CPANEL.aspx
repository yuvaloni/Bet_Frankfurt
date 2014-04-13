<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPANEL.aspx.cs" Inherits="Bet_Frankfurt_NewsLetter.CPANEL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>            
    <form id="form1" runat="server">
    <div>
    
       סיסמה:
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="הוסף אירועים" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="מחק אירועים" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="ניהול אנשי קשר" />
    </form>
</body>
</html>
