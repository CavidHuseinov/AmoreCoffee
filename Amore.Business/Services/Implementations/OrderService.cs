using Amore.Business.Helpers.DTOs.Order;
using Amore.Business.Helpers.DTOs.Product;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Context;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Amore.Business.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReadRepository<Order> _readRepository;
        private readonly IMapper _mapper;
        private readonly AmoreDbContext _context;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IReadRepository<Order> readRepository, AmoreDbContext context)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _readRepository = readRepository;
            _context = context;
        }

        public async Task<IEnumerable<GetOrderDto>> GetAllAsync()
        {
            var orders = await _readRepository.GetAllAsync(
                include: query => query
                    .Include(o => o.OrderProducts).ThenInclude(op => op.Product));

            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }

        public async Task<GetOrderDto> GetByIdAsync(Guid id)
        {
            var order = await _readRepository.GetAllAsync(
                predicate: o => o.Id == id,
                include: query => query
                    .Include(o => o.OrderProducts).ThenInclude(op => op.Product));

            var result = order.FirstOrDefault();

            if (result == null) throw new OrderNotFoundException();

            return _mapper.Map<GetOrderDto>(result);
        }


        public async Task<GetOrderDto> CreateAsync(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            var createdOrder = await _orderRepository.CreateAsync(order);

            var products = await _context.Products
                .Where(product => dto.ProductIds.Contains(product.Id))
                .ToListAsync();

            if (products.Any())
            {
                createdOrder.OrderProducts = new Collection<OrderProduct>();
                foreach (Product product in products)
                {

                    createdOrder.OrderProducts.Add(new OrderProduct()
                    {
                        ProductId = product.Id,
                        OrderId = createdOrder.Id
                    });

                }

                await _orderRepository.UpdateAsync(createdOrder);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<GetOrderDto>(createdOrder);
        }




        public async Task<IEnumerable<GetOrderDto>> GetUserOrdersAsync(string userId)
        {
            var orders = await _orderRepository.GetUserOrdersAsync(userId);
            return _mapper.Map<IEnumerable<GetOrderDto>>(orders);
        }
    }
}
