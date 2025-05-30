﻿using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk> GetByIDAsync(Guid id);
        Task<Walk> UpdateAsync(Guid id, Walk walk);
        Task <Walk?> DeleteAsync(Guid id);
    }
}
