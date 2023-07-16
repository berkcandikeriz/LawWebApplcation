<%@ Page Title="Dil Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsLanguage.aspx.cs" Inherits="LawWebSite.Management.SettingsLanguage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa fa-flag"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active"><i class="fa fa-flag"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#modal-default">
                Yeni Dil Ekle
            </a>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa fa-flag"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 40%"></th>
                                <th style="width: 20%">#Id Bilgisi</th>
                                <th style="width: 20%">Dil Adı
                                </th>
                                <th style="width: 20%">Bayrak</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RLanguages">
                                <ItemTemplate>
                                    <tr>
                                        <td></td>
                                        <td><%#Eval("LanguageId") %></td>
                                        <td><%#Eval("Name") %></td>
                                        <td><%#Eval("Flag") %></td>
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
                    <h4 class="modal-title">Yeni Dil Ekle</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                 <div class="modal-body">
                    <form class="form" role="form" autocomplete="off">

                      
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">İsim</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLanguageName" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label">Bayrak</label>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtLanguageFlag" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </form>
                </div>
                  <div class="modal-footer justify-content-between">
                    <asp:LinkButton runat="server" ID="lnkCloseLanguage" CssClass="btn btn-danger" OnClick="lnkCloseLanguage_Click">Pencereyi Kapat</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkAddLanguage" CssClass="btn btn-primary" OnClick="lnkAddLanguage_Click">Yeni Dil Ekle</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
