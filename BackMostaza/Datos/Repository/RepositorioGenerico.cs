using Datos.Repository.DbContextMostaza;
using Datos.Repository.UnidadDeTrabajo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository
{

    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly DbMostazaContext dataContext;

        private DbSet<T> Dbset => dataContext.Set<T>();
        public IQueryable<T> Entities => Dbset;

        public RepositorioGenerico(DbMostazaContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<T>> ListarEntidadesAsync()
        {
            try
            {
                var entidades = await Dbset.ToListAsync();
                return entidades;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<T> EncontrarUnico(Expression<Func<T, bool>> Condition)
        {
            IQueryable<T> query = Dbset;
            try
            {
                var entidad = await query.FirstAsync(Condition);
                return entidad;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<T>> ListarEntidadesCondicionalesAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = Dbset;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public  bool RemoverEntidad(T entity)
        {
            try
            {
                Dbset.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> CrearEntidadAsync(T entidad)
        {
            var entityCreada = await Dbset.AddAsync(entidad);
            if (entityCreada != null)
                return entityCreada.Entity;
            else
                return null;
        }

    }
}
