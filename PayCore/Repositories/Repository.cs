using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayCore.DTO.EntityModel;
using PayCore.IRepository;

namespace PayCore.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PayContext _dbContext;

        public Repository(PayContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }
        public async Task<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);

        }
    }
}
