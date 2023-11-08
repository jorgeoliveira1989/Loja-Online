<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="recuperarpasse.aspx.cs" Inherits="loja_online.recuperarpasse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
<div class="row justify-content-center">
    <div class="col-md-4">
        <div class="card p-4" style="background-color: #f8f9fa;">
            <div class="card-body">
                <h3 class="card-title text-center mb-4"><b>Recuperar Password</b></h3>
                    <div class="mb-3">
                        <label for="username" class="form-label">Username</label>
                        <asp:TextBox ID="txt_username" class="form-control" runat="server"></asp:TextBox>
                    </div>
                <br />
                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <asp:TextBox ID="txt_email" class="form-control" runat="server"></asp:TextBox>
                    </div>
                <br />
                <div class="text-center">
                    <asp:Button ID="btn_recuperarConta" runat="server" Text="Recuperar Password" class="btn btn-danger btn-lg w-100" OnClick="btn_recuperarConta_Click" />
                        <br />
                        <br />
                    <asp:Label ID="lbl_info" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
</div>
            </div>
        </div>
    </div>
</div>
   </div>


</asp:Content>
