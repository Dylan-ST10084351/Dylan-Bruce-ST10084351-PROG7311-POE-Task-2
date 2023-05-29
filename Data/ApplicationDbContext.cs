using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models;
using Microsoft.AspNetCore.Identity;

namespace Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models.Product>? Product { get; set; }
        public DbSet<Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models.Farmer>? Farmer { get; set; }
        public DbSet<Dylan_Bruce_ST10084351_PROG7311_POE_Task_2.Models.Category>? Category { get; set; }
    }
}