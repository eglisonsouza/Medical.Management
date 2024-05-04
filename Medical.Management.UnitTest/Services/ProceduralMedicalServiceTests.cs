using Medical.Management.Application.Models.InputModels;
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
    public class ProceduralMedicalServiceTests
    {
        private readonly IProceduralMedicalRepository _repository;
        private readonly ProceduralMedicalService _service;

        public ProceduralMedicalServiceTests()
        {
            _repository = Substitute.For<IProceduralMedicalRepository>();
            _service = new ProceduralMedicalService(_repository);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnProceduralMedicalViewModel_WhenValidModelIsProvided()
        {
            // Arrange
            _repository.AddAsync(Arg.Any<ProceduralMedical>()).Returns(ProceduralMedicalMocks.GetProceduralMedicalEntity());

            // Act
            var result = await _service.AddAsync(ProceduralMedicalMocks.GetProceduralMedicalInputModel());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProceduralMedicalViewModel>(result);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldReturnListOfProceduralMedicalViewModel_WhenValidModelsAreProvided()
        {
            // Arrange
            var models = new List<ProceduralMedicalInputModel> { ProceduralMedicalMocks.GetProceduralMedicalInputModel() };

            // Act
            var result = await _service.AddRangeAsync(models);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProceduralMedicalViewModel>>(result);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnProceduralMedicalViewModel_WhenValidIdIsProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Returns(ProceduralMedicalMocks.GetProceduralMedicalEntity());

            // Act
            var result = await _service.GetAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProceduralMedicalViewModel>(result);
        }

        [Fact]
        public async Task GetByDoctorIdAsync_ShouldReturnListOfProceduralMedicalViewModel_WhenValidDoctorIdIsProvided()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            _repository.GetByDoctorIdAsync(doctorId).Returns(new List<ProceduralMedical>() { ProceduralMedicalMocks.GetProceduralMedicalEntity() });

            // Act
            var result = await _service.GetByDoctorIdAsync(doctorId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProceduralMedicalViewModel>>(result);
        }

        [Fact]
        public async Task Update_ShouldNotThrowException_WhenValidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new ProceduralMedicalInputModel();
            _repository.GetAsync(id).Returns(ProceduralMedicalMocks.GetProceduralMedicalEntity());

            // Act
            await _service.Update(model, id);

            // Assert
            _repository.Received(1).Update(Arg.Any<ProceduralMedical>());
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenInvalidIdAndModelAreProvided()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new ProceduralMedicalInputModel();
            _repository.GetAsync(id).ReturnsNull();

            // Act
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await _service.Update(model, id));
        }
    }

}
