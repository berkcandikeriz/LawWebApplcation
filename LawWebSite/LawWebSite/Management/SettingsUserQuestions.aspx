<%@ Page Title="Kullanıcı Soruları" Language="C#" MasterPageFile="~/Management/LawWebManagement.Master" AutoEventWireup="true" CodeBehind="SettingsUserQuestions.aspx.cs" Inherits="LawWebSite.Management.SettingsUserQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><i class="fa fa-question nav-icon"></i>&nbsp;<%: Page.Title %></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active"><i class="fa fa-question nav-icon"></i>&nbsp;<%: Page.Title %></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>

        <section class="content">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title"><i class="fa fa-question nav-icon"></i>&nbsp;<%: Page.Title %></h3>
                </div>
                <div class="card-body p-0">
                    <table class="table table-striped projects">
                        <thead>
                            <tr>
                                <th style="width: 2%"></th>
                                <th style="width: 14%">Kullanıcı İd</th>
                                <th style="width: 14%">Ad</th>
                                <th style="width: 14%">Soyad</th>
                                <th style="width: 14%">Mail</th>
                                <th style="width: 14%">Telefon Numarası</th>
                                <th style="width: 14%">Sorulan Soru</th>
                                <th style="width: 14%">Gönderilme Tarihi</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RUserList">
                                <ItemTemplate>
                                    <tr>
                                        <td></td>
                                        <td><%# Eval("UserId") %></td>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Surname") %></td>
                                        <td><%# Eval("Mail") %></td>
                                        <td><%# Eval("PhoneNumber") %></td>
                                        <td><%# Eval("Question") %></td>
                                        <td><%# Eval("CreatedDate") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
