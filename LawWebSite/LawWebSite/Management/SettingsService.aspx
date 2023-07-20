<%@ Page Title="Hizmetlerimiz Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsService.aspx.cs" Inherits="LawWebSite.Management.SettingsService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbServiceEdit() {
            $("#ModalServiceNewEdit").modal("show");
        }

        function PopUpModalServiceInformation() {
            $("#ModalServicelInformation").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa-solid fa-scale-balanced"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active"><i class="fa-solid fa-scale-balanced"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <asp:LinkButton runat="server" ID="LbServiceEkle" OnClick="LbServiceEkle_Click" CssClass="btn btn-primary">Yeni Hizmet Ekle</asp:LinkButton>
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
                                <th style="width: 14%"></th>
                                <th style="width: 14%">#Service Id</th>
                                <th style="width: 14%">Dil</th>
                                <th style="width: 14%">Hizmet Adı</th>
                                <th style="width: 16%">Açıklama</th>
                                <th style="width: 14%">Url</th>
                                <th style="width: 14%">Görsel Linki</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RServices">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbServiceLanguageEdit" OnClick="LbServiceLanguageEdit_Click" CommandArgument='<%#Eval("ServiceId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LbServiceLanguageDelete" OnClick="LbServiceLanguageDelete_Click" CommandArgument='<%#Eval("ServiceId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <%# Eval("ServiceId") %>
                                        </td>
                                        <td>
                                            <%# Eval("LanguageId") %>
                                        </td>
                                        <td>
                                            <%# Eval("Title") %>
                                        </td>
                                        <td>
                                            <%# Eval("Description") %>
                                        </td>
                                        <td>
                                            <%# Eval("Url") %>
                                        </td>
                                        <td>
                                            <%# Eval("Image") %>
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

    <div class="modal fade" id="ModalServiceNewEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblServiceAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Seçiniz</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="DdlServiceDilSeciniz" CssClass="form-control" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Hizmet Adı</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtServiceAdi" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Url</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtServiceUrl" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Görsel Linki</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtServiceGorselLinki" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Açıklama</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtServiceAciklama" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>


                    </div>
                </div>
                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddService" CssClass="btn btn-primary" OnClick="lnkAddService_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>

    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalServicelInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblServiceModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblServiceModalBody" />
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

