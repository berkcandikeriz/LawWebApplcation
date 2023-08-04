<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LawWebSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-slider owl-carousel">
        <asp:Repeater runat="server" ID="RSliders">
            <ItemTemplate>
                <div class="slider-item">
                    <div class="container">
                        <div class="row d-flex slider-text justify-content-center align-items-center" data-scrollax-parent="true">
                            <div class="img" style="background-image: url('<%# GetImageUrl(Eval("ImageUrl")) %>');">
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
</asp:Content>
