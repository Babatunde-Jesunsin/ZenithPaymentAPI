using AutoMapper;
using Microsoft.Extensions.Logging;
using PayCore.DTO.EntityModel;
using PayCore.DTO.ViewModel;
using PayCore.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.Manager
{
    //I am here
    public class PaymentManager : IPaymentManager
    {
        private readonly IFlutterWaveRepository _fWRepository;
        private readonly IUPRepository _uPRepository;
        private readonly ICPRepository _cPRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentManager> _logger;
        private readonly IQueryPaymentRepository _queryPaymentRepository;

        public PaymentManager(IFlutterWaveRepository fWRepository, IUPRepository uPRepository, ICPRepository cPRepository, IMapper mapper, ILogger<PaymentManager> logger, IQueryPaymentRepository queryPaymentRepository)
        {
            _fWRepository = fWRepository;
            _uPRepository = uPRepository;
            _cPRepository = cPRepository;
            _mapper = mapper;
            _logger = logger;
            _queryPaymentRepository = queryPaymentRepository;
        }
        public async Task<Payment> GetPayment(Guid id)
        {
            var res = new Payment();
            try
            {
    
                 res= await _queryPaymentRepository.GetByCondition(c=> c.PayRef ==id);

            }
            catch(Exception e)
            {
                _logger.LogError("GetPaymentError:", e);
            }
            return res;
        }

        public async Task<Guid> MakePayment(PaymentRequest paymentRequest)
        {
            Guid payRef = new Guid(DateTime.Now.ToString());
            try
            {                
                if (paymentRequest.Amount <= 200000)
                {
                    Payment payment = new Payment()
                    {
                        TimeStamp = DateTime.Now,
                        StatusCode = "01",
                        Message = "Pending",
                        PaymentGateway = "FW",
                        PayRef = payRef
                    };
                    payRef = payment.PayRef;
                    payment = _mapper.Map<Payment>(paymentRequest);
                    _logger.LogInformation("Add MakePayment: ", payment);
                     _fWRepository.Add(payment);
                }
                else if (paymentRequest.Amount > 200000 && paymentRequest.Amount <= 500000)
                {
                    Payment payment = new Payment()
                    {
                        TimeStamp = DateTime.Now,
                        StatusCode = "00",
                        Message = "Success",
                        PaymentGateway = "CP",
                        PayRef = new Guid(DateTime.Now.ToString())
                    };
                    payment = _mapper.Map<Payment>(paymentRequest);
                    _logger.LogInformation("Add MakePayment: ", payment);
                    _cPRepository.Add(payment);
                }
                else if (paymentRequest.Amount > 500000)
                {
                    Payment payment = new Payment()
                    {
                        TimeStamp = DateTime.Now,
                        StatusCode = "00",
                        Message = "Failed",
                        PaymentGateway = "UP",
                        PayRef = new Guid(DateTime.Now.ToString())
                    };
                    payment = _mapper.Map<Payment>(paymentRequest);
                    _logger.LogInformation("Add MakePayment: ", payment);
                    _uPRepository.Add(payment);
                }
                

            }catch(Exception e)
            {
                _logger.LogError("MakePayment Error: ", e);
            }
            return payRef;


        }
        
    }     

}
        
