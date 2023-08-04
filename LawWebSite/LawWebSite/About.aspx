<%@ Page Title="Hakkımızda" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LawWebSite.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2 mb-3" style="background-image: url('Assets/images/bg_4.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate pb-5 text-center">
                    <h1 class="bread">Hakkımızda</h1>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="container mb-5  mt-5">
            <div class="row d-flex">

                <div class="col-lg-6 d-flex justify-content-center">
                    <div class="kozanoglu_column-inner">
                        <div class="kozanoglu_wrapper">
                            <div class="kozanoglu_single_image kozanoglu_content_element">
                                <figure class="kozanoglu_wrapper">
                                    <div class="sidebar-box ftco-animate">
                                        <asp:Image runat="server" ID="ImgAboutImageUrl" CssClass="img-fluid img-thumbnail" />
                                    </div>
                                </figure>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6 pl-md-5 py-5">
                    <div class="kozanoglu_column-inner">
                        <div class="kozanoglu_wrapper">
                            <div class="col-md-7 heading-section ftco-animate fadeInUp ftco-animated">
                                <h2 class="mb-4"><span>
                                    <asp:Label ID="LblAbout" runat="server"></asp:Label></span></h2>
                            </div>
                            <asp:Repeater runat="server" ID="RAbouts">
                                <ItemTemplate>
                                    <div class="kozanoglu_text_column kozanoglu_content_element ">
                                        <div class="kozanoglu_wrapper">
                                            <p>
                                                <%#Eval("AboutDescription") %>
                                            </p>
                                        </div>
                                    </div>
                                    </div>
                            </div>
                        </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                </div>
            </div>


        </div>
    </section>


</asp:Content>
