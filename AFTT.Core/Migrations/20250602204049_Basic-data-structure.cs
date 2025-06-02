using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFTT.Core.Migrations
{
    /// <inheritdoc />
    public partial class Basicdatastructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "mission",
                table: "Missions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCompletion",
                schema: "mission",
                table: "Missions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "mission",
                table: "Missions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                schema: "mission",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PredictedCompletion",
                schema: "mission",
                table: "Missions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "mission",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Urgency",
                schema: "mission",
                table: "Missions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_OwnerId",
                schema: "mission",
                table: "Missions",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_OwnerId",
                schema: "user",
                table: "Settings",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_User_OwnerId",
                schema: "mission",
                table: "Missions",
                column: "OwnerId",
                principalSchema: "user",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_User_OwnerId",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "user");

            migrationBuilder.DropTable(
                name: "User",
                schema: "user");

            migrationBuilder.DropIndex(
                name: "IX_Missions_OwnerId",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "ActualCompletion",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "PredictedCompletion",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "mission",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Urgency",
                schema: "mission",
                table: "Missions");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "mission",
                table: "Missions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
