using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class UsuariosCategoria
    {
        public int IdUsuarioCategoria { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public int IdEstadoUsuarioCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual EstadosUsuariosCategorias IdEstadoUsuarioCategoriaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
