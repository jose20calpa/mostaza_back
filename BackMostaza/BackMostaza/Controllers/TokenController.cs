using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackMostaza.Models;
using Datos.Repository;
using Datos.Repository.DbContextMostaza;
using DatosLayer.Repository.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackMostaza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsuariorepositorio repositorioUsuarios;
        private readonly IRepositorioGenerico<EstadosUsuarios> repositorioGenericoEstadosUsuario;

        public TokenController(IUsuariorepositorio repositorioUsuarios, IRepositorioGenerico<EstadosUsuarios> repositorioGenericoEstadosUsuario)
        {
            this.repositorioUsuarios = repositorioUsuarios;
            this.repositorioGenericoEstadosUsuario = repositorioGenericoEstadosUsuario;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuario = new Usuarios()
            {
                Correo = "chavo@test.com"
            };
            var user = await repositorioUsuarios.EncontrarUsuarioPorEmail(usuario);

            return Ok(user);
        }

        [HttpGet("[Action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetEstados()
        {
            var estados = await repositorioGenericoEstadosUsuario.ListarEntidadesAsync();

            return Ok(estados);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Usuario usuario)
        {

            return Ok ("asdasd");
        }

    }
}