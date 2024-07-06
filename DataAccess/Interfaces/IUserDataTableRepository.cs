using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserDataTableRepository : IDataTableRepository<User>
    {
        public void LogUser(User user);
    }
}
