using PayCore.DTO.EntityModel;
using PayCore.IRepositories;
using PayCore.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.Repositories
{
    public class CPRepository: Repository<Payment>, ICPRepository
    {
        public CPRepository(PayContext dbContext) : base(dbContext)
        {

        }
    }
}
