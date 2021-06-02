using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayCore.DTO.ViewModel
{
    public class PaymentRequest
    {
        [Required(ErrorMessage = "ClintId is required")]
        public int ClintId { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, 99999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Purpose is required")]
        public string Purpose { get; set; }
        [Required(ErrorMessage = "AccountNumber is required")]
        public string AccountNumber { get; set; }
    }
}
