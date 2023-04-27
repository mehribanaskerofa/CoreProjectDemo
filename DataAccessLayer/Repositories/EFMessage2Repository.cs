using DataAccessLayer.Abstract;
using DataAccessLayer.SqlServer.Concrete;
using DataAccessLayer.SqlServer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EFMessage2Repository:GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var c = new SqlServerContext())
            {
                return c.Message2s.Include(x => x.ReceiverUser).Where(y => y.SenderID == id).ToList();
            }
        }

        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            using (var c = new SqlServerContext())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
