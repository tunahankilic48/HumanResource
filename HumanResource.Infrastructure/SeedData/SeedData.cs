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

                if (!context.Status.Any())
                {
                    
                    foreach (var item in Enum.GetValues(typeof(Status)))
                    {
                        Statu statu = new Statu ();
                        statu.Name = item.ToString();
                        statu.StatuEnumId = item.GetHashCode();
                        status.Add(statu);
                    }

                    await context.Status.AddRangeAsync (status);
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

            }
        }
    }
}

