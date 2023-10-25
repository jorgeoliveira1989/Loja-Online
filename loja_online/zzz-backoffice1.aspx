<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zzz-backoffice1.aspx.cs" Inherits="loja_online.backoffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Backoffice - Admin</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
<script>
    function updateClock() {
        var now = new Date();
        var options = { timeZone: 'Europe/Lisbon', hour12: false, hour: 'numeric', minute: 'numeric', second: 'numeric' };
        var formattedTime = new Intl.DateTimeFormat('pt-PT', options).format(now);
        document.getElementById('clock').textContent = formattedTime;
    }

    setInterval(updateClock, 1000);
</script>

</head>
<body>
    
     <div class="bg-secondary p-2">
        <div class="container d-flex justify-content-between align-items-center">
            <h1 class="text-white font-weight-bold">BACKOFFICE</h1>
            <div id="clock" class="text-white"></div>
            <img src="admin.jpg" alt="foto" width="50" height="50"/>
            <a href="#" class="btn btn-danger">Sair</a>
        </div>
    </div>

    <div class="d-flex">
        <div class="text-white p-3" style="width: 250px; background-color: #000000; height: 95vh;">
            <br />
            <br />
            <h4><b>UTILIZADORES</b></h4>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Visualizar Utilizadores</a>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Contas Ativas</a>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Contas Inativas</a>
            <br />
            <h4><b>PRODUTOS</b></h4>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Visualizar Produtos</a>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Criar Produto</a>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Editar Produto</a>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Apagar Produto</a>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Gestão de Stock</a>
            <br />
            <h4><b>ENCOMENDAS</b></h4>
                <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Visualizar Encomendas</a>
            <br />
            <h4><b>OUTRAS</b></h4>
            <a href="#" class="text-white text-decoration-none d-block mb-2 m-2">Criar Conta Admin</a>
            <!-- Adicione mais links conforme necessário -->
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            
            <small class="text-muted text-center py-3">Backoffice v1.0.0</small>
        </div>
        <!-- Conteúdo do backoffice aqui -->
        Aqui fica o texto que quero que apresente.
    </div>
    

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="script.js"></script>
</body>
</html>
