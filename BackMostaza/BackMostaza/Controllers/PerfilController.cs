using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackMostaza.Models;
using Datos.Repository;
using Datos.Repository.DbContextMostaza;
using DatosLayer.Repository.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackMostaza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IRepositorioGenerico<Perfiles> repositorioGenericoPerfil;
        private readonly IUsuariorepositorio repositorioUsuario;


        public PerfilController(IRepositorioGenerico<Perfiles> repositorioGenericoPerfil,
            IUsuariorepositorio repositorioUsuario
            )
        {
            this.repositorioGenericoPerfil = repositorioGenericoPerfil;
            this.repositorioUsuario = repositorioUsuario;


        }
        [HttpGet("[action]/{idPerfil}")]
        public async Task<ActionResult<Perfiles>> GetPerfil(int idPerfil)
        {
            var perfiles= await repositorioGenericoPerfil.ListarEntidadesCondicionalesAsync(x => x.IdPerfil ==idPerfil);
            var perfil = perfiles.ToList().FirstOrDefault();
            return perfil;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Registrar([FromBody] Usuario usuarioModel)
        {
            var usuarioEntidad = new Usuarios();

            usuarioEntidad.IdTipoUsuario = 1;
            usuarioEntidad.IdEstadoUsuario = 1;
            usuarioEntidad.Correo = usuarioModel.Correo;
            usuarioEntidad.Contrasenia = usuarioModel.Contrasenia;
            var idUsuario = await repositorioUsuario.ModificarUsuarioAsync(usuarioEntidad);
            var perfilEntidad = new Perfiles
            {
                Nombre = usuarioModel.Nombre,
                Apellido = usuarioModel.Apellido,
                Telefono = usuarioModel.Celular,
                IdUsuario = idUsuario
            };
            var perfil = await repositorioGenericoPerfil.CrearEntidadAsync(perfilEntidad);
            return Ok(idUsuario);
        }
    }
}