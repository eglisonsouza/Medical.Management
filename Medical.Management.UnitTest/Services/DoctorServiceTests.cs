using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Implementations;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Repositories;
using Medical.Management.UnitTest.Mocks;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Medical.Management.UnitTests.Services
{
    public class DoctorServiceTests
    {
        private readonly IDoctorRepository _repository;
        private readonly DoctorService _service;

        public DoctorServiceTests()
        {
            _repository = Substitute.For<IDoctorRepository>();
            _service = new DoctorService(_repository);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnDoctorViewModel_WhenValidModelIsProvided()
        {
            // Arrange
            _repository.AddAsync(Arg.Any<People>()).Returns(PeopleMocks.GetPeopleEntity());
            _repository.AddAsync(Arg.Any<Doctor>()).Returns(DoctorMocks.GetDoctorEntity());

            // Act
            var result = await _service.AddAsync(DoctorMocks.GetDoctorInputModel());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DoctorViewModel>(result);
            await _repository.Received(1).AddAsync(Arg.Any<People>());
            await _repository.Received(1).AddAsync(Arg.Any<Doctor>());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnDoctorViewModel_WhenValidIdIsProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(DoctorMocks.GetDoctorEntity());

            // Act
            var result = await _service.GetAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DoctorViewModel>(result);
            await _repository.Received(1).GetAsync(Arg.Any<Guid>());
        }

        [Fact]
        public async Task UpdateAsync_ShouldNotThrowException_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(DoctorMocks.GetDoctorEntity());

            // Act
            await _service.UpdateAsync(DoctorMocks.GetDoctorInputModel(), id);

            // Assert
            await _repository.Received(1).GetAsync(Arg.Any<Guid>());
            await _repository.Received(1).UpdateAsync(Arg.Any<Doctor>()); ;
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).ReturnsNull();

            // Act
            await Assert.ThrowsAsync<DoctorNotFoundException>(async () => await _service.UpdateAsync(DoctorMocks.GetDoctorInputModel(), id));
        }
    }
}
