using IdentityEmailChatProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityEmailChatProject.Context
{
    public class EmailContext:IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-39MI0O0\\SQLEXPRESS;initial Catalog=IdentityEmailChatDb; integrated security=True; trust server certificate=true");

        }

        public DbSet<Message> Messages { get; set; }
    }
}
