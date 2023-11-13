<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="visualizar_admins.aspx.cs" Inherits="loja_online.visualizar_admins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .ativo{
        color: green;
        font-weight:bold;
    }
    .desativo{
        color:red;
        font-weight:bold;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded bg-light">
            <br />
                <h1>Dados dos Admins</h1>
            <br />
            <asp:Repeater ID="rpt_verAdmins" runat="server">
                <HeaderTemplate>
                    <table border="1" width="1000">
                        <tr>
                            <td><b>ID</b></td>
                            <td><b>Nome</b></td>
                            <td><b>Email</b></td>
                            <td><b>Username</b></td>
                            <td><b>Tipo Conta</b></td>
                            <td><b>Ativo</b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                     <tr>
                         <td><%# Eval("id_empresa")%></td>
                         <td><%# Eval("nome")%></td>
                         <td><%# Eval("email")%></td>
                         <td><%# Eval("username")%></td>
                         <td><%# Eval("tipo")%></td>
                         <td class="<%# Eval("estilosCSS")%>"><%# Eval("ativo")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
     </div>
</asp:Content>
