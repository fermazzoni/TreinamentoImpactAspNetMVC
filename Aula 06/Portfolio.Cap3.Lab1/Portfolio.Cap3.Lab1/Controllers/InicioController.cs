using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Portfolio.Cap3.Lab1.Models;

namespace Portfolio.Cap3.Lab1.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            string pathVirtual = "~/imagens/Portfolio/";
            string pathFisico = Server.MapPath(pathVirtual);
            string[] arquivos = Directory.GetFiles(pathFisico);
            List<string> imageUrlList = new List<string>();
            foreach (string arquivo in arquivos)
            {
                string nomeArquivo = Path.GetFileName(arquivo);
                string imageUrl = Url.Content(pathVirtual +
               nomeArquivo);
                imageUrlList.Add(imageUrl);
            }
            ViewBag.ImageUrlList = imageUrlList;
            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Concluido = false;

            return View();
        }

        [HttpPost]
        public ActionResult Contato(ContatoViewModel contato)
        {
            string pathVirtual = "~/contatos.txt";
            string pathFisico = Server.MapPath(pathVirtual);
            using (var sw = new StreamWriter(pathFisico, true))
            {
                sw.WriteLine(contato.Nome);
                sw.WriteLine(contato.Email);
                sw.WriteLine(contato.Mensagem);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine();
            }
            ViewBag.Concluido = true;
            return View();
        }



    }
}