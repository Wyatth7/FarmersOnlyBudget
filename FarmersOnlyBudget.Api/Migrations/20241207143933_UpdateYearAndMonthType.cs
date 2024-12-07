using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateYearAndMonthType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YearlyBudgets_YearTypes_YearTypeId",
                table: "YearlyBudgets");

            migrationBuilder.DropTable(
                name: "YearTypes");

            migrationBuilder.DropIndex(
                name: "IX_YearlyBudgets_YearTypeId",
                table: "YearlyBudgets");

            migrationBuilder.DropColumn(
                name: "YearTypeId",
                table: "YearlyBudgets");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "YearlyBudgets",
                type: "integer",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "MonthTypes",
                columns: new[] { "MonthTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "January" },
                    { 2, "February" },
                    { 3, "March" },
                    { 4, "April" },
                    { 5, "May" },
                    { 6, "June" },
                    { 7, "July" },
                    { 8, "August" },
                    { 9, "September" },
                    { 10, "October" },
                    { 11, "November" },
                    { 12, "December" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearlyBudgets_Year",
                table: "YearlyBudgets",
                column: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_YearlyBudgets_Year",
                table: "YearlyBudgets");

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MonthTypes",
                keyColumn: "MonthTypeId",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "Year",
                table: "YearlyBudgets");

            migrationBuilder.AddColumn<int>(
                name: "YearTypeId",
                table: "YearlyBudgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_YearlyBudgets_YearTypeId",
                table: "YearlyBudgets",
                column: "YearTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_YearlyBudgets_YearTypes_YearTypeId",
                table: "YearlyBudgets",
                column: "YearTypeId",
                principalTable: "YearTypes",
                principalColumn: "YearTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
