using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models.Entites
{
    public class Company:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer("Server =.;Database=CUR2CompanyMVC;Trust Connection= True ; Encrypt = False");
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-8TDDMOU ; Initial Catalog = CompanyITI; Integrated Security = True; Encrypt = False;");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProductsCard> ProductsCards { get; set; }
    }
}

