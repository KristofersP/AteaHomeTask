using BillingApi.Core.Services;
using BillingApi.Database;
using BillingApi.Models;
using BillingApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BillingApi.Test
{
    public class BillingServiceTests
    {
        private readonly Mock<IBillingApiDbContext> _context = new Mock<IBillingApiDbContext>();
        private readonly BillingService _bill;

        public BillingServiceTests()
        {
            _bill = new BillingService(_context.Object);
        }

        [Fact]
        public void IsValid_PayementGatewayIsEmpty_ReturnFalse()
        {
            //Arrange
            var itemMock = new Mock<IValidator>();
            List<IValidator> validators = new List<IValidator> { itemMock.Object };
            var order = new Order();

            order.Description = "";
            order.OrderNumber = 1;
            order.UserId = 1;
            order.PayableAmount = 5.4f;
            order.PaymentGateway = "";
            //Act
            var result = validators.All(v => v.IsValid(order));
            //Assert
            Assert.False(result);

        }

        [Fact]
        public void IsValid_OrderIsNull_ReturnFalse()
        {
            //Arrange
            var itemMock = new Mock<IValidator>();
            List<IValidator> validators = new List<IValidator> { itemMock.Object };
            var order = new Order();

            //Act
            var result = validators.All(v => v.IsValid(order));

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void MapPaymentGateway_PaymentGatewayIspaypal_ReturnPayPal()
        {
            //Arrange
            var order = new Order();
            order.Description = "Test order";
            order.OrderNumber = 1;
            order.UserId = 1;
            order.PayableAmount = 5.4f;
            order.PaymentGateway = "paypal";

            var receipt = new Receipt();
            receipt.Description = order.Description;
            receipt.OrderNumber = 1;
            receipt.PaidAmount = order.PayableAmount;
            receipt.Date = DateTime.Now.ToString();

            _context.Setup(x => x.Receipts.Add(receipt));

            //Act
            var result = _bill.MapPayementGateway(order);

            //Assert
            Assert.Equal("PayPal", result.PaymentGateway);

        }


    }
}
