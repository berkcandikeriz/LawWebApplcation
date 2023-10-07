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

    <section id="testimonials" class="testimonials articles">
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
                    <asp:Repeater runat="server" ID="RHomeServices" OnItemDataBound="RHomeServices_ItemDataBound">
                        <ItemTemplate>
                            <div class="swiper-slide">
                                <div class="testimonial-wrap">
                                   <a href='ServiceDetail?ServiceDetailContent=<%#Eval("ServiceId") %>' class="img-2">
                                    <div class="testimonial-item article-wrapper">
                                        <figure>
                                              <img src='Assets/Uploads/<%#Eval("Image") %>' class="testimonial-img" alt="">
                                        </figure>
                                        </a>
                                      <div  class="article-body">
                                           <h3><%#Eval("Title") %></h3>
                                        <p class="mt-3"><a href='ServiceDetail?ServiceDetailContent=<%#Eval("ServiceId") %>' class="btn btn-black py-2">
                                          <asp:Label ID="LblReadMore" runat="server"></asp:Label><span class="icon-arrow_forward ml-4"></span></a></p>
                                      </div>
                                       
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
