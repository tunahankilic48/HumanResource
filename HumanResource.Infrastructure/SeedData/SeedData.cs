using Bogus;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Infrastructure.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResource.Infrastructure.SeedData
{
    public class SeedData
    {
        public async static Task Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                List<Statu> status = new List<Statu>();
                List<BloodType> bloodTypes = new List<BloodType>();
                List<LeaveType> LeaveTypes = new List<LeaveType>();
                List<City> city = new List<City>();
                List<District> district = new List<District>();
                List<Department> department = new List<Department>();
                List<CurrencyType> currencyTypes = new List<CurrencyType>();
                List<ExpenseType> expenseTypes = new List<ExpenseType>();

                if (!context.Status.Any())
                {

                    foreach (var item in Enum.GetValues(typeof(Status)))
                    {
                        Statu statu = new Statu();
                        statu.Name = item.ToString();
                        statu.StatuEnumId = item.GetHashCode();
                        status.Add(statu);
                    }

                    await context.Status.AddRangeAsync(status);
                    await context.SaveChangesAsync();


                }

                if (!context.BloodTypes.Any())
                {
                    foreach (var item in Enum.GetValues(typeof(BloodTypes)))
                    {

                        BloodType bloodType = new BloodType();
                        bloodType.Name = item.ToString();
                        bloodType.BloodTypeEnumId = item.GetHashCode();
                        bloodTypes.Add(bloodType);
                    }

                    await context.BloodTypes.AddRangeAsync(bloodTypes);
                    await context.SaveChangesAsync();
                }

                if (!context.LeaveTypes.Any())
                {
                    foreach (var item in Enum.GetValues(typeof(LeaveTypes)))
                    {

                        LeaveType leaveType = new LeaveType();
                        leaveType.Name = item.ToString();
                        leaveType.LeaveTypeEnumId = item.GetHashCode();
                        LeaveTypes.Add(leaveType);
                    }

                    await context.LeaveTypes.AddRangeAsync(LeaveTypes);
                    await context.SaveChangesAsync();
                }

                if (!context.CurrencyTypes.Any())
                {
                    foreach (var item in Enum.GetValues(typeof(CurrencyTypes)))
                    {

                        CurrencyType currencyType = new CurrencyType();
                        currencyType.Name = item.ToString();
                        currencyType.CurrencyTypeEnumId = item.GetHashCode();
                        currencyTypes.Add(currencyType);
                    }

                    await context.CurrencyTypes.AddRangeAsync(currencyTypes);
                    await context.SaveChangesAsync();
                }

                if (!context.ExpenseTypes.Any())
                {
                    foreach (var item in Enum.GetValues(typeof(ExpenseTypes)))
                    {

                        ExpenseType expenseType = new ExpenseType();
                        expenseType.Name = item.ToString();
                        expenseType.ExpenseTypeEnumId = item.GetHashCode();
                        expenseTypes.Add(expenseType);
                    }

                    await context.ExpenseTypes.AddRangeAsync(expenseTypes);
                    await context.SaveChangesAsync();
                }

                if (!context.Cities.Any())
                {
                    var cityFaker = new Faker<City>()
                       .RuleFor(x => x.Name, y => y.Address.City());

                    city = cityFaker.Generate(10);
                    await context.Cities.AddRangeAsync(city);
                    await context.SaveChangesAsync();

                }

                if (!context.Districts.Any())
                {
                    var districtFaker = new Faker<District>()
                        .RuleFor(x => x.Name, y => y.Address.State())
                        .RuleFor(x => x.City, y => y.PickRandom(context.Cities.ToList()));

                    district = districtFaker.Generate(30);
                    await context.Districts.AddRangeAsync(district);
                    await context.SaveChangesAsync();

                }

                if (!context.Departments.Any())
                {
                    var departmentFaker = new Faker<Department>()
                        .RuleFor(x => x.Name, y => y.Company.CompanyName())
                        .RuleFor(x=>x.StatuId, y=> Status.Active.GetHashCode());

                    department = departmentFaker.Generate(5);
                    await context.Departments.AddRangeAsync(department);
                    await context.SaveChangesAsync();

                }

                if (!context.Roles.Any())
                {
                    var roleStore = new RoleStore<IdentityRole<Guid>, ApplicationDbContext, Guid>(context);

                    await roleStore.CreateAsync(new IdentityRole<Guid>() { Name = "SiteAdmin", NormalizedName = "SiteAdmin" });
                    await roleStore.CreateAsync(new IdentityRole<Guid>() { Name = "CompanyManager", NormalizedName = "CompanyManager" });
                    await roleStore.CreateAsync(new IdentityRole<Guid>() { Name = "Employee", NormalizedName = "Employee" });
                    await context.SaveChangesAsync();
                }

                if (!context.Users.Any())
                {
                    var passwordHasher = new PasswordHasher<AppUser>();

                    AppUser companyManager = new AppUser
                    {
                        FirstName="company",
                        LastName="manager",
                        UserName = "companyManager",
                        NormalizedUserName = "companyManager",
                        Email = "companyManager@gmail.com",
                        ImagePath = "/images/noImage.png",
                        CreatedDate = DateTime.Now,
                        EmailConfirmed=true,
                        LockoutEnabled=true,
                        TwoFactorEnabled=false,
                        PhoneNumberConfirmed=false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };

                    var hashed = passwordHasher.HashPassword(companyManager, "123456");
                    companyManager.PasswordHash = hashed;

                    var companyManagerStore = new UserStore<AppUser, IdentityRole<Guid>, ApplicationDbContext, Guid>(context);

                    await companyManagerStore.CreateAsync(companyManager);
                    await companyManagerStore.AddToRoleAsync(companyManager, "CompanyManager");
                    await context.SaveChangesAsync();


                    AppUser employee = new AppUser
                    {
                        FirstName = "employee",
                        LastName = "employee",
                        UserName = "employee",
                        NormalizedUserName = "employee",
                        Email = "employee@gmail.com",
                        ImagePath = "/images/noImage.png",
                        CreatedDate = DateTime.Now,
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        TwoFactorEnabled = false,
                        PhoneNumberConfirmed = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };

                    var hashedCustomer = passwordHasher.HashPassword(employee, "123456");
                    employee.PasswordHash = hashedCustomer;

                    var employeeStore = new UserStore<AppUser, IdentityRole<Guid>, ApplicationDbContext, Guid>(context);

                    await employeeStore.CreateAsync(employee);
                    await employeeStore.AddToRoleAsync(employee, "Employee");
                    await context.SaveChangesAsync();

                }

            }
        }
    }
}

