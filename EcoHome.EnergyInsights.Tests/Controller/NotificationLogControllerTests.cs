using EcoHome.EnergyInsights.API.Controllers;
using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EcoHome.EnergyInsights.Tests.Controllers
{
    public class NotificationLogControllerTests
    {
        private readonly Mock<INotificationLogService> _mockService;
        private readonly NotificationLogController _controller;

        public NotificationLogControllerTests()
        {
            _mockService = new Mock<INotificationLogService>();
            _controller = new NotificationLogController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithLogs()
        {
            var logs = new List<NotificationLogEntity>
            {
                new NotificationLogEntity { Id = 1, Message = "Log 1" },
                new NotificationLogEntity { Id = 2, Message = "Log 2" }
            };
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(logs);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<NotificationLogEntity>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}
