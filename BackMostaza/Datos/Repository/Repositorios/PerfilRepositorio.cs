using Datos.Repository;
using Datos.Repository.DbContextMostaza;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer.Repository.Repositorios
{
    public class PerfilRepositorio : IPerfilRepositorio
    {
        private readonly IRepositorioGenerico<Perfiles> repositorio;
        private readonly DbMostazaContext dataContext;

        private bool disposed = false;
        public PerfilRepositorio(DbMostazaContext dataContext, IRepositorioGenerico<Perfiles> repositorio)
        {
            this.dataContext = dataContext;
            this.repositorio = repositorio;

        }
        public async Task<Perfiles> EncontrarPerfilPorIdUsuario(int idUsuario)
        {
            var perfilRepositorio = await repositorio.ListarEntidadesCondicionalesAsync(x => x.IdUsuario == idUsuario);
            return perfilRepositorio.FirstOrDefault();
        }
        public async Task<int> CrearPerfilAsync(Perfiles perfil)
        {
            var perfilRepositorio = await repositorio.CrearEntidadAsync(perfil);
            dataContext.SaveChanges();
            return perfilRepositorio.IdUsuario;
        }
        public async Task<int> ModificarUsuarioAsync(Perfiles perfil)
        {
            var perfilRepositorio = await repositorio.EncontrarUnico(x => x.IdUsuario == perfil.IdUsuario);
            perfilRepositorio.Nombre = perfil.Nombre;
            perfilRepositorio.Apellido = perfil.Apellido;
            perfilRepositorio.Telefono = perfil.Telefono;
            dataContext.Entry(perfilRepositorio).State = EntityState.Modified;
            try
            {
                dataContext.SaveChanges();
                var usuarioModificado = await repositorio.CrearEntidadAsync(perfil);
                return usuarioModificado.IdUsuario;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
