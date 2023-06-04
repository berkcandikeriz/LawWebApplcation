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

    <section class="ftco-counter ftco-section ftco-no-pt ftco-no-pb img" id="section-counter">
        <div class="container">
            <div class="row d-flex">
                <div class="col-md-6 d-flex">
                    <div class="img d-flex align-self-stretch" style="background-image: url(Assets/images/about.jpg);"></div>
                </div>
                <div class="col-md-6 pl-md-5 py-5">
                    <div class="row justify-content-start pb-3">
                        <div class="col-md-12 heading-section ftco-animate">
                            <h2 class="mb-4"><span>About Stories</span></h2>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 justify-content-center counter-wrap ftco-animate">
                            <div class="block-18 text-center py-5 bg-light mb-4">
                                <div class="text">
                                    <strong class="number" data-number="10">0</strong>
                                    <span>Years of Experienced</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 justify-content-center counter-wrap ftco-animate">
                            <div class="block-18 text-center py-5 bg-light mb-4">
                                <div class="text">
                                    <strong class="number" data-number="200">0</strong>
                                    <span>Foods</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 justify-content-center counter-wrap ftco-animate">
                            <div class="block-18 text-center py-5 bg-light mb-4">
                                <div class="text">
                                    <strong class="number" data-number="300">0</strong>
                                    <span>Lifestyle</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 justify-content-center counter-wrap ftco-animate">
                            <div class="block-18 text-center py-5 bg-light mb-4">
                                <div class="text">
                                    <strong class="number" data-number="40">0</strong>
                                    <span>Happy Customers</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
