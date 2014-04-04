<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bet_Frankfurt_NewsLetter._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent"  runat="server">
    <img src ="bg.jpg" style="position:absolute; height:100%; top:0;"/>
    <img src ="white.jpg" style="position:absolute;top:25%; height:45%; width:65%; left:17.5%;"/>
    <div style="position:absolute;layer:0; top:25%; left: 18%; height:45%; width:65%;">

    <img src="Logo.jpg" style="width: 65%; height: 45% ;position:absolute;" /></br>
    </br>
    שם מלא: <asp:TextBox ID="TextBox1"  CausesValidation = "false"  runat="server" Height="33px" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True" Width="357px"></asp:TextBox>
    </br>
    </br>
    כתובת דוא"ל: <asp:TextBox ID="TextBox2" runat="server" Height="33px" OnTextChanged="TextBox2_TextChanged" AutoPostBack="True" Width = "357px"></asp:TextBox>
    </br>
   </br>
    מספר טלפון: <asp:TextBox ID="TextBox3"  runat="server" Height="33px" OnTextChanged="TextBox3_TextChanged" AutoPostBack="True" Width="357px"></asp:TextBox>
    </br>
    </br>
    <asp:CheckBox ID="CheckBox1" runat="server" Text="אירועים למבוגרים" />
    <asp:CheckBox ID="CheckBox2" runat="server" Text ="אירועים לילדים"  />
    </br>
    </br>
    <asp:Button ID="Button1" runat="server" Text="תרשמו אותי!" OnClick="Button1_OnClick" />
    </div>

</asp:Content>

