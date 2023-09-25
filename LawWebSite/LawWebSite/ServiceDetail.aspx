<%@ Page Title="" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="ServiceDetail.aspx.cs" Inherits="LawWebSite.ServiceDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row mb-3">
                <div class="col-12">
                    <h1 class="mb-1">
                        <asp:Label runat="server" ID="LblServiceHeader"></asp:Label>
                    </h1>
                    <small class="d-none">
                        <i class="fa fa-calendar"></i>&nbsp;<asp:Label runat="server" ID="LblCreatedDate"></asp:Label>
                    </small>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 order-lg-last ftco-animate">
                    <p>
                        <asp:Label runat="server" ID="LblServiceContent" CssClass="text-dark"></asp:Label>
                    </p>
                </div>

                <div class="col-lg-4 sidebar pr-lg-5 ftco-animate">
                    <div class="sidebar-box ftco-animate">
                        <asp:Image runat="server" ID="ServiceDetailImageUrl" CssClass="img-fluid img-thumbnail" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
