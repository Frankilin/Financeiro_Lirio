using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.DataSource;
using FinanceiroLirio.Infra.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroListio.Infra.Persistence
{
    public class CidadeRepository : OperacoesGenericas<Cidade>
    {
        public List<Cidade> CidadePorEstado(int idEstado)
        {
            try
            {
                using(Conexao con = new Conexao())
                {
                    return con.Cidade
                                .Where(c => c.IdEstado == idEstado)
                                .ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public override List<Cidade> All()
        {
            try
            {
                using(Conexao con = new Conexao())
                {
                    return con.Cidade
                                .OrderBy(c => c.Nome)
                                .ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
