using Medical.Management.Domain.Models.Entities;

namespace Medical.Management.Domain.Repositories
{
    public interface IHealthInsuranceRepository
    {
        Task<HealthInsurance> AddAsync(HealthInsurance entity);
        List<HealthInsurance> GetAll();
        Task<HealthInsurance?> GetAsync(Guid id);
        void Remove(Guid id);
        void Update(HealthInsurance entity);
    }
}