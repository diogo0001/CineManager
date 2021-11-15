using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Data
{
    public interface IRepository
    {
        // General
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
