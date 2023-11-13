using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Collections;
using static loja_online.conta;
using System.Globalization;

namespace loja_online
{
    public partial class conta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("loja_online.aspx");
            }

            if (!IsPostBack)
            {
                // Carrega a DropDownList apenas se não for uma solicitação pós-volta.
                CarregarDropDownList();
            }

        }
        protected void btn_alterarSenha_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void btn_verCompras_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;

            string user = (string)Session["username"];

            string query = "Select id_venda,username,produto,quantidade,data_venda from vendas where '" +user+ "'=username";

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            if (query == null)
            {
                lblSemCompras.Visible = true;
                lblSemCompras.Text = "Zero compras efetuadas até ao momento.";
            }
            else
            {

                List<Vendas> lst_vendas = new List<Vendas>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();


                while (reader.Read())
                {
                    Vendas venda = new Vendas();

                    venda.id_vendas = reader.GetInt32(0);
                    venda.username = reader.GetString(1);
                    venda.produto = reader.GetString(2);
                    venda.quantidade = reader.GetInt32(3);
                    venda.data_venda = reader.GetDateTime(4);

                    lst_vendas.Add(venda);
                }

                myconn.Close();


            
                rpt_vendas.DataSource = lst_vendas;
                rpt_vendas.DataBind();
            }

        }

        public class Vendas{

            public int id_vendas {  get; set; }
            public string username {  get; set; }
            public string produto {  get; set; }
            public int quantidade { get; set; }
            public DateTime data_venda { get; set; }
        }
    

        protected void btn_Sair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loja_online.aspx");
        }

        protected void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "alterar_passe";

            mycomm.Connection = myconn;
            mycomm.Parameters.AddWithValue("@user", Session["username"]);
            mycomm.Parameters.AddWithValue("@passeAtual", EncryptString(txtSenhaAtual.Text));
            mycomm.Parameters.AddWithValue("@passeNova", EncryptString(txtConfirmarNovaSenha.Text));

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
                lblInfo.Text = "Palavra-Passe alterada com Sucesso!!!";
            }
            else
            {
                lblInfo.Text = "Palavra-passe errada!!!";
            }
        }

        public static string EncryptString(string Message)
        {
            string Passphrase = "cinel";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();



            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below



            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));



            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();



            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;



            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);



            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }



            // Step 6. Return the encrypted string as a base64 encoded string



            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KLKLK");
            enc = enc.Replace("/", "JLJLJL");
            enc = enc.Replace("\\", "IOIOIO");
            return enc;
        }
        private void CarregarDropDownList()
        {
            if (Session["username"] != null)
            {
                ddl_data.DataSourceID = null; // Remover a fonte de dados existente para permitir a alteração do DataSourceID
                SqlDataSource1.SelectParameters["username"].DefaultValue = Session["username"].ToString();
                ddl_data.DataSource = SqlDataSource1;
                ddl_data.DataBind();
            }
        }

        protected void ddl_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ddl_data.SelectedValue;

            // Extrair o dia da data selecionada
            DateTime dataSelecionada = DateTime.Parse(valor);
            string diaSelecionado = dataSelecionada.Day.ToString();

            // Construir a consulta SQL para buscar pelo dia
            string query = $"SELECT id_venda, username, produto, quantidade, data_venda FROM vendas WHERE DAY(data_venda) = {diaSelecionado}";

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Vendas> lst_vendas = new List<Vendas>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Vendas venda = new Vendas();

                venda.id_vendas = reader.GetInt32(0);
                venda.username = reader.GetString(1);
                venda.produto = reader.GetString(2);
                venda.quantidade = reader.GetInt32(3);
                venda.data_venda = reader.GetDateTime(4);

                lst_vendas.Add(venda);
            }

            myconn.Close();

            rpt_vendas.DataSource = lst_vendas;
            rpt_vendas.DataBind();
        }
    }
}