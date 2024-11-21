using EcoHome.EnergyInsights.Application.Services;
using EcoHome.EnergyInsights.Domain.Interfaces;
using EcoHome.EnergyInsights.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EcoHome.EnergyInsights.Tests 
{

    public class EnergySavingTipServiceTests
    {
        private readonly Mock<IEnergySavingTipRepository> _mockRepository;
        private readonly EnergySavingTipService _service;

        public EnergySavingTipServiceTests()
        {
            _mockRepository = new Mock<IEnergySavingTipRepository>();
            _service = new EnergySavingTipService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllTips()
        {
            var tips = new List<EnergySavingTipEntity>
            {
                new EnergySavingTipEntity { Id = 1, Title = "Tip 1", Description = "Description 1", IsActive = true },
                new EnergySavingTipEntity { Id = 2, Title = "Tip 2", Description = "Description 2", IsActive = false }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tips);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.ToList().Count);
            Assert.Equal("Tip 1", result.First().Title);
        }

        [Fact]
        public async Task AddAsync_ShouldInvokeRepositoryMethod()
        {
            var newTip = new EnergySavingTipEntity { Title = "New Tip", Description = "New Description", IsActive = true };

            await _service.AddAsync(newTip);

            _mockRepository.Verify(repo => repo.AddAsync(newTip), Times.Once);
        }
    }
}
