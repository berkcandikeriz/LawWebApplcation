<%@ Page Title="Hakkımzda Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsAbout.aspx.cs" Inherits="LawWebSite.Management.SettingsAbout" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbAboutEditModal() {
            $("#ModalAboutNewEdit").modal("show");
        }

        function PopUpModalAboutInformation() {
            $("#ModalAboutInformation").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa fa-house nav-icon"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item">
                                <a href="#">Hakkımızda</a>
                            </li>
                            <li class="breadcrumb-item active"><i class="fa fa-house nav-icon"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa fa-house nav-icon"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 20%"></th>
                                <th style="width: 20%">Dil</th>
                                <th style="width: 40%">Açıklama</th>
                                <th style="width: 20%">Görsel</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RAbouts">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbAboutEdit" OnClick="LbAboutEdit_Click" CommandArgument='<%#Eval("AboutId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>

                                                </div>
                                            </div>
                                        </td>
                                        <td><%#Eval("Language.Name") %></td>
                                        <td>
                                            <%# (Eval("AboutDescription").ToString().Length > 599) ? Eval("AboutDescription").ToString().Substring(0, 600) + " <span alt='Devamı için güncellemeye tıklayabilirsiniz' title='Devamı için güncellemeye tıklayabilirsiniz'>[...]</span>" : Eval("AboutDescription").ToString() %>

                                        </td>
                                        <td>
                                            <img src='../Assets/Uploads/<%#Eval("ImageUrl") %>' class="img-fluid" width="50%" />
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

    <div class="modal fade" id="ModalAboutNewEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblAboutAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Id</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="DdlAboutDilSeciniz" CssClass="form-control" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Açıklama</label>
                            <div class="col-md-9">
                                 <CKEditor:CKEditorControl ID="txtAboutIsim" BasePath="/../Assets/ckeditor/" runat="server">
                                </CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Görsel</label>
                            <div class="col-md-9">
                                <asp:FileUpload runat="server" ID="FuAboutPhoto" AllowMultiple="false" />
                            </div>
                        </div>

                    </div>
                </div>

                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddAbout" CssClass="btn btn-primary" OnClick="lnkAddAbout_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalAboutInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblAboutModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblAboutModalBody" />
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
