using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Generics;
using FinanceiroLirio.Infra.DataSource;

namespace FinanceiroLirio.Infra.Persistence
{
    public class GrupoUsuarioRepository : OperacoesGenericas<GrupoUsuario>
    {

        public List<GrupoUsuario> ListaGrupoUsuario(int IdGrupoUsuario)
        {
            try
            {
                using (Conexao con = new Conexao())
                {
                    return con.GrupoUsuario
                                .Where(g => g.IdGrupoUsuario == IdGrupoUsuario)
                                .ToList();
               }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public override List<GrupoUsuario> All()
        {
            try
            {
                using (Conexao con = new Conexao())
                {
                    return con.GrupoUsuario
                            .OrderBy(g => g.Descricao)
                            .ToList();
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        
    }
}
