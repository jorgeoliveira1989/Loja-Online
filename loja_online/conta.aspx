<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="conta.aspx.cs" Inherits="loja_online.conta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container mt-5">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center">Backoffice</h3>
                    </div>
                    <div class="card-body text-center">
                        <asp:Button ID="btn_alterarSenha" class="btn btn-primary btn-block mb-3" runat="server" Text="Alterar Senha" OnClick="btn_alterarSenha_Click" />
                        <asp:Button ID="btn_verCompras" runat="server" class="btn btn-success btn-block mb-3" Text="Ver Compras" OnClick="btn_verCompras_Click" />
                        <asp:Button ID="btn_Sair" runat="server" class="btn btn-danger btn-block mb-3" Text="SAIR" OnClick="btn_Sair_Click" />
                    </div>
                </div>
            </div>
        </div>
          <!--Aqui é onde coloco o panel1-->
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <div class="row mt-4">
                            <div class="col-md-6 offset-md-3">
                                <div class="card">
                                    <div class="card-header bg-primary text-white font-weight-bold d-flex justify-content-between">
                                        <h3 class="text-center">Alterar Senha</h3>
                                    </div>
                                      <div class="card-body">
                                        <div class="form-group">
                                            <label for="txtSenhaAtual">Senha Atual</label>
                                            <asp:TextBox ID="txtSenhaAtual" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtNovaSenha">Nova Senha</label>
                                            <asp:TextBox ID="txtNovaSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtConfirmarNovaSenha">Confirmar Nova Senha</label>
                                            <asp:TextBox ID="txtConfirmarNovaSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        <br />
                                        </div>
                                            <asp:Button ID="btnAlterarSenha" runat="server" Text="Alterar Senha" CssClass="btn btn-primary" OnClick="btnAlterarSenha_Click" />
                                            <br />
                                            <br />
                                          <asp:Label ID="lblInfo" runat="server" CssClass="mt-3" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </div>
                                </div>
                            </div>
                        </div>
                   </asp:Panel>

                 <!--Aqui é onde coloco o panel2-->
                   <asp:Panel ID="Panel2" runat="server" Visible="False">
                       <div class="row mt-4">
                           <div class="col-md-6 offset-md-3">
                               <div class="card">
                                   <div class="card-header bg-success text-white font-weight-bold d-flex justify-content-between">
                                       <h3 class="text-center">Ver Compras</h3>
                                       <asp:DropDownList ID="ddl_data" runat="server" DataTextField="data_venda" DataValueField="data_venda" AutoPostBack="True" OnSelectedIndexChanged="ddl_data_SelectedIndexChanged"></asp:DropDownList>
                                       <br />
                                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lojaOnline_aulaTesteConnectionString %>"
                                            SelectCommand="SELECT DISTINCT [data_venda] FROM [vendas] WHERE [username] = @username">
                                                <SelectParameters>
                                                    <asp:Parameter Name="username" Type="String" />
                                                    
                                                </SelectParameters>
                                        </asp:SqlDataSource>
                                       <br />
                                   </div>
                                   <asp:Repeater ID="rpt_vendas" runat="server">
                                       <HeaderTemplate>
                                           <table border="1" width="632">
                                               <tr>
                                                    <td><b>PRODUTO</b></td>
                                                    <td><b>QUANTIDADE</b></td>
                                                    <td><b>VENDA</b></td>
                                               </tr>
                                       </HeaderTemplate>
                                       <ItemTemplate>
                                           <tr>
                                                 <td><%# Eval("produto")%></td>
                                                 <td><%# Eval("quantidade")%></td>
                                                 <td><%# Eval("data_venda")%></td>
                                           </tr>
                                       </ItemTemplate>
                                       <FooterTemplate>
                                           </table>
                                       </FooterTemplate>
                                   </asp:Repeater>
                                    </div>
                               <asp:Label ID="lblSemCompras" runat="server" Text="Label" Visible="false"></asp:Label>
                           </div>
                       </div>
                  </asp:Panel>

        </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</asp:Content>
