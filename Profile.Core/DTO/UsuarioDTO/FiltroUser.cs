using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Core.DTO.UsuarioDTO
{
    public class FiltroUser
    {
        public FiltroUser()
        {
            CantItem = 10;
            Page = 1;
        }
        public string Nombre { get; set; }
        /// <summary>
        /// Cantidad de registros que se mostrarán por página.
        /// </summary>
        public int CantItem { get; set; }
        /// <summary>
        /// Número de página desde la que se está pidiendo los datos
        /// </summary>
        public int Page { get; set; }
    }
}
