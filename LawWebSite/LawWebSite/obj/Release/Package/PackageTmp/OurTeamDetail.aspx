<%@ Page Title="Avukatlarımız" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="OurTeamDetail.aspx.cs" Inherits="LawWebSite.OurTeamDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section ourTeam">
        <div class="container">
            <div class="row mb-3">
                <div class="col-12">
                    <h1 class="mb-1">
                        <asp:Label runat="server" ID="LblLawyerName"></asp:Label>
                    </h1>
                    <h5 class="mb-3">
                        <asp:Label runat="server" ID="LblLawyerTitle"></asp:Label></h5>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 order-lg-last ftco-animate">
                    <p>
                        <asp:Label runat="server" ID="LblLawyerDescription" CssClass="text-dark"></asp:Label>
                    </p>
                </div>
                <div class="col-lg-4 sidebar pr-lg-5 ftco-animate">
                    <div class="sidebar-box ftco-animate">
                        <asp:Image runat="server" ID="ImgImageUrl" CssClass="img-fluid img-thumbnail" />
                    </div>
                </div>
            </div>
            <small>
                <a runat="server" href='<%# Eval("Instagram") %>' target="_blank">
                    <i class="fa fa-instagram"></i>
                    <asp:Label runat="server" ID="LblLawyerInstagram" Text='<%# Eval("Instagram") %>'></asp:Label>
                </a>
            </small>
            <small>
                <a runat="server" href='<%# Eval("Email") %>' target="_blank">
                    <i class="fa fa-envelope"></i>
                    <asp:Label runat="server" ID="LblLawyerMail" Text='<%# Eval("Email") %>'></asp:Label>
                </a>
            </small>
            <small>
                <a runat="server" href='<%# Eval("Linkedin") %>' target="_blank">
                    <i class="fa fa-linkedin"></i>
                    <asp:Label runat="server" ID="LblLawyerLinkdln" Text='<%# Eval("Linkedin") %>'></asp:Label>
                </a>
            </small>
            <small>
                <a runat="server" href='<%# Eval("Twitter") %>' target="_blank">
                    <i class="fa fa-twitter"></i>
                    <asp:Label runat="server" ID="LblLawyerTwitter" Text='<%# Eval("Twitter") %>'></asp:Label>
                </a>
            </small>

            <small>
                <a runat="server" href='<%# Eval("PhoneNumber") %>' target="_blank">
                    <i class="fa fa-phone"></i>
                    <asp:Label runat="server" ID="LblLawyerPhone"></asp:Label>
                </a>
            </small>
        </div>
    </section>
</asp:Content>
