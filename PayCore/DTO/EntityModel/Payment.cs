using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.DTO.EntityModel
{
    public class Payment
    {
        public int Id { get; set; }
        public Guid PayRef { get; set; }
        public double Amount { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PaymentGateway { get; set; }
        public int ClintId { get; set; }
        public string Purpose { get; set; }
        public string AccountNumber { get; set; }
    }
}
