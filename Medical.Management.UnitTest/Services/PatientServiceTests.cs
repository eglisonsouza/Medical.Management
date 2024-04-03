using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Implementations;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Repositories;
using Medical.Management.UnitTest.Mocks;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Medical.Management.UnitTest.Services
{
    public class PatientServiceTests
    {
        private readonly IPatientRepository _repository;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _repository = Substitute.For<IPatientRepository>();
            _service = new PatientService(_repository);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnPatientViewModel_WhenValidModelIsProvided()
        {
            // Arrange
            _repository.AddAsync(Arg.Any<People>()).Returns(PeopleMocks.GetPeopleEntity());
            _repository.AddAsync(Arg.Any<Patient>()).Returns(PatientMocks.GetPatientEntity());

            // Act
            var result = await _service.AddAsync(PatientMocks.GetPatientInputModel());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PatientViewModel>(result);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnPatientViewModel_WhenValidIdIsProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(PatientMocks.GetPatientEntity());

            // Act
            var result = await _service.GetAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PatientViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenInvalidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).ReturnsNull();

            // Act
            await Assert.ThrowsAsync<PatientNotFoundException>(async () => await _service.UpdateAsync(PatientMocks.GetPatientInputModel(), id));
        }

        [Fact]
        public async Task UpdateAsync_ShouldNotThrowException_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(PatientMocks.GetPatientEntity());

            // Act
            await _service.UpdateAsync(PatientMocks.GetPatientInputModel(), id);

            await _repository.Received(1).UpdateAsync(Arg.Any<Patient>());
        }
    }

}
