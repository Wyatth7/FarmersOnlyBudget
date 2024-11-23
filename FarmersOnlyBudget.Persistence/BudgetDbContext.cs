using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence;

public class BudgetDbContext : DbContext
{
    public BudgetDbContext() { }

    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<decimal>()
            .HavePrecision(16, 6);
    }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<YearBudgetEntity> YearlyBudgets { get; set; }

    public DbSet<MonthBudgetEntity> MonthlyBudgets { get; set; }

    public DbSet<BudgetItemEntity> BudgetItems { get; set; }

    public DbSet<TransactionEntity> Transactions { get; set; }

    public DbSet<SplitTransactionEntity> SplitTransactions { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<BudgetAmountEntity> BudgetAmounts { get; set; }

    public DbSet<MonthTypeEntity> MonthTypes { get; set; }

    public DbSet<YearTypeEntity> YearTypes { get; set; }
}