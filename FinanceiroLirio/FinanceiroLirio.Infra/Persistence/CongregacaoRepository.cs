using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLirio.Infra.Generics;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.DataSource;
using System.Data.Entity;

namespace FinanceiroListio.Infra.Persistence
{
    public class CongregacaoRepository : OperacoesGenericas<Congregacao>
    {
        public override List<Congregacao> All() 
        {
            using(Conexao con = new Conexao()) //usando a conexão do banco
            {
                return con.Congregacao
                            .Include(c => c.Endereco) //inner join endereço
                            .Include(c => c.Endereco.Cidade) //inner join cidade
                            .Include(c => c.Endereco.Cidade.Estado)
                            .OrderBy(c => c.Endereco.Cidade.Estado.Nome)
                            .ThenBy(c => c.Endereco.Cidade.Nome)
                            .ThenBy(c => c.Apelido)
                            .ToList(); //gerando a lista
            }
        }
    }
}
