<%@ Page Title="Sıkça Sorulan Sorular Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsFaq.aspx.cs" Inherits="LawWebSite.Management.SettingsFaq" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbFaqEdit() {
            $("#ModalFaqNewEdit").modal("show");
        }

        function PopUpModalFaqInformation() {
            $("#ModalFaqInformation").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa-solid fa-scale-question"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Sıkça Sorulan Sorular</a></li>
                            <li class="breadcrumb-item active"><i class="fa-solid fa-scale-question"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>
        <section class="content mb-3">
            <asp:LinkButton runat="server" ID="LbFaqEkle" OnClick="LbFaqEkle_Click" CssClass="btn btn-primary">Yeni Hizmet Ekle</asp:LinkButton>
        </section>
        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa-solid fa-scale-balanced"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 16%"></th>
                                <th style="width: 16%">#Soru Id</th>
                                <th style="width: 16%">Dil</th>
                                <th style="width: 18%">Soru</th>
                                <th style="width: 18%">Cevabı</th>
                                <th style="width: 16%">Url</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RFaqs">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbFaqLanguageEdit" OnClick="LbFaqLanguageEdit_Click" CommandArgument='<%#Eval("FaqId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LbFaqLanguageDelete" OnClick="LbFaqLanguageDelete_Click" CommandArgument='<%#Eval("FaqId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <%# Eval("FaqId") %>
                                        </td>
                                        <td>
                                            <%# Eval("LanguageId") %>
                                        </td>
                                        <td>
                                            <%# Eval("Question") %>
                                        </td>
                                        <td>
                                            <%# (Eval("Answer").ToString().Length > 259) ? Eval("Answer").ToString().Substring(0, 260) + " <span alt='Devamı için güncellemeye tıklayabilirsiniz' title='Devamı için güncellemeye tıklayabilirsiniz'>[...]</span>" : Eval("Answer").ToString() %>
                                        </td>
                                        <td>
                                            <%# Eval("Url") %>
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
    <div class="modal fade" id="ModalFaqNewEdit">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblFaqAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Seçiniz</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="DdlFaqDilSeciniz" CssClass="form-control" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Soru</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtFaqQuestion" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Cevap</label>
                            <div class="col-md-9">
                                <CKEditor:CKEditorControl ID="txtFaqAnswer" BasePath="/../Assets/ckeditor/" runat="server">
                                </CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Url</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtFaqUrl" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddFaq" CssClass="btn btn-primary" OnClick="lnkAddFaq_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalFaqInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblFaqModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblFaqModalBody" />
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
