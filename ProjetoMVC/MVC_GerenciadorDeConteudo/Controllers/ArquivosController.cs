using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class  ArquivosController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Arquivo = new Arquivo().lista();
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public void Criar()
        {
           
           
            var Arquivo = new Arquivo();
            Arquivo.Titulo = Request["Titulo"];
            Arquivo.Processo = Request["Processo"];
            Arquivo.Categoria = Convert.ToInt32(Request["Categoria"]);


            var files = AddFiles(Request.Files, "Arquivo");

            foreach (var f in files)
            {
                if (f.Key == "Arquivo")
                    Arquivo.Arquivos = f.Value;
            }

            
            Arquivo.save();
            TempData.Add("sucesso", "Dados salvos com sucesso!");
           
            Response.Redirect("/Arquivos");
        }
        public ActionResult Editar(int id)
        {
            var arquivo = Arquivo.BuscaPorId(id);
            ViewBag.Arquivo = arquivo;
            return View();
        }
        [HttpPost]
        public void Alterar(int id)
        {
            try
            {
                var arquivo = Arquivo.BuscaPorId(id);
                DateTime data;
                DateTime.TryParse(Request["data"], out data);
                arquivo.Titulo = Request["Titulo"];
                arquivo.Processo = Request["Processo"];
                arquivo.Categoria = Convert.ToInt32(Request["Categoria"]);

                var files = AddFiles(Request.Files, "Arquivo");

                foreach (var f in files)
                {
                    if (f.Key == "Arquivo")
                       arquivo.Arquivos = f.Value;
                }
                arquivo.save();

                TempData.Add("sucesso", "Dados Actualizada com sucesso!");

            }
            catch(Exception e)
            {
                TempData.Add("erro",e.Message);
            }
            Response.Redirect("/Arquivos");
        }
        public void Excluir(int id)
        {
            
            Arquivo.Excluir(id);

            Response.Redirect("/Arquivos");
        }

        public IDictionary<string, string> AddFiles(HttpFileCollectionBase files, string name)
        {
            try
            {

                IDictionary<string, string> savedFile = new Dictionary<string, string>();

                for (int i = 0; i < files.Count; i++)
                {
                    string fname = "";

                    string path = AppDomain.CurrentDomain.BaseDirectory + "Upload/";
                    string filename = Path.GetFileName(Request.Files[i].FileName);
                    string extension = Path.GetExtension(Request.Files[i].FileName);

                    HttpPostedFileBase file = files[i];

                    if (filename != "")
                    {
                        fname = name + "_" + DateTime.Now.Day.ToString() + "0" + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + "_" + i + DateTime.Now.Millisecond.ToString() + extension;

                        filename = Path.Combine(Server.MapPath("~/Upload/"), fname);
                        file.SaveAs(filename);
                    }
                    savedFile[files.AllKeys[i]] = fname;

                }

                return savedFile;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}