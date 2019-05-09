using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsilioServices.Infrastructure.Data.Migrations
{
    public partial class addtopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicAccessId",
                table: "MenuAccesses",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TopicAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicAccesses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuAccesses_TopicAccessId",
                table: "MenuAccesses",
                column: "TopicAccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuAccesses_TopicAccesses_TopicAccessId",
                table: "MenuAccesses",
                column: "TopicAccessId",
                principalTable: "TopicAccesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuAccesses_TopicAccesses_TopicAccessId",
                table: "MenuAccesses");

            migrationBuilder.DropTable(
                name: "TopicAccesses");

            migrationBuilder.DropIndex(
                name: "IX_MenuAccesses_TopicAccessId",
                table: "MenuAccesses");

            migrationBuilder.DropColumn(
                name: "TopicAccessId",
                table: "MenuAccesses");
        }
    }
}
