<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="Bet_Frankfurt_NewsLetter.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        נושא:<asp:TextBox ID="TextBox1" runat="server" Width="574px"></asp:TextBox>
        <br />
        גוף ההודעה:<asp:TextBox ID="TextBox2" runat="server" Height="246px" TextMode="MultiLine" Width="574px"></asp:TextBox>
        <br />
        <br />
        <br />
        תמונה:<asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp; jpg בלבד<br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="שליחה לרשומים לאירועים לילדים בלבד" Width="319px" OnClick="Button1_Click" />
    
    </div>
        <p>
            <asp:Button ID="Button2" runat="server" Text="שליחה לרשומים לאירועים למבוגרים בלבד" OnClick="Button2_Click" />
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="שליחה לכולם" Width="326px" OnClick="Button3_Click" />
        </p>
    </form>
</body>
</html>
