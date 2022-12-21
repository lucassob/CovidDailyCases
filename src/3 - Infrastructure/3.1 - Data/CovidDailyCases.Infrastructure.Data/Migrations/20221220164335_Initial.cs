using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidDailyCases.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "CovidCases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "varchar(25)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Variant = table.Column<string>(type: "varchar(20)", nullable: false),
                    NumSequences = table.Column<int>(type: "integer", nullable: false),
                    PercSequences = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    NumSequencesTotal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidCases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidCases");
        }
    }
}
