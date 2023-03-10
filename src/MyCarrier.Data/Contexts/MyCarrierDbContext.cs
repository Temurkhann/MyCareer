using Microsoft.EntityFrameworkCore;

namespace MyCarrier.Data.Contexts;

public class MyCarrierDbContext : DbContext
{
    public MyCarrierDbContext(DbContextOptionsBuilder<MyCarrierDbContext> options)
    {
    }
}