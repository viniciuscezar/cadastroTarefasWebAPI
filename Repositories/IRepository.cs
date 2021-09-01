using CadstrarTarefasWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadstrarTarefasWebAPI.Repositories
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Tarefa> BuscarTarefaId(int id);
        Task<IEnumerable<Tarefa>> BuscarTarefas();

        Task<IEnumerable<Usuario>> BuscarUsuarios();
        Task<Usuario> BuscarUsuarioId(int id);
    }
}
