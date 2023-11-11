using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Security.Cryptography;
using itextsharp;
using System.Windows.Controls;
using System.Text;
using iTextSharp.text.pdf.security;



namespace loja_online
{
    public partial class carrinho : System.Web.UI.Page
    {

        decimal valorTotal = 0;
        private List<Produtos> ListaProdutosCarrinho
        {
            get
            {
                if (Session["Carrinho"] == null)
                    Session["Carrinho"] = new List<Produtos>();
                return (List<Produtos>)Session["Carrinho"];
            }
            set { Session["Carrinho"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                AtualizarCarrinho();
                
            }

            if (Session["username"] == null)
            {
                btnFinalizarEncomenda.Visible = false;
                lbl_mail.Visible = false;
                txt_email.Visible = false;
                btnlogin.Visible = true;
                btncriarconta.Visible = true;
            }
            else
            {
                btnFinalizarEncomenda.Visible = true;
                lbl_mail.Visible = true;
                txt_email.Visible = true;
                btnlogin.Visible = false;
                btncriarconta.Visible = false;
            }

        }

        protected void rptCarrinho_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Subtrair":
                    SubtrairQuantidade(index);
                    break;
                case "Adicionar":
                    AdicionarQuantidade(index);
                    break;
            }
            AtualizarCarrinho();
            
        }

        private void SubtrairQuantidade(int index)
        {
             if (ListaProdutosCarrinho[index].Quantidade > 0)
             {
                 ListaProdutosCarrinho[index].Quantidade--;
                 if (ListaProdutosCarrinho[index].Quantidade == 0)
                 {
                     ListaProdutosCarrinho.RemoveAt(index);
                    
                }
             }

             // Atualiza o valor total do carrinho após subtrair a quantidade
             AtualizarValorTotal();
            Session["ValorTotal"] = valorTotal;
            AtualizarValorAcumulado();
        }

        private void AdicionarQuantidade(int index)
        {
            ListaProdutosCarrinho[index].Quantidade++;
            if (ListaProdutosCarrinho[index].Quantidade == 0)
            {
                ListaProdutosCarrinho.RemoveAt(index);
            }

            // Atualiza o valor total do carrinho após adicionar a quantidade
            AtualizarValorTotal();
        }

        private void AtualizarCarrinho()
        {
            rptCarrinho.DataSource = ListaProdutosCarrinho;
            rptCarrinho.DataBind();

            // Atualiza o valor total do carrinho
            AtualizarValorTotal();
        }

        private void AtualizarValorTotal()
        {
            valorTotal = 0;

            foreach (var produto in ListaProdutosCarrinho)
            {
                valorTotal += produto.preco * produto.Quantidade;
            }

            lbl_valor.Text = valorTotal.ToString("C");

            Session["ValorTotal"] = valorTotal;
        }
        public int CalcularTotalArtigos()
        {
            int totalArtigos = 0;

            foreach (var item in ListaProdutosCarrinho)
            {
                totalArtigos += item.Quantidade;

            }

            if (totalArtigos == 0)
            {
                txt_email.Enabled = false;
                btnFinalizarEncomenda.Enabled = false;
            }
            else
            {
                txt_email.Enabled = true;
                btnFinalizarEncomenda.Enabled = true;
            }

            return totalArtigos;
        }

        private void AtualizarValorAcumulado()
        {
            decimal valorAcumulado = 0;

            foreach (var produto in ListaProdutosCarrinho)
            {
                valorAcumulado += produto.preco * produto.Quantidade;
            }

            Session["ValorAcumulado"] = valorAcumulado;
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btncriarconta_Click(object sender, EventArgs e)
        {
            Response.Redirect("criar_conta.aspx");
        }

        protected void btn_avançar_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            Panel2.Visible = true;
        }

        protected void btnFinalizarEncomenda_Click(object sender, EventArgs e)
        {
            string caminhoPathPDFS = ConfigurationManager.AppSettings["PathPDFS"];

            string PdfTemplate = caminhoPathPDFS + "Template\\template.pdf";

            string NomePDF = EncryptString(DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "")) + ".pdf";

            string NovoFicheiro = caminhoPathPDFS + "Gerados\\" + NomePDF;


            PdfReader preader = new PdfReader(PdfTemplate) ;
            PdfStamper pstamper = new PdfStamper(preader, new FileStream(NovoFicheiro, FileMode.Create));

            DateTime dia = DateTime.Now;

            AcroFields pdfFields = pstamper.AcroFields;
            pdfFields.SetField("Data", dia.ToString());
            pdfFields.SetField("Cliente", Session["username"].ToString());
            pdfFields.SetField("Email", txt_email.Text);
            pdfFields.SetField("Valor Final", lbl_valor.Text);

            for (int i = 0; i < rptCarrinho.Items.Count; i++)
            {
                System.Web.UI.WebControls.Label lblproduto = (System.Web.UI.WebControls.Label)rptCarrinho.Items[i].FindControl("lblproduto");
                System.Web.UI.WebControls.Label lblpreco = (System.Web.UI.WebControls.Label)rptCarrinho.Items[i].FindControl("lblpreco");
                System.Web.UI.WebControls.TextBox txtQuantidade = (System.Web.UI.WebControls.TextBox)rptCarrinho.Items[i].FindControl("txtQuantidade");

                // Usar a codificação UTF-8 diretamente
                string produtoText = lblproduto.Text;
                byte[] produtoBytes = Encoding.UTF8.GetBytes(produtoText);

                // Definindo os campos no PDF
                pdfFields.SetField("Produto" + (i + 1), Encoding.UTF8.GetString(produtoBytes));
                pdfFields.SetField("Preco" + (i + 1), lblpreco.Text);
                pdfFields.SetField("Quantidade" + (i + 1), txtQuantidade.Text);

            }
            
            pstamper.Close();

            guardaDetalhesTabelaVendas();

                //Response.Redirect(caminhoSiteURL + "PDFS\\Gerados\\" + NomePDF);

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();

                string emailenviar = "Jorge.Vieira.Oliveira@formandos.cinel.pt";

                email.From = new MailAddress(emailenviar);
                email.To.Add(new MailAddress(txt_email.Text));
                email.Subject = "Compra Efetuada!!" + dia;

                email.IsBodyHtml = true;
                email.Body = "Obrigado por comprar na nossa Loja.<br/> Enviamos em anexo o comprovativo. <br/><br/> VOLTE SEMPRE!!!";

                Attachment anexo = new Attachment(NovoFicheiro, "application/pdf");
                email.Attachments.Add(anexo);

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

                string utilizador = ConfigurationManager.AppSettings["SMTP_USER"];
                string passe = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(utilizador, passe);
                servidor.EnableSsl = true;

                servidor.Send(email);

        }

        private void guardaDetalhesTabelaVendas()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString))
            {
                connection.Open();

                string user = (string)Session["username"];
                DateTime dataVenda = DateTime.Now;

                for (int i = 0; i < rptCarrinho.Items.Count; i++)
                {
                   
                    int quantidade = Convert.ToInt32((rptCarrinho.Items[i].FindControl("txtQuantidade") as System.Web.UI.WebControls.TextBox).Text);
                    string produto = Convert.ToString((rptCarrinho.Items[i].FindControl("lblproduto") as System.Web.UI.WebControls.Label).Text);

                    string query = "INSERT INTO vendas (username,produto,quantidade,data_venda) VALUES (@username, @produto, @quantidade, @data)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", user);
                        cmd.Parameters.AddWithValue("@produto", produto);
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@data", dataVenda);

                        cmd.ExecuteNonQuery();
                    }
                }

                connection.Close();
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
    }
}