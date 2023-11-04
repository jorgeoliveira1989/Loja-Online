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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
           
            if (!IsPostBack)
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand cmdClientesAtivos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE tipo_cliente = 'Cliente' and ativo = 'True'", myconn);

                SqlCommand cmdClientesInativos = new SqlCommand("SELECT COUNT(*) as TotalClientes FROM clientes WHERE tipo_cliente = 'Cliente' and ativo = 'False'", myconn);

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

                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;

                int totalClientes = ativos + inativos;

                lbl_totalClientesSpan.Text = totalClientes.ToString();

                myconn.Close();

            }


        }
    }
    
}
