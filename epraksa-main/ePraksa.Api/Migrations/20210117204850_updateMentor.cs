using Microsoft.EntityFrameworkCore.Migrations;

namespace ePraksa.Api.Migrations
{
    public partial class updateMentor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Mentors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Mentors");
        }
    }
}
