<%@ Page Title="İletişim Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsCommunication.aspx.cs" Inherits="LawWebSite.Management.SettingsCommunication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbCommunicationEditModal() {
            $("#ModalCommunicationNewEdit").modal("show");
        }

        function PopUpModalCommunicationInformation() {
            $("#ModalCommunicationInformation").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="nav-icon fas fa-phone"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">İletişim Bilgileri</a></li>
                            <li class="breadcrumb-item active"><i class="nav-icon fas fa-phone"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>
        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="nav-icon fas fa-phone"></i>&nbsp;<%: Page.Title %></h3>
                </div>

                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 7%"></th>
                                <th style="width: 11%">Dil</th>
                                <th style="width: 14%">Adres</th>
                                <th style="width: 11%">Telefon Numarası</th>
                                <th style="width: 13%">Konum</th>
                                <th style="width: 11%">Mail</th>
                                <th style="width: 11%">Hafta içi</th>
                                <th style="width: 11%">Cumartesi</th>
                                <th style="width: 11%">Pazar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RCommunications">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbCommunicationEdit" OnClick="LbCommunicationEdit_Click" CommandArgument='<%#Eval("CommunicationId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LbCommunicationDelete" OnClick="LbCommunicationDelete_Click" CommandArgument='<%#Eval("CommunicationId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <%# Eval("Language.Name") %>
                                        </td>
                                        <td>
                                            <%# Eval("Address") %>
                                        </td>
                                        <td>
                                            <%# Eval("PhoneNumber") %>
                                        </td>
                                         <td>
                                             <%# Eval("MapUrl").ToString().Substring(0, 50 - 3) + " <span alt='Devamı için güncellemeye tıklayabilirsiniz' title='Devamı için güncellemeye tıklayabilirsiniz'>[...]</span>" %>
                                             
                                        </td>
                                        <td>
                                            <%# Eval("Mail") %>
                                        </td>
                                        <td>
                                            <%# Eval("MidWeek") %>
                                        </td>
                                        <td>
                                            <%# Eval("Saturday") %>
                                        </td>
                                        <td>
                                            <%# Eval("Sunday") %>
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


    <div class="modal fade" id="ModalCommunicationNewEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblCommunicationAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Seçiniz</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="DdlCommunicationDilSeciniz" CssClass="form-control" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Adres</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationAdres" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Telefon Numarası</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationTel" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Konum</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationMap" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Mail</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationMail" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Hafta içi</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationHaftaIci" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Cumartesi</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationCumartesi" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Pazar</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCommunicationPazar" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddCommunication" CssClass="btn btn-primary" OnClick="lnkAddCommunication_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>

    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalCommunicationInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblModalBody" />
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
