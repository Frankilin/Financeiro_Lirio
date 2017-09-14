﻿using FinanceiroLirio.Entidades;
using FinanceiroListio.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Regras
{
    public class CidadeBusiness 
    {
        public List<Cidade> CidadesPorEstado(int idEstado)
        {
            try
            {
                CidadeRepository cr = new CidadeRepository();
                
                if(idEstado == 0)
                {
                    throw new Exception("Selecione um estado.");
                }

                List<Cidade> c = cr.CidadePorEstado(idEstado);

                if(c == null)
                {
                    throw new Exception("Nenhuma cidade encontrada para este estado.");
                }

                return c;
            }  
            catch(Exception e)
            {
                throw e;
            }
        }

        public Cidade AcharCidadePorId(int idCidade)
        {
            try
            {
                CidadeRepository cr = new CidadeRepository();
                Cidade c = cr.FindById(idCidade);

                if (c == null)
                {
                    throw new Exception("Nenhuma cidade cadastrada.");
                }

                return c;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<Cidade> TodasCidades()
        {
            try
            {
                CidadeRepository cr = new CidadeRepository();

                List<Cidade> c = cr.All();

                if(c == null)
                {
                    throw new Exception("Nenhuma cidade cadastrada.");
                }

                return c;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
    }
}