using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsilioServices.Infrastructure.Data.Migrations
{
    public partial class correcao_manytomanyprofileaccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemProfileMenuAccesses",
                table: "SystemProfileMenuAccesses");

            migrationBuilder.DropIndex(
                name: "IX_SystemProfileMenuAccesses_SystemProfileId",
                table: "SystemProfileMenuAccesses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SystemProfileMenuAccesses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemProfileMenuAccesses",
                table: "SystemProfileMenuAccesses",
                columns: new[] { "SystemProfileId", "MenuAccessId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemProfileMenuAccesses",
                table: "SystemProfileMenuAccesses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SystemProfileMenuAccesses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemProfileMenuAccesses",
                table: "SystemProfileMenuAccesses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProfileMenuAccesses_SystemProfileId",
                table: "SystemProfileMenuAccesses",
                column: "SystemProfileId");
        }
    }
}
