﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    partial class BudgetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Persistence.Entities.BudgetAmountEntity", b =>
                {
                    b.Property<int>("BudgetAmountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BudgetAmountId"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 6)
                        .HasColumnType("numeric(16,6)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Remaining")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 6)
                        .HasColumnType("numeric(16,6)")
                        .HasDefaultValue(0m);

                    b.HasKey("BudgetAmountId");

                    b.ToTable("BudgetAmounts", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.BudgetItemEntity", b =>
                {
                    b.Property<int>("BudgetItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BudgetItemId"));

                    b.Property<int>("BudgetAmountId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("MonthBudgetId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.HasKey("BudgetItemId");

                    b.HasIndex("BudgetAmountId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MonthBudgetId");

                    b.ToTable("BudgetItems", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.HasKey("CategoryId");

                    b.ToTable("Catagories", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.MonthBudgetEntity", b =>
                {
                    b.Property<int>("MonthBudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MonthBudgetId"));

                    b.Property<int>("BudgetAmountId")
                        .HasColumnType("integer");

                    b.Property<int>("MonthTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("YearBudgetId")
                        .HasColumnType("integer");

                    b.HasKey("MonthBudgetId");

                    b.HasIndex("BudgetAmountId");

                    b.HasIndex("MonthTypeId");

                    b.HasIndex("YearBudgetId");

                    b.ToTable("MonthyBudgets", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.MonthTypeEntity", b =>
                {
                    b.Property<int>("MonthTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MonthTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasDefaultValue("");

                    b.HasKey("MonthTypeId");

                    b.ToTable("MonthTypes", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.SplitTransactionEntity", b =>
                {
                    b.Property<int>("SplitTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SplitTransactionId"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 6)
                        .HasColumnType("numeric(16,6)")
                        .HasDefaultValue(0m);

                    b.Property<int>("BudgetItemId")
                        .HasColumnType("integer");

                    b.Property<int>("PrincipleTransactionId")
                        .HasColumnType("integer");

                    b.HasKey("SplitTransactionId");

                    b.HasIndex("BudgetItemId");

                    b.HasIndex("PrincipleTransactionId");

                    b.ToTable("SplitTransactions", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.TransactionEntity", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 6)
                        .HasColumnType("numeric(16,6)")
                        .HasDefaultValue(0m);

                    b.Property<int>("BudgetItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("");

                    b.Property<DateTimeOffset>("TransactionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

                    b.HasKey("TransactionId");

                    b.HasIndex("BudgetItemId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.Property<string>("FirebaseId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.Property<string>("NameFull")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("");

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasDefaultValue("");

                    b.HasKey("UserId");

                    b.HasIndex("Email");

                    b.HasIndex("FirebaseId");

                    b.HasIndex("NameFull");

                    b.HasIndex("Phone");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.YearBudgetEntity", b =>
                {
                    b.Property<int>("YearBudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("YearBudgetId"));

                    b.Property<int>("BudgetAmountId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("YearTypeId")
                        .HasColumnType("integer");

                    b.HasKey("YearBudgetId");

                    b.HasIndex("BudgetAmountId");

                    b.HasIndex("UserId");

                    b.HasIndex("YearTypeId");

                    b.ToTable("YearlyBudgets", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.YearTypeEntity", b =>
                {
                    b.Property<int>("YearTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("YearTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasDefaultValue("");

                    b.HasKey("YearTypeId");

                    b.ToTable("YearTypes", (string)null);
                });

            modelBuilder.Entity("Persistence.Entities.BudgetItemEntity", b =>
                {
                    b.HasOne("Persistence.Entities.BudgetAmountEntity", "BudgetAmount")
                        .WithMany("BudgetItems")
                        .HasForeignKey("BudgetAmountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.CategoryEntity", "Category")
                        .WithMany("BudgetItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.MonthBudgetEntity", "MonthBudget")
                        .WithMany("BudgetItems")
                        .HasForeignKey("MonthBudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetAmount");

                    b.Navigation("Category");

                    b.Navigation("MonthBudget");
                });

            modelBuilder.Entity("Persistence.Entities.MonthBudgetEntity", b =>
                {
                    b.HasOne("Persistence.Entities.BudgetAmountEntity", "BudgetAmount")
                        .WithMany("MonthlyBudgets")
                        .HasForeignKey("BudgetAmountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.MonthTypeEntity", "MonthType")
                        .WithMany("MonthlyBudgets")
                        .HasForeignKey("MonthTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.YearBudgetEntity", "YearBudget")
                        .WithMany("MonthBudgets")
                        .HasForeignKey("YearBudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetAmount");

                    b.Navigation("MonthType");

                    b.Navigation("YearBudget");
                });

            modelBuilder.Entity("Persistence.Entities.SplitTransactionEntity", b =>
                {
                    b.HasOne("Persistence.Entities.BudgetItemEntity", "BudgetItem")
                        .WithMany("SplitTransactions")
                        .HasForeignKey("BudgetItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.TransactionEntity", "Transaction")
                        .WithMany("SplitTransactions")
                        .HasForeignKey("PrincipleTransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetItem");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Persistence.Entities.TransactionEntity", b =>
                {
                    b.HasOne("Persistence.Entities.BudgetItemEntity", "BudgetItem")
                        .WithMany("Transactions")
                        .HasForeignKey("BudgetItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetItem");
                });

            modelBuilder.Entity("Persistence.Entities.YearBudgetEntity", b =>
                {
                    b.HasOne("Persistence.Entities.BudgetAmountEntity", "BudgetAmount")
                        .WithMany("YearlyBudgets")
                        .HasForeignKey("BudgetAmountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.UserEntity", "User")
                        .WithMany("YearlyBudgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Entities.YearTypeEntity", "YearType")
                        .WithMany("YearlyBudgets")
                        .HasForeignKey("YearTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetAmount");

                    b.Navigation("User");

                    b.Navigation("YearType");
                });

            modelBuilder.Entity("Persistence.Entities.BudgetAmountEntity", b =>
                {
                    b.Navigation("BudgetItems");

                    b.Navigation("MonthlyBudgets");

                    b.Navigation("YearlyBudgets");
                });

            modelBuilder.Entity("Persistence.Entities.BudgetItemEntity", b =>
                {
                    b.Navigation("SplitTransactions");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Persistence.Entities.CategoryEntity", b =>
                {
                    b.Navigation("BudgetItems");
                });

            modelBuilder.Entity("Persistence.Entities.MonthBudgetEntity", b =>
                {
                    b.Navigation("BudgetItems");
                });

            modelBuilder.Entity("Persistence.Entities.MonthTypeEntity", b =>
                {
                    b.Navigation("MonthlyBudgets");
                });

            modelBuilder.Entity("Persistence.Entities.TransactionEntity", b =>
                {
                    b.Navigation("SplitTransactions");
                });

            modelBuilder.Entity("Persistence.Entities.UserEntity", b =>
                {
                    b.Navigation("YearlyBudgets");
                });

            modelBuilder.Entity("Persistence.Entities.YearBudgetEntity", b =>
                {
                    b.Navigation("MonthBudgets");
                });

            modelBuilder.Entity("Persistence.Entities.YearTypeEntity", b =>
                {
                    b.Navigation("YearlyBudgets");
                });
#pragma warning restore 612, 618
        }
    }
}
