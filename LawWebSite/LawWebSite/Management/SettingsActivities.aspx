﻿<%@ Page Title="Faaliyet Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsActivities.aspx.cs" Inherits="LawWebSite.SettingsActivities" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbActivitiesEdit() {
            $("#ModalActivitiesNewEdit").modal("show");
        }

        function PopUpModalActivitiesInformation() {
            $("#ModalActivitiesInformation").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="nav-icon fas fa-pencil"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Faaliyetler</a></li>
                            <li class="breadcrumb-item active"><i class="nav-icon fas fa-pencil"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>
        <section class="content mb-3">
            <asp:LinkButton runat="server" ID="LbActivitiesEkle" OnClick="LbActivitiesEkle_Click" CssClass="btn btn-primary">Yeni Faaliyet Ekle</asp:LinkButton>
        </section>
        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="nav-icon fas fa-pencil"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 14%"></th>
                                <th style="width: 14%">#Faaliyet Id</th>
                                <th style="width: 14%">Dil</th>
                                <th style="width: 14%">Faaliyet Adı</th>
                                <th style="width: 16%">Açıklama</th>
                                <th style="width: 14%">Görsel Linki</th>
                                <th style="width: 14%">Sıralama</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RActivities">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbActivitiesLanguageEdit" OnClick="LbActivitiesLanguageEdit_Click" CommandArgument='<%#Eval("ActivitiesId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LbActivitiesLanguageDelete" OnClick="LbActivitiesLanguageDelete_Click" CommandArgument='<%#Eval("ActivitiesId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <%# Eval("ActivitiesId") %>
                                        </td>
                                        <td>
                                            <%# Eval("Language.Name") %>
                                        </td>
                                        <td>
                                            <%# Eval("BlogTitle") %>
                                        </td>

                                        <td>
                                            <%# (Eval("Description").ToString().Length > 349) ? Eval("Description").ToString().Substring(0, 350) + " <span alt='Devamı için güncellemeye tıklayabilirsiniz' title='Devamı için güncellemeye tıklayabilirsiniz'>[...]</span>" : Eval("Description").ToString() %>
                                        </td>

                                        <td>
                                            <img src='../Assets/Uploads/<%#Eval("ImageUrl") %>' class="img-fluid" width="50%" />
                                        </td>
                                        <td>
                                            <%# Eval("OrderNumber") %>
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
    <div class="modal fade" id="ModalActivitiesNewEdit">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblActivitiesAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Seçiniz</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="DdlActivitiesDilSeciniz" CssClass="form-control" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Faaliyet Adı</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtActivitiesAdi" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Açıklama</label>
                            <div class="col-md-9">
                                <CKEditor:CKEditorControl ID="txtActivitiesAciklama" BasePath="/../Assets/ckeditor/" runat="server">
                                </CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Görsel</label>
                            <div class="col-md-9">
                                <asp:FileUpload runat="server" ID="FuActivitiesPhoto" AllowMultiple="false" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Sıralama</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtActivitiesOrder" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddActivities" CssClass="btn btn-primary" OnClick="lnkAddActivities_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalActivitiesInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblActivitiesModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblActivitiesModalBody" />
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