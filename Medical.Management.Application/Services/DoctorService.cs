using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Service;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Medical.Management.Application.Services
{
    public class DoctorService(SqlServerDbContext dbContext) : IDoctorService
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<DoctorViewModel> AddAsync(DoctorInputModel model)
        {
            var people = await _dbContext.Peoples.AddAsync(model.People.ToEntity());
            var doctor = await _dbContext.Doctors.AddAsync(model.ToEntity(people.Entity.Id));
            await _dbContext.SaveChangesAsync();

            return DoctorViewModel.FromEntity(doctor.Entity);
        }

        public async Task<DoctorViewModel> GetAsync(Guid id)
        {
            var doctor = await _dbContext.Doctors.Include(d => d.People).SingleOrDefaultAsync(d => d.Id.Equals(id))
                ?? throw new DoctorNotFoundException();

            return DoctorViewModel.FromEntity(doctor);
        }

        public async Task UpdateAsync(DoctorInputModel model, Guid id)
        {
            var doctor = _dbContext.Doctors
                .Include(d => d.People)
                .Where(d => d.Id.Equals(id));

            await doctor
                .ExecuteUpdateAsync(
                    setters =>
                    setters
                        .SetProperty(p => p.CrmRegistration, model.CrmRegistration)
                        .SetProperty(p => p.Specialty, model.Specialty)
                );

            var idPeople = doctor.First().People.Id;

            _dbContext.Peoples
                .Where(p => p.Id.Equals(idPeople))
                .ExecuteUpdate(
            setters =>
            setters
                    .SetProperty(p => p.Name, model.People.Name)
                    .SetProperty(p => p.LastName, model.People.LastName)
                    .SetProperty(p => p.BirthDate, model.People.BirthDate)
                    .SetProperty(p => p.Phone, model.People.Phone)
                    .SetProperty(p => p.Email, model.People.Email)
                    .SetProperty(p => p.Cpf, model.People.Cpf)
                    .SetProperty(p => p.BloodType, model.People.BloodType)
                );
        }
    }
}
