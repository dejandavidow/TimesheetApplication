using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
           builder.HasData(
           new IdentityRole
           {
               Name = "Employee",
               NormalizedName = "EMPLOYEE"
           },
           new IdentityRole
           {
               Name = "Administrator",
               NormalizedName = "ADMINISTRATOR"
           });
        }
    }
}
