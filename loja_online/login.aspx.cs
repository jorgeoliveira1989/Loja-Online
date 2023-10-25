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

namespace loja_online
{
    public partial class login : System.Web.UI.Page
    {
        string cargo = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            Session["username"] = txt_user.Text;

            cargo = ddl_tipo.SelectedItem.ToString();

            if (cargo == "-------------")
            {
                ddl_tipo.Focus();
                lbl_info.Text = "Indique um cargo!!! (Administrador, Cliente ou Revendedor)";

            }
            else if (cargo == "Administrador") 
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "autenticacao_ativacao_admin";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@user", txt_user.Text);
                mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_passe.Text));
                mycomm.Parameters.AddWithValue("@cargo", ddl_tipo.Text);

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
                    Response.Redirect("backoffice.aspx");
                }
                else if (resposta == 0)
                {
                    lbl_info.Text = "Username e/ou Password não existem!!!";
                }
                else if (resposta == 2)
                {
                    lbl_info.Text = "Conta está inativa!!!";
                }
            }
            else if (cargo == "Cliente")
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "autenticacao_ativacao";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@user", txt_user.Text);
                mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_passe.Text));
                mycomm.Parameters.AddWithValue("@cargo", ddl_tipo.Text);

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
                    Response.Redirect("conta.aspx");
                }
                else if (resposta == 0)
                {
                    lbl_info.Text = "Username e/ou Password não existem!!!";
                }
                else if (resposta == 2)
                {
                    lbl_info.Text = "Conta está inativa!!!";
                }
            }
            else if (cargo == "Revendedor")
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "autenticacao_ativacao";

                mycomm.Connection = myconn;
                mycomm.Parameters.AddWithValue("@user", txt_user.Text);
                mycomm.Parameters.AddWithValue("@passe", EncryptString(txt_passe.Text));
                mycomm.Parameters.AddWithValue("@cargo", ddl_tipo.Text);

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
                    Response.Redirect("conta.aspx");
                }
                else if (resposta == 0)
                {
                    lbl_info.Text = "Username e/ou Password não existem!!!";
                }
                else if (resposta == 2)
                {
                    lbl_info.Text = "Conta está inativa!!!";
                }
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