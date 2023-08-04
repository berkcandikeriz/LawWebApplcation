<%@ Page Title="Avukat Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsLawyer.aspx.cs" Inherits="LawWebSite.Management.SettingsLawyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbLawyerEditModal() {
            $("#ModalLawyerNewEdit").modal("show");
        }

        function PopUpModalLawyerInformation() {
            $("#ModalLawyerInformation").modal("show");
        }
    </script>
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
                            <li class="breadcrumb-item"><a href="#">Avukatlarımız</a></li>
                            <li class="breadcrumb-item active"><i class="fa fa-users"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <asp:LinkButton runat="server" ID="LbLawyerEkle" OnClick="LbLawyerEkle_Click" CssClass="btn btn-primary">Yeni Avukat Ekle</asp:LinkButton>
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
                                <th style="width: 7%"></th>
                                <th style="width: 6%">#Lawyer Id</th>
                                <th style="width: 6%">Avukat Adı</th>
                                <th style="width: 6%">Avukat Soyadı</th>
                                <th style="width: 6%">Rütbesi</th>
                                <th style="width: 6%">Fotoğrafı</th>
                                <th style="width: 6%">Facebook</th>
                                <th style="width: 6%">Twitter</th>
                                <th style="width: 6%">Instgram</th>
                                <th style="width: 6%">Linkedln</th>
                                <th style="width: 6%">Email</th>
                                <th style="width: 9%">Telefon Numarası</th>
                                <th style="width: 10%">Açıklama</th>
                                <th style="width: 6%">Panel Yöneticisimi</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RLawyers">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbLawyerEdit" OnClick="LbLawyerEdit_Click" CommandArgument='<%#Eval("LawyerId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LbLawyerDelete" OnClick="LbLawyerDelete_Click" CommandArgument='<%#Eval("LawyerId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>

                                        <td><%#Eval("LawyerId") %></td>
                                        <td><%#Eval("FirstName") %></td>
                                        <td><%#Eval("LastName") %></td>
                                        <td><%#Eval("Title") %></td>
                                        <td><img src='../Assets/Uploads/<%#Eval("ImgUrl") %>' class="img-fluid" width="50%" /> </td>
                                        <td><%#Eval("Facebook") %></td>
                                        <td><%#Eval("Twitter") %></td>
                                        <td><%#Eval("Instagram") %></td>
                                        <td><%#Eval("Linkedin") %></td>
                                        <td><%#Eval("Email") %></td>
                                        <td><%#Eval("PhoneNumber") %></td>
                                        <td><%#Eval("Description") %></td>
                                        <td><%#Eval("IsAdmin").ToString() == "True" ? "Evet" : "Hayır" %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </div>

    <div class="modal fade" id="ModalLawyerNewEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblLawyerAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">

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
                                <asp:FileUpload runat="server" ID="FuLawyerPhoto" AllowMultiple="false"/>
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
                                <asp:DropDownList runat="server" ID="DdlAdminSeciniz" CssClass="form-control">
                                    <asp:ListItem Text="Hayır" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Evet" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddLawyer" CssClass="btn btn-primary" OnClick="lnkAddLawyer_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>

            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalLawyerInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblLawyerModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblLawyerModalBody" />
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
