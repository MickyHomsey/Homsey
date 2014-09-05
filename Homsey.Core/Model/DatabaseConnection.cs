using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homsey.Core.Entities
{
  internal class DatabaseConnection : DbContext
  {
    public DatabaseConnection() : base("name=DatabaseEntities") 
    { 
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Database.SetInitializer<DatabaseConnection>(null);
    }

    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<DataTranslation> DataTranslations { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<MenuData> MenuData { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<PageContentView> PageContentView { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}
