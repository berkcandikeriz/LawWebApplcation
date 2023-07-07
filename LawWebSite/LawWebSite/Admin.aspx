<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LawWebSite.Admin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
</head>
<style>
    body{
    height: 100%;
     background: #000;
    }
    .kozan-admin-page {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    padding: 85px;
    background-color: #fff;
    border: 1px solid #ddd;
    border-radius: 5px;
    max-width: 400px;
    width: 100%;
    }

    .kozan-admin-title {
        text-align: center;
        margin-bottom: 20px;
    }

    .kozan-admin-form.form-group {
        margin-bottom: 15px;
        margin-top: 9px;
    }

    .kozan-admin-form label {
        display: block;
        margin-bottom: 5px;
    }

    input[type="text"],
    input[type="password"] {
        width: 100%;
        padding: 10px;
        border: 1px solid #ddd;
        border-radius: 5px;
    }

    button[type="submit"] {
    display: block;
    width: 100%;
    padding: 10px;
    background-color: #000;
    color: #fff;
    border: none;
    border-radius: 6px;
    cursor: pointer;
}
   
    
</style>
<body>
    <form runat="server">
        <div class="container kozan-admin-page">
            <h1 class="kozan-admin-title">Admin Paneli</h1>
            <div class="form-group kozan-admin-form">
                <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div class="form-group kozan-admin-form">
                <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
            </div>
            <asp:Button ID="BtnLogin" runat="server" Text="Giriş Yap" OnClick="btnLogin_Click" />
            <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials"  Visible="true"></asp:Label>
        </div>
    </form>
</body>


</html>
