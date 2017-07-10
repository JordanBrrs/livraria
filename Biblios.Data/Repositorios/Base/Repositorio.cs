using Biblios.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblios.Data.Repositorios.Base
{
    public abstract class Repositorio<TEntity> : IDisposable,
       IRepositorio<TEntity> where TEntity : class
    {
        ContextoBanco contexto = new ContextoBanco();
        public void Adicionar(TEntity obj)
        {
            contexto.Set<TEntity>().Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            contexto.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => contexto.Set<TEntity>().Remove(del));
        }

        public TEntity Find(params object[] key)
        {
            return contexto.Set<TEntity>().Find(key);
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return contexto.Set<TEntity>();
        }

        public int SalvarTodos()
        {
            return contexto.SaveChanges();
        }
    }
}
