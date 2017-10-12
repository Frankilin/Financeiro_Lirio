using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Regras
{
    public class EnderecoBusiness
    {
        public Endereco NovoEndereco(Endereco e)
        {
            try
            {
                if (e.IdCidade == 0)
                {
                    throw new Exception("Cidade não informada.");
                }

                CidadeBusiness cb = new CidadeBusiness();

                if(cb.AcharCidadePorId(e.IdCidade) == null)
                {
                    throw new Exception("Cidade não encontrada em nossa base.");
                }

                if(e.Cep != null)
                {
                    e.Cep = e.Cep.Replace(".", String.Empty);
                    e.Cep = e.Cep.Replace("-", String.Empty);
                }
                
                EnderecoRepository er = new EnderecoRepository();

                er.Insert(e);

                return e;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
