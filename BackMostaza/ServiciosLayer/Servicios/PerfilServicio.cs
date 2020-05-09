using Datos.Repository.DbContextMostaza;
using DatosLayer.Repository.Repositorios;
using ServiciosLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosLayer.Servicios
{
    public class PerfilServicio
    {
        private readonly IUsuariorepositorio usuariorepositorio;
        private readonly IPerfilRepositorio perfilRepositorio;
        public PerfilServicio(IUsuariorepositorio usuariorepositorio, IPerfilRepositorio perfilRepositorio)
        {
            this.usuariorepositorio = usuariorepositorio;
            this.perfilRepositorio = perfilRepositorio;

        }

        public async Task CrearPerfilAsync(PerfilModel perfilModel)
        {
            var usuarioEntidad = new Usuarios
            {
                IdTipoUsuario = 1,
                IdEstadoUsuario = 1,
                Correo = perfilModel.Correo,
                Contrasenia = perfilModel.Contrasenia
            };
            var idUsuario = await usuariorepositorio.CrearUsuarioAsync(usuarioEntidad);

            var perfilEntidad = new Perfiles
            {
                Nombre = perfilModel.Nombre,
                Apellido = perfilModel.Apellido,
                Telefono = perfilModel.Telefono,
                IdUsuario = idUsuario
            };
            var perfil = await perfilRepositorio.CrearPerfilAsync(perfilEntidad);
        }
        public void ActualizarPerfil()
        {

        }
    }
}
