using WebApiChallengeCQRS.Models;
using WebApiChallengeCQRS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
using System.Security.Cryptography;

namespace WebApiChallengeCQRS.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly DbContextClass _dbContext;

        public PermissionsRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permissions> AddPermissionAsync(Permissions permissions)
        {
            var result = _dbContext.Permissions.Add(permissions);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Permissions>> GetPermissionsListAsync()
        {
            return await _dbContext.Permissions.ToListAsync();
        }

        public async Task<int> UpdatePermissionAsync(Permissions permissions)
        {
            _dbContext.Permissions.Update(permissions);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<Permissions> GetPermissionsByIdAsync(int Id)
        {
            return await _dbContext.Permissions.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
