using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context == null || context.Employees.Any()) return;
            var employees = new List<EmployeeInfo>
            {
                new EmployeeInfo
                {
                    EmployeeId = "MM0001",
                    EmailAddress = "mm0001@gmail.com",
                    FirstName = "mm",
                    LastName = "0001"
                }, new EmployeeInfo
                {
                    EmployeeId = "MM0002",
                    EmailAddress = "mm0002@gmail.com",
                    FirstName = "mm",
                    LastName = "0002"
                }, new EmployeeInfo
                {
                    EmployeeId = "MM0003",
                    EmailAddress = "mm0003@gmail.com",
                    FirstName = "mm",
                    LastName = "0003"
                }
            };
            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
    }
}
