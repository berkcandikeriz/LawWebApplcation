<%@ Page Title="Slayt Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsSlider.aspx.cs" Inherits="LawWebSite.Management.SettingsSlider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function LbSliderEditModal() {
            $("#ModalSliderNewEdit").modal("show");
        }

        function PopUpModalSliderInformation() {
            $("#ModalSliderInformation").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa-regular fa-image"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">AnaSayfa Slider</a></li>
                            <li class="breadcrumb-item active"><i class="fa-regular fa-image"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <asp:LinkButton runat="server" ID="LbSliderEkle" OnClick="LbSliderEkle_Click" CssClass="btn btn-primary">Yeni Slide Ekle</asp:LinkButton>
        </section>
        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa-regular fa-image"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 10%"></th>
                                <th style="width: 18%">Dil</th>
                                <th style="width: 18%">Başlık</th>
                                <th style="width: 18%">AltBaşlık</th>
                                <th style="width: 18%">Açıklama</th>
                                <th style="width: 18%">Görsel</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RSliders">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-sm btn-secondary dropdown-toggle dropdown-icon" data-toggle="dropdown">
                                                    <i class="fa-solid fa-cogs"></i>&nbsp;İşlem Yap&nbsp;
                                                </button>
                                                <div class="dropdown-menu p-0">
                                                    <asp:LinkButton runat="server" ID="LbSliderEdit" OnClick="LbSliderEdit_Click" CommandArgument='<%#Eval("SliderId") %>' CssClass="dropdown-item bg-info p-2">
                                                            <i class="fa fa-pencil-alt"></i>&nbsp;Güncelle
                                                    </asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="LbSliderDelete" OnClick="LbSliderDelete_Click" CommandArgument='<%#Eval("SliderId") %>' CssClass="dropdown-item bg-danger p-2">
                                                            <i class="fa fa-trash"></i>&nbsp;Sil
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                        <td><%#Eval("Language.Name") %></td>
                                        <td><%#Eval("SliderTitle") %></td>
                                        <td><%#Eval("SliderSubTitle") %></td>
                                        <td>    <%# (Eval("SliderDescription").ToString().Length > 149) ? Eval("SliderDescription").ToString().Substring(0, 150) + " <span alt='Devamı için güncellemeye tıklayabilirsiniz' title='Devamı için güncellemeye tıklayabilirsiniz'>[...]</span>" : Eval("SliderDescription").ToString() %></td>
                                         <td><img src='../Assets/Uploads/<%#Eval("ImageUrl") %>' class="img-fluid" width="50%" /> </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
        </div>

    <div class="modal fade" id="ModalSliderNewEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblSliderAddEditHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Dil Id</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="DdlSliderDilSeciniz" CssClass="form-control" DataTextField="Name" DataValueField="LanguageId"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Başlık</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtSliderTitle" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label">Alt Başlık</label>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtSliderSubtitle" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label">Açıklama</label>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtSliderDescription" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Görsel</label>
                            <div class="col-md-9">
                                <asp:FileUpload runat="server" ID="FuSliderPhoto" AllowMultiple="false"/>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="modal-footer justify-content-end">
                    <asp:LinkButton runat="server" ID="lnkAddSlider" CssClass="btn btn-primary" OnClick="lnkAddSlider_Click"></asp:LinkButton>
                    <a href="#" class="btn btn-danger" data-dismiss="modal">Pencereyi Kapat</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Bilgilendirme -->
    <div class="modal fade" id="ModalSliderInformation">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblSliderModalHeader" /></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label runat="server" ID="LblSliderModalBody" />
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
