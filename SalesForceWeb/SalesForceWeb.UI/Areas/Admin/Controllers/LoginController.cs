﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SalesForceWeb.Domain.Entities;

namespace SalesForceWeb.UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection usuario)
        {

            HttpClient client = null;
            string retorno = string.Empty;
            int idusuario = 0;  
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:61154/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resultado = client.GetAsync("sales/Login/AuthenticarUsuario/" + usuario["Login"] + "/" + "/" + usuario["Senha"]).Result;
                retorno = resultado.Content.ReadAsStringAsync().Result;
                

                if (retorno == "[]")
                    ViewBag.mensagem = "Erro! Usuário ou Senha não cadastrado";

                else {
                    
                    FormsAuthentication.SetAuthCookie(usuario["Login"], false);

                    JArray usuarioarrray = JArray.Parse(retorno);
                    foreach (JObject obj in usuarioarrray.Children<JObject>())
                    {
                        foreach (JProperty prop in obj.Properties())
                        {
                            if (prop.Name == "id")
                            {
                                idusuario = Convert.ToInt32(prop.Value.ToString());
                                break;
                            }
                        }

                    }
                    TempData["IdUsuario"] = idusuario;
                    

                }

            }

            if (ViewBag.mensagem != null)
                return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet); // retornando arquivo json 
            else

                return JavaScript("window.location.href = '/Admin/Relatorio/Index' ");// trabalhando com javascript dentro do controller


        }

        public ActionResult RedefinirSenha() {
            return View();
        }

        public ActionResult AlteracaoDadosCliente() {
            var idusuario = Convert.ToString(TempData["IdUsuario"]);
            Usuario dados = new Usuario();
            List<Usuario> dst = new List<Usuario>();
            HttpClient client = null;
            string retorno = string.Empty;
            Domain.ValuesObject.Email vlemail = new Domain.ValuesObject.Email();
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:61154/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resultado = client.GetAsync("sales/Login/DadosUsuario/"+idusuario).Result;
                retorno = resultado.Content.ReadAsStringAsync().Result;
                if (retorno != "[]") {
                    JArray usuarioarrray = JArray.Parse(retorno);
                    foreach (JObject obj in usuarioarrray.Children<JObject>())
                    {
                        foreach (JProperty prop in obj.Properties())
                        {
                            switch (prop.Name) {
                                case "nome": 
                                    dados.Nome = prop.Value.ToString();                           
                                    break;
                                case "sobreNome":
                                    dados.SobreNome = prop.Value.ToString();
                                    break;
                                case "idade":
                                    dados.Idade = prop.Value.ToString();
                                    break;
                                case "sexo":
                                    dados.Sexo = prop.Value.ToString();
                                    break;
                                case "login":
                                    dados.Login = prop.Value.ToString();
                                    break;
                                case "senha":
                                    dados.Senha = prop.Value.ToString();
                                    break;
                                case "email":   
                                    ViewBag.semail = vlemail.EmailJson("[" + prop.Value.ToString() + "]");
                                    
                                    break;
                                    
                                default:
                                    break;
                            }
                            
                        }

                    }
                }
            }
            dst.Add(dados);
             return View(dst);
        }


        public ActionResult Deslogar() {
            FormsAuthentication.SignOut();
            return RedirectToAction("/Index");
        }
    }
}