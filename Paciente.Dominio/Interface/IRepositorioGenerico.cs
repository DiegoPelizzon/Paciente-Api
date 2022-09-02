using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paciente.Dominio.IRepositorio
{
    public interface IRepositorioGenerico<TEntity>:IDisposable where TEntity:class
    {
        public List<TEntity> ObterTodos();

        public void Criar(TEntity entidade);

        public TEntity BuscarporId(int id);

        public void Atualizar(TEntity entidade);

        public void Deletar(int id);

        public int SalvarOk();


    }
}
