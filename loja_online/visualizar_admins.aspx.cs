using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace loja_online
{
    public partial class visualizar_admins : System.Web.UI.Page
    {
        string estilo = "";
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
            mycomm.CommandText = "lista_admins_detalhes";
            mycomm.Connection = myconn;

            List<lista_admins> lst_admin = new List<lista_admins>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                lista_admins admin = new lista_admins();
                admin.id_empresa = reader.GetInt32(0);
                admin.nome = reader.GetString(1);
                admin.email = reader.GetString(2);
                admin.username = reader.GetString(3);
                admin.tipo = reader.GetString(4);
                admin.ativo = reader.GetBoolean(5);

                if (admin.ativo.ToString() == "True")
                {
                    estilo = Convert.ToString("ativo");
                }
                else
                {
                    estilo = Convert.ToString("desativo");
                }

                admin.estilosCSS = estilo;


                lst_admin.Add(admin);
            }

            myconn.Close();

            rpt_verAdmins.DataSource = lst_admin;
            rpt_verAdmins.DataBind();
        }

        public class lista_admins
        {
            public int id_empresa { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public string username { get; set; }
            public string tipo { get; set; }
            public bool ativo { get; set; }
            public string estilosCSS { get; set; }

        }
    }
    
}