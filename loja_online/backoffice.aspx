<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="backoffice.aspx.cs" Inherits="loja_online.backoffice2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center">
    <div class="row">
        
        <div class="col-md-6 mb-4">
            <div class="bg-primary p-3">
                Conteúdo Div 1
                </div>
        </div>
        <div class="col-md-6 mb-4">
            <div class="bg-secondary p-3">
                Conteúdo Div 2
            </div>
        </div>
        </div>
        <br />
    <div class="row">
        <div class="col-md-6 mb-4">
            <div class="bg-success p-3">
                Conteúdo Div 3
            </div>
        </div>
        <div class="col-md-6 mb-4">
            <div class="bg-danger p-3">
                Conteúdo Div 4
            </div>
        </div>
    </div>
</div>
</asp:Content>
