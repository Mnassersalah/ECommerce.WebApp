using Microsoft.EntityFrameworkCore;
using Skinet.Core.Specificatios;

namespace Skinet.Infrastructure.Helpers
{
    public static class SpecificationsEvaluator
    {
        public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> specification)
        where T : class
        {
            ArgumentNullException.ThrowIfNull(specification);

            if (specification?.Criteria is not null)
            {
                query = query?.Where(specification.Criteria);
            }

            query = specification.Includes
                                 .Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
