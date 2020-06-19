using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profile.Core.DTO.UsuarioDTO;
using Profile.Core.Model;
using Profile.Core.Repositories;
using Profile.SQL;
namespace Profile.SQL.Repositories
{
    public class UsuarioRepositories : IUsuarioRepositories
    {
        private readonly ProfileContext _db;
        public UsuarioRepositories(DbContext db)
        {
            _db = db as ProfileContext;
        }
        public async Task CrearEditarUsuarioAsync(Usuario user)
        {
            await _db.Usuario.AddAsync(user);
        }

        public async Task EliminarUsuarioAsync(int codigo)
        {
            Usuario user = new Usuario() {Codigo = codigo };
            _db.Entry(user).State = EntityState.Deleted;
        }

        public async Task<List<Usuario>> GetListaUsuariosAsync(FiltroUser filtro, bool tracked = false)
        {
            IQueryable<Usuario> query;
            if (tracked)
                query = _db.Usuario;
            else
                query = _db.Usuario.AsNoTracking();

            Expression<Func<Usuario, bool>> where = GetWhere(filtro);
            query = query.Where(where)
                         .OrderBy(x => x.Nombre)
                         .Skip((filtro.Page - 1) * filtro.CantItem)
                         .Take(filtro.CantItem);

            List<Usuario> user = await query.ToListAsync().ConfigureAwait(false);
            return user;
        }
        private Expression<Func<Usuario, bool>> GetWhere(FiltroUser filtros)
        {
            Expression<Func<Usuario, bool>> where = x => ((string.IsNullOrEmpty(filtros.Nombre)) || (x.Nombre.Contains(filtros.Nombre)));
            return where;
        }
        public async Task<int> GetTotalResultadosAsync(FiltroUser filtro)
        {
            IQueryable<Usuario> query = _db.Usuario;
            Expression<Func<Usuario, bool>> where = GetWhere(filtro);
            int resultado = await query.CountAsync(where).ConfigureAwait(false);
            return resultado;
        }

        public async Task<Usuario> GetUsuarioByCodigoAsync(int codigo, bool tracked = false)
        {
            IQueryable<Usuario> query;

            if (tracked)
                query = _db.Usuario;
            else
                query = _db.Usuario.AsNoTracking();

            query = query.Where(x => x.Codigo == codigo);

            Usuario user = await query.FirstOrDefaultAsync().ConfigureAwait(false);
            return user;
        }

        public async Task SaveChangeAsync()
        {
            _db.SaveChanges();
        }
    }
}
