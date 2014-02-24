<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bet_Frankfurt_NewsLetter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent"  runat="server">
    <img src="Logo.jpg" style="width: 903px; height: 113px" /></br>
    </br>
    שם מלא: <asp:TextBox ID="TextBox1"  CausesValidation = "false"  runat="server" Height="33px" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True" Width="357px"></asp:TextBox>
    </br>
    </br>
    כתובת: <asp:TextBox ID="TextBox2" runat="server" Height="33px" OnTextChanged="TextBox2_TextChanged" AutoPostBack="True" Width = "357px"></asp:TextBox>
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

</asp:Content>

