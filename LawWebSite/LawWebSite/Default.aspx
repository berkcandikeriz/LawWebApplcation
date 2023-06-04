<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawWebSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-slider owl-carousel">
        <div class="slider-item">
            <div class="container">
                <div class="row d-flex slider-text justify-content-center align-items-center" data-scrollax-parent="true">

                    <div class="img" style="background-image: url(Assets/images/bg_1.jpg);"></div>

                    <div class="text d-flex align-items-center ftco-animate">
                        <div class="text-2 pb-lg-5 mb-lg-4 px-4 px-md-5">
                            <h3 class="subheading mb-3 text-white">Featured Posts</h3>
                            <h1 class="mb-5 text-white">Love the Delicious &amp; Tasty Foods</h1>
                            <p class="mb-md-5 text-white">A small river named Duden flows by their place and supplies it with the necessary regelialia</p>
                            <p><a href="#" class="btn btn-white px-3 px-md-4 py-3">Read More <span class="icon-arrow_forward ml-lg-4"></span></a></p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="slider-item">
            <div class="container">
                <div class="row d-flex slider-text justify-content-center align-items-center" data-scrollax-parent="true">

                    <div class="img" style="background-image: url(Assets/images/bg_2.jpg);"></div>

                    <div class="text d-flex align-items-center ftco-animate">
                        <div class="text-2 pb-lg-5 mb-lg-4 px-4 px-md-5">
                            <h3 class="subheading mb-3 text-white">Featured Posts</h3>
                            <h1 class="mb-5 text-white">I am A Blogger &amp; I Love Foods</h1>
                            <p class="mb-md-5 text-white">A small river named Duden flows by their place and supplies it with the necessary regelialia</p>
                            <p><a href="#" class="btn btn-white px-3 px-md-4 py-3">Read More <span class="icon-arrow_forward ml-lg-4"></span></a></p>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>

</asp:Content>
