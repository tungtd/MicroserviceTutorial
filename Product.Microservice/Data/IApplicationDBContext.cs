using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Product.Microservice.Data
{
    public interface IApplicationDBContext
    {
        DbSet<Entities.Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}