using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsilioServices.Infrastructure.Data.Migrations
{
    public partial class profileaccessmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acess",
                table: "MenuAccesses");

            migrationBuilder.CreateTable(
                name: "SystemProfileMenuAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemProfileId = table.Column<int>(nullable: false),
                    MenuAccessId = table.Column<int>(nullable: false),
                    Access = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemProfileMenuAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemProfileMenuAccesses_MenuAccesses_MenuAccessId",
                        column: x => x.MenuAccessId,
                        principalTable: "MenuAccesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemProfileMenuAccesses_SystemProfiles_SystemProfileId",
                        column: x => x.SystemProfileId,
                        principalTable: "SystemProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemProfileMenuAccesses_MenuAccessId",
                table: "SystemProfileMenuAccesses",
                column: "MenuAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProfileMenuAccesses_SystemProfileId",
                table: "SystemProfileMenuAccesses",
                column: "SystemProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemProfileMenuAccesses");

            migrationBuilder.AddColumn<bool>(
                name: "Acess",
                table: "MenuAccesses",
                nullable: false,
                defaultValue: false);
        }
    }
}
