using backlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace backlog.Domain.Ports
{
    public interface IRepository
    {
        /// <summary>
        /// guardar entidades
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// retornar una entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Get<T>(Expression<Func<T,bool>> expression, CancellationToken cancellationToken) where T : Entity;

        /// <summary>
        /// retonar una lista de objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressionConditional"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> Gets<T>(Expression<Func<T, bool>> expressionConditional, CancellationToken cancellationToken) where T : Entity;
    }
}
