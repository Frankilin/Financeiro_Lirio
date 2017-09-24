using FinanceiroLirio.Entidades;
using FinanceiroListio.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FinanceiroLirio.Regras
{
    public class CongregacaoBusiness
    {
        public Congregacao NovaCongregacao(Congregacao c)
        {
            try
            {
                if(c.Descricao == null)
                {
                    throw new Exception("Informe a descrição da congregação.");
                }

                if(c.Apelido == null)
                {
                    throw new Exception("Informe o apelido da congregação.");
                }
                
                c.Ativo = true;
                c.DataInclusao = DateTime.Now;

                CongregacaoRepository cr = new CongregacaoRepository();

                cr.Insert(c);
                
                return c;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<Congregacao> TodasCongregacoes()//função na business que retornará uma listagem de congregações
        {
            try
            {
                List<Congregacao> c = null;

                CongregacaoRepository cr = new CongregacaoRepository();

                c = cr.All();

                if(c == null)
                {
                    throw new Exception("Nenhuma congregação encontrada.");
                }

                return c;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public SelectList ListaTodasCongragacoesDropdownlist()
        {
            try
            {
                List<Congregacao> tmp = this.TodasCongregacoes();

                var itens = new List<SelectListItem>();

                foreach (Congregacao c in tmp)
                {
                    itens.Add(new SelectListItem { Value = c.IdCongregacao.ToString(), Text = c.Descricao });
                }

                SelectList sl = new SelectList(itens, "Value", "Text");

                return sl;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
