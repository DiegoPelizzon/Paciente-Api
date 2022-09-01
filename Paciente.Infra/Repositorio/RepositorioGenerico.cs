using Microsoft.EntityFrameworkCore;
using Paciente.Dominio.IRepositorio;
using Paciente.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Infra.Repositorio
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        protected readonly BancoContext _banco;
        protected readonly DbSet<TEntity> DbSet;

        public RepositorioGenerico(BancoContext bancoContext)
        {
            _banco = bancoContext;
            DbSet = _banco.Set<TEntity>();
        }

        public List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Criar(TEntity entidade)
        {
            DbSet.Add(entidade);
        }

        public TEntity BuscarporId(int id)
        {
            return DbSet.Find(id);
        }

        public void Atualizar(TEntity entidade)
        {
            DbSet.Update(entidade);
        }

        public void Deletar(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SalvarOk()
        {
            return _banco.SaveChanges();
        }



        public void Dispose()
        {
            _banco.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
