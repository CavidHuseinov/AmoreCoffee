using Amore.Business.Helpers.DTOs.Order;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var order = await _orderService.GetByIdAsync(id);
                return Ok(order);
            }
            catch(OrderNotFoundException ex)
            {
                throw new OrderNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromForm] CreateOrderDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            dto.AppUserId = userId;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Hesabınıza giriş edin sonra");

            //try
            //{
            var order = await _orderService.CreateAsync(dto);
            return Ok(new { message = "Sifariş yaradıldı", orderId = order.Id });
            //}
            //catch(OrderCannotBeCreate ex)
            //{
            //    throw new OrderCannotBeCreate(ex.Message);
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetUserOrders()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Hesabınıza giriş edin zəhmət olmasa");
            try
            {
                var orders = await _orderService.GetUserOrdersAsync(userId);
                return Ok(orders);
            }
            catch (OrderNotFoundException ex)
            {
                throw new OrderNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
