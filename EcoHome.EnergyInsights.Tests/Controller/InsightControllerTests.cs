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
    public class InsightControllerTests
    {
        private readonly Mock<IInsightService> _mockService;
        private readonly InsightController _controller;

        public InsightControllerTests()
        {
            _mockService = new Mock<IInsightService>();
            _controller = new InsightController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithInsights()
        {
            var insights = new List<InsightEntity>
            {
                new InsightEntity { Id = 1, Title = "Insight 1", Description = "Description 1" },
                new InsightEntity { Id = 2, Title = "Insight 2", Description = "Description 2" }
            };
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(insights);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<InsightEntity>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task Add_ShouldReturnCreatedResult()
        {
            var newInsight = new InsightEntity { Title = "New Insight", Description = "Description" };
            _mockService.Setup(s => s.AddAsync(newInsight)).Returns(Task.CompletedTask);

            var result = await _controller.Add(newInsight);

            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
