using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EMS.Infrastructure.Data
{
    public class EMSContextInitialiser
    {
        private readonly ILogger<EMSContextInitialiser> _logger;
        private readonly EMSContext _context;

        public EMSContextInitialiser(EMSContext context, ILogger<EMSContextInitialiser> logger)
        {
            this._logger = logger;
            this._context = context;
        }
        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await SeedDepartmentAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
        private async Task SeedDepartmentAsync()
        {
            if (!_context.Departments.Any())
            {
                var departments = new List<Department>() {
                    new Department
                    {
                        Name = "Human Resource"
                    },
                    new Department
                    {
                        Name = "IT"
                    },
                    new Department
                    {
                        Name="Finance"
                    },
                    new Department
                    {
                        Name = "QA"
                    }

                };

                //add list to list
                _context.Departments.AddRange(departments);
            }
            await _context.SaveChangesAsync();
        }
    }
}
