using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {

        void Update(ApplicationUser applicationUser);

    }
}
