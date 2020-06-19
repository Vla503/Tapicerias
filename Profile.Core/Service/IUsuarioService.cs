using Profile.Core.DTO.UsuarioDTO;
using Profile.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Core.Service
{
    public interface IUsuarioService
    {
        //meotodo para crear y editar los usuarios
        /// <param name="user">Modelo para obtener los usuarios</param>
        Task CrearEditarUsuarioAsync(Usuario user);

        //meotodo para crear y editar los usuarios
        /// <param name="user">Modelo para obtener los usuarios</param>
        Task<List<Usuario>> GetListaUsuariosAsync(FiltroUser filtro);

        //meotodo para crear y editar los usuarios
        /// <param name="user">Modelo para obtener los usuarios</param>
        Task<Usuario> GetUsuarioByCodigoAsync(int codigo);

        //meotodo para crear y editar los usuarios
        /// <param name="user">Modelo para obtener los usuarios</param>
        Task EliminarUsuarioAsync(int codigo);
        /// Metodo para obtener el total de resultados de la lista
        Task<int> GetTotalResultadosAsync(FiltroUser filtro);
    }
}
