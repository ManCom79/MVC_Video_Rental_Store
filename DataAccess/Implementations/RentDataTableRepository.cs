using DataAccess.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class RentDataTableRepository : DataTableRepository<Rental>, IRentDataTableRepository
    {
    }
}
