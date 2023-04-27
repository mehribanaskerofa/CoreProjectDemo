using DataAccessLayer.Abstract;
using DataAccessLayer.SqlServer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class EFAdminRepository : GenericRepository<Admin>, IAdminDal
    {
    }
}
