using PayCore.DTO.EntityModel;
using PayCore.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.Manager
{
    public interface IPaymentManager
    {
        Task<Payment> GetPayment(Guid id);
        Task<Guid> MakePayment(PaymentRequest paymentRequest);

    }
}
