using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Learning.Data.Entities;

namespace Learning.Data {
    public class EntityRepository<T, TContext> : IEntityRepository<T>
        where T : Entities.BaseEntity, new()
        where TContext : DbContext{

        protected readonly TContext dbContext;

        public EntityRepository(DbContext db) {
            if (db == null)
               throw new ArgumentNullException("dbContext");
            dbContext = db as TContext;
        }

        public IQueryable<T> All {
            get {
                return GetAll();
            }
        }

        public void Add(T entity) {
           var dbEntity = dbContext.Entry<T>(entity);
            entity.CreatedDate = DateTime.Now;
            dbContext.Set<T>().Add(entity);
           
        }

        public void Delete(T entity) {
            var dbEntity = dbContext.Entry<T>(entity);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            dbEntity.State = EntityState.Modified;
        }

        public void Edit(T entity) {
            var dbEntity = dbContext.Entry<T>(entity);
            entity.UpdatedDate = DateTime.Now;
            dbEntity.State = EntityState.Modified;
            
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) {
            return dbContext.Set<T>().Where(predicate);
           
        }

        public IQueryable<T> GetAll() {
            return FindBy(ee=>ee.IsActive==true);
        }

        public async Task<T> GetSingleAsync(object key) {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == (int)key);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties) {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var item in includeProperties) {
                query.Include(item);
            }
            return query;
        }

        public void Save() {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync() {
           await dbContext.SaveChangesAsync();
        }

        public T FindOne(Expression<Func<T, bool>> where = null) {
            return FindBy(where).FirstOrDefault();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> where = null) {
            return await FindBy(where).FirstOrDefaultAsync();
        }

    }
}
