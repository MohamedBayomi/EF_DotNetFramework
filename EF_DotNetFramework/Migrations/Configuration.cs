namespace EF_DotNetFramework.Migrations
{
    using EF_DotNetFramework.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_DotNetFramework.Models.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF_DotNetFramework.Models.AppDBContext context)
        {
            context.Countries.AddOrUpdate(new Country { ID = 1, Name = "Egypt" });
            context.Countries.AddOrUpdate(new Country { ID = 2, Name = "USA" });
            context.Countries.AddOrUpdate(new Country { ID = 3, Name = "UK" });

            context.Departments.AddOrUpdate(new Department { ID = 1, Name = "Management" });
            context.Departments.AddOrUpdate(new Department { ID = 2, Name = "HR" });
            context.Departments.AddOrUpdate(new Department { ID = 3, Name = "Sales" });
            context.Departments.AddOrUpdate(new Department { ID = 4, Name = "Marketing" });
            context.Departments.AddOrUpdate(new Department { ID = 5, Name = "IT" });

            context.SaveChanges();
        }
    }
}
