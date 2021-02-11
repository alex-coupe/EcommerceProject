using CheckoutService.Interfaces;
using CheckoutService.Models;
using Gateway.DataTransfer.CheckoutService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutServiceController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IInventoryService _inventoryService;
        public CheckoutServiceController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IInventoryService inventoryService )
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _inventoryService = inventoryService;
        }

        [HttpPost]
        [Route("v1/Checkout")]
        public async Task<ActionResult<OrderConfirmationTransferObject>> Checkout(CheckoutTransferObject checkoutTransferObject)
        {
            var stockSecured = await _inventoryService.Post(checkoutTransferObject);

            if (stockSecured)
            {
                var order = new Order
                {
                    CardType = checkoutTransferObject.PaymentInfo.CardType,
                    CardLastFourDigits = checkoutTransferObject.PaymentInfo.CardNumber.Skip(12).ToString(),
                    City = checkoutTransferObject.Customer.Address.City,
                    FirstLine = checkoutTransferObject.Customer.Address.FirstLine,
                    SecondLine = checkoutTransferObject.Customer.Address.SecondLine,
                    FirstName = checkoutTransferObject.Customer.FirstName,
                    LastName = checkoutTransferObject.Customer.LastName,
                    EmailAddress = checkoutTransferObject.Customer.EmailAddress,
                    State = checkoutTransferObject.Customer.Address.State,
                    PostalCode = checkoutTransferObject.Customer.Address.PostalCode,
                    DeliveryCost = checkoutTransferObject.DeliveryCost,
                    DeliveryTax = checkoutTransferObject.DeliveryTax,
                    Total = checkoutTransferObject.Total
                };
                _orderRepository.Create(order);
                await _orderRepository.SaveChanges();
                _orderItemRepository.Create(checkoutTransferObject.Cart, order.Id);
                await _orderItemRepository.SaveChanges();

                var orderConfirmation = new OrderConfirmationTransferObject
                {
                    DeliveryCost = order.DeliveryCost,
                    DeliveryTax = order.DeliveryTax,
                    Id = order.Id,
                    OrderDate = DateTime.Now,
                    OrderItems = checkoutTransferObject.Cart.CartItems,
                    Total = order.Total
                };
                return Ok(orderConfirmation);
            }
            return BadRequest();


        }
    }
}
