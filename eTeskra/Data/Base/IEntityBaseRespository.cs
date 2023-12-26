﻿using eTeskra.Models;

namespace eTeskra.Data.Base
{
    public interface IEntityBaseRespository<T> where T : class,IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
