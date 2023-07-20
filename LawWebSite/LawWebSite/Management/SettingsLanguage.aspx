<%@ Page Title="Dil Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsLanguage.aspx.cs" Inherits="LawWebSite.Management.SettingsLanguage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbLanguageEdit() {
            $("#ModalNewEditLanguage").modal("show");
        }

        function PopUpLanguageModalInformation() {
            $("#ModalInformationLanguage").modal("show");
        }

        function LbEdit() {
            LbLanguageEdit();
        }
    </script>
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
            <asp:LinkButton runat="server" ID="LbLanguageEkle" OnClick="LbLanguageEkle_Click" CssClass="btn btn-primary">Yeni Language Ekle</asp:LinkButton>
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
                                <th style="width: 20%">Dil Adı</th>
                                <th style="width: 20%">Bayrak</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RLanguages">
                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbLanguageModalEdit" OnClick="LbLanguageModalEdit_Click" CommandArgument='<%#Eval("LanguageId") %>' CssClass="dropdown-item bg-info p-2" OnClientClick="LbEdit();">
                                                        <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>

                                                    <asp:LinkButton runat="server" ID="LbLanguageModalDelete" OnClick="LbLanguageModalDelete_Click" CommandArgument='<%#Eval("LanguageId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <%#Eval("LanguageId") %>

                                        </td>
                                        <td>
                                            <%#Eval("Name") %>

                                        </td>
                                        <td>
                                            <%#Eval("Flag") %>

                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade" id="ModalNewEditLanguage">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblLanguageAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">


                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Seçiniz</label>
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

                    </div>
                </div>
                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddLanguage" CssClass="btn btn-primary" OnClick="lnkAddLanguage_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalInformationLanguage">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblLanguageModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblLanguageModalBody" />
                    </p>
                </div>
                <div class="modal-footer text-right">
                    <a href="#" class="btn btn-primary" data-dismiss="modal">Tamam</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
</asp:Content>
