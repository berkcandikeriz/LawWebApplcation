<%@ Page Title="Kullanıcı Soruları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsUserQuestions.aspx.cs" Inherits="LawWebSite.Management.SettingsUserQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbQuestionEditModal() {
            $("#ModalQuestionNewEdit").modal("show");
        }

        function PopUpModalQuestionInformation() {
            $("#ModalQuestionInformation").modal("show");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa-solid fa-user"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Kullanıcı Soruları</a></li>
                            <li class="breadcrumb-item active"><i class="fa-solid fa-user"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa-solid fa-user"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 13%"></th>
                                <th style="width: 13%">Ad</th>
                                <th style="width: 13%">Soyad</th>
                                <th style="width: 15%">Mail</th>
                                <th style="width: 13%">Telefon Numarası</th>
                                <th style="width: 20%">Sorulan Soru</th>
                                <th style="width: 13%">Gönderilme Tarihi</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RUserList">
                                <ItemTemplate>
                                    <tr>
                                          <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbQuestionDelete" OnClick="LbQuestionDelete_Click" CommandArgument='<%#Eval("UserId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                     
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Surname") %></td>
                                        <td><%# Eval("Mail") %></td>
                                        <td><%# Eval("PhoneNumber") %></td>
                                        <td><%# Eval("Question") %></td>
                                        <td><%# Eval("CreatedDate") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </div>
      <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalQuestionInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblQuestionModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblQuestionModalBody" />
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
