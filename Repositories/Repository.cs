using CadstrarTarefasWebAPI.Data;
using CadstrarTarefasWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadstrarTarefasWebAPI.Repositories
{
    public class Repository : IRepository
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0 ;
        }

        public async Task<Tarefa> BuscarTarefaId(int id)
        {
            IQueryable<Tarefa> query = _context.Tarefas;

            query = query.AsNoTracking().OrderBy(t => t.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tarefa>> BuscarTarefas()
        {
            IQueryable<Tarefa> query = _context.Tarefas;

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> BuscarUsuarioId(int id)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
