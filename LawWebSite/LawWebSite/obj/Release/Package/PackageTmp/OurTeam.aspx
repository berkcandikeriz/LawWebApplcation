<%@ Page Title="Ekibimiz" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="OurTeam.aspx.cs" Inherits="LawWebSite.OurTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2 mb-3" style="background-image: url('Assets/images/bg_3.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="bread">
                        <asp:Label ID="LblOurLawyers" runat="server"></asp:Label></h1>
                </div>
            </div>
        </div>
    </section>
    <div class="container mt-5">
        <div class="whos-speaking-area speakers pad100">
            <div class="container">
                <div class="row mb-3">
                    <asp:Repeater runat="server" ID="ROurTeam" OnItemDataBound="ROurTeam_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-xl-3 col-lg-3 col-md-4 col-sm-6 mb-3">

                                <div class="speakers xs-mb-3">
                                    <a href='OurTeamDetail?LawyerDetailContent=<%#Eval("LawyerId") %>'>
                                        <div class="spk-img">
                                            <img class="img-fluid" src='Assets/Uploads/<%#Eval("ImgUrl") %>'>
                                        </div>
                                    </a>
                                    <div class="spk-info">
                                        <ul>
                                            <li>
                                                <p class="mb-0">
                                                    <a href='OurTeamDetail?LawyerDetailContent=<%#Eval("LawyerId") %>' class="btn btn-black py-2">
                                                        <asp:Label ID="LblExamine" runat="server">
                                                        </asp:Label></h1><span class="icon-arrow_forward ml-4"></span></a>
                                                </p>
                                            </li>
                                        </ul>
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
