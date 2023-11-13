using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loja_online
{
    public partial class backoffice1 : System.Web.UI.Page
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
            mycomm.CommandText = "lista_clientes_detalhes";
            mycomm.Connection = myconn;

            List<lista_clientes> lst_cliente = new List<lista_clientes>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                lista_clientes cliente = new lista_clientes();
                cliente.id_cliente = reader.GetInt32(0);
                cliente.nome = reader.GetString(1);
                cliente.email = reader.GetString(2);
                cliente.username = reader.GetString(3);
                cliente.tipo_cliente = reader.GetString(4);
                cliente.ativo = reader.GetBoolean(5);
            
                if(cliente.ativo.ToString() == "True")
                {
                    estilo = Convert.ToString("ativo");
                }
                else
                {
                    estilo = Convert.ToString("desativo");
                }
                
                cliente.estilosCSS = estilo;


                lst_cliente.Add(cliente);
            }

            myconn.Close();

            rpt_verClientes.DataSource = lst_cliente;
            rpt_verClientes.DataBind();
        }

        public class lista_clientes
        {
            public int id_cliente { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public string username { get; set; }
            public string tipo_cliente { get; set; }
            public bool ativo { get; set; }
            public string estilosCSS { get; set; }

        }

        protected void ddl_tipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_tipoConta.SelectedItem.ToString()== "Cliente")
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "lista_clientes_detalhes_Cliente";
                mycomm.Connection = myconn;

                List<lista_clientes> lst_cliente = new List<lista_clientes>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    lista_clientes cliente = new lista_clientes();
                    cliente.id_cliente = reader.GetInt32(0);
                    cliente.nome = reader.GetString(1);
                    cliente.email = reader.GetString(2);
                    cliente.username = reader.GetString(3);
                    cliente.tipo_cliente = reader.GetString(4);
                    cliente.ativo = reader.GetBoolean(5);

                    if (cliente.ativo.ToString() == "True")
                    {
                        estilo = Convert.ToString("ativo");
                    }
                    else
                    {
                        estilo = Convert.ToString("desativo");
                    }

                    cliente.estilosCSS = estilo;


                    lst_cliente.Add(cliente);
                }

                myconn.Close();

                rpt_verClientes.DataSource = lst_cliente;
                rpt_verClientes.DataBind();

            } 
            else if(ddl_tipoConta.SelectedItem.ToString() == "Revendedor")
            {
                SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

                SqlCommand mycomm = new SqlCommand();

                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.CommandText = "lista_clientes_detalhes_Revendedor";
                mycomm.Connection = myconn;

                List<lista_clientes> lst_cliente = new List<lista_clientes>();

                myconn.Open();

                var reader = mycomm.ExecuteReader();

                while (reader.Read())
                {
                    lista_clientes cliente = new lista_clientes();
                    cliente.id_cliente = reader.GetInt32(0);
                    cliente.nome = reader.GetString(1);
                    cliente.email = reader.GetString(2);
                    cliente.username = reader.GetString(3);
                    cliente.tipo_cliente = reader.GetString(4);
                    cliente.ativo = reader.GetBoolean(5);

                    if (cliente.ativo.ToString() == "True")
                    {
                        estilo = Convert.ToString("ativo");
                    }
                    else
                    {
                        estilo = Convert.ToString("desativo");
                    }

                    cliente.estilosCSS = estilo;


                    lst_cliente.Add(cliente);
                }

                myconn.Close();

                rpt_verClientes.DataSource = lst_cliente;
                rpt_verClientes.DataBind();

            }
        }
    }
}