using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static loja_online.backoffice1;
using System.Drawing;
using System.Data.SqlTypes;

namespace loja_online
{
    public partial class visualizar_produtos : System.Web.UI.Page
    {
        string estilo = "";
        string ativoCSS = "";

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
            mycomm.CommandText = "lista_produtos_detalhes";
            mycomm.Connection = myconn;

            List<lista_produtos> lst_produto = new List<lista_produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                lista_produtos produto = new lista_produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.preco = reader.GetDecimal(2);
                produto.quantidade = reader.GetInt32(3);
                if(produto.quantidade <= 5)
                {
                    estilo = Convert.ToString("baixo_stock");
                }
                else if (produto.quantidade > 5 && produto.quantidade <= 15)
                {
                    estilo = Convert.ToString("medio_stock");
                }
                else 
                {
                    estilo = Convert.ToString("alto_stock");
                }

                produto.quantidadeprodutocss = estilo;
                produto.preco_revenda = reader.GetDecimal(4);
                produto.ativo = reader.GetBoolean(7);

                if(produto.ativo.ToString() == "True")
                {
                    ativoCSS = Convert.ToString("positivo");
                }
                else 
                {
                    ativoCSS = Convert.ToString("negativo");
                }
                produto.ativoCSS = ativoCSS;

                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produto.Add(produto);
            }
            myconn.Close();

            rpt_produtos.DataSource = lst_produto;
            rpt_produtos.DataBind();
        }

        public class lista_produtos
        {
            public int id_produto { get; set; }
            public string produto { get; set; }
            public decimal preco { get; set; }
            public int quantidade { get; set; }
            public decimal preco_revenda { get; set; }
            public byte[] foto { get; set; }
            public string contenttype { get; set; }
            public string imagemSrc { get; set; }
            public string quantidadeprodutocss {  get; set; }
            public bool ativo { get; set; } 
            public string ativoCSS { get; set; }
        }

        protected void ddl_atividadeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_atividadeProduto.SelectedItem.ToString()== "Ativo")
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "lista_produtos_detalhes_Ativo";
                mycomm.Connection = myconn;

                List<lista_produtos> lst_produto = new List<lista_produtos>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    lista_produtos produto = new lista_produtos();

                    produto.id_produto = reader.GetInt32(0);
                    produto.produto = reader.GetString(1);
                    produto.preco = reader.GetDecimal(2);
                    produto.quantidade = reader.GetInt32(3);
                    if (produto.quantidade <= 5)
                    {
                        estilo = Convert.ToString("baixo_stock");
                    }
                    else if (produto.quantidade > 5 && produto.quantidade <= 15)
                    {
                        estilo = Convert.ToString("medio_stock");
                    }
                    else
                    {
                        estilo = Convert.ToString("alto_stock");
                    }

                    produto.quantidadeprodutocss = estilo;
                    produto.preco_revenda = reader.GetDecimal(4);
                    produto.ativo = reader.GetBoolean(7);

                    if (produto.ativo.ToString() == "True")
                    {
                        ativoCSS = Convert.ToString("positivo");
                    }
                    else
                    {
                        ativoCSS = Convert.ToString("negativo");
                    }
                    produto.ativoCSS = ativoCSS;

                    byte[] imagemBytes = (byte[])reader["foto"];
                    string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                    // Convertendo os bytes da imagem em uma string base64
                    string imagemBase64 = Convert.ToBase64String(imagemBytes);
                    string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                    produto.imagemSrc = imagemSrc;


                    lst_produto.Add(produto);
                }
                myconn.Close();

                rpt_produtos.DataSource = lst_produto;
                rpt_produtos.DataBind();
            }
            else if (ddl_atividadeProduto.SelectedItem.ToString() == "Inativo")
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "lista_produtos_detalhes_Inativo";
                mycomm.Connection = myconn;

                List<lista_produtos> lst_produto = new List<lista_produtos>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    lista_produtos produto = new lista_produtos();

                    produto.id_produto = reader.GetInt32(0);
                    produto.produto = reader.GetString(1);
                    produto.preco = reader.GetDecimal(2);
                    produto.quantidade = reader.GetInt32(3);
                    if (produto.quantidade <= 5)
                    {
                        estilo = Convert.ToString("baixo_stock");
                    }
                    else if (produto.quantidade > 5 && produto.quantidade <= 15)
                    {
                        estilo = Convert.ToString("medio_stock");
                    }
                    else
                    {
                        estilo = Convert.ToString("alto_stock");
                    }

                    produto.quantidadeprodutocss = estilo;
                    produto.preco_revenda = reader.GetDecimal(4);
                    produto.ativo = reader.GetBoolean(7);

                    if (produto.ativo.ToString() == "True")
                    {
                        ativoCSS = Convert.ToString("positivo");
                    }
                    else
                    {
                        ativoCSS = Convert.ToString("negativo");
                    }
                    produto.ativoCSS = ativoCSS;

                    byte[] imagemBytes = (byte[])reader["foto"];
                    string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                    // Convertendo os bytes da imagem em uma string base64
                    string imagemBase64 = Convert.ToBase64String(imagemBytes);
                    string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                    produto.imagemSrc = imagemSrc;


                    lst_produto.Add(produto);
                }
                myconn.Close();

                rpt_produtos.DataSource = lst_produto;
                rpt_produtos.DataBind();
            }
        }
    }
}