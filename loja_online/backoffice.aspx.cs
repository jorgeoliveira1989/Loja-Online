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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
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

                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart3.Series["Series1"].ChartType = SeriesChartType.Column;

                int totalRevendedores = revativos + revinativos;
                int totalClientes = ativos + inativos;
                int totalProdutos = ProdutosAtivos + ProdutosInativos;

                lbl_totalClientesSpan.Text = totalClientes.ToString();
                lbl_totalRevendedoresSpan.Text = totalRevendedores.ToString();
                lbl_totalprodutosspan.Text = totalProdutos.ToString();
                myconn.Close();

            }


        }
    }
    
}
