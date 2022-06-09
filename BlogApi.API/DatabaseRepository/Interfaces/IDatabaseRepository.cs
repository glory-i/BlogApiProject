using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.API.DatabaseRepository.Interfaces
{
    public interface IDatabaseRepository<TEntity> where TEntity: class
    {
        TEntity Get(int id);
        Task<IEnumerable<TEntity>> GetAll();

        void Insert(TEntity entity);
        void Update(TEntity entity);

        void Remove(TEntity entity, bool saveNow = true);

    }
}
