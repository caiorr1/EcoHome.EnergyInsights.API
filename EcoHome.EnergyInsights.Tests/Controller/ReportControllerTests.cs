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
    public class ReportControllerTests
    {
        private readonly Mock<IReportService> _mockService;
        private readonly ReportController _controller;

        public ReportControllerTests()
        {
            _mockService = new Mock<IReportService>();
            _controller = new ReportController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkWithReports()
        {
            var reports = new List<ReportEntity>
            {
                new ReportEntity { Id = 1, ReportType = "Type 1", Data = "Data 1" },
                new ReportEntity { Id = 2, ReportType = "Type 2", Data = "Data 2" }
            };
            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(reports);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ReportEntity>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}
