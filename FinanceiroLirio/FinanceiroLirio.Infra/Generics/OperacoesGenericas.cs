using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FinanceiroLirio.Entidades;
using FinanceiroLirio.Infra.DataSource;

namespace FinanceiroLirio.Infra.Generics
{
    public abstract class OperacoesGenericas<TEntity>
        where TEntity : class
    {
        public virtual void Insert(TEntity obj)
        {
                try
                {
                    using (Conexao con = new Conexao())
                    {
                        con.Entry(obj).State = EntityState.Added;
                        con.SaveChanges();
                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
        }

        public virtual void Update(TEntity obj)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(obj).State = EntityState.Modified;
                con.SaveChanges();
            }
        }

        public virtual void Delete(TEntity obj)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(obj).State = EntityState.Deleted;
                con.SaveChanges();
            }
        }

        public virtual List<TEntity> All()
        {
            using (Conexao con = new Conexao())
            {
                return con.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity FindById(int id)
        {
            using (Conexao con = new Conexao())
            {
                return con.Set<TEntity>().Find(id);
            }
        }
    }
}
