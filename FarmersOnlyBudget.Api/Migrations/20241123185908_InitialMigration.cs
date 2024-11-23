using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetAmounts",
                columns: table => new
                {
                    BudgetAmountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false, defaultValue: 0m),
                    Remaining = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAmounts", x => x.BudgetAmountId);
                });

            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MonthTypes",
                columns: table => new
                {
                    MonthTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthTypes", x => x.MonthTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameFirst = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    NameLast = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    NameFull = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    Phone = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "YearTypes",
                columns: table => new
                {
                    YearTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearTypes", x => x.YearTypeId);
                });

            migrationBuilder.CreateTable(
                name: "YearlyBudgets",
                columns: table => new
                {
                    YearBudgetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    YearTypeId = table.Column<int>(type: "integer", nullable: false),
                    BudgetAmountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyBudgets", x => x.YearBudgetId);
                    table.ForeignKey(
                        name: "FK_YearlyBudgets_BudgetAmounts_BudgetAmountId",
                        column: x => x.BudgetAmountId,
                        principalTable: "BudgetAmounts",
                        principalColumn: "BudgetAmountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YearlyBudgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YearlyBudgets_YearTypes_YearTypeId",
                        column: x => x.YearTypeId,
                        principalTable: "YearTypes",
                        principalColumn: "YearTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthyBudgets",
                columns: table => new
                {
                    MonthBudgetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YearBudgetId = table.Column<int>(type: "integer", nullable: false),
                    BudgetAmountId = table.Column<int>(type: "integer", nullable: false),
                    MonthTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthyBudgets", x => x.MonthBudgetId);
                    table.ForeignKey(
                        name: "FK_MonthyBudgets_BudgetAmounts_BudgetAmountId",
                        column: x => x.BudgetAmountId,
                        principalTable: "BudgetAmounts",
                        principalColumn: "BudgetAmountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthyBudgets_MonthTypes_MonthTypeId",
                        column: x => x.MonthTypeId,
                        principalTable: "MonthTypes",
                        principalColumn: "MonthTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthyBudgets_YearlyBudgets_YearBudgetId",
                        column: x => x.YearBudgetId,
                        principalTable: "YearlyBudgets",
                        principalColumn: "YearBudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetItems",
                columns: table => new
                {
                    BudgetItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonthBudgetId = table.Column<int>(type: "integer", nullable: false),
                    BudgetAmountId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.BudgetItemId);
                    table.ForeignKey(
                        name: "FK_BudgetItems_BudgetAmounts_BudgetAmountId",
                        column: x => x.BudgetAmountId,
                        principalTable: "BudgetAmounts",
                        principalColumn: "BudgetAmountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetItems_Catagories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Catagories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetItems_MonthyBudgets_MonthBudgetId",
                        column: x => x.MonthBudgetId,
                        principalTable: "MonthyBudgets",
                        principalColumn: "MonthBudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BudgetItemId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false, defaultValue: 0m),
                    Name = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    TransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_BudgetItems_BudgetItemId",
                        column: x => x.BudgetItemId,
                        principalTable: "BudgetItems",
                        principalColumn: "BudgetItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SplitTransactions",
                columns: table => new
                {
                    SplitTransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrincipleTransactionId = table.Column<int>(type: "integer", nullable: false),
                    BudgetItemId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(16,6)", precision: 16, scale: 6, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitTransactions", x => x.SplitTransactionId);
                    table.ForeignKey(
                        name: "FK_SplitTransactions_BudgetItems_BudgetItemId",
                        column: x => x.BudgetItemId,
                        principalTable: "BudgetItems",
                        principalColumn: "BudgetItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SplitTransactions_Transactions_PrincipleTransactionId",
                        column: x => x.PrincipleTransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItems_BudgetAmountId",
                table: "BudgetItems",
                column: "BudgetAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItems_CategoryId",
                table: "BudgetItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItems_MonthBudgetId",
                table: "BudgetItems",
                column: "MonthBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthyBudgets_BudgetAmountId",
                table: "MonthyBudgets",
                column: "BudgetAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthyBudgets_MonthTypeId",
                table: "MonthyBudgets",
                column: "MonthTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthyBudgets_YearBudgetId",
                table: "MonthyBudgets",
                column: "YearBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_SplitTransactions_BudgetItemId",
                table: "SplitTransactions",
                column: "BudgetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SplitTransactions_PrincipleTransactionId",
                table: "SplitTransactions",
                column: "PrincipleTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BudgetItemId",
                table: "Transactions",
                column: "BudgetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NameFull",
                table: "Users",
                column: "NameFull");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_YearlyBudgets_BudgetAmountId",
                table: "YearlyBudgets",
                column: "BudgetAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_YearlyBudgets_UserId",
                table: "YearlyBudgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_YearlyBudgets_YearTypeId",
                table: "YearlyBudgets",
                column: "YearTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SplitTransactions");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BudgetItems");

            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropTable(
                name: "MonthyBudgets");

            migrationBuilder.DropTable(
                name: "MonthTypes");

            migrationBuilder.DropTable(
                name: "YearlyBudgets");

            migrationBuilder.DropTable(
                name: "BudgetAmounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "YearTypes");
        }
    }
}
