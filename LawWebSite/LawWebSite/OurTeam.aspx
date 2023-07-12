<%@ Page Title="Ekibimiz" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="OurTeam.aspx.cs" Inherits="LawWebSite.OurTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2 mb-3" style="background-image: url('Assets/images/bg_3.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="bread">Ekibimiz</h1>
                </div>
            </div>
        </div>
    </section>
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-12 heading-section ftco-animate fadeInUp ftco-animated">
                <h2 class="mb-4">
                    <span><asp:Label ID="LblOurLawyers" runat="server"></asp:Label></span>
                </h2>
            </div>
        </div>
        <div class="whos-speaking-area speakers pad100">
            <div class="container">
                <div class="row mb-3">
                    <asp:Repeater runat="server" ID="ROurTeam">
                        <ItemTemplate>
                            <div class="col-xl-3 col-lg-3 col-md-4 col-sm-6 mb-3">
                                <div class="speakers xs-mb-3">
                                    <div class="spk-img">
                                        <img class="img-fluid" src="Assets/images/user_profil.jpg" alt="trainer-img">
                                        <ul>
                                            <li>
                                                <a href='<%#Eval("Twitter") %>' target="_blank"><i class="fa fa-twitter"></i></a>
                                            </li>
                                            <li>
                                                <a href='<%#Eval("Linkedin") %>' target="_blank"><i class="fa fa-linkedin"></i></a>
                                            </li>
                                            <li>
                                                <a href='<%#Eval("Facebook") %>' target="_blank"><i class="fa fa-facebook"></i></a>
                                            </li>
                                            <li>
                                                <a href='<%#Eval("Email") %>' target="_blank"><i class="fa fa-envelope"></i></a>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="spk-info">
                                        <h3><%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %></h3>
                                        <p><%#Eval("Title") %></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
