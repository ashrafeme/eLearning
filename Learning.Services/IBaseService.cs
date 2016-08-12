using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Services {
   public interface IBaseService<T> {

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        T Find(int id);

        Task<T> FindAsync(int id);

        Task SaveChangeAsync();

        void SaveChange();
    }
}
