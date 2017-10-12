using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Regras
{
    public class EstadoBusiness
    {
        public List<Estado> ListaEstados()
        {
            try
            {
                EstadoRepository er = new EstadoRepository();
                
                return er.All();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Estado AcharEstadoPorId(int idEstado)
        {
            try
            {
                EstadoRepository er = new EstadoRepository();

                return er.FindById(idEstado);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
