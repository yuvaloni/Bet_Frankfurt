<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="Bet_Frankfurt_NewsLetter.AddEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
       שם: <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="418px"></asp:TextBox>
        <p>
          חודש:  <asp:TextBox ID="TextBox2" runat="server" Width="451px"></asp:TextBox>
            תאריך: <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
       תיאור: <asp:TextBox ID="TextBox3" runat="server" Height="169px" TextMode="MultiLine" Width="420px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Text="הוסף אירוע לילדים" Width="148px" OnClick="AddChildren" />
            <asp:Button ID="Button2" runat="server" Text="הוסף אירוע למבוגרים" Width="148px" OnClick="AddAdults" />
        </p>
    </form>
</body>
</html>
