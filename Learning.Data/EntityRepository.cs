using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data {
    class EntityRepository<T> : IEntityRepository<T>
        where T : Entities.BaseEntity, new() {

        readonly DbContext dbContext;

        public EntityRepository(DbContext db) {
            if (db == null)
               throw new ArgumentNullException("dbContext");
            dbContext = db;
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

        public T GetSingle(object key) {
            return GetAll().FirstOrDefault(x => x.Id == (int)key);
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
    }
}
