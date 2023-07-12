<%@ Page Title="Hizmetlerimiz" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="LawWebSite.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2 mb-3" style="background-image: url('Assets/images/bg_7.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate pb-5 text-center">
                    <h1 class="bread">Hizmetlerimiz</h1>
                </div>
            </div>
        </div>
    </section>
    
    <div class="container mt-5">
         <div class="row">
                    <div class="col-md-12 heading-section ftco-animate fadeInUp ftco-animated ">
                        <h2 class="mb-4"><span><asp:Label ID="LblServices" runat="server"></asp:Label></span></h2>
                    </div>
                </div>
       
        <div class="row clearfix">

            <asp:Repeater runat="server" ID="RServices">
                <ItemTemplate>
            <div class="services-block-two col-lg-4 col-md-6 col-sm-12">

                <div class="inner-box">

                    <div class="icon-box">

                        <img class="w-100"  src="https://www.agahhukuk.com/wp-content/themes/avukat/ortak/assets/images/idarehukuk.jpg" alt="<%#Eval("Title") %>">
                    </div>

                    <h3><%#Eval("Title") %></h3>

                    <div class="overlay-box" style="background-image: url(https://www.agahhukuk.com/wp-content/themes/agah/images/resource/service-1.jpg);">

                        <div class="overlay-inner">

                            <div class="content">

                                <h4><a href="https://www.agahhukuk.com/avukatlik-hizmetlerimiz/idare-hukuku"><%#Eval("Title") %></a></h4>

                                <a href="https://www.agahhukuk.com/avukatlik-hizmetlerimiz/idare-hukuku" class="theme-btn btn-style-one">İncele</a>

                            </div>

                        </div>

                    </div>

                </div>

            </div>
                  </ItemTemplate>
                </asp:Repeater>
        </div>
    </div>
</asp:Content>
