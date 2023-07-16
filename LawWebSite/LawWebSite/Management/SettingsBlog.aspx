<%@ Page Title="Blog Ayarları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsBlog.aspx.cs" Inherits="LawWebSite.Management.SettingsBlog" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa fa-pencil-square-o"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active"><i class="fa fa-pencil-square-o"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content mb-3">
            <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#modal-default">Yeni Blog Ekle
            </a>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa fa-pencil-square-o"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 10%">#Blog Id</th>
                                <th style="width: 10%">#Dil Id</th>
                                <th style="width: 10%">Blog Adı</th>
                                <th style="width: 10%">Blog Alt Başlık</th>
                                <th style="width: 10%">Açıklama</th>
                                <th style="width: 10%">Yazar</th>
                                <th style="width: 10%">Url</th>
                                <th style="width: 10%">Görsel Linki</th>
                                <th style="width: 10%">Oluşturma Tarihi</th>
                                <th style="width: 10%">Güncelleme Tarihi</th>
                                <th style="width: 10%"></th>


                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RBlogs">
                                <ItemTemplate>
                                    <tr>

                                        <td>
                                            <%# Eval("BlogId") %>
                                        </td>
                                        <td>
                                            <%# Eval("LanguageId") %>
                                        </td>
                                        <td>
                                            <%# Eval("BlogTitle") %>
                                        </td>
                                        <td>
                                            <%# Eval("BlogSubtitle") %>
                                        </td>
                                        <td>
                                            <%# Eval("Description") %>
                                        </td>
                                        <td>
                                            <%# Eval("Author") %>
                                        </td>
                                        <td>
                                            <%# Eval("Url") %>
                                        </td>
                                        <td>
                                            <%# Eval("ImageUrl") %>
                                        </td>
                                        <td>
                                            <%# Eval("CreatedDate") %>
                                        </td>
                                        <td>
                                            <%# Eval("UpdateDate") %>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnEdit" Text="Güncelle" CommandName="Edit" CommandArgument='<%# Eval("BlogId") %>' CssClass="btn btn-primary" />
                                        </td>
                                        <td>
                                         <asp:Button runat="server" ID="btnDelete" Text="Sil" CommandName="Delete" CommandArgument='<%# Eval("BlogId") %>' CssClass="btn btn-danger" OnClientClick="return confirm('Bu blogu silmek istediğinize emin misiniz?');" />

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

    <div class="modal fade" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Yeni Blog Ekle</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form class="form" role="form" autocomplete="off">

                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">#Dil Id</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogDilId" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Blog Adı</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogAdi" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Blog Alt Başlık</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogAltBaslik" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Açıklama</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogAciklama" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Yazar</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogYazar" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Url</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogUrl" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label">Görsel Linki</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtBlogGorselLinki" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </form>
                </div>



                <div class="modal-footer justify-content-between">
                    <asp:LinkButton runat="server" ID="lnkCloseBlog" CssClass="btn btn-danger" OnClick="lnkCloseBlog_Click">Pencereyi Kapat</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkAddBlog" CssClass="btn btn-primary" OnClick="lnkAddBlog_Click">Yeni Blog Ekle</asp:LinkButton>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
