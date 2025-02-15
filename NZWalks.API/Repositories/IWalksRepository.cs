﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<Walk> CreateAsync(Walk newWalk);

        Task<List<Walk>> GetAllAsync(string? filterOn = null,string? filterQuery = null,
                                    string? sortBy = null, 
                                    bool isAscending = true,
                                    int pageNumber = 1,
                                    int pageSize = 1000);

        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id,Walk walk);

        Task<Walk?> Delete(Guid id);
    }
}
