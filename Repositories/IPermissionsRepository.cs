using WebApiChallengeCQRS.Models;

namespace WebApiChallengeCQRS.Repositories
{
    public interface IPermissionsRepository
    {
        public Task<Permissions> AddPermissionAsync(Permissions permissions);
        public Task<List<Permissions>> GetPermissionsListAsync();
        public Task<int> UpdatePermissionAsync(Permissions permissions);
        public Task<Permissions> GetPermissionsByIdAsync(int Id);
    }
}
