using Skinet.Core.Entities;
using System.Linq.Expressions;

namespace Skinet.Core.Specificatios
{
    public interface ISpecification<T>
    {
        Expression<Func<T?,bool>> Criteria { get; }
        List<Expression<Func<T?, object>>> Includes { get; }
    }
}
