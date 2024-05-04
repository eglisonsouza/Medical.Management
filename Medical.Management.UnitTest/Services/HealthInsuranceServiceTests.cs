using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Implementations;
using Medical.Management.Domain.Exceptions;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Medical.Management.UnitTest.Mocks;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Medical.Management.UnitTest.Services
{
    public class HealthInsuranceServiceTests
    {
        private readonly IHealthInsuranceRepository _repository;
        private readonly HealthInsuranceService _service;

        public HealthInsuranceServiceTests()
        {
            _repository = Substitute.For<IHealthInsuranceRepository>();
            _service = new HealthInsuranceService(_repository);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnHealthInsuranceViewModel_WhenValidModelIsProvided()
        {
            // Arrange
            var model = HealthInsuranceMocks.GetHealthInsuranceInputModel();
            _repository.AddAsync(Arg.Any<HealthInsurance>()).Returns(HealthInsuranceMocks.GetHealthInsuranceEntity());

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<HealthInsuranceViewModel>(result);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnHealthInsuranceViewModel_WhenValidIdIsProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(HealthInsuranceMocks.GetHealthInsuranceEntity());

            // Act
            var result = await _service.GetAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<HealthInsuranceViewModel>(result);
        }

        [Fact]
        public async Task GetAsync_ShouldThrowException_WhenInvalidIdIsProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).ReturnsNull();

            // Act
            await Assert.ThrowsAsync<HealthInsuranceNotFoundException>(async () => await _service.GetAsync(id));
        }

        [Fact]
        public void GetAll_ShouldReturnListOfHealthInsuranceViewModel()
        {
            // Arrange
            _repository.GetAll().Returns(new List<HealthInsurance>());

            // Act
            var result = _service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<HealthInsuranceViewModel>>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldNotThrowException_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = HealthInsuranceMocks.GetHealthInsuranceInputModel();
            _repository.GetAsync(id).Returns(HealthInsuranceMocks.GetHealthInsuranceEntity());

            // Act
            await _service.UpdateAsync(model, id);

            _repository.Received(1).Update(Arg.Any<HealthInsurance>());
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenInvalidIdAndModelAreProvided()
        {

            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).ReturnsNull();

            // Act
            await Assert.ThrowsAsync<HealthInsuranceNotFoundException>(async () => await _service.UpdateAsync(HealthInsuranceMocks.GetHealthInsuranceInputModel(), Guid.NewGuid()));
        }



        [Fact]
        public void Remove_ShouldNotThrowException_WhenRemoveIdIsProvided()
        {
            var id = Guid.NewGuid();
            _service.Remove(id);

            _repository.Received(1).Remove(id);
        }
    }
}
