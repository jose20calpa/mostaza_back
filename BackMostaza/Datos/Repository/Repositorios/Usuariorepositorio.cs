using Datos.Repository;
using Datos.Repository.DbContextMostaza;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatosLayer.Repository.Repositorios
{
    public class Usuariorepositorio : IDisposable, IUsuariorepositorio
    {

        private readonly IRepositorioGenerico<Usuarios> repositorio;
        private readonly DbMostazaContext dataContext;

        private bool disposed = false;
        public Usuariorepositorio(DbMostazaContext dataContext, IRepositorioGenerico<Usuarios> repositorio)
        {
            this.dataContext = dataContext;
            this.repositorio = repositorio;

        }
        public async Task <Usuarios> EncontrarUsuarioPorEmail(Usuarios usuario)
        {
            var usuarioRepositorio = await repositorio.ListarEntidadesCondicionalesAsync(x=> x.Correo == usuario.Correo);
            return usuarioRepositorio.FirstOrDefault(); 
        }
        public async Task<int> CrearUsuarioAsync(Usuarios usuario) {
            var usuarioRepositorio = await repositorio.CrearEntidadAsync(usuario);
            dataContext.SaveChanges();
            return usuarioRepositorio.IdUsuario;
        }
        public async Task<int> ModificarUsuarioAsync(Usuarios usuario)
        {
            var usuarioRepositorio = await repositorio.EncontrarUnico(x => x.Correo == usuario.Correo);
            usuarioRepositorio.Contrasenia = usuario.Correo;
            dataContext.Entry(usuarioRepositorio).State = EntityState.Modified;
            try
            {
                dataContext.SaveChanges();
                var usuarioModificado = await repositorio.CrearEntidadAsync(usuario);
                return usuarioModificado.IdUsuario;
            }
            catch(Exception ex)
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
