using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data {
    public interface IEntityRepository<T>{

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        
        T FindOne(Expression<Func<T, bool>> where = null);

        Task<T> FindOneAsync(Expression<Func<T, bool>> where = null);

        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        Task<T> GetSingleAsync(object key);


        void Edit(T entity);
        void Add(T entity);
        void Delete(T entity);

        void Save();

        Task SaveAsync();

    }
}
