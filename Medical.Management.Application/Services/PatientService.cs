using Medical.Management.Domain.Arguments.InputModels;
using Medical.Management.Domain.Arguments.ViewModels;
using Medical.Management.Domain.Models.Exceptions;
using Medical.Management.Domain.Service;
using Medical.Management.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Medical.Management.Application.Services
{
    public class PatientService(SqlServerDbContext dbContext) : IPatientService
    {
        private readonly SqlServerDbContext _dbContext = dbContext;

        public async Task<PatientViewModel> AddAsync(PatientInputModel model)
        {
            var people = await _dbContext.Peoples.AddAsync(model.People.ToEntity());
            var patient = await _dbContext.Patients.AddAsync(model.ToEntity(people.Entity.Id));
            await _dbContext.SaveChangesAsync();

            return PatientViewModel.FromEntity(patient.Entity);
        }

        public async Task<PatientViewModel> GetAsync(Guid id)
        {
            var patient = await _dbContext.Patients.Include(d => d.People).SingleOrDefaultAsync(d => d.Id.Equals(id))
                ?? throw new PatientNotFoundException();

            return PatientViewModel.FromEntity(patient);
        }

        public async Task UpdateAsync(PatientInputModel model, Guid id)
        {
            var patient = _dbContext.Patients
                            .Include(d => d.People)
                            .Where(d => d.Id.Equals(id));

            await patient
                .ExecuteUpdateAsync(
                    setters =>
                    setters
                        .SetProperty(p => p.Height, model.Height)
                        .SetProperty(p => p.Weight, model.Weight)
                );

            var idPeople = patient.First().People.Id;

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
