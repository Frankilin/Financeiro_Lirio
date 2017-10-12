using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Persistence;
using System.Web.Mvc;


namespace FinanceiroLirio.Regras
{
    public class GrupoUsuarioBusiness
    {

        public List<GrupoUsuario> TodoGrupoUsuario()
        {
            try
            {
               
                GrupoUsuarioRepository gur = new GrupoUsuarioRepository();

                List<GrupoUsuario>  gu = gur.All();

                if (gu == null)
                {
                    throw new Exception("Nenhum grupo usuário foi encontrado");
                }
                return gu;

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public SelectList ListaGrupoUsuarioDropdownList()
        {
            try
            {
                List<GrupoUsuario> tmp = this.TodoGrupoUsuario(); 

                var itens = new List<SelectListItem>();

                foreach (GrupoUsuario g in tmp)
                {
                    itens.Add(new SelectListItem { Value = g.IdGrupoUsuario.ToString(), Text = g.Descricao });
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
