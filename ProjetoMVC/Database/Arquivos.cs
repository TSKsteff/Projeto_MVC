

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.ComponentModel.Design;
using System.Web;
using System.IO;
//using System.Web.Routing;

namespace Database
{
    public class Arquivo
    {
        private string sqlconn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (MySqlConnection connection = new MySqlConnection(sqlconn()))
            {
                string queryString = "select * from Arquivos ";
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string arquivos, bool ativo, string processo, string titulo, int categoria)
        {

            using (MySqlConnection connection = new MySqlConnection(sqlconn()))
            {
                string queryString = "INSERT INTO Arquivos (Arquivos,Ativo,Processo,Titulo,Categoria) values ('" + arquivos + "','" + Convert.ToBoolean(ativo) + "','" + processo + "','" + titulo + "','" + categoria + "')";

                if (id != 0)
                {
                    queryString = "update Arquivos  set titulo ='" + titulo + "',arquivos='" + arquivos + "',ativo='" + Convert.ToBoolean(ativo) + "',processo='" + processo + "', categoria ='" + categoria + "' where arquivoid=" + id;
                }
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(sqlconn()))
            {
                string queryString = "DELETE FROM Arquivos  where arquivoid=" + id;
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(sqlconn()))
            {
                string queryString = "select * from Arquivos where ArquivoID= " + id;
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }



    }
}
