using DataAccess.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class UserDataTableRepository : DataTableRepository<User>, IUserDataTableRepository
    {
        public UserDataTableRepository(VideoRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void LogUser(User user)
        {
            UserLogged.Id = user.Id;
            UserLogged.FullName = user.FullName;
            UserLogged.Email = user.Email;
            UserLogged.Password = user.Password;
            UserLogged.Age = user.Age;
            UserLogged.CardNumber = user.CardNumber;
            UserLogged.CreatedOn = user.CreatedOn;
            UserLogged.IsSubscriptionExpired = user.IsSubscriptionExpired;
            UserLogged.SubscriptionType = (Enums.SubscriptionTypeEnum)user.SubscriptionType;
        }
    }
}
