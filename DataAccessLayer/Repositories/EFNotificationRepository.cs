using DataAccessLayer.Abstract;
using DataAccessLayer.SqlServer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EFNotificationRepository:GenericRepository<Notification>, INotificationDal
    {

    }
}
