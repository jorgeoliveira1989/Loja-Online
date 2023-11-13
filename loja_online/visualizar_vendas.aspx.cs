using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static loja_online.visualizar_admins;

namespace loja_online
{
    public partial class visualizar_encomendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("loja_online.aspx");
            }

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();

            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "lista_vendas";
            mycomm.Connection = myconn;

            List<lista_vendas> lst_venda = new List<lista_vendas>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                lista_vendas venda = new lista_vendas();
                venda.id_venda = reader.GetInt32(0);
                venda.username = reader.GetString(1);
                venda.produto = reader.GetString(2);
                venda.quantidade = reader.GetInt32(3);
                venda.data_venda = reader.GetDateTime(4);

                lst_venda.Add(venda);
            }

            myconn.Close();

            rpt_verVendas.DataSource = lst_venda;
            rpt_verVendas.DataBind();

            rpt_verVendas.ItemDataBound += rpt_verVendas_ItemDataBound;
        }

        public class lista_vendas
        {
            public int id_venda { get; set; }
            public string username { get; set; }
            public string produto { get; set; }
            public int quantidade { get; set; }
            public DateTime data_venda { get; set; }

        }

        protected void rpt_verVendas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtém a venda atualmente associada ao item do Repeater
                lista_vendas venda = (lista_vendas)e.Item.DataItem;

                // Encontra o controle Label para exibição da data
                Label lblDataVenda = (Label)e.Item.FindControl("lblDataVenda");

                // Formata a data para exibir apenas o dia
                string dataFormatada = venda.data_venda.ToString("dd/MM/yyyy");

                // Atribui a data formatada ao controle Label
                lblDataVenda.Text = dataFormatada;
            }
        }
    }
}