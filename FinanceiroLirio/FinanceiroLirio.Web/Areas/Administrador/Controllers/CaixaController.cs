﻿using FinanceiroLirio.Entidades;
using FinanceiroLirio.Regras;
using FinanceiroLirio.Web.Areas.Administrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceiroLirio.Web.Areas.Administrador.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CaixaController : Controller
    {
        // GET: Administrador/Caixa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NovoCaixa()
        {

            CongregacaoBusiness cb = new CongregacaoBusiness();
            CadastroCaixaModel model = new CadastroCaixaModel();
            model.Congregacao = cb.ListaTodasCongragacoesDropdownlist();

            ViewBag.Title = "Cadastro de Caixa";
            return View(model); 
        }

        [HttpPost]
        public ActionResult NovoCaixa(CadastroCaixaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CaixaBusiness cb = new CaixaBusiness();
                    Caixa ca = new Caixa();
                    ca.Descricao = model.Descricao;
                    ca.SaldoInicial = model.SaldoInicial;
                    ca.IdCongregacao = model.CongregacaoSelecionada;

                    cb.NovoCaixa(ca);

                    TempData["Mensagem"] = "Caixa cadastrado com sucesso!";
                    TempData["Resposta"] = "Sucesso";
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
            }
            return RedirectToAction("NovoCaixa", "Caixa");                          
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult ListaCaixas()
        {
            List<ListaCaixasModel> lista = new List<ListaCaixasModel>();

            try
            {
                CaixaBusiness cb = new CaixaBusiness();
                List<Caixa> c = cb.ListaTodosCaixas();

                foreach (Caixa ca in c)
                {
                    ListaCaixasModel lcm = new ListaCaixasModel();

                    lcm.CongregacaoSelecionada = ca.IdCongregacao;
                    lcm.Descricao = ca.Descricao;
                    lcm.SaldoInicial = ca.SaldoInicial;

                    lista.Add(lcm);
                }
                return View(lista);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("Novo", "Home");
            }
        }
    }
}