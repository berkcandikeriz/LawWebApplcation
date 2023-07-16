<%@ Page Title="Menü Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsMenu.aspx.cs" Inherits="LawWebSite.Management.SettingsMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa fa-list nav-icon"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active"><i class="fa fa-list nav-icon"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#modal-default">Yeni Menü Ekle
            </a>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa fa-list nav-icon"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>

                                <th style="width: 20%">#Dil Id</th>
                                <th style="width: 20%">Isim</th>
                                <th style="width: 20%">Url</th>
                                <th style="width: 20%">Sıralama</th>
                                <th style="width: 20%">Konumu</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RMenus">
                                <ItemTemplate>
                                    <tr>

                                        <td><%#Eval("LanguageId") %></td>
                                        <td><%#Eval("Name") %></td>
                                        <td><%#Eval("Url") %></td>
                                        <td><%#Eval("Order") %></td>
                                        <td><%#Eval("Location") %></td>
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
                    <h4 class="modal-title">Yeni Menü Ekle</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Id</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtDilId" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">İsim</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtIsim" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label">Url</label>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtUrl" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label">Sıralama</label>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtSiralama" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label">Konumu</label>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtKonum" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </form>
                </div>



                <div class="modal-footer justify-content-between">
                    <asp:LinkButton runat="server" ID="lnkCloseMenu" CssClass="btn btn-danger" OnClick="lnkCloseMenu_Click">Pencereyi Kapat</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkAddMenu" CssClass="btn btn-primary" OnClick="lnkAddMenu_Click">Yeni Menü Ekle</asp:LinkButton>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
