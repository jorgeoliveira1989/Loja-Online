<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="rec_passe.aspx.cs" Inherits="loja_online.rec_passe" %>
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
                        <label for="user" class="form-label">Username</label>
                        <asp:Label ID="lbl_user" runat="server" class="form-control"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Nova Palavra Passe
                        </label>
&nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txt_repnovapasse" ControlToValidate="txt_novapasse" ErrorMessage="As Passwords não coincidem!" Font-Bold="True" ForeColor="Red">*</asp:CompareValidator>
                        <asp:TextBox ID="txt_novapasse" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Repetir Nova Palavra Passe <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_novapasse" ControlToValidate="txt_repnovapasse" ErrorMessage="As Passwords não coincidem!" Font-Bold="True" ForeColor="Red">*</asp:CompareValidator>
                        </label>
                        &nbsp;<asp:TextBox ID="txt_repnovapasse" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" />
                <br />
                <div class="text-center">
                    <asp:Button ID="btn_recuperarConta" runat="server" Text="Recuperar Password" class="btn btn-danger btn-lg w-100" onclick="btn_recuperarConta_Click" />
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
