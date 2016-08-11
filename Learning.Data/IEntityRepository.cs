using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data {
    interface IEntityRepository<T>  where T : Entities.BaseEntity, new() {

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(object key);

        void Edit(T entity);
        void Add(T entity);
        void Delete(T entity);

        void Save();

    }
}
