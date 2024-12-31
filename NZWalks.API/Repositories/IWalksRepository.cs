using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<Walk> CreateAsync(Walk newWalk);

        Task<List<Walk>> GetAllAsync();
    }
}
