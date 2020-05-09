using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Articulos = new HashSet<Articulos>();
            Donaciones = new HashSet<Donaciones>();
            Perfiles = new HashSet<Perfiles>();
            Reservas = new HashSet<Reservas>();
            Solicitudes = new HashSet<Solicitudes>();
            UsuariosCategoria = new HashSet<UsuariosCategoria>();
        }

        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Token { get; set; }
        public int IdEstadoUsuario { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual EstadosUsuarios IdEstadoUsuarioNavigation { get; set; }
        public virtual TiposUsuarios IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Articulos> Articulos { get; set; }
        public virtual ICollection<Donaciones> Donaciones { get; set; }
        public virtual ICollection<Perfiles> Perfiles { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }
        public virtual ICollection<Solicitudes> Solicitudes { get; set; }
        public virtual ICollection<UsuariosCategoria> UsuariosCategoria { get; set; }
    }
}
