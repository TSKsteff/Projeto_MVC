
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Arquivo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Arquivos { get; set; }
        public int Categoria { get; set; }

        public string NomeCategoria { get; set; }

        public string Processo { get; set; }
        public bool Ativo { get; set; }
        public List<Arquivo> lista()
        {
            var lista = new List<Arquivo>();
            var arquivoDb = new Database.Arquivo();
            foreach (DataRow row in arquivoDb.Lista().Rows)
            {
                var arquivo = new Arquivo();
                arquivo.Id = Convert.ToInt32(row["ArquivoID"]);
                arquivo.Titulo = row["Titulo"].ToString();
                arquivo.Arquivos = row["Arquivos"].ToString();
                arquivo.Categoria = Convert.ToInt32(row["Categoria"]);
                if(arquivo.Categoria == 1)
                {
                   arquivo.NomeCategoria = "teste 01";
                }
                else if(arquivo.Categoria == 2)
                {
                    arquivo.NomeCategoria = "teste 02";
                }
                arquivo.Processo = row["Processo"].ToString();
                arquivo.Ativo = Convert.ToBoolean(row["Ativo"]);
                lista.Add(arquivo);
            }

            return lista;
        }

        public static Arquivo BuscaPorId(int id)
        {
            var Arquivo = new Arquivo();
            var arquivoDb = new Database.Arquivo();
            foreach (DataRow row in arquivoDb.BuscaPorId(id).Rows)
            {
               
                Arquivo.Id = Convert.ToInt32(row["ArquivoID"]);
                Arquivo.Titulo = row["Titulo"].ToString();
                Arquivo.Arquivos = row["Arquivos"].ToString();
                Arquivo.Categoria = Convert.ToInt32(row["Categoria"]);
                Arquivo.Processo = row["Processo"].ToString();
                Arquivo.Ativo = Convert.ToBoolean(row["Ativo"]);

            }

            return Arquivo;

        }

        public void save()
        {
            new Database.Arquivo().Salvar(this.Id, this.Arquivos, this.Ativo, this.Processo, this.Titulo, this.Categoria);
        }


        public static void Excluir(int id)
        {
            new Database.Arquivo().Excluir(id);
        }
    }
}
