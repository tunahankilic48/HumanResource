using Bogus;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Infrastructure.DbContext;
using Microsoft.AspNetCore.Builder;
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
                        .RuleFor(x => x.Name, y => y.Company.CompanyName());

                    department = departmentFaker.Generate(30);
                    await context.Departments.AddRangeAsync(department);
                    await context.SaveChangesAsync();

                }

            }
        }
    }
}

