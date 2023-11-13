using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace loja_online
{
    public partial class backoffice2 : System.Web.UI.Page
    {
        int ativos = 0;
        int inativos = 0;
        int revativos = 0;
        int revinativos = 0;
        int ProdutosAtivos = 0;
        int ProdutosInativos = 0;
        int produtosvendidos = 0;
        int encomendasdia = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("loja_online.aspx");
            }
           
            if (!IsPostBack)
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand cmdClientesAtivos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE tipo_cliente = 'Cliente' and ativo = 'True'", myconn);

                SqlCommand cmdClientesInativos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE tipo_cliente = 'Cliente' and ativo = 'False'", myconn);

                //revendedores:

                SqlCommand cmdRevendedoresAtivos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE tipo_cliente = 'Revendedor' and ativo = 'True'", myconn);

                SqlCommand cmdRevendedoresInativos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE tipo_cliente = 'Revendedor' and ativo = 'False'", myconn);

                //produtos:

                SqlCommand cmdProdutosAtivos = new SqlCommand("SELECT COUNT(*) as TotalProdutos FROM produtos WHERE ativo = 'True'", myconn);

                SqlCommand cmdProdutosInativos = new SqlCommand("SELECT COUNT(*) as TotalProdutos FROM produtos WHERE ativo = 'False'", myconn);

                //vendas

                SqlCommand cmdTotalVendas = new SqlCommand("SELECT COUNT(DISTINCT CONCAT(username, CONVERT(date, data_venda))) AS total_vendas_distintas FROM vendas", myconn);

                DateTime dataAtual = DateTime.Now.Date;

                SqlCommand cmdEncomendasDia = new SqlCommand(
                    "SELECT COUNT(DISTINCT CONCAT(username, CONVERT(date, data_venda))) AS total_vendas_distintas1 " +
                    "FROM vendas " +
                    "WHERE CONVERT(date, data_venda) = @DataAtual", myconn);

                cmdEncomendasDia.Parameters.AddWithValue("@DataAtual", dataAtual);


                DateTime dataSemanaPassada = dataAtual.AddDays(-7); // Obtém a data de uma semana atrás

                SqlCommand cmdVendasSemana = new SqlCommand(
                    "SELECT COUNT(DISTINCT CONCAT(username, CONVERT(date, data_venda))) AS total_vendas_distintas2 " +
                    "FROM vendas " +
                    "WHERE CONVERT(date, data_venda) BETWEEN @DataInicio AND @DataFim", myconn);

                cmdVendasSemana.Parameters.AddWithValue("@DataInicio", dataSemanaPassada);
                cmdVendasSemana.Parameters.AddWithValue("@DataFim", dataAtual);

                DateTime data30DiasAtras = dataAtual.AddDays(-30); // Obtém a data de 30 dias atrás
                SqlCommand cmdVendas30Dias = new SqlCommand(
                    "SELECT COUNT(DISTINCT CONCAT(username, CONVERT(date, data_venda))) AS total_vendas_distintas3 " +
                    "FROM vendas " +
                    "WHERE CONVERT(date, data_venda) BETWEEN @DataInicio1 AND @DataFim1", myconn);

                cmdVendas30Dias.Parameters.AddWithValue("@DataInicio1", data30DiasAtras);
                cmdVendas30Dias.Parameters.AddWithValue("@DataFim1", dataAtual);

                myconn.Open();

                SqlDataReader readerAtivos = cmdClientesAtivos.ExecuteReader();
                if (readerAtivos.Read())
                {
                    int totalClientesAtivos = Convert.ToInt32(readerAtivos["TotalClientes"]);
                    Chart1.Series["Series1"].Points.AddXY("Clientes Ativos", totalClientesAtivos);

                    ativos = totalClientesAtivos;
                }
                readerAtivos.Close();

                SqlDataReader readerInativos = cmdClientesInativos.ExecuteReader();
                if (readerInativos.Read())
                {
                    int totalClientesInativos = Convert.ToInt32(readerInativos["TotalClientes"]);
                    Chart1.Series["Series1"].Points.AddXY("Clientes Inativos", totalClientesInativos);

                    inativos = totalClientesInativos;

                }
                readerInativos.Close();

                SqlDataReader readerRevendedoresAtivos = cmdRevendedoresAtivos.ExecuteReader();
                if (readerRevendedoresAtivos.Read())
                {
                    int totalRevendedoresAtivos = Convert.ToInt32(readerRevendedoresAtivos["TotalClientes"]);
                    Chart2.Series["Series1"].Points.AddXY("Revendedores Ativos", totalRevendedoresAtivos);

                    revativos = totalRevendedoresAtivos;
                }
                readerRevendedoresAtivos.Close();

                SqlDataReader readerRevendedoresInativos = cmdRevendedoresInativos.ExecuteReader();
                if (readerRevendedoresInativos.Read())
                {
                    int totalRevendedoresInativos = Convert.ToInt32(readerRevendedoresInativos["TotalClientes"]);
                    Chart2.Series["Series1"].Points.AddXY("Revendedores Inativos", totalRevendedoresInativos);

                    revinativos = totalRevendedoresInativos;

                }
                readerRevendedoresInativos.Close();


                //produtos:

                SqlDataReader readerProdutosAtivos = cmdProdutosAtivos.ExecuteReader();
                if (readerProdutosAtivos.Read())
                {
                    int totalProdutosAtivos = Convert.ToInt32(readerProdutosAtivos["TotalProdutos"]);
                    Chart3.Series["Series1"].Points.AddXY("Produtos Ativos", totalProdutosAtivos);

                    ProdutosAtivos = totalProdutosAtivos;
                }
                readerProdutosAtivos.Close();

                SqlDataReader readerProdutosInativos = cmdProdutosInativos.ExecuteReader();
                if (readerProdutosInativos.Read())
                {
                    int totalProdutosInativos = Convert.ToInt32(readerProdutosInativos["TotalProdutos"]);
                    Chart3.Series["Series1"].Points.AddXY("Produtos Inativos", totalProdutosInativos);

                    ProdutosInativos = totalProdutosInativos;

                }
                readerProdutosInativos.Close();

                //fim produtos

                SqlDataReader readerVendas = cmdTotalVendas.ExecuteReader();
                if (readerVendas.Read())
                {
                    int totalVendas = Convert.ToInt32(readerVendas["total_vendas_distintas"]);
    
                    produtosvendidos = totalVendas;
                }
                readerVendas.Close();

                SqlDataReader readerEncomendasDia = cmdEncomendasDia.ExecuteReader();

                if (readerEncomendasDia.Read())
                {
                    int totalEncomendasDia = Convert.ToInt32(readerEncomendasDia["total_vendas_distintas1"]);
                    Chart4.Series["Series1"].Points.AddXY("Vendas do Dia", totalEncomendasDia);

                    encomendasdia = totalEncomendasDia;
                }

                readerEncomendasDia.Close();

                SqlDataReader readerVendasSemana = cmdVendasSemana.ExecuteReader();

                if (readerVendasSemana.Read())
                {
                    int totalVendasSemana = Convert.ToInt32(readerVendasSemana["total_vendas_distintas2"]);
                    Chart4.Series["Series1"].Points.AddXY("Vendas da Semana", totalVendasSemana);


                }

                readerVendasSemana.Close();

                SqlDataReader readerVendas30Dias = cmdVendas30Dias.ExecuteReader();

                if (readerVendas30Dias.Read())
                {
                    int totalVendas30Dias = Convert.ToInt32(readerVendas30Dias["total_vendas_distintas3"]);
                    Chart4.Series["Series1"].Points.AddXY("Vendas do mês", totalVendas30Dias);

                }

                readerVendas30Dias.Close();


                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart3.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart4.Series["Series1"].ChartType = SeriesChartType.Column;

                int totalRevendedores = revativos + revinativos;
                int totalClientes = ativos + inativos;
                int totalProdutos = ProdutosAtivos + ProdutosInativos;


                lbl_totalClientesSpan.Text = totalClientes.ToString();
                lbl_totalRevendedoresSpan.Text = totalRevendedores.ToString();
                lbl_totalprodutosspan.Text = totalProdutos.ToString();
                lbl_encomendasspan.Text = produtosvendidos.ToString();
                myconn.Close();

            }


        }
    }
    
}
