using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.IRepository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
