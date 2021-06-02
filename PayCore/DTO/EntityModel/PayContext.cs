using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.DTO.EntityModel
{
    public class PayContext:DbContext
    {
        public PayContext(DbContextOptions option):base(option) { }
        public DbSet<Payment> Payment { get; set; }


    }
}
