using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Checkout;
using Amore.Business.Helpers.DTOs.Payment;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Amore.Business.Services.Implementations
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        //private readonly IPromoCodeRepository _promoCodeRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutService(
            IMapper mapper,
            ICheckoutRepository checkoutRepository,
            //IPromoCodeRepository promoCodeRepository,
            IPaymentService paymentService)
        {
            _mapper = mapper;
            _checkoutRepository = checkoutRepository;
            //_promoCodeRepository = promoCodeRepository;
            _paymentService = paymentService;
        }

        public async Task<GetCheckoutDto> ProcessPaymentAsync(CreateCheckoutDto dto)
        {
            decimal totalPrice = dto.TotalPrice;

            var paymentRequest = new PaymentRequestDto
            {
                Amount = totalPrice,
                Token = dto.PaymentToken,
                OrderId = dto.OrderId
            };

            var paymentResult = await _paymentService.ProcessPaymentAsync(paymentRequest);

            if (!paymentResult.IsSuccess)
            {
                throw new PaymentFailedException(paymentResult.ErrorMessage ?? "Ödəmə uğursuz oldu.");
            }

            var checkout = _mapper.Map<Checkout>(dto);
            checkout.TransactionId = paymentResult.TransactionId;

            var createdCheckout = await _checkoutRepository.CreateAsync(checkout);
            return _mapper.Map<GetCheckoutDto>(createdCheckout);
        }

    }
}
