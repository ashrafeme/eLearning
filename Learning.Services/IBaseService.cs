using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Services {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public interface IBaseService<T> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        T Find(int id);

        Task<T> FindAsync(int id);

        Task SaveChangeAsync();

        void SaveChange();
    }
}
