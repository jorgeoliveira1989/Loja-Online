<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="criar_conta_admin.aspx.cs" Inherits="loja_online.Criar_Conta_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
    <div class="p-4 border rounded bg-light">
       <h3 class="text-center mb-4"><b>Criar Conta Admin</b></h3>

        <div class="mb-3">
            <label for="nome" class="form-label">Nome</label>
            <asp:TextBox ID="txt_nome" class="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="email" class="form-label">Email</label>
            <asp:TextBox ID="txt_email" class="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="username" class="form-label">Username</label>
            <asp:TextBox ID="txt_username" class="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="password" class="form-label">Password</label>
            <asp:TextBox ID="txt_password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="foto" class="form-label">Foto</label>
            <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
        </div>

        <div class="d-grid">
            <asp:Button ID="btn_enviar" class="btn btn-danger w-100" runat="server" Text="Criar Conta" Font-Bold="True" Font-Size="Medium" OnClick="btn_enviar_Click" />
        </div>
        <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>   
        </div>
    </div>
</div>

</asp:Content>
