using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AA.FinTechBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FintechFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    ClientLastName = table.Column<string>(type: "text", nullable: false),
                    ClientCount = table.Column<int>(type: "integer", nullable: false),
                    ClientBalance = table.Column<int>(type: "integer", nullable: false),
                    ClientDateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientAddress = table.Column<string>(type: "text", nullable: false),
                    ClientPhone = table.Column<string>(type: "text", nullable: false),
                    ClientEmail = table.Column<string>(type: "text", nullable: false),
                    ClientType = table.Column<int>(type: "integer", nullable: false),
                    ClientMaritalStatus = table.Column<int>(type: "integer", nullable: false),
                    ClientIdentificationId = table.Column<int>(type: "integer", nullable: false),
                    ClientOccupation = table.Column<string>(type: "text", nullable: false),
                    ClientGenre = table.Column<string>(type: "text", nullable: false),
                    ClientNationality = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
