using PayCore.DTO.EntityModel;
using PayCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.Repositories
{
    public class FlutterWaveRepository: Repository<Payment>, IFlutterWaveRepository
    {
        public FlutterWaveRepository(PayContext dbContext) : base(dbContext)
        {

        }
    }
}
