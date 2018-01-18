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
                    lcm.IdCaixa = ca.IdCaixa;

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

        //Tem que utilizar int id nos parâmetro para que não ocorra erro.
        public ActionResult Alteracao(int id)
        {
            try
            {
                CaixaBusiness cb = new CaixaBusiness();

                CongregacaoBusiness congb = new CongregacaoBusiness();

                AlteracaoCaixa model = new AlteracaoCaixa();

                Caixa temp = cb.FindById(id);

                model.IdCaixa = temp.IdCaixa;
                model.Descricao = temp.Descricao;
                model.SaldoInicial = temp.SaldoInicial;
                model.CongregacaoSelecionada = temp.IdCongregacao;
                model.Congregacaos = congb.ListaTodasCongragacoesDropdownlist();

                return View(model);
                
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("ListaCaixas");
            }
        }

        [HttpPost]
        public ActionResult Alteracao(AlteracaoCaixa temp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CaixaBusiness cb = new CaixaBusiness();

                    CongregacaoBusiness gb = new CongregacaoBusiness();

                    Caixa caixa = cb.FindById(temp.IdCaixa);

                
                    caixa.IdCaixa = temp.IdCaixa;
                    caixa.Descricao = temp.Descricao;
                    caixa.SaldoInicial = temp.SaldoInicial;
                    temp.Congregacaos = gb.ListaTodasCongragacoesDropdownlist();
                    caixa.IdCongregacao = temp.CongregacaoSelecionada;

                    cb.Alteracao(caixa);
                }
             
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
            }

            return RedirectToAction("ListaCaixas");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                CaixaBusiness cb = new CaixaBusiness();

                Caixa caixa = cb.FindById(id);

                DeleteCaixaModel temp = new DeleteCaixaModel();

                temp.IdCaixa = caixa.IdCaixa;
                temp.Descricao = caixa.Descricao;

                return View(temp);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("ListaCaixas");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteCaixaModel temp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CaixaBusiness cb = new CaixaBusiness();

                    Caixa caixa = cb.FindById(temp.IdCaixa);

                    cb.delete(caixa);
                }

                TempData["Mensagem"] = "Caixa excluído com sucesso!";
                TempData["Resposta"] = "Sucesso";

                return RedirectToAction("ListaCaixas");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro: " + e.Message;
                TempData["Resposta"] = "Falha";
                return RedirectToAction("ListaCaixas");
            }
        }
    }
}