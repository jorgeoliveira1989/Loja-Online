<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="criar_conta.aspx.cs" Inherits="loja_online.criar_conta_aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
function validarNumeros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode < 48 || charCode > 57)
        return false;

    return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card p-4" style="background-color: #f8f9fa;">
                <div class="card-body">
                    <h3 class="card-title text-center mb-4"><b>Criar Conta</b></h3>
                    
                        <div class="mb-3">
                            <label for="username" class="form-label">Nome</label>
                            <asp:TextBox ID="txt_nome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <asp:TextBox ID="txt_email" class="form-control" runat="server" ></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="username" class="form-label">Username</label>
                            <asp:TextBox ID="txt_username" class="form-control" runat="server"></asp:TextBox>
                        </div>
                         <div class="mb-3">
                            <label for="txtPassword" class="form-label">Password</label>
                            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
                         </div>
                        <div class="mb-3">
                            <label for="txtNIF" class="form-label">NIF</label>
                            <asp:TextBox runat="server" ID="txt_nif" CssClass="form-control" onkeypress="return validarNumeros(event);" MaxLength="9"></asp:TextBox>
                        </div>
                         <div class="mb-3">
                             <label class="form-label">Tipo de Conta</label>
                             <asp:DropDownList ID="ddl_tipo" class="form-control" runat="server" TabIndex="2">
                                 <asp:ListItem>-------------</asp:ListItem>
                                 <asp:ListItem>Cliente</asp:ListItem>
                                 <asp:ListItem>Revendedor</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="fileUpload" class="form-label">Foto</label>
                            <asp:FileUpload runat="server" ID="FileUpload1" CssClass="form-control" />
                        </div>
                           
                        <div class="text-center">
                            <asp:Button ID="btn_criar_conta" runat="server" Text="Criar Conta" class="btn btn-danger btn-lg w-100" OnClick="btn_criar_conta_Click" />
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
