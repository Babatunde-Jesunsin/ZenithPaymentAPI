using PayCore.DTO.EntityModel;
using PayCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.Repositories
{
    public class UPRepository: Repository<Payment>, IUPRepository
    {
        public UPRepository(PayContext dbContext) : base(dbContext)
        {

        }
    }
}
