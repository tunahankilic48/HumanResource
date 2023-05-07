using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.EntitiesConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Advance> Advances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfig())
                        .ApplyConfiguration(new AdvanceConfig())
                        .ApplyConfiguration(new AppUserConfig())
                        .ApplyConfiguration(new BloodTypeConfig())
                        .ApplyConfiguration(new CityConfig())
                        .ApplyConfiguration(new DepartmentConfig())
                        .ApplyConfiguration(new DistrictConfig())
                        .ApplyConfiguration(new LeaveConfig())
                        .ApplyConfiguration(new LeaveTypeConfig())
                        .ApplyConfiguration(new StatuConfig())
                        .ApplyConfiguration(new ExpenseTypeConfig())
						.ApplyConfiguration(new CurrencyTypeConfig());

			foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
