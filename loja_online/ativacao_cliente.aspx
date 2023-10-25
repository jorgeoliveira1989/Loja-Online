<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ativacao_cliente.aspx.cs" Inherits="loja_online.ativacao_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ativação conta Cliente</title>
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <div class="container mt-5 text-center">
     <h1>Painel de Ativação de Clientes</h1>
    <br />
    <br />
      <button class="btn btn-success" id="ativarAdmin">Ativar Cliente</button>
 </div>

 <!-- Modal -->
 <div class="modal fade" id="sucessoModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
     <div class="modal-dialog modal-dialog-centered">
         <div class="modal-content">
             <div class="modal-header">
                 <h5 class="modal-title" id="exampleModalLabel">Sucesso!</h5>
                 <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                     <span aria-hidden="true">&times;</span>
                 </button>
             </div>
             <div class="modal-body">
                 Cliente ativado com sucesso.
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-primary" data-dismiss="modal">Fechar</button>
             </div>
         </div>
     </div>
 </div>

 <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
 <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
 <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
 
 <script>
     // Adiciona um evento de clique ao link
     document.getElementById('ativarAdmin').addEventListener('click', function () {
         // Mostra o modal
         $('#sucessoModal').modal('show');
     });
 </script>
</body>
</html>
