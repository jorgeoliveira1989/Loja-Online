using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loja_online
{
    public partial class criar_produto : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
        }

        protected void btn_criar_produto_Click(object sender, EventArgs e)
        {
            float preco_revenda = float.Parse(txt_preco.Text) / 1.20f;
            decimal preco = decimal.Parse(txt_preco.Text);

            Stream imgstream = FileUpload1.PostedFile.InputStream;
            int tamanhoFicheiro = FileUpload1.PostedFile.ContentLength;
            string contentType = FileUpload1.PostedFile.ContentType;


            byte[] imgBinaryData = new byte[tamanhoFicheiro];
            imgstream.Read(imgBinaryData, 0, tamanhoFicheiro);

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "inserir_produto";

            mycomm.Connection = myconn;
            mycomm.Parameters.AddWithValue("@produto", txt_produto.Text);
            mycomm.Parameters.AddWithValue("@designacao", txt_designacao.Text);
            mycomm.Parameters.AddWithValue("@descricao", txt_descricao.Text);
            mycomm.Parameters.AddWithValue("@preco", preco);
            mycomm.Parameters.AddWithValue("@revenda", preco_revenda);
            mycomm.Parameters.AddWithValue("@quantidade", txt_quantidade.Text);
            mycomm.Parameters.AddWithValue("@ct", contentType);
            mycomm.Parameters.AddWithValue("@foto", imgBinaryData);


            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Produto adicionado com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "Produto já existe!!!";
            }
        }
    }
}