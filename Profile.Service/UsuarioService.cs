using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Profile.Core.DTO.UsuarioDTO;
using Profile.Core.Model;
using Profile.Core.Repositories;
using Profile.Core.Service;
namespace Profile.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositories _usuarioRepositories;
        public UsuarioService(IUsuarioRepositories usuarioRepositories)
        {
            _usuarioRepositories = usuarioRepositories;
        }
        public async Task CrearEditarUsuarioAsync(Usuario user)
        {
            if (user.Codigo > 0)
            {
                Usuario seccionExiste = await _usuarioRepositories.GetUsuarioByCodigoAsync(user.Codigo, tracked: true);
            }
            else
            {
                await _usuarioRepositories.CrearEditarUsuarioAsync(user);
            }
            await _usuarioRepositories.SaveChangeAsync();
        }

        public async Task EliminarUsuarioAsync(int codigo)
        {
            await _usuarioRepositories.EliminarUsuarioAsync(codigo);
            await _usuarioRepositories.SaveChangeAsync();
        }

        public async Task<List<Usuario>> GetListaUsuariosAsync(FiltroUser filtro)
        {
            List<Usuario> userList = await _usuarioRepositories.GetListaUsuariosAsync(filtro);
            return userList;
        }

        public async Task<int> GetTotalResultadosAsync(FiltroUser filtro)
        {
            int cantidadResultado = await _usuarioRepositories.GetTotalResultadosAsync(filtro);
            return cantidadResultado;
        }

        public async Task<Usuario> GetUsuarioByCodigoAsync(int codigo)
        {
            Usuario user = await _usuarioRepositories.GetUsuarioByCodigoAsync(codigo);
            return user;
        }
    }
}
