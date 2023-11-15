<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="loja_online.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://accounts.google.com/gsi/client" async defer></script>
     <script src="https://unpkg.com/jwt-decode/build/jwt-decode.js"></script>

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
                            <label for="password" class="form-label">Password </label>
                            &nbsp;<asp:TextBox ID="txt_passe" class="form-control" placeholder="Indique a sua Password" runat="server" TextMode="Password" TabIndex="1" ></asp:TextBox>
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
                            <a href="recuperarpasse.aspx">Recuperar Password?</a>
                        <br />
                        <br />
                            <a href="criar_conta.aspx" class="btn btn-primary btn-lg w-100">Criar Conta</a>
                        <br />
                        <br />
                            <asp:Label ID="lbl_info" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                              <div id="buttonDiv"></div>
                    <br />
                     <p id="fullName"></p> 
                    <br />
                   <p id="email"></p> 
                        <br />  
                </div>
            </div>
        </div>
    </div>
</div>

  <script>
      function parseJwt(token) {
          try {
              const base64Url = token.split('.')[1];
              const base64 = base64Url.replace('-', '+').replace('_', '/');
              const jsonPayload = decodeURIComponent(atob(base64).split('').map(c => {
                  return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
              }).join(''));

              return JSON.parse(jsonPayload);
          } catch (e) {
              return null;
          }
      }

      function handleCredentialResponse(response) {
          const data = parseJwt(response.credential);
          console.log(data);

          if (data && data.name) {
              const fullName = data.name;
              const email = data.email;

              // Armazena os valores na sessão
              sessionStorage.setItem('FullName', fullName);
              sessionStorage.setItem('UserEmail', email);

              // Atualiza o conteúdo na página
              document.getElementById('fullName').textContent = fullName;
              document.getElementById('email').textContent = email;

              // Redireciona para a página após o login
              window.location.href = 'loja_online.aspx'; // Substitua com a página que deseja redirecionar.
          }
      }

      document.addEventListener('DOMContentLoaded', function () {
          var FullName = sessionStorage.getItem('FullName');
          var UserEmail = sessionStorage.getItem('UserEmail');

          
          if (FullName && UserEmail) {
              // As variáveis de sessão estão definidas, o usuário está autenticado.
              // Redirecione-o para a página adequada.
              window.location.href = 'loja_online.aspx'; // Substitua com a página que deseja redirecionar.
          }
      });

/*
      function responseCallBack(response) {
          const data = jwt_decode(response.credential);
          console.log(data)
          sub.textContent = data.sub
          fullName.textContent = data.name
          given_name.textContent = data.given_name
          family_name.textContent = data.family_name
          email.textContent = data.email
          picture.setAttribute("src", data.picture)
      }
*/
      window.onload = function () {
          google.accounts.id.initialize({
              client_id: "939579512807-r8jf51ee2l8ntddgssh6tq5jmb3pfgfm.apps.googleusercontent.com",
              callback: handleCredentialResponse
          });
          google.accounts.id.renderButton(
              buttonDiv, {
              theme: "outline",
              // theme: "filled_black",
              // size: "small",
              size: "large",
              // shape: "pill",
              // logo_alignment: "left"
          }
          );
      }
  </script>

</asp:Content>
