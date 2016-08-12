using Learning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Services {
   public class BaseService<T> : IBaseService<T> where T: Learning.Data.Entities.BaseEntity {

        private readonly IEntityRepository<T> baseRepository;

        public BaseService(IEntityRepository<T> baseRepository) {
            this.baseRepository = baseRepository;
        }
        public void Add(T entity) {
            baseRepository.Add(entity);
        }

        public void Delete(T entity) {
            baseRepository.Delete(entity);
        }

        public T Find(int id) {
            return baseRepository.FindOne(e => e.Id == id);
        }

        public async Task<T> FindAsync(int id) {
            return await baseRepository.FindOneAsync(e => e.Id == id);
        }

        public void SaveChange() {
            baseRepository.Save();
        }

        public async Task SaveChangeAsync() {
            await baseRepository.SaveAsync();
        }

        public void Update(T entity) {
            baseRepository.Edit(entity);
        }

       
    }
}
