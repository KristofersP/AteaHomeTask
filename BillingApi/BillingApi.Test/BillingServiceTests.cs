using BillingApi.Core.Services;
using BillingApi.Database;
using BillingApi.Models;
using BillingApi.Service.Services.GatewayHandlers;
using BillingApi.Services;
using BillingApi.Services.Validators;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BillingApi.Test
{
    public class BillingServiceTests
    {
        private readonly IEnumerable<IPaymentGateway> _gatewayHandlers;
        protected readonly IBillingApiDbContext _context;
        public BillingServiceTests()
        {
            
        }

        [Fact]
        public void IsValid_PayementGatewayIsEmpty_ReturnFalse()
        {
            //Arrange
            var order = new Order();
            var validator = new PaymentGatewayValidator();

            order.Description = "";
            order.OrderNumber = 1;
            order.UserId = 1;
            order.PayableAmount = 5.4f;
            order.PaymentGateway = "";

            //Act
            var result = validator.IsValid(order);

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void IsValid_OrderIsNull_ReturnFalse()
        {
            //Arrange
            var order = new Order();
            var validator = new OrderValidator();

            //Act
            var result = validator.IsValid(order);

            //Assert
            Assert.True(result);

        }

        

       [Fact]
        public void AmazonPaymentGatewayHandler_PaymentGatewayIsamazonpay_ReturnsAmazonPay()
        {
            //Arrange
            var handler = new AmazonPaymentGatewayHandler();

            var order = new Order();
            order.Description = "Test order";
            order.OrderNumber = 1;
            order.UserId = 1;
            order.PayableAmount = 5.4f;
            order.PaymentGateway = "amazonpay";

            //Act
            var result = handler.GetGateway(order);


            //Assert
            Assert.Equal("amazonpay", result);
        }

        [Fact]
        public void PayPalPaymentGatewayHandler_PaymentGatewayIsEmpty_ReturnsEmpty()
        {
            //Arrange
            var handler = new PayPalGatewayHandler();

            var order = new Order();
            order.Description = "Test order";
            order.OrderNumber = 1;
            order.UserId = 1;
            order.PayableAmount = 5.4f;
            order.PaymentGateway = "";

            //Act
            var result = handler.GetGateway(order);


            //Assert
            Assert.Equal("", result);
        }
    }
}
