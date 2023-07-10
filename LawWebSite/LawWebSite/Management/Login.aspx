<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LawWebSite.Management.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Giriş Yap - Yönetim Paneli | Kozanoğlu Hukuk</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="https://kit.fontawesome.com/d413deb380.css" crossorigin="anonymous" />
    <script src="https://kit.fontawesome.com/d413deb380.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <link rel="stylesheet" href="dist/css/adminlte.min.css" />
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <!--Buraya logo gelecek-->
                <%--<img src="../Assets/img/logo-official.png" class="img-fluid" width="75%" />--%>
                <h3>Kozanoğlu Hukuk</h3>
            </div>
            <asp:Panel class="card" runat="server" ID="PnlLogin" DefaultButton="LbSignIn">
                <div class="card-body login-card-body">
                    <div class="input-group mb-3">
                        <asp:TextBox runat="server" ID="TbUsername" CssClass="form-control" placeholder="Kullanıcı Adınız" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <i class="fa-solid fa-envelope"></i>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox runat="server" ID="TbPassword" TextMode="password" CssClass="form-control" placeholder="Şifreniz" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <i class="fa-solid fa-lock"></i>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-12 text-right">
                            <asp:LinkButton runat="server" ID="LbSignIn" CssClass="btn btn-primary" OnClick="LbSignIn_Click"><i class="fa-solid fa-sign-in"></i>&nbsp;Giriş Yap</asp:LinkButton>
                        </div>
                    </div>
                    <p class="login-box-msg">
                        <b><asp:Label runat="server" ID="LblInformation" /></b>
                    </p>
                </div>

            </asp:Panel>
            <div class="text-center">
                <a href="Login.aspx" runat="server"><span class="color-a">Kozanoğlu Hukuk</span></a>
                <br />
                <asp:Label runat="server" ID="LblFooterCopyright" />&nbsp;&copy; <%: DateTime.Now.Year %>
            </div>
        </div>

        <script src="plugins/jquery/jquery.min.js"></script>
        <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
