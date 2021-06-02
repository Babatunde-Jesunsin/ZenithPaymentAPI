using PayCore.DTO.EntityModel;
using PayCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.Repositories
{
    public class QueryPaymentRepository: Repository<Payment>, IQueryPaymentRepository
    {
        public QueryPaymentRepository(PayContext payContext):base(payContext)
        {

        }
    }
}
