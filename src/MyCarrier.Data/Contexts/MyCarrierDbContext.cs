using Microsoft.EntityFrameworkCore;
using MyCarrier.Domain.Entities.Freelancers;

namespace MyCarrier.Data.Contexts;

public class MyCarrierDbContext : DbContext
{
    public MyCarrierDbContext(DbContextOptionsBuilder<MyCarrierDbContext> options)
    {
    }
}