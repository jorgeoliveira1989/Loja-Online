using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace loja_online
{
    public partial class Criar_Conta_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            Stream imgstream = FileUpload1.PostedFile.InputStream;
            int tamanhoFicheiro = FileUpload1.PostedFile.ContentLength;
            string contentType = FileUpload1.PostedFile.ContentType;


            byte[] imgBinaryData = new byte[tamanhoFicheiro];
            imgstream.Read(imgBinaryData, 0, tamanhoFicheiro);

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "inserir_admin_ativacao";

            mycomm.Connection = myconn;
            mycomm.Parameters.AddWithValue("@nome", txt_nome.Text);
            mycomm.Parameters.AddWithValue("@email", txt_email.Text);
            mycomm.Parameters.AddWithValue("@username", txt_username.Text);
            mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_password.Text));
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
                lbl_mensagem.Text = "Verifique o Seu email para ativar a sua conta!";

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();

                email.From = new MailAddress("Jorge.Vieira.Oliveira@formandos.cinel.pt");
                email.To.Add(new MailAddress(txt_email.Text));
                email.Subject = "Ativação de Conta do Utilizador!";

                email.IsBodyHtml = true;
                email.Body = "<b>Obrigado pelo Registo na nossa aplicação.<br/> Para ativar a sua conta carregue <a href='https://localhost:44383/ativacao_admin.aspx?username=" + EncryptString(txt_username.Text) + "'>aqui";

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);


                string utilizador = ConfigurationManager.AppSettings["SMTP_USER"];
                string passe = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(utilizador, passe);
                servidor.EnableSsl = true;

                servidor.Send(email);



            }
            else
            {
                lbl_mensagem.Text = "Utilizador já existe!!!";
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