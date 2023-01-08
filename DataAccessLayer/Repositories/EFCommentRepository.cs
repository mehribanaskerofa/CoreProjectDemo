using DataAccessLayer.SqlServer.Abstract;
using DataAccessLayer.SqlServer.Concrete;
using DataAccessLayer.SqlServer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SqlServer.Repositories
{
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var c = new SqlServerContext())
            {
                return c.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
