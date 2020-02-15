using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using EditoraMazzoni.WebMvc.Web.Utils;

namespace EditoraMazzoni.WebMvc.Web.Controllers
{
    public class InicioController : Controller
    {
        // Definir variaveis

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contato()
        {
            //retorna o html da view correspondente com a actionResult contato
            return View();
        }

        [HttpPost]
        public ActionResult Contato(FormCollection form)
        {
            var emailRemetente = "fernandos.s.mazzoni@gmail.com";
            var nomeRemetente = form["Nome"];
            var emailDestiatario = form["Email"]; 
            var assunto = form["Assunto"];
            var mensagem = form["Mensagem"];

            try
            {
                // vamos usar a classe envio de email
                EnviarEmail enviarEmail = new EnviarEmail(emailRemetente, nomeRemetente, emailDestiatario, mensagem, assunto);

                //TODO testar depois
                //enviarEmail.Send();

                ViewBag.MensagemEnviada = "Mensagem enviada com sucesso";

                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}