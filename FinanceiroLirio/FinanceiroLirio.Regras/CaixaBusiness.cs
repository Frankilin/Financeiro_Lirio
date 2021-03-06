﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Persistence;
using System.Web.Mvc;

namespace FinanceiroLirio.Regras
{
    public class CaixaBusiness
    {
        public Caixa NovoCaixa(Caixa C)
        {
            try
            {
                if (C.IdCongregacao <= 0)
                {
                    throw new Exception("Nenhuma congregação selecionada");
                }
                else
                {
                    //Verifica se a descrição do caixa está nula
                    if (C.Descricao == null)
                    {
                        throw new Exception("Insira uma descrição valida!");
                    }

                    //Verifica se o IdCongregação está nulo
                    CongregacaoRepository cr = new CongregacaoRepository();
                    Congregacao cg = cr.FindById(C.IdCongregacao);
                    if (cg == null)
                    {
                        throw new Exception("Congregação selecionada não encontrada na base");
                    }

                    //Passa a data e hora atual
                    CaixaRepository cx = new CaixaRepository();
                    C.DataInclusao = DateTime.Now;

                    cx.Insert(C);
                    return C;

                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Caixa> ListaTodosCaixas()
        {
            try
            {
                
                CaixaRepository cr = new CaixaRepository();
                
                List<Caixa> c = cr.All();
                if (c == null)
                {
                       throw new Exception("Lista de caixas não encontrado!");
                }
                return c;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Caixa FindById(int IdCaixa)
        {
            try
            {
                CaixaRepository cr = new CaixaRepository();

                Caixa caixa = cr.FindById(IdCaixa);

                if (caixa == null)
                {
                    throw new Exception("Caixa selecionada foi excluído");
                }

                return caixa; 
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Caixa Alteracao(Caixa caixa)
        {
            try
            {

                CaixaRepository cr = new CaixaRepository();

                Caixa temp = this.FindById(caixa.IdCaixa);

                if (temp != caixa)
                {
                    cr.Update(caixa);
                }

                return caixa;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void delete(Caixa caixa)
        {
            try
            {
                CaixaRepository cr = new CaixaRepository();

                Caixa temp = this.FindById(caixa.IdCaixa);

                if (temp != null)
                {
                    cr.Delete(temp);
                }
                else
                {
                    throw new Exception("Caixa não encontrada");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
