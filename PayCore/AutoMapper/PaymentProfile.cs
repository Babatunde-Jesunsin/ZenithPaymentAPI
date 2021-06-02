using AutoMapper;
using PayCore.DTO.EntityModel;
using PayCore.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayCore.AutoMapper
{
    public class PaymentProfile: Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentRequest, Payment >();
        }
    }
}
