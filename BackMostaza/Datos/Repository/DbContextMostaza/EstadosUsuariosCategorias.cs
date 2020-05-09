using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class EstadosUsuariosCategorias
    {
        public EstadosUsuariosCategorias()
        {
            UsuariosCategoria = new HashSet<UsuariosCategoria>();
        }

        public int IdEstadoUsuarioCategoria { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<UsuariosCategoria> UsuariosCategoria { get; set; }
    }
}
