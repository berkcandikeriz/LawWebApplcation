<%@ Page Title="Blog" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="LawWebSite.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2 mb-3" style="background-image: url('Assets/images/bg_6.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="bread">Blog Sayfası</h1>
                </div>
            </div>
        </div>
    </section>
    <section class="ftco-section ftco-no-pt mt-5">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-md-12 heading-section ftco-animate">
                            <h2 class="mb-4"><span>
                                <asp:Label ID="LblBlog" runat="server" ></asp:Label></span></h2>
                        </div>
                    </div>
                    <div class="row">
                          <asp:Repeater runat="server" ID="RBlogs">
                        <ItemTemplate>
                        <div class="col-md-4 ftco-animate">
                            <div class="blog-entry">
                                <a href="single.html" class="img-2">
                                    <img src="Assets/images/image_1.jpg" class="img-fluid" alt="Colorlib Template"></a>
                                <div class="text pt-3">
                                    <p class="meta d-flex"><span class="pr-3"><%#Eval("BlogSubtitle") %></span><span class="ml-auto pl-3"><%#Eval("Date") %></span></p>
                                    <h3><a href="#"><%#Eval("BlogTitle") %></a></h3>
                                    <p class="mb-0"><a href="single.html" class="btn btn-black py-2">Devamını Oku <span class="icon-arrow_forward ml-4"></span></a></p>
                                </div>
                            </div>
                        </div>
                            </ItemTemplate>
                              </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
