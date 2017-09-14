using FinanceiroLirio.Entidades;
using FinanceiroLirio.Regras;
using FinanceiroLirio.Web.Areas.Administrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Controllers
{
    
    public class CongregacaoController : Controller
    {
        // GET: Administrador/Congregacao
        [Authorize(Roles = "Administrador")]
        public ActionResult Nova()
        {
            CidadeBusiness cb = new CidadeBusiness();

            var model = new CadastroCongregacaoModel();

            List<Cidade> tmp = cb.TodasCidades();

            var itens = new List<SelectListItem>();

            foreach (Cidade c in tmp)
            {
                itens.Add(new SelectListItem { Value = c.IdCidade.ToString(), Text = c.Nome });
            }

            SelectList sl = new SelectList(itens, "Value", "Text");

            model.Cidade = sl;
            ViewBag.ListaItensEstados = sl;
            ViewBag.Titulo = "Cadastrar congregação";

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Nova(CadastroCongregacaoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Congregacao c = new Congregacao();

                    c.Apelido = model.Apelido;
                    c.Descricao = model.Descricao;
                    //c.Endereco = new Endereco();

                    //c.Endereco.Rua = model.Rua;
                    //c.Endereco.Numero = model.Numero;
                    //c.Endereco.Cep = model.Cep;
                    //c.Endereco.Bairro = model.Bairro;
                    //c.Endereco.IdCidade = model.CidadeSelecionada;
                    //c.Endereco.Complemento = model.Complemento;

                    Endereco e = new Endereco();

                    e.Rua = model.Rua;
                    e.Numero = model.Numero;
                    e.Cep = model.Cep;
                    e.Bairro = model.Bairro;
                    e.IdCidade = model.CidadeSelecionada;
                    e.Complemento = model.Complemento;

                    EnderecoBusiness eb = new EnderecoBusiness();

                    e = eb.NovoEndereco(e);
                    c.IdEndereco = e.IdEndereco;

                    CongregacaoBusiness cb = new CongregacaoBusiness();

                    c = cb.NovaCongregacao(c);

                    TempData["Mensagem"] = "Congregação cadastrada com sucesso.";
                    TempData["Resposta"] = "Sucesso";
                }
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
            }

            try
            {
                CidadeBusiness cb = new CidadeBusiness();
                List<Cidade> tmp = cb.TodasCidades();

                var itens = new List<SelectListItem>();

                foreach (Cidade c in tmp)
                {
                    itens.Add(new SelectListItem { Value = c.IdCidade.ToString(), Text = c.Nome });
                }

                SelectList sl = new SelectList(itens, "Value", "Text");

                model.Cidade = sl;
                ViewBag.ListaItensEstados = sl;
                ViewBag.Titulo = "Cadastrar congregação";
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
            }
            return View(model);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Lista()
        {
            List<ListaCongregacaoModel> lista = new List<ListaCongregacaoModel>();
            try
            {
                CongregacaoBusiness cb = new CongregacaoBusiness();
                List<Congregacao> c = cb.TodasCongregacoes();
                
                foreach (Congregacao o in c)
                {
                    ListaCongregacaoModel tmp = new ListaCongregacaoModel();

                    tmp.Apelido = o.Apelido;
                    tmp.Cidade = o.Endereco.Cidade.Nome;
                    tmp.Estado = o.Endereco.Cidade.Estado.Nome;
                    tmp.IdCongregacao = o.IdCongregacao;

                    lista.Add(tmp);
                    
                }
                return View(lista);
            }
            catch(Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("Index", "Home");
            }
            
        }
        
    }
}