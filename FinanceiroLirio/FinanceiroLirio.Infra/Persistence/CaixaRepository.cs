using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.DataSource;
using FinanceiroLirio.Infra.Generics;



namespace FinanceiroLirio.Infra.Persistence
{
    public class CaixaRepository : OperacoesGenericas<Caixa>
    {
        public List<Caixa> CaixasCongregacao(int Idcongregacao)
        {
            try
            {
                using (Conexao con = new Conexao())
                {
                    return con.Caixa
                            .Where(c => c.IdCongregacao == Idcongregacao)
                            .ToList();
                }
            }
            catch (Exception c)
            {

                throw c;
            }
        }

        public List<CaixaUsuario> CaixaUsuarios(int UsuarioId)
        {
            try
            {
                using (Conexao con = new Conexao())
                {
                    return con.CaixaUsuario
                            .Where(c => c.IdUsuario == UsuarioId)
                            .ToList();
                }
            }
            catch (Exception c)
            {

                throw c;
            }
        }

    }
}
