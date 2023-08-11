<%@ Page Title="Hizmetlerimiz" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="LawWebSite.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2 mb-3" style="background-image: url('Assets/images/bg_7.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate pb-5 text-center">
                    <h1 class="bread"><asp:Label ID="LblServices" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
    </section>

    <section class="ftco-section ftco-no-pt mt-5">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <asp:Repeater runat="server" ID="RServices">
                            <ItemTemplate>
                                <div class="col-md-4 ftco-animate">
                                    <div class="blog-entry">
                                        <a href='ServiceDetail?ServiceDetailContent=<%#Eval("ServiceId") %>' class="img-2">
                                              <img class="img-fluid" src='../Assets/Uploads/<%#Eval("Image") %>'></a>
                                        <div class="text pt-3">
                                            <p class="meta d-flex"><span class="pr-3"><%#Eval("Title") %></span><span class="ml-auto pl-3"><%#Eval("CreatedDate", "{0: dd/MM/yyyy}") %></span></p>
                                            <h3><a href="#"><%#Eval("Title") %></a></h3>
                                            <p class="mb-0"><a href='ServiceDetail?ServiceDetailContent=<%#Eval("ServiceId") %>' class="btn btn-black py-2">Devamını Oku <span class="icon-arrow_forward ml-4"></span></a></p>
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
