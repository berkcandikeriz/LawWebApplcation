<%@ Page Title="Avukat Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsLawyer.aspx.cs" Inherits="LawWebSite.Management.SettingsLawyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa fa-users"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active"><i class="fa fa-users"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#modal-default">Yeni Avukat Ekle
            </a>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa fa-users"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 7%">#Lawyer Id</th>
                                <th style="width: 7%">Avukat Adı</th>
                                <th style="width: 7%">Avukat Soyadı</th>
                                <th style="width: 7%">Rütbesi</th>
                                <th style="width: 7%">Fotoğrafı</th>
                                <th style="width: 7%">Facebook</th>
                                <th style="width: 7%">Twitter</th>
                                <th style="width: 7%">Instgram</th>
                                <th style="width: 7%">Linkedln</th>
                                <th style="width: 7%">Email</th>
                                <th style="width: 8%">Telefon Numarası</th>
                                <th style="width: 8%">Açıklama</th>
                                <th style="width: 7%">Panel Yöneticisimi</th>
                                <th style="width: 7%">Şifresi</th>



                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RLawyers">
                                <ItemTemplate>
                                    <tr>

                                        <td><%#Eval("LawyerId") %></td>
                                        <td><%#Eval("FirstName") %></td>
                                        <td><%#Eval("LastName") %></td>
                                        <td><%#Eval("Title") %></td>
                                        <td><%#Eval("ImgUrl") %></td>
                                        <td><%#Eval("Facebook") %></td>
                                        <td><%#Eval("Twitter") %></td>
                                        <td><%#Eval("Instagram") %></td>
                                        <td><%#Eval("Linkedin") %></td>
                                        <td><%#Eval("Email") %></td>
                                        <td><%#Eval("IsAdmin") %></td>
                                        <td><%#Eval("Description") %></td>
                                        <td><%#Eval("IsAdmin") %></td>
                                        <td><%#Eval("Password") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Yeni Avukat Ekle</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Avukat Adı</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerName" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Avukat Soyadı</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerSurname" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Rütbesi</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerTitle" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Fotoğrafı</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerImage" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Facebook</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerFacebook" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Twitter</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerTwitter" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Instgram</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerInstgram" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Linkedln</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerLinkedln" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Email</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerEmail" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Telefon Numarası</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerTel" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Açıklama</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerDescription" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Panel Yöneticisimi</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerAdmin" placeHolder="Admin ise 1 değilse 0 verilmesi gerekiyor" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group row">
                            <label class ="col-md-3 col-form-label form-control-label">Şifresi</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLawyerPassword" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </form>
                </div>



                <div class="modal-footer justify-content-between">
                    <asp:LinkButton runat="server" ID="lnkCloseLawyer" CssClass="btn btn-danger" OnClick="lnkCloseLawyer_Click">Pencereyi Kapat</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkAddLawyer" CssClass="btn btn-primary" OnClick="lnkAddLawyer_Click">Yeni Avukat Ekle</asp:LinkButton>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
