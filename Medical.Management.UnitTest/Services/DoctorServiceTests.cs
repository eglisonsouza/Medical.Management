using AutoMapper;
using Medical.Management.Application.Models.ViewModels;
using Medical.Management.Application.Services.Implementations;
using Medical.Management.Domain.Exceptions;
using Medical.Management.Domain.Models.Entities;
using Medical.Management.Domain.Repositories;
using Medical.Management.UnitTest.Mocks;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Smart.Essentials.Core.ResultDataModel;

namespace Medical.Management.UnitTests.Services
{
    public class DoctorServiceTests
    {
        private readonly IDoctorRepository _repository;
        private readonly DoctorService _service;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;

        public DoctorServiceTests()
        {
            _repository = Substitute.For<IDoctorRepository>();
            _mapper = Substitute.For<IMapper>();
            _notificationContext = new NotificationContext();
            _service = new DoctorService(_repository, _mapper, _notificationContext);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnDoctorViewModel_WhenValidModelIsProvided()
        {
            // Arrange
            _repository.AddAsync(Arg.Any<Doctor>()).Returns(DoctorMocks.GetDoctorEntity());
            _mapper.Map<DoctorViewModel>(Arg.Any<Doctor>()).Returns(DoctorMocks.GetDoctorViewModel());

            // Act
            var result = await _service.AddAsync(DoctorMocks.GetDoctorValidInputModel());

            // Assert
            _repository.Received(1).CpfIsExist(Arg.Any<string>());
            await _repository.Received(1).AddAsync(Arg.Any<Doctor>());
            Assert.NotNull(result);
            Assert.IsType<DoctorViewModel>(result);
            Assert.Empty(_notificationContext.Errors);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnDoctorViewModel_WhenInvalidModelIsProvided()
        {
            // Arrange
            _repository.AddAsync(Arg.Any<Doctor>()).Returns(DoctorMocks.GetDoctorEntity());
            _mapper.Map<DoctorViewModel>(Arg.Any<Doctor>()).Returns(DoctorMocks.GetDoctorViewModel());

            // Act
            var result = await _service.AddAsync(DoctorMocks.GetDoctorInvalidInputModel());

            // Assert
            _repository.Received(1).CpfIsExist(Arg.Any<string>());
            await _repository.Received(1).AddAsync(Arg.Any<Doctor>());
            Assert.Null(result);
            Assert.Empty(_notificationContext.Errors);
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
            _repository.Received(1).CpfIsExist(Arg.Any<string>());
            await _repository.Received(1).GetAsync(Arg.Any<Guid>());
            Assert.Null(result);
            Assert.NotEmpty(_notificationContext.Errors);
        }

        [Fact]
        public async Task UpdateAsync_ShouldNotThrowException_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(DoctorMocks.GetDoctorEntity());

            // Act
            await _service.UpdateAsync(DoctorMocks.GetDoctorValidInputModel(), id);

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
            await Assert.ThrowsAsync<DoctorNotFoundException>(async () => await _service.UpdateAsync(DoctorMocks.GetDoctorValidInputModel(), id));
        }
    }
}
