using System;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Ekisa.Api.BotFetal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ekisa.Api.BotFetal.Configuration;
using Bitacora.Api.Interfaces;
using Bitacora.Api.Interfaces.Repositories;

namespace Ekisa.Api.BotFetal.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Attributes
        private readonly EkisaAppContext _context;
        #endregion

        #region Constructor
        public Repository(EkisaAppContext generalDbContext)
        {
            _context = generalDbContext;
        }
        #endregion

        #region Methods        
        public virtual Response GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {

                // Guarda una instancia del tipo genérico y devuelve una consulta
                var query = _context.Set<T>().AsNoTracking().AsQueryable();

                // Agrega propiedades de navegación especificadas en el delegado 
                if (query != null && includes != null)
                    query = includes(query);

                return new Response { IsSuccess = true, Message = "Ok", Result = query };
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }
        public virtual Response GetObjectByCondition(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            try
            {
                // Guarda una instancia del tipo genérico y devuelve una consulta
                var query = _context.Set<T>().AsNoTracking().AsQueryable();

                // Agrega propiedades de navegación especificadas en el delegado 
                if (query != null && includes != null)
                    query = includes(query);

                // Retorna una entidad filtrada por el predicado
                var result = query.Where(predicate).FirstOrDefault();

                return new Response { IsSuccess = true, Message = "Ok", Result = result };
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }
        public virtual Response GetAllObjectsByCondition(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null, bool isLoadingAll = true, int skip = 0, int take = 0)
        {
            try
            {
                // Guarda una instancia del tipo genérico y devuelve una consulta
                var query = _context.Set<T>().AsNoTracking().AsQueryable();

                // Agrega propiedades de navegación especificadas en el delegado 
                if (query != null && includes != null)
                    query = includes(query);

                var totalCount = query.Count();

                // Retorna una entidad filtrada por el predicado
                var result = query.Where(predicate);

                if (!isLoadingAll)
                {
                    if (skip >= 0)
                        result = result.Skip(skip);

                    if (take >= 0)
                        result = result.Take(take);

                }

                return new Response { IsSuccess = true, Message = "Ok", Result = result, MetaData = totalCount };
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }
        public virtual Response Create(T entity)
        {
            // Modifica el estado a "Added" y devuelve un objeto diferente dependiendo del resultado
            Response response;
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                var isCreated = _context.SaveChanges() > 0;

                if (isCreated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al guardar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public virtual Response CreateWithRelated(T entity)
        {
            // Guarda la entidad + las propiedades de navegación y devuelve un objeto diferente dependiendo del resultado
            Response response;
            try
            {
                _context.Add(entity);
                var isCreated = _context.SaveChanges() > 0;

                if (isCreated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al guardar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public Response CreateListWithRelated(IEnumerable<T> entity)
        {
            Response response;
            try
            {
                _context.AddRange(entity);
                var isCreated = _context.SaveChanges() > 0;

                if (isCreated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al guardar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public virtual Response Delete(T entity)
        {
            // Modifica el estado a "Deleted" y devuelve un objeto diferente dependiendo del resultado            
            Response response;
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                var isDeleted = _context.SaveChanges() > 0;

                if (isDeleted)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al eliminar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public virtual Response DeleteWithRelated(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            // Modifica el estado a "Deleted" y devuelve un objeto diferente dependiendo del resultado            
            Response response;
            try
            {
                response = GetObjectByCondition(predicate, includes);

                if (response.IsSuccess)
                {
                    _context.Remove(response.Result);
                    var isDeleted = _context.SaveChanges() > 0;
                    if (isDeleted)
                        response = new Response { IsSuccess = true, Message = "Ok", Result = response.Result };
                    else
                        response = new Response { IsSuccess = false, Message = $"Error al eliminar el registro {response.Result}" };
                }


                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public virtual Response Update(T entity)
        {
            // Modifica el estado a "Modified" y devuelve un objeto diferente dependiendo del resultado
            Response response;
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                var isCreated = _context.SaveChanges() > 0;

                if (isCreated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al guardar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }
        public virtual Response UpdateWithRelated(T entity)
        {
            // Modifica el estado a "Modified" y devuelve un objeto diferente dependiendo del resultado
            Response response;
            try
            {

                _context.Update(entity);
                var isUpdated = _context.SaveChanges() > 0;

                if (isUpdated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al actualizar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }





        public Response UpdateListWithRelated(IEnumerable<T> entity)
        {
            Response response;
            try
            {
                _context.UpdateRange(entity);
                var isUpdated = _context.SaveChanges() > 0;

                if (isUpdated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al actualizar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public async Task<Response> TruncateEntity(dynamic entity)
        {
            Response response;
            try
            {
                _context.RemoveRange(entity);
                var isDeleted = await _context.SaveChangesAsync() > 0;
                if (isDeleted)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = true, Message = $"No se encontraron registros" };



                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }



        async Task<Response> IRepository<T>.DeleteById(dynamic id)
        {

            // Guarda una instancia del tipo genérico y devuelve una consulta
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
                return entity;
            _context.Set<T>().Remove(entity);
            var isDeleted = await _context.SaveChangesAsync() > 0;

            if (isDeleted)
                return new Response { IsSuccess = true, Message = "Ok", Result = entity };
            else
                return new Response { IsSuccess = false, Message = $"Error al eliminar el registro" };
        }

        public Response UpdateSpecificProperties(T entity, params string[] properties)
        {
            //_context.Set<T>().Attach(entity);
            var entry = _context.Entry(entity);

            foreach (string name in properties)
            {
                entry.Property(name).IsModified = true;
            }

            var isUpdate = _context.SaveChanges() > 0;
            if (isUpdate)
                return new Response { IsSuccess = true, Message = "Estado actualizado", Result = entity };

            return new Response { IsSuccess = false, Message = "Error al actualizar estado", Result = null };
        }

        public Response FindAllByConditionInclude(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            try
            {
                var result = _context.Set<T>().AsNoTracking().AsQueryable().Where(predicate);
                foreach (string item in includes)
                {

                    result = result.Include(item).AsQueryable();
                }

                return new Response { IsSuccess = true, Message = "Ok", Result = result };
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        public Response FindOneByConditionInclude(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            try
            {
                var result = _context.Set<T>().AsNoTracking().AsQueryable().Where(predicate);
                foreach (string item in includes)
                {

                    result = result.Include(item).AsQueryable();
                }

                return new Response { IsSuccess = true, Message = "Ok", Result = result.FirstOrDefault() };
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }

        //public Response GetAllPaginateFilter(Expression<Func<T, bool>> predicate, int take = 5, int page = 1, string[] filter = null, params string[] includes)
        //{
        //    try
        //    {

        //        // Guarda una instancia del tipo genérico y busca por el predicado (el valor de la propiedad debe ser igual) Ejemplo : "IdCurso=1"
        //        var result = _context.Set<T>().AsNoTracking().AsQueryable().Where(predicate);

        //        // Agrega los include de la entidad
        //        foreach (string item in includes)
        //        {
        //            result = result.Include(item).AsQueryable();
        //        }

        //        // Filtrar de manera sensitiva por la propiedad enviada en Filter buscando la ocurrencia del valor

        //        IQueryable<T> filterResult = null;

        //        var withFilter = filter.Length > 0;

        //        if (withFilter)
        //        {
        //            var filterProperty = filter[0];
        //            var filterValue = filter[1];

        //            filterResult = result
        //            .Where(x => x.GetType().GetProperty(filterProperty).GetValue(x, null).ToString().ToUpper().IndexOf(filterValue.ToUpper()) > -1);
        //        }


        //        double totalRegistros = withFilter ? filterResult.Count() : result.Count();
        //        double totalPaginas = Math.Ceiling(totalRegistros / take);

        //        var paginateResult = withFilter ? filterResult.Skip((page - 1) * take).Take(take) : result.Skip((page - 1) * take).Take(take);


        //        return new Response { IsSuccess = true, Message = "Ok", Result = paginateResult, MetaData = new Paginacion { TotalItems = totalRegistros, TotalPage = totalPaginas } };
        //    }
        //    catch (Exception exception)
        //    {
        //        return ExceptionResponse.Exception(exception);
        //    }
        //}

        public async Task<Response> UpdateAsync(T entity)
        {
            // Modifica el estado a "Modified" y devuelve un objeto diferente dependiendo del resultado
            Response response;
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                var isCreated = await _context.SaveChangesAsync() > 0;

                if (isCreated)
                    response = new Response { IsSuccess = true, Message = "Ok", Result = entity };
                else
                    response = new Response { IsSuccess = false, Message = $"Error al guardar el registro {entity}" };

                return response;
            }
            catch (Exception exception)
            {
                return ExceptionResponse.Exception(exception);
            }
        }
        #endregion
    }
}
