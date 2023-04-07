using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<City> Cities { get; set; }

        //Address added.
        DbSet<Address> Addresses { get; set; }
        //Note added.
        DbSet<Note> Notes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

        //GetByIdAsync added.
        Task<Address> GetByIdAsync(string ıd, bool v);
    }
}
