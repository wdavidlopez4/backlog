using backlog.Domain.Entities;
using backlog.Domain.Ports;
using backlog.Infrastructure.BacklogContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace backlog.Infrastructure.Repositories
{
    public class RepositorySQLServer : IRepository
    {
        private readonly BacklogContextSqlServer context;

        public RepositorySQLServer(BacklogContextSqlServer backlogContextSqlServer)
        {
            this.context = backlogContextSqlServer;
        }


        public async Task<T> Get<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<List<T>> Gets<T>(Expression<Func<T, bool>> expressionConditional, CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                return await context.Set<T>()
                    .Where(expressionConditional)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : Entity
        {
            try
            {
                var entity = await context.Set<T>().AddAsync(obj, cancellationToken);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync(cancellationToken) < 0)
                    throw new Exception($"no se guardo la entidad en la db: {obj.GetType()}");

                return entity.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
