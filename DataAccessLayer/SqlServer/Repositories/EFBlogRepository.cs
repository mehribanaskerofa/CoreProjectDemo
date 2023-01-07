using DataAccessLayer.SqlServer.Abstract;
using DataAccessLayer.SqlServer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SqlServer.Repositories
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
    }
}
