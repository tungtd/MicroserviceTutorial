using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Customer.Microservice.Data
{
    public interface IApplicationDBContext
    {
        DbSet<Entities.Customer> Customers { get; set; }

        Task<int> SaveChanges();
    }
}