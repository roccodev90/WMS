using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "containers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Sscc = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_containers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    coordinate_aisle = table.Column<int>(type: "integer", nullable: false),
                    coordinate_bay = table.Column<int>(type: "integer", nullable: false),
                    coordinate_level = table.Column<int>(type: "integer", nullable: false),
                    ShelfKind = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MovementKind = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uuid", nullable: true),
                    SourceLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TargetLocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_tasks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_containers_Sscc",
                table: "containers",
                column: "Sscc",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "containers");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "warehouse_tasks");
        }
    }
}
