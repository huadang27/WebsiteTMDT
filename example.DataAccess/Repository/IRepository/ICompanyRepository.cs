using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {

        void Update(Company obj);

    }
}
