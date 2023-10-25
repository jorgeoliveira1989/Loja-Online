<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="loja_online.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card p-4" style="background-color: #f8f9fa;">
                <div class="card-body">
                    <h3 class="card-title text-center mb-4"><b>Login de Conta</b></h3>
                    
                        <div class="mb-3">
                            <label for="username" class="form-label">Username</label>
                            <asp:TextBox ID="txt_user" class="form-control" placeholder="Indique o seu Username" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Password</label>
                            <asp:TextBox ID="txt_passe" class="form-control" placeholder="Indique a sua Password" runat="server" TextMode="Password" TabIndex="1" ></asp:TextBox>
                        </div>
                         <div class="mb-3">
                             <label class="form-label">Cargo</label>
                             <asp:DropDownList ID="ddl_tipo" class="form-control" runat="server" TabIndex="2">
                                 <asp:ListItem>-------------</asp:ListItem>
                                 <asp:ListItem>Administrador</asp:ListItem>
                                 <asp:ListItem>Cliente</asp:ListItem>
                                 <asp:ListItem>Revendedor</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="btn_entrar" runat="server" Text="Login" class="btn btn-danger btn-lg w-100" OnClick="btn_entrar_Click" />
                        <br />
                        <br />
                            <asp:LinkButton ID="lbtn_recuperarPasse" runat="server" PostBackUrl="~/index.aspx">Recuperar Password?</asp:LinkButton>
                        <br />
                        <br />
                            <a href="criar_conta.aspx" class="btn btn-primary btn-lg w-100">Criar Conta</a>
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
