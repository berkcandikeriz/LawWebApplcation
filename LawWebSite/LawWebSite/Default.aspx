<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawWebSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-slider owl-carousel mb-3">
        <asp:Repeater runat="server" ID="RSliders">
            <ItemTemplate>
                <div class="slider-item">
                    <div class="container">
                        <div class="row d-flex slider-text justify-content-center align-items-center" data-scrollax-parent="true">
                            <div class="img" style="background-image: url('../Assets/Uploads/<%#Eval("ImageUrl") %>');">
                                &nbsp;
                            </div>
                            <div class="text d-flex align-items-center ftco-animate">
                                <div class="text-2 pb-lg-5 mb-lg-4 px-4 px-md-5">
                                    <h3 class="subheading mb-3 text-white"><%#Eval("SliderTitle") %></h3>
                                    <h2 class="mb-5 text-white"><%#Eval("SliderSubTitle") %></h2>
                                    <p class="mb-md-5 text-white"><%#Eval("SliderDescription") %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </section>

    <section id="testimonials" class="testimonials">
        <div class="container" data-aos="fade-up">
            <div class="row">
                <div class="col-md-7 heading-section ftco-animate fadeInUp ftco-animated">
                    <h2 class="mb-4"><span>
                        <asp:Label runat="server" ID="LblActivities"></asp:Label>
                    </span>
                    </h2>
                </div>
            </div>

            <div class="testimonials-slider swiper" data-aos="fade-up" data-aos-delay="100">
                <div class="swiper-wrapper">
                    <asp:Repeater runat="server" ID="RActivities">
                        <ItemTemplate>
                            <div class="swiper-slide">
                                <div class="testimonial-wrap">
                                    <div class="testimonial-item">
                                        <img src='Assets/Uploads/<%#Eval("ImageUrl") %>' class="testimonial-img" alt="">
                                        <h3><%# Eval("BlogTitle") %></h3>
                                        <p>
                                            <%# Eval("Description") %>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="swiper-pagination"></div>
            </div>
        </div>
    </section>
</asp:Content>
