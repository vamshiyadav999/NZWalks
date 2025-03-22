using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
          await dbContext.AddAsync(walk);
          await dbContext.SaveChangesAsync();
          return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingwalK = dbContext.Walks.FirstOrDefault(x => x.Id == id);

            if (existingwalK == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingwalK);
            dbContext.SaveChanges();
            return existingwalK;   
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetByIDAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }
            else
            {
                existingWalk.Name = walk.Name;
                existingWalk.Description = walk.Description;
                existingWalk.RegionID = walk.RegionID;
                existingWalk.DifficultyID = walk.DifficultyID;
                existingWalk.WalkImageUrl = walk.WalkImageUrl;

                await dbContext.SaveChangesAsync();

                return existingWalk;

            }
        }
    }
}
