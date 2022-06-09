using BlogApi.API.Authentication;
using BlogApi.API.DatabaseRepository.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.DatabaseRepository.Implementations
{
    public class DatabaseRepository<TEntity> : IDatabaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;
        private readonly DbContext _context;
       
        public DatabaseRepository(DbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
            
        }

        

        public TEntity Get(int id)
        {
            
            return DbSet.Find(id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
            //throw new NotImplementedException();
        }

        public async void Insert(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            //await _context.SaveChangesAsync();
            //return entity;
            //await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public virtual void Remove(TEntity entity, bool saveNow = true)
        {
            ((DbContext)_context).Entry(entity).State = EntityState.Deleted;
            if (saveNow)
                _context.SaveChanges();

        }

        public void Update(TEntity entity)
        {
            //await Task.FromResult(DbSet.Update(entity));
            //await _context.SaveChangesAsync();
            //return entity;
            _context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            //throw new NotImplementedException();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
